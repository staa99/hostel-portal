using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Authentication.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Authentication
{
    public interface IUserAuthenticationService
    {
        /// <summary>
        ///     This API gets the user profile from the username and password. Such is how the system has been designed.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>The profile of the user identified by the provided credentials</returns>
        Task<UserProfileDto?> AuthenticateUserAsync(string username, string password);
    }
}