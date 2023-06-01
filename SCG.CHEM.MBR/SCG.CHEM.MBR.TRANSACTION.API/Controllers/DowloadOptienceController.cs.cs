using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Optience;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Optience.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services.Validation.Interface;

namespace SCG.CHEM.MBR.TRANSACTION.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    //[AdAuthorize]
    public class DowloadOptienceController : ControllerBase
    {
        #region Inject

        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;
        private readonly IDowloadOptienceService _dowloadService;

        public DowloadOptienceController(AppSettings appSetting, IDowloadOptienceService downloadService)
        {

            _appSetting = appSetting;
            _dowloadService = downloadService;
        }

        #endregion Inject
        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult DownloadOptience(OptienceDownloadRequest req)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Status = 200;
                res.IsSuccess = true;
                res.Data = _dowloadService.DowloadOptience(req);
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
