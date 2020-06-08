using Staawork.Funaab.HostelPortal.Services.Authentication.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Authentication
{
    /// <summary>
    ///     The default implementation of the <see cref="IUserData" /> interface.
    /// </summary>
    public class UserData : IUserData
    {
        public UserProfileDto? CurrentUserProfile { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}