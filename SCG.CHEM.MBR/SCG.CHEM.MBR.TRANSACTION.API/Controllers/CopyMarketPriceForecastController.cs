using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using System.Net;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MarketPriceForecast.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services.Validation.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Logging.Interface;
using Newtonsoft.Json;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;

namespace SCG.CHEM.MBR.TRANSACTION.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class CopyMarketPriceForecastController : ControllerBase
    {
        #region Inject

        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;
        private readonly ICopyMarketPriceForecastService _marketPriceForecastService;
        private readonly IValidateTransationService _validationService;
        private readonly ILogService _logService;

        public CopyMarketPriceForecastController(AppSettings appSetting, ICopyMarketPriceForecastService marketPriceForecastService, IValidateTransationService validationService, ILogService logService)
        {
            _appSetting = appSetting;
            _marketPriceForecastService = marketPriceForecastService;
            _validationService = validationService;
            _logService = logService;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult CopyMarketPriceForecast([FromBody] MarketPriceForecastCopyRequest data)
        {
            ResponseModel res = new ResponseModel();
            List<MBR_TMP_MARKET_PRICE_FORECAST> dataCopy;
            var check = _marketPriceForecastService.CheckExistData(data);
            var logId = _logService.CreateLog(Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.MARKET_PRICE_FORECAST, data.ScenarioTo, data.CycleTo, data.CaseTo);

            try
            {
                int total;
                res.Data = _marketPriceForecastService.CopyMarketPriceForecast(data, out total, out dataCopy);
                res.Total = total;
                res.IsSuccess = true;
            }
            catch (Exception e)
            {
                res = new ResponseModel()
                {
                    Error = e.Message,
                    Data = e.StackTrace,
                    IsSuccess = false,
                };

                // Log Error
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(res));
                return new BadRequestObjectResult(res);
            }

            #region Create Validate Model & Set Id (RowNo)

            var validateModels = new List<ValidateMarketPriceForecastModel>();
            var dataGroup = dataCopy?.GroupBy(g => new { g.PlanType, g.Case, g.Cycle, g.MarketSource }).ToList();
            var lst = new List<ValidateMarketPriceForecastModel>();
            foreach (var item in dataGroup)
            {
                lst.Add(new ValidateMarketPriceForecastModel
                {
                    M0 = item?.FirstOrDefault(f => f.MonthIndex == "M0")?.Price?.ToString() ?? "",
                    M1 = item?.FirstOrDefault(f => f.MonthIndex == "M1")?.Price?.ToString() ?? "",
                    M2 = item?.FirstOrDefault(f => f.MonthIndex == "M2")?.Price?.ToString() ?? "",
                    M3 = item?.FirstOrDefault(f => f.MonthIndex == "M3")?.Price?.ToString() ?? "",
                    M4 = item?.FirstOrDefault(f => f.MonthIndex == "M4")?.Price?.ToString() ?? "",
                    M5 = item?.FirstOrDefault(f => f.MonthIndex == "M5")?.Price?.ToString() ?? "",
                    M6 = item?.FirstOrDefault(f => f.MonthIndex == "M6")?.Price?.ToString() ?? "",
                    M7 = item?.FirstOrDefault(f => f.MonthIndex == "M7")?.Price?.ToString() ?? "",
                    M8 = item?.FirstOrDefault(f => f.MonthIndex == "M8")?.Price?.ToString() ?? "",
                    M9 = item?.FirstOrDefault(f => f.MonthIndex == "M9")?.Price?.ToString() ?? "",
                    M10 = item?.FirstOrDefault(f => f.MonthIndex == "M10")?.Price?.ToString() ?? "",
                    M11 = item?.FirstOrDefault(f => f.MonthIndex == "M11")?.Price?.ToString() ?? "",
                    M12 = item?.FirstOrDefault(f => f.MonthIndex == "M12")?.Price?.ToString() ?? "",
                    M13 = item?.FirstOrDefault(f => f.MonthIndex == "M13")?.Price?.ToString() ?? "",
                    M14 = item?.FirstOrDefault(f => f.MonthIndex == "M14")?.Price?.ToString() ?? "",
                    M15 = item?.FirstOrDefault(f => f.MonthIndex == "M15")?.Price?.ToString() ?? "",
                    M16 = item?.FirstOrDefault(f => f.MonthIndex == "M16")?.Price?.ToString() ?? "",
                    M17 = item?.FirstOrDefault(f => f.MonthIndex == "M17")?.Price?.ToString() ?? "",
                    M18 = item?.FirstOrDefault(f => f.MonthIndex == "M18")?.Price?.ToString() ?? "",
                    MarketSource = item?.Key.MarketSource ?? "",
                    Unit = item?.FirstOrDefault()?.Unit ?? "",
                    EBACode = item?.FirstOrDefault()?.EBACode ?? ""
                });
            }

            #endregion Create Validate Model & Set Id (RowNo)

            var mappingInputWithError = new DataWithMarketPriceForecastModel<MarketPriceForecastCopyRequest, ValidateMarketPriceForecastModel>();
            mappingInputWithError.Criteria = data;
            mappingInputWithError.Data = lst;
            // Log Success
            _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithError));
            return new OkObjectResult(res);
        }

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult PreviewCopyMarketPriceForecast([FromBody] MarketPriceForecastCopyRequest data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                res.Status = 200;
                res.Data = _marketPriceForecastService.PreviewCopyMarketPriceForecast(data);
                res.IsSuccess = true;
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