using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Authentication.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Authentication
{
    public interface IUserTokenManager
    {
        /// <summary>
        ///     Generates a token for the user. It is intended to be used only after valid authentication of the user to get the
        ///     token.
        /// </summary>
        /// <returns>A token consisting of an encrypted form of the user profile DTO</returns>
        Task<string> GenerateAuthenticationTokenAsync(UserProfileDto userProfileDto);


        /// <summary>
        ///     Decrypts and parses the user token
        /// </summary>
        /// <returns></returns>
        UserProfileDto? ParseToken(string token);
    }
}