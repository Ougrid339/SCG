using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;
using System.Collections.Generic;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services.Account.Interface;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Authentication.Interface;

namespace SCG.CHEM.MBR.AUTH.API.Controllers.Account
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    [AdAuthorize]
    public class AccountController : ControllerBase
    {
        #region Inject

        private readonly IAccountService _accountService;
        private readonly ITokenManager _tokenManager;
        private readonly AppSettings _appSetting;

        public AccountController(IAccountService accountService, ITokenManager tokenManager, AppSettings appSetting)
        {
            _accountService = accountService;
            _tokenManager = tokenManager;
            _appSetting = appSetting;
        }

        #endregion Inject

        [HttpPost]
        public IActionResult GetAccount(AccountLoggedInReqModel data)
        {
            var result = _accountService.GetAccount(data);
            result.AppToken = _tokenManager.GenerateAppToken(result);
            result.Menu = _accountService.GetMenu(result.Roles);
            result.AppVersion = _appSetting.AppVersion;
            result.IsProduction = _appSetting.ENVIRONMENT == "Production";
            return new OkObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetMenu([FromQuery] List<short> roles = null)
        {
            var result = _accountService.GetMenu(roles);
            return new OkObjectResult(result);
        }
    }
}