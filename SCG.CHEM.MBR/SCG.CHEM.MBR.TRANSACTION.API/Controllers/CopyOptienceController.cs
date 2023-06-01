using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Optience;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Logging.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Optience.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services.Validation.Interface;

namespace SCG.CHEM.MBR.TRANSACTION.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class CopyOptienceController : ControllerBase
    {
        #region Inject

        private readonly AppSettings _appSetting;
        private readonly ICopyOptienceService _optienceService;
        private readonly UnitOfWork _unit;
        private readonly IValidateTransationService _validationService;
        private readonly ILogService _logService;

        public CopyOptienceController(AppSettings appSetting, IValidateTransationService validationService, ICopyOptienceService optienceService, ILogService logService)
        {
            _appSetting = appSetting;
            _validationService = validationService;
            _optienceService = optienceService;
            _logService = logService;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult CopyOptience([FromBody] OptienceCopyRequest data)
        {
            ResponseModel res = new ResponseModel();

            var check = _optienceService.CheckExistData(data);

            #region Log

            long? logIdFeedPurchase = null;
            var mappingInputWithErrorFeedPurchase = new DataWitOptienceDataModel<OptienceCopyRequest, ValidateFeedPurchaseModel>();
            long? logIdFeedConsumption = null;
            var mappingInputWithErrorFeedConsumption = new DataWitOptienceDataModel<OptienceCopyRequest, ValidateFeedConsumptionModel>();
            long? logIdBeginningInventory = null;
            var mappingInputWithErrorBeginningInventory = new DataWitOptienceDataModel<OptienceCopyRequest, ValidateBeginningInventoryModel>();
            long? logIdProductionVolume = null;
            var mappingInputWithErrorProductionVolume = new DataWitOptienceDataModel<OptienceCopyRequest, ValidateProductionVolumeModel>();

            var dataLog = data;

            #region data Result

            var feedPurchaseData = new List<ValidateFeedPurchaseModel>();
            var feedConsumptiondata = new List<ValidateFeedConsumptionModel>();
            var beginningInventoryData = new List<ValidateBeginningInventoryModel>();
            var productionVolumeData = new List<ValidateProductionVolumeModel>();

            #endregion data Result

            if (data.TypeTo.Any(a => a == 2))
            {
                dataLog.TypeTo = new List<int> { 2 };
                logIdProductionVolume = _logService.CreateLog(Request.Path.Value + "ProductionVolume", JsonConvert.SerializeObject(dataLog), APPCONSTANT.HISTORY_MBR_TYPE.PRODUCTION_VOLUME, data.ScenarioTo, data.CycleTo, data.CaseTo);
            }
            if (data.TypeTo.Any(a => a == 3))
            {
                dataLog.TypeTo = new List<int> { 3 };
                logIdFeedConsumption = _logService.CreateLog(Request.Path.Value + "FeedConsumption", JsonConvert.SerializeObject(dataLog), APPCONSTANT.HISTORY_MBR_TYPE.FEED_CONSUMPTION, data.ScenarioTo, data.CycleTo, data.CaseTo);
            }
            if (data.TypeTo.Any(a => a == 4))
            {
                dataLog.TypeTo = new List<int> { 4 };
                logIdBeginningInventory = _logService.CreateLog(Request.Path.Value + "BeginningInventory", JsonConvert.SerializeObject(dataLog), APPCONSTANT.HISTORY_MBR_TYPE.BEGINNING_INVENTORY, data.ScenarioTo, data.CycleTo, data.CaseTo);
            }
            if (data.TypeTo.Any(a => a == 5))
            {
                dataLog.TypeTo = new List<int> { 5 };

                logIdFeedPurchase = _logService.CreateLog(Request.Path.Value + "FeedPurchase", JsonConvert.SerializeObject(dataLog), APPCONSTANT.HISTORY_MBR_TYPE.FEED_PURCHASE, data.ScenarioTo, data.CycleTo, data.CaseTo);
            }

            #endregion Log

            OptienceData dataCopy = new OptienceData();
            try
            {
                int total;
                res.Data = _optienceService.CopyOptience(data, out total, out dataCopy);
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

                #region Set Log Error

                if (logIdFeedPurchase != null)
                {
                    dataLog.TypeTo = new List<int> { 5 };
                    // Log Error
                    _logService.LogError(logIdFeedPurchase.Value, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(res));
                }
                if (logIdFeedConsumption != null)
                {
                    dataLog.TypeTo = new List<int> { 3 };
                    // Log Error
                    _logService.LogError(logIdFeedConsumption.Value, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(res));
                }
                if (logIdBeginningInventory != null)
                {
                    dataLog.TypeTo = new List<int> { 4 };
                    // Log Error
                    _logService.LogError(logIdBeginningInventory.Value, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(res));
                }
                if (logIdProductionVolume != null)
                {
                    dataLog.TypeTo = new List<int> { 2 };
                    // Log Error
                    _logService.LogError(logIdProductionVolume.Value, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(res));
                }

                #endregion Set Log Error

                return new BadRequestObjectResult(res);
            }

            #region Set Log Success

            if (logIdFeedPurchase != null)
            {
                var result = new ResponseModel()
                {
                    Data = dataCopy?.feedPurchaseData,
                    IsSuccess = true,
                };

                #region Create Validate Model & Set Id (RowNo)

                var validateModels = new List<ValidateFeedPurchaseModel>();
                var dataGroup = dataCopy?.feedPurchaseData.GroupBy(g => new { g.Company, g.MCSC, g.FeedName, g.FeedShortName }).ToList();
                var lst = new List<ValidateFeedPurchaseModel>();
                foreach (var item in dataGroup)
                {
                    lst.Add(new ValidateFeedPurchaseModel
                    {
                        Company = item?.Key.Company ?? "",
                        ElementCode = item?.FirstOrDefault()?.ElementCodeEBA ?? "",
                        FeedName = item?.Key.FeedName ?? "",
                        FeedShortName = item?.Key.FeedShortName ?? "",
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
                        MCSC = item?.Key.MCSC ?? "",
                        SupplierKey = item?.FirstOrDefault()?.SupplierKey ?? "",
                        MaterialCode = item?.FirstOrDefault()?.MaterialCode ?? "",
                        SupplierCode = item?.FirstOrDefault()?.SupplierCode ?? ""
                    });
                }

                #endregion Create Validate Model & Set Id (RowNo)

                mappingInputWithErrorFeedPurchase.Criteria = data;
                mappingInputWithErrorFeedPurchase.Data = lst;
                // Log Success
                _logService.LogSuccessPassValidate(logIdFeedPurchase.Value, JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(mappingInputWithErrorFeedPurchase));
            }
            if (logIdFeedConsumption != null)
            {
                var result = new ResponseModel()
                {
                    Data = dataCopy?.feedConsumptionData,
                    IsSuccess = true,
                };

                #region Create Validate Model & Set Id (RowNo)

                var validateModels = new List<ValidateFeedConsumptionModel>();
                var dataGroup = dataCopy?.feedConsumptionData.GroupBy(g => new { g.Company, g.MCSC, g.FeedName, g.FeedShortName }).ToList();
                var lst = new List<ValidateFeedConsumptionModel>();
                foreach (var item in dataGroup)
                {
                    lst.Add(new ValidateFeedConsumptionModel
                    {
                        Company = item?.Key.Company ?? "",
                        ElementCode = item?.FirstOrDefault()?.ElementCodeEBA ?? "",
                        FeedName = item?.Key.FeedName ?? "",
                        FeedShortName = item?.Key.FeedShortName ?? "",
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
                        MCSC = item?.Key.MCSC ?? "",
                        SupplierKey = item?.FirstOrDefault()?.SupplierKey ?? "",
                        SupplierCode = item?.FirstOrDefault()?.SupplierCode ?? "",
                        MaterialCode = item?.FirstOrDefault()?.MaterialCode ?? ""
                    });
                }

                #endregion Create Validate Model & Set Id (RowNo)

                mappingInputWithErrorFeedConsumption.Criteria = data;
                mappingInputWithErrorFeedConsumption.Data = lst;
                // Log Success
                _logService.LogSuccessPassValidate(logIdFeedConsumption.Value, JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(mappingInputWithErrorFeedConsumption));
            }
            if (logIdBeginningInventory != null)
            {
                var result = new ResponseModel()
                {
                    Data = dataCopy?.beginningInventoryData,
                    IsSuccess = true,
                };

                #region Create Validate Model & Set Id (RowNo)

                var validateModels = new List<ValidateBeginningInventoryModel>();
                var dataGroup = dataCopy?.beginningInventoryData.GroupBy(g => new { g.Company, g.MCSC, g.ProductShortName }).ToList();
                var lst = new List<ValidateBeginningInventoryModel>();
                foreach (var item in dataGroup)
                {
                    lst.Add(new ValidateBeginningInventoryModel
                    {
                        Company = item?.Key.Company ?? "",
                        M0 = item?.FirstOrDefault(f => f.MonthIndex == "M0")?.Price?.ToString() ?? "",
                        MCSC = item?.Key.MCSC ?? "",
                        ProductShortName = item?.FirstOrDefault()?.ProductShortName ?? "",
                        ElementCode = item?.FirstOrDefault()?.ElementCodeEBA ?? "",
                        SupplierCode = item?.FirstOrDefault()?.SupplierCode ?? "",
                        MaterialCode = item?.FirstOrDefault()?.MaterialCode ?? "",
                        SupplierKey = item?.FirstOrDefault()?.SupplierKey ?? "",
                        InventoryName = item?.FirstOrDefault()?.InventoryName ?? "",
                        TankNumber = item?.FirstOrDefault()?.TankNumber ?? ""
                    });
                }

                #endregion Create Validate Model & Set Id (RowNo)

                mappingInputWithErrorBeginningInventory.Criteria = data;
                mappingInputWithErrorBeginningInventory.Data = lst;

                // Log Success
                _logService.LogSuccessPassValidate(logIdBeginningInventory.Value, JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(mappingInputWithErrorBeginningInventory));
            }
            if (logIdProductionVolume != null)
            {
                var result = new ResponseModel()
                {
                    Data = dataCopy?.productionVolumeData,
                    IsSuccess = true,
                };

                #region Create Validate Model & Set Id (RowNo)

                var validateModels = new List<ValidateProductionVolumeModel>();
                var dataGroup = dataCopy?.productionVolumeData.GroupBy(g => new { g.Company, g.MCSC, g.ProductName, g.ProductShortName }).ToList();
                var lst = new List<ValidateProductionVolumeModel>();
                foreach (var item in dataGroup)
                {
                    lst.Add(new ValidateProductionVolumeModel
                    {
                        Company = item?.Key.Company ?? "",
                        ElementCode = item?.FirstOrDefault()?.ElementCodeEBA ?? "",
                        ProductName = item?.Key.ProductName ?? "",
                        ProductShortName = item?.Key.ProductShortName ?? "",
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
                        MCSC = item?.Key.MCSC ?? "",
                        MaterialCode = item?.FirstOrDefault()?.MaterialCode ?? ""
                    });
                }

                #endregion Create Validate Model & Set Id (RowNo)

                mappingInputWithErrorProductionVolume.Criteria = data;
                mappingInputWithErrorProductionVolume.Data = lst;
                // Log Success
                _logService.LogSuccessPassValidate(logIdProductionVolume.Value, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithErrorProductionVolume));
            }

            #endregion Set Log Success

            return new OkObjectResult(res);
        }

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult PreviewCopyOptience([FromBody] OptienceCopyRequest data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                res.Status = 200;
                res.Data = _optienceService.PreviewCopyOptience(data);
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