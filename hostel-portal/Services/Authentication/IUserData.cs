using Staawork.Funaab.HostelPortal.Services.Authentication.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Authentication
{
    /// <summary>
    ///     This is a scoped service set by the authentication middleware
    /// </summary>
    public interface IUserData
    {
        public UserProfileDto? CurrentUserProfile { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}