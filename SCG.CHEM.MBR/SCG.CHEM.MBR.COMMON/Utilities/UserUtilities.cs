using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SCG.CHEM.MBR.COMMON.AppModels.Account;
using SCG.CHEM.MBR.COMMON.Authentication.Interface;
using System.IdentityModel.Tokens.Jwt;

namespace SCG.CHEM.MBR.COMMON.Utilities
{
    public class UserUtilities
    {

        internal static IServiceProvider _serviceProvider = null;
        public static void Configure(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static IServiceScope GetScope(IServiceProvider serviceProvider = null)
        {
            var provider = serviceProvider ?? _serviceProvider;
            return provider?
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
        }

        public static HttpContext GetContext()
        {
            var scope = GetScope().ServiceProvider.GetServices<IUserLocalService>();
            var ur = scope.FirstOrDefault();
            var httpContext = ur.GetHttpContext();

            return httpContext;
        }

        public static AccountTokenModel GetADAccount()
        {
            HttpContext httpContext = GetContext();

            string token = httpContext?.Request?.Headers["Authorization"];
            if (string.IsNullOrEmpty(token))
            {
                token = httpContext?.Request?.Headers["Ad-Authorization"];
            }

            if (string.IsNullOrEmpty(token)) return null;

            var handler = new JwtSecurityTokenHandler();
            token = token.Replace("Bearer ", "");
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

            var userToken = new AccountTokenModel()
            {
                //UserId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "preferred_username")?.Value?.ToLower(),
                UserId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "preferred_username")?.Value?.ToLower() ?? jwtToken.Claims.FirstOrDefault(claim => claim.Type == "unique_name")?.Value?.ToLower() ?? jwtToken.Claims.FirstOrDefault(claim => claim.Type == "upn")?.Value?.ToLower(),
                FirstName = jwtToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.GivenName)?.Value,
                LastName = jwtToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.FamilyName)?.Value,
                Email = jwtToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Email)?.Value
            };

            return userToken;

        }

    }
}
