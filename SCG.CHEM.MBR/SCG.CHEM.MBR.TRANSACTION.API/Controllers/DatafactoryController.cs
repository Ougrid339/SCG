using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.DataFactory;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Datafacetory.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.FeedInfo.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Logging.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MarketPriceForecast.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Optience.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Sales.Interface;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.TRANSACTION.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class DatafactoryController : ControllerBase
    {
        #region Inject

        private readonly IDataFactoryService _dataFactoryService;
        private readonly AppSettings _appSetting;
        private readonly IMarketPriceForecastService _marketPriceForecastService;
        private readonly IOptienceService _optienceService;
        private readonly IFeedInfoService _feedInfoService;
        private readonly ISalesService _salesService;
        private readonly ILogService _logService;

        public DatafactoryController(IDataFactoryService datafactory, AppSettings appSetting, IMarketPriceForecastService marketPriceForecastService, ISalesService salesService
                , IOptienceService optienceService, IFeedInfoService feedInfoService, ILogService logService)
        {
            _dataFactoryService = datafactory;
            _appSetting = appSetting;
            _marketPriceForecastService = marketPriceForecastService;
            _optienceService = optienceService;
            _feedInfoService = feedInfoService;
            _logService = logService;
            _salesService = salesService;
        }

        #endregion Inject

        //[HttpPost]
        //[RequestSizeLimit(long.MaxValue)]
        //public IActionResult Latest()
        //{
        //    ResponseModel res = new ResponseModel();

        //    try
        //    {
        //        res.IsSuccess = true;
        //        res.Data = _datafactory.GetLatestUpdate();
        //    }
        //    catch (Exception e)
        //    {
        //        res = new ResponseModel()
        //        {
        //            Error = e.Message,
        //            Data = e.StackTrace,
        //            IsSuccess = false,
        //        };

        //        return new BadRequestObjectResult(res);
        //    }

        //    return new OkObjectResult(res);
        //}

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult RunStatus([FromBody] RequestDataFactoryRunIdStatus data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                res.Data = _dataFactoryService.StatusRunId(data.RunId);
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

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult MoveTransaction([FromBody] RequestDataFactoryRunIdStatus data)
        {
            ResponseModel res = new ResponseModel();
            var logId = _logService.CreateLogMove(Request.Path.Value, JsonConvert.SerializeObject(data), null, data.planTypeName, data.cycleName, data.caseName);
            try
            {
                var statusImport = true;
                var trnName = _dataFactoryService.GetNameDatafactory(data.RunId);
                _logService.UpdateLogMove(logId, Request.Path.Value + trnName);

                res.IsSuccess = true;
                res.Data = _dataFactoryService.DWHImportCompleteStatus(data.RunId, data.status);

                if (_dataFactoryService.GetNameDatafactory(data.RunId) == TRANSACTIONNAME.MARKETPRICEFORECAST)
                {
                    res.Total = _marketPriceForecastService.MoveMarketPriceForecast(data.RunId, out statusImport);
                }
                else if (_dataFactoryService.GetNameDatafactory(data.RunId) == TRANSACTIONNAME.FEEDPURCHASE)
                {
                    res.Total = _optienceService.MoveFeedPurchase(data.RunId, data.company);
                }
                else if (_dataFactoryService.GetNameDatafactory(data.RunId) == TRANSACTIONNAME.FEEDCONSUMPTION)
                {
                    res.Total = _optienceService.MoveFeedConsumption(data.RunId, data.company);
                }
                else if (_dataFactoryService.GetNameDatafactory(data.RunId) == TRANSACTIONNAME.BEGINNINGINVENTORY)
                {
                    res.Total = _optienceService.MoveBeginningInventory(data.RunId, data.company);
                }
                else if (_dataFactoryService.GetNameDatafactory(data.RunId) == TRANSACTIONNAME.PRODUCTIONVOLUME)
                {
                    res.Total = _optienceService.MoveProductionVolume(data.RunId, data.company);
                }
                else if (_dataFactoryService.GetNameDatafactory(data.RunId) == TRANSACTIONNAME.FEEDINFO)
                {
                    res.Total = _feedInfoService.MoveFeedInfo(data);
                }
                if (statusImport)
                {
                    var status = _dataFactoryService.WebImportCompleteStatus(data.RunId);
                }
                else
                {
                    var status = _dataFactoryService.WebImportFailStatus(data.RunId);
                }
            }
            catch (Exception e)
            {
                res = new ResponseModel()
                {
                    Error = e.Message,
                    Data = e.StackTrace,
                    IsSuccess = false,
                };

                _logService.UpdateLogMoveOnError(logId, e.Message);

                return new BadRequestObjectResult(res);
            }

            return new OkObjectResult(res);
        }

        // This is to be refactored into an appropriate service
        [HttpPost]
        public async Task<IActionResult> MoveOrUpdatePreviewStatusForSalesVolume([FromBody] RequestDataFactoryRunIdStatus data)
        {
            var res = new ResponseModel();
            var logId = _logService.CreateLogMove(Request.Path.Value, JsonConvert.SerializeObject(data), null, data.planTypeName, data.cycleName, data.caseName);

            try
            {
                res.IsSuccess = true;

                // Preview
                // RunId = PreviewRunId
                if (data.submitStatus == SUBMIT_STATUS.PREVIEW)
                {
                    if (data.status == "Succeeded")
                    {
                        _dataFactoryService.UpdateSalesPreviewSucceeded(data.RunId);
                        res.Data = "Succeeded";
                        res.IsSuccess = true;
                    }
                    else
                    {
                        _dataFactoryService.UpdateSalesPreviewFailed(data.RunId);
                        res.Data = "Failed";
                        res.IsSuccess = false;
                    }
                }

                // Submit After Preview
                // RunId = SubmitRunId
                else if (data.submitStatus == SUBMIT_STATUS.SUBMIT_AFTER_PREVIEW)
                {
                    if (data.status == "Succeeded")
                    {
                        // Move TMP_SalesVolume with FinalPrice to TRN_SalesVolume
                        // Use submid runid returned from dwh to get preview runid
                        _dataFactoryService.UpdateSalesSubmitSucceeded(data.RunId);
                        _dataFactoryService.UpdateDatafactoryRunStatus(data.RunId, data.status ?? "");

                        var previewRunId = _salesService.GetPreviewRunIdFromSubmitRunId(data.RunId);
                        _salesService.MoveSales(data, previewRunId);

                        _dataFactoryService.WebImportCompleteStatus(data.RunId);
                        res.Data = "Succeeded";
                        res.IsSuccess = true;
                    }
                    else
                    {
                        res.Data = "Failed";
                        res.IsSuccess = false;
                        _dataFactoryService.UpdateSalesSubmitFailed(data.RunId);
                        _dataFactoryService.UpdateDatafactoryRunStatus(data.RunId, data.status ?? "");
                    }
                }

                // Direct Submit
                // RunId = SubmitRunId
                else if (data.submitStatus == SUBMIT_STATUS.SUBMIT)
                {
                    if (data.status == "Succeeded")
                    {
                        var webUUID =  _salesService.GetUUIDFromSubmitRunId(data.RunId);

                        var runIdPipeline = await _dataFactoryService.RunPipeLineImportFinalPrice(data.RunId, false);

                        while (await _salesService.KeepCheckingForStatus(SALES_MODE.IMPORTING_SUCCEDED, webUUID))
                        {
                            await Task.Delay(10000);
                        }

                        _salesService.MoveSales(data, data.RunId);
                        _dataFactoryService.UpdateSalesSubmitSucceeded(data.RunId);
                        _dataFactoryService.WebImportCompleteStatus(data.RunId);
                        res.Data = "Succeeded";
                        res.IsSuccess = true;
                    }

                    else
                    {
                        res.Data = "Failed";
                        res.IsSuccess = false;
                        _dataFactoryService.UpdateSalesSubmitFailed(data.RunId);
                        _dataFactoryService.UpdateDatafactoryRunStatus(data.RunId, data.status ?? "");
                    }
                }

                else
                {
                    throw new Exception("Unknown submit status");
                }
            }
            catch (Exception e)
            {
                res = new ResponseModel()
                {
                    Error = e.Message,
                    Data = e.StackTrace,
                    IsSuccess = false,
                };

                _logService.UpdateLogMoveOnError(logId, e.Message);

                return new BadRequestObjectResult(res);
            }

            return new OkObjectResult(res);
        }
    }
}