using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;
using System.Collections.Generic;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services.Account.Interface;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services.Master;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services.Authorization;
using static SCG.CHEM.MBR.COMMON.Constants.AppConstant;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Relate;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Authentication.Interface;

namespace SCG.CHEM.MBR.AUTH.API.Controllers.Account
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    [AdAuthorize]
    public class AuthController : ControllerBase
    {
        #region Inject

        private readonly IAuthService _authService;
        private readonly AppSettings _appSetting;

        public AuthController(IAuthService authService, ITokenManager tokenManager, AppSettings appSetting)
        {
            _authService = authService;
            _appSetting = appSetting;
        }

        #endregion Inject

        [HttpGet]
        [AppRoleAuthorize(ROLE.SYSTEM_ADMIN)]
        public IActionResult GetRole([FromQuery] RoleSearchReqModel req)
        {
            var result = _authService.FindRole(req);
            return new OkObjectResult(result);
        }

        [HttpPost]
        [AppRoleAuthorize(ROLE.SYSTEM_ADMIN)]
        public IActionResult AddGroupRole(GroupRoleModel req)
        {
            var result = _authService.AddGroupRole(req);
            return new OkObjectResult(result);
        }

        [HttpPost]
        [AppRoleAuthorize(ROLE.SYSTEM_ADMIN)]
        public IActionResult DeleteGroupRole([FromQuery] GroupRoleModel req)
        {
            var result = _authService.DeleteGroupRole(req);
            return new OkObjectResult(result);
        }
    }
}