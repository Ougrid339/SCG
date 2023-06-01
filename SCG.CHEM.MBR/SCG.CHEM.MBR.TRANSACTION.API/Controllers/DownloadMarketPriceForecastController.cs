using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MarketPriceForecast.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services.Validation.Interface;

namespace SCG.CHEM.MBR.TRANSACTION.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    //[AdAuthorize]
    public class DownloadMarketPriceForecastController : Controller
    {
        #region Inject

        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;
        private readonly IDownloadMarketPriceForecastService _marketPriceForecastService;
        private readonly IValidateTransationService _validationService;

        public DownloadMarketPriceForecastController(AppSettings appSetting, IDownloadMarketPriceForecastService marketPriceForecastService, IValidateTransationService validationService)
        {

            _appSetting = appSetting;
            _marketPriceForecastService = marketPriceForecastService;
            _validationService = validationService;
        }

        #endregion Inject
        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult DownloadMarketPriceForecast(MarketPriceForecastDownloadRequest req)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Status = 200;
                res.IsSuccess = true;
                res.Data = _marketPriceForecastService.DownloadMarketPriceForecast(req);
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
