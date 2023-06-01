using Microsoft.AspNetCore.Mvc.Filters;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Authentication;
using SCG.CHEM.MBR.COMMON.AppException;
using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Net;

namespace SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes
{
    public class AppAuthorizeAttribute : ActionFilterAttribute
    {
        public AppAuthorizeAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var appToken = context.HttpContext?.GetAppLoggedInAccount();
            var adToken = context.HttpContext?.GetADAccount();

            if (adToken == null)
            {
                throw new UnauthorizedAccessException("Unauthorized.Please Log In");
            }
            else if (appToken == null)
            {
                throw new UnauthorizedAccessException($"Unauthorized Logged In User,Please log out and then try logging in again");
            }
            else if (appToken.UserId.ToLower() != adToken.UserId.ToLower())
            {
                var _logger = NLog.LogManager.GetCurrentClassLogger();
                _logger.Error($"[Logged In] AD: {adToken?.UserId},APP: {appToken.UserId}");
                throw new UnauthorizedAccessException($"Unauthorized Logged In User,Please log out and then try logging in again");
            }
        }
    }
}
