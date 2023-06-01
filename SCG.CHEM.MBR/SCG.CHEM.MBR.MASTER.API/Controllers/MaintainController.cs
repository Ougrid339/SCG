using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.MASTER.API.AppModels.Maintain;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master.Interface;

namespace SCG.CHEM.MBR.MASTER.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    [AdAuthorize]
    public class MaintainController : ControllerBase
    {
        #region Inject

        private readonly IMasterService _masterService;
        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;

        public MaintainController(IMasterService masterService, AppSettings appSetting)
        {
            _masterService = masterService;
            _appSetting = appSetting;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult MasterMapping([FromBody] RequestMaintainModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                res.IsSuccess = true;
                res.Data = _masterService.MasterMapping(data);
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