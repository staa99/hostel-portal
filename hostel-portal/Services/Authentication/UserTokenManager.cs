using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;
using Staawork.Funaab.HostelPortal.Services.Authentication.Config;
using Staawork.Funaab.HostelPortal.Services.Authentication.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Authentication
{
    public class UserTokenManager : IUserTokenManager
    {
        private const    string                      ProtectorPurpose = "auth-token";
        private readonly AuthenticationConfiguration _authenticationConfiguration;
        private readonly ISystemClock                _clock;
        private readonly IDataProtector              _protector;


        public UserTokenManager(AuthenticationConfiguration authenticationConfiguration,
                                IDataProtectionProvider     dataProtectionProvider,
                                ISystemClock                clock)
        {
            _authenticationConfiguration = authenticationConfiguration;
            _clock = clock;
            _protector = dataProtectionProvider.CreateProtector(ProtectorPurpose);
        }


        public async Task<string> GenerateAuthenticationTokenAsync(UserProfileDto userProfileDto)
        {
            var stream = new MemoryStream();
            await SerializeProfileToStream(userProfileDto, stream);

            var protectedBytes = _protector.Protect(stream.ToArray());
            return Convert.ToBase64String(protectedBytes);
        }


        public UserProfileDto? ParseToken(string token)
        {
            try
            {
                var unprotectedData = _protector.Unprotect(Convert.FromBase64String(token));
                var stream = new MemoryStream(unprotectedData);
                using var reader = new BinaryReader(stream);

                CheckTokenExpiry(reader);

                var matricNumber = reader.ReadString();
                var name = reader.ReadString();

                CheckProtectorPurpose(reader);

                return new UserProfileDto
                {
                    Name = name,
                    MatricNumber = matricNumber
                };
            }
            catch
            {
                // Do not leak exception
            }

            return null;
        }


        private static void CheckProtectorPurpose(BinaryReader reader)
        {
            var purpose = reader.ReadString();

            if (purpose != ProtectorPurpose)
            {
                throw new ApplicationException();
            }
        }


        private void CheckTokenExpiry(BinaryReader reader)
        {
            var creationTime = new DateTimeOffset(reader.ReadInt64(),
                                                  TimeSpan.Zero);

            var expires = creationTime.AddHours(_authenticationConfiguration.AuthTokenValidityInHours);
            if (expires <= _clock.UtcNow)
            {
                throw new ApplicationException();
            }
        }


        private async Task SerializeProfileToStream(UserProfileDto userProfileDto, Stream stream)
        {
            await using var writer = new BinaryWriter(stream);

            writer.Write(_clock.UtcNow.ToOffset(TimeSpan.Zero)
                               .UtcTicks);

            writer.Write(userProfileDto.MatricNumber);
            writer.Write(userProfileDto.Name);
            writer.Write(ProtectorPurpose);
        }
    }
}