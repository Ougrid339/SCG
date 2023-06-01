using Microsoft.AspNetCore.Mvc.Filters;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Authentication;
using SCG.CHEM.MBR.COMMON.AppException;
using System.Collections.Generic;
using System.Linq;
using static SCG.CHEM.MBR.COMMON.Constants.AppConstant;

namespace SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes
{
    public class AppRoleAuthorizeAttribute : ActionFilterAttribute
    {
        private readonly List<short> _roles;

        public AppRoleAuthorizeAttribute(params ROLE[] roles)
        {
            _roles = roles?.Select(x => (short)x).ToList();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var appToken = context.HttpContext?.GetAppLoggedInAccount();

            var matchedRole = appToken?.Roles?.Intersect(_roles).ToList();
            if (matchedRole == null || !matchedRole.Any())
            {
                throw new UnauthorizedActionException("Unauthorized Role");
            }
        }
    }

}
