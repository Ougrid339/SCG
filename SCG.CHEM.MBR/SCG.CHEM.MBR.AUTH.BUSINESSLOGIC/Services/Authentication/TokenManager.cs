using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Authentication.Interface;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Authentication
{
    public class TokenManager : ITokenManager
    {
        private readonly AppSettings _appSettings;
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenManager(AppSettings appSettings, IHttpContextAccessor contextAccessor)
        {
            _appSettings = appSettings;
            _contextAccessor = contextAccessor;
        }

        public string GenerateAppToken(AccountLoggedInResModel data)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.JwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, data.UserDetail.UserId ?? string.Empty),
                    new Claim(ClaimTypes.GivenName, data.UserDetail.FirstName ?? string.Empty),
                    new Claim(ClaimTypes.Surname, data.UserDetail.LastName ?? string.Empty),
                    new Claim(ClaimTypes.Email, data.UserDetail.Email ?? string.Empty),
                    new Claim(ClaimTypes.Role, JsonConvert.SerializeObject(data.Roles)),
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public AccountTokenModel GetAppLoggedInAccount()
        {
            var userToken = _contextAccessor.HttpContext?.GetAppLoggedInAccount();
            return userToken;
        }
    }
}