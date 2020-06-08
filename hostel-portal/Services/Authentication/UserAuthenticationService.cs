using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Authentication.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Authentication
{
    /// <summary>
    ///     The default user authentication service.
    /// </summary>
    internal class UserAuthenticationService : IUserAuthenticationService
    {
        /// <summary>
        ///     This API gets the user profile from the username and password. Such is how the system has been designed.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>The profile of the user identified by the provided credentials</returns>
        public Task<UserProfileDto?> AuthenticateUserAsync(string username,
                                                           string password)
        {
            // for now, this is a mere stub
            // once accepted by the school, it will use the portal API for authentication
            UserProfileDto? dto;
            if (username == "20163097" && password == "password")
            {
                dto = new UserProfileDto
                {
                    MatricNumber = "20163097",
                    Name = "Timehin Ahmad Alfawwaz"
                };
            }
            else
            {
                dto = null;
            }

            return Task.FromResult(dto);
        }
    }
}