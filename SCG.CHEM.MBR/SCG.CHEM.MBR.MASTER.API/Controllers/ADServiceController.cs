using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.MASTER.API.AppModels.AD;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services.Interface;

namespace SCG.CHEM.MBR.MASTER.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class ADServiceController : ControllerBase
    {
        #region Inject

        private readonly IADService _adService;
        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;

        public ADServiceController(IADService adService, AppSettings appSetting)
        {
            _adService = adService;
            _appSetting = appSetting;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult GetADUserResult([FromBody] ReqADTokenModel data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Status = 200;
                res.IsSuccess = true;
                res.Data = _adService.GetADUserResult(data);
            }
            catch (Exception e)
            {
                res = new ResponseModel()
                {
                    Error = e.Message,
                    Data = e.StackTrace,
                    IsSuccess = false,
                };

                return new BadRequestObjectResult(res);
            }

            return new OkObjectResult(res);
        }

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult GetADUsers([FromBody] ReqADModel data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Status = 200;
                res.IsSuccess = true;
                res.Data = _adService.GetADUsers(data);
            }
            catch (Exception e)
            {
                res = new ResponseModel()
                {
                    Error = e.Message,
                    Data = e.StackTrace,
                    IsSuccess = false,
                };

                return new BadRequestObjectResult(res);
            }

            return new OkObjectResult(res);
        }

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult GetUserAD([FromBody] ReqADUserModel data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Status = 200;
                res.IsSuccess = true;
                res.Data = _adService.GetUserAD(data.token, data.name);
            }
            catch (Exception e)
            {
                res = new ResponseModel()
                {
                    Error = e.Message,
                    Data = e.StackTrace,
                    IsSuccess = false,
                };

                return new BadRequestObjectResult(res);
            }

            return new OkObjectResult(res);
        }
    }
}