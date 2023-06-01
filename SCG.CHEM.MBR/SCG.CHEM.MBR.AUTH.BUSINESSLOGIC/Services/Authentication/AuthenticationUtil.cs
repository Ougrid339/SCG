using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Authentication
{
    public static class AuthenticationUtil
    {
        public static AccountTokenModel GetAppLoggedInAccount(this HttpContext httpContext)
        {
            string token = httpContext?.Request?.Headers["App-Authorization"];

            if (string.IsNullOrEmpty(token)) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var handler = new JwtSecurityTokenHandler();
            token = token.Replace("Bearer ", "");
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

            var userToken = new AccountTokenModel()
            {
                UserId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.NameId)?.Value,
                FirstName = jwtToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.GivenName)?.Value,
                LastName = jwtToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.FamilyName)?.Value,
                Email = jwtToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Email)?.Value
            };

            var rolesStr = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "role")?.Value;
            userToken.Roles = JsonConvert.DeserializeObject<List<short>>(rolesStr);

            return userToken;
        }

        public static AccountTokenModel GetADAccount(this HttpContext httpContext)
        {
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