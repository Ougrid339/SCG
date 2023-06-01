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
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using Newtonsoft.Json;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Logging.Interface;

namespace SCG.CHEM.MBR.TRANSACTION.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class UploadMarketPriceForecastController : ControllerBase
    {
        #region Inject

        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;
        private readonly IMarketPriceForecastService _marketPriceForecastService;
        private readonly IValidateTransationService _validationService;
        private readonly ILogService _logService;

        public UploadMarketPriceForecastController(AppSettings appSetting, UnitOfWork unit, IMarketPriceForecastService marketPriceForecastService, IValidateTransationService validationService, ILogService logService)
        {
            _appSetting = appSetting;
            _unit = unit;
            _marketPriceForecastService = marketPriceForecastService;
            _validationService = validationService;
            _logService = logService;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult ValidateMarketPriceForecast([FromBody] DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel> data)
        {
            ResponseModel res = new ResponseModel();

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateMarketPriceForecastModel>();
            data.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();

                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateMarketPriceForecastModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateModels.Add(validateModel);
            });
            var newData = new DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel>();
            newData.Data = validateModels;
            newData.Criteria = data.Criteria;

            #endregion Create Validate Model & Set Id (RowNo)

            var logId = _logService.CreateLog(Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.MARKET_PRICE_FORECAST, data.Criteria.Scenario, data.Criteria.Cycle, data.Criteria.Case);
            var mappingInputWithError = newData;
            try
            {
                var validateResult = _validationService.ValidateMarketPriceForecast(data);
                validateResult.InterfaceId = logId;
                res.Data = validateResult;
                res.IsSuccess = true;

                #region create custom_msg log

                int index = 0;
                mappingInputWithError.Data.ForEach(item =>
                {
                    int row = index + 1;

                    item.ErrorMsg = new List<string>();
                    var output_row = validateResult.Data.FirstOrDefault(f => f.Id == row);
                    if (output_row?.ErrorMsg?.Any() ?? false)
                    {
                        // Set Error Msg By Validate ErrorMsg
                        item.ErrorMsg = output_row.ErrorMsg;
                    }

                    index++;
                });

                #endregion create custom_msg log
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
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithError));
                return new BadRequestObjectResult(res);
            }
            // Log Success
            _logService.LogSuccess(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithError));
            return new OkObjectResult(res);
        }

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult UploadMarketPriceForecast([FromBody] DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel> data)
        {
            ResponseModel res = new ResponseModel();

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateMarketPriceForecastModel>();
            data.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();

                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateMarketPriceForecastModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateModels.Add(validateModel);
            });
            var newData = new DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel>();
            newData.Data = validateModels;
            newData.Criteria = data.Criteria;

            #endregion Create Validate Model & Set Id (RowNo)

            var mappingInputWithError = newData;
            try
            {
                var validateResult = _validationService.ValidateMarketPriceForecast(data);
                if (validateResult.Data.Any(a => a.ErrorMsg.Count > 0))
                {
                    res = new ResponseModel()
                    {
                        Data = validateResult,
                        Error = "Validate Data Error",
                        IsSuccess = false,
                    };
                    // Customer Msg

                    #region create custom_msg log

                    int index = 0;
                    mappingInputWithError.Data.ForEach(item =>
                    {
                        int row = index + 1;

                        item.ErrorMsg = new List<string>();
                        var output_row = validateResult.Data.FirstOrDefault(f => f.Id == row);
                        if (output_row?.ErrorMsg?.Any() ?? false)
                        {
                            // Set Error Msg By Validate ErrorMsg
                            item.ErrorMsg = output_row.ErrorMsg;
                        }

                        index++;
                    });

                    #endregion create custom_msg log

                    // Log Success
                    _logService.LogSuccess(data.InterfaceId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithError));
                    return new OkObjectResult(res);
                }

                int total;
                res.Data = _marketPriceForecastService.UploadMarketPriceForecast(data, out total);
                res.Total = total;
                res.IsSuccess = true;
                var logId = _logService.UpdateLog(data.InterfaceId, Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.MARKET_PRICE_FORECAST, data.Criteria.Scenario, data.Criteria.Cycle, data.Criteria.Case);

                // Log Success
                _logService.LogSuccess(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithError));
            }
            catch (Exception e)
            {
                res = new ResponseModel()
                {
                    Error = e.Message,
                    Data = e.StackTrace,
                    IsSuccess = false,
                };

                var logId = _logService.UpdateLog(data.InterfaceId, Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.MARKET_PRICE_MAPPING, data.Criteria.Scenario, data.Criteria.Cycle, data.Criteria.Case);

                // Log Error
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithError));
                return new BadRequestObjectResult(res);
            }
            return new OkObjectResult(res);
        }

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult PreviewUploadMarketPriceForecast([FromBody] DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel> data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                var validateResult = _validationService.ValidateMarketPriceForecast(data);
                if (validateResult.Data.Any(a => a.ErrorMsg.Count > 0))
                {
                    res = new ResponseModel()
                    {
                        Data = validateResult,
                        Error = "Validate Data Error",
                        IsSuccess = false,
                    };
                    return new OkObjectResult(res);
                }

                res.Data = _marketPriceForecastService.PreviewUploadMarketPriceForecast(data);
                res.IsSuccess = true;
                res.Status = 200;
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