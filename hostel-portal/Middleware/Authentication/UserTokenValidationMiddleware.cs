using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Staawork.Funaab.HostelPortal.Middleware.Authentication.Config;
using Staawork.Funaab.HostelPortal.Services.Authentication;


namespace Staawork.Funaab.HostelPortal.Middleware.Authentication
{
    public class UserTokenValidationMiddleware : IMiddleware
    {
        private readonly AuthenticationMiddlewareConfiguration _configuration;
        private readonly IUserData                             _userData;
        private readonly IUserTokenManager                     _userTokenManager;


        public UserTokenValidationMiddleware(AuthenticationMiddlewareConfiguration configuration,
                                             IUserData                             userData,
                                             IUserTokenManager                     userTokenManager)
        {
            _configuration = configuration;
            _userData = userData;
            _userTokenManager = userTokenManager;
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var headerName = _configuration.AuthTokenHeaderName;
            var headers = context.Request.Headers;
            var validationResult = CheckHeaderExistsAsync(context, next, headers, headerName);
            if (validationResult != null)
            {
                await validationResult;
                return;
            }

            var headerValue = headers[headerName].ToString();
            var tokenIndexStart = _configuration.AuthenticationScheme.Length + 1;
            if (await CheckHeaderValueMatchesAuthenticationSchemeAsync(context, next, headerValue, tokenIndexStart))
            {
                return;
            }

            await SetUserDataAsync(context, next, headerValue, tokenIndexStart);
        }


        private Task? CheckHeaderExistsAsync(HttpContext       context,
                                             RequestDelegate   next,
                                             IHeaderDictionary headers,
                                             string            headerName)
        {
            if (headers.ContainsKey(headerName))
            {
                return null;
            }

            UnsetUserData();
            return next(context);
        }


        private async Task<bool> CheckHeaderValueMatchesAuthenticationSchemeAsync(HttpContext     context,
                                                                                  RequestDelegate next,
                                                                                  string          headerValue,
                                                                                  int             tokenIndexStart)
        {
            if (headerValue.StartsWith($"{_configuration.AuthenticationScheme} ") &&
                headerValue.Length > tokenIndexStart)
            {
                return false;
            }

            UnsetUserData();
            await next(context);
            return true;
        }


        private async Task SetUserDataAsync(HttpContext     context,
                                            RequestDelegate next,
                                            string          headerValue,
                                            int             tokenIndexStart)
        {
            var token = headerValue.Substring(tokenIndexStart);
            var profile = _userTokenManager.ParseToken(token);

            if (profile == null)
            {
                UnsetUserData();
                await next(context);
                return;
            }

            _userData.CurrentUserProfile = profile;
            _userData.IsAuthenticated = true;
        }


        private void UnsetUserData()
        {
            _userData.IsAuthenticated = false;
            _userData.CurrentUserProfile = null;
        }
    }
}