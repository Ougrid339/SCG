using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using SCG.CHEM.MBR.COMMON.Authentication.Interface;

namespace SCG.CHEM.MBR.COMMON.Authentication
{
    public class UserLocalService : IUserLocalService
    {
        private readonly IHttpContextAccessor _httpContext;
        public UserLocalService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;

        }

        public HttpContext GetHttpContext()
        {
            return _httpContext.HttpContext;
        }
    }
}
