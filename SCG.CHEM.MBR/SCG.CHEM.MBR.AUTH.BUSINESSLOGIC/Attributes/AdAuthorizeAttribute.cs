using Microsoft.AspNetCore.Mvc.Filters;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Authentication;
using SCG.CHEM.MBR.COMMON.AppException;
using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.Net;

namespace SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes
{
    public class AdAuthorizeAttribute : ActionFilterAttribute
    {
        public AdAuthorizeAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var adToken = context.HttpContext?.GetADAccount();

            if (adToken == null)
            {
                throw new UnauthorizedAccessException("Unauthorized.Please Log In");
            }

            //var _logger = NLog.LogManager.GetCurrentClassLogger();
            //_logger.Info($"[Logged In] {adToken?.UserId}");

        }
    }
}
