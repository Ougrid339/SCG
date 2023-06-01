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
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Validation.Interface;

namespace SCG.CHEM.MBR.TRANSACTION.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class UploadOptienceController : ControllerBase
    {
        #region Inject

        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;
        private readonly IValidateOptienceService _validationService;
        private readonly IOptienceService _optienceService;
        private readonly ILogService _logService;

        public UploadOptienceController(AppSettings appSetting, IOptienceService optienceService, IValidateOptienceService validationService, ILogService logService)
        {
            _appSetting = appSetting;
            _validationService = validationService;
            _optienceService = optienceService;
            _logService = logService;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult ValidateOptience([FromBody] DataWitOptienceModel<OptienceCriteriaModel> param)
        {
            ResponseModel res = new ResponseModel();

            #region Log

            long? logIdFeedPurchase = null;
            var mappingInputWithErrorFeedPurchase = new DataWitOptienceDataModel<OptienceCriteriaModel, ValidateFeedPurchaseModel>();
            long? logIdFeedConsumption = null;
            var mappingInputWithErrorFeedConsumption = new DataWitOptienceDataModel<OptienceCriteriaModel, ValidateFeedConsumptionModel>();
            long? logIdBeginningInventory = null;
            var mappingInputWithErrorBeginningInventory = new DataWitOptienceDataModel<OptienceCriteriaModel, ValidateBeginningInventoryModel>();
            long? logIdProductionVolume = null;
            var mappingInputWithErrorProductionVolume = new DataWitOptienceDataModel<OptienceCriteriaModel, ValidateProductionVolumeModel>();

            #region data Result

            var feedPurchaseData = new List<ValidateFeedPurchaseModel>();
            var feedConsumptiondata = new List<ValidateFeedConsumptionModel>();
            var beginningInventoryData = new List<ValidateBeginningInventoryModel>();
            var productionVolumeData = new List<ValidateProductionVolumeModel>();

            #endregion data Result

            if (param.FeedPurchaseData?.Count >= 1)
            {
                #region Create Validate Model & Set Id (RowNo)

                int row = 0;
                var validateModels = new List<ValidateFeedPurchaseModel>();
                param.FeedPurchaseData.ForEach(i =>
                {
                    row++;
                    i.Id = row;
                    i.ErrorMsg = new List<string>();

                    var convertErrorList = new List<string>();
                    var convertDataWarningList = new List<string>();
                    var convertModel = i.TryConvertToModel(out convertErrorList);

                    // create model
                    var validateModel = new ValidateFeedPurchaseModel();
                    validateModel.Id = i.Id;
                    validateModel.SetModel(convertModel);
                    validateModel.ErrorMsg.AddRange(convertErrorList);
                    validateModels.Add(validateModel);
                });

                #endregion Create Validate Model & Set Id (RowNo)

                logIdFeedPurchase = _logService.CreateLog(Request.Path.Value + "FeedPurchase", JsonConvert.SerializeObject(param.FeedPurchaseData), APPCONSTANT.HISTORY_MBR_TYPE.FEED_PURCHASE, param.Criteria.Scenario, param.Criteria.Cycle, param.Criteria.Case);
                mappingInputWithErrorFeedPurchase.Criteria = param.Criteria;
                mappingInputWithErrorFeedPurchase.Data = validateModels;
                mappingInputWithErrorFeedPurchase.InterfaceId = logIdFeedPurchase;
            }
            if (param.FeedConsumptionData?.Count >= 1)
            {
                #region Create Validate Model & Set Id (RowNo)

                int row = 0;
                var validateModels = new List<ValidateFeedConsumptionModel>();
                param.FeedConsumptionData.ForEach(i =>
                {
                    row++;
                    i.Id = row;
                    i.ErrorMsg = new List<string>();

                    var convertErrorList = new List<string>();
                    var convertDataWarningList = new List<string>();
                    var convertModel = i.TryConvertToModel(out convertErrorList);

                    // create model
                    var validateModel = new ValidateFeedConsumptionModel();
                    validateModel.Id = i.Id;
                    validateModel.SetModel(convertModel);
                    validateModel.ErrorMsg.AddRange(convertErrorList);
                    validateModels.Add(validateModel);
                });

                #endregion Create Validate Model & Set Id (RowNo)

                logIdFeedConsumption = _logService.CreateLog(Request.Path.Value + "FeedConsumption", JsonConvert.SerializeObject(param.FeedConsumptionData), APPCONSTANT.HISTORY_MBR_TYPE.FEED_CONSUMPTION, param.Criteria.Scenario, param.Criteria.Cycle, param.Criteria.Case);
                mappingInputWithErrorFeedConsumption.Criteria = param.Criteria;
                mappingInputWithErrorFeedConsumption.Data = validateModels;
                mappingInputWithErrorFeedConsumption.InterfaceId = logIdFeedConsumption;
            }
            if (param.BeginningInventoryData?.Count >= 1)
            {
                #region Create Validate Model & Set Id (RowNo)

                int row = 0;
                var validateModels = new List<ValidateBeginningInventoryModel>();
                param.BeginningInventoryData.ForEach(i =>
                {
                    row++;
                    i.Id = row;
                    i.ErrorMsg = new List<string>();

                    var convertErrorList = new List<string>();
                    var convertDataWarningList = new List<string>();
                    var convertModel = i.TryConvertToModel(out convertErrorList);

                    // create model
                    var validateModel = new ValidateBeginningInventoryModel();
                    validateModel.Id = i.Id;
                    validateModel.SetModel(convertModel);
                    validateModel.ErrorMsg.AddRange(convertErrorList);
                    validateModels.Add(validateModel);
                });

                #endregion Create Validate Model & Set Id (RowNo)

                logIdBeginningInventory = _logService.CreateLog(Request.Path.Value + "BeginningInventory", JsonConvert.SerializeObject(param.BeginningInventoryData), APPCONSTANT.HISTORY_MBR_TYPE.BEGINNING_INVENTORY, param.Criteria.Scenario, param.Criteria.Cycle, param.Criteria.Case);
                mappingInputWithErrorBeginningInventory.Criteria = param.Criteria;
                mappingInputWithErrorBeginningInventory.Data = validateModels;
                mappingInputWithErrorBeginningInventory.InterfaceId = logIdBeginningInventory;
            }
            if (param.ProductionVolumeData?.Count >= 1)
            {
                #region Create Validate Model & Set Id (RowNo)

                int row = 0;
                var validateModels = new List<ValidateProductionVolumeModel>();
                param.ProductionVolumeData.ForEach(i =>
                {
                    row++;
                    i.Id = row;
                    i.ErrorMsg = new List<string>();

                    var convertErrorList = new List<string>();
                    var convertDataWarningList = new List<string>();
                    var convertModel = i.TryConvertToModel(out convertErrorList);

                    // create model
                    var validateModel = new ValidateProductionVolumeModel();
                    validateModel.Id = i.Id;
                    validateModel.SetModel(convertModel);
                    validateModel.ErrorMsg.AddRange(convertErrorList);
                    validateModels.Add(validateModel);
                });

                #endregion Create Validate Model & Set Id (RowNo)

                logIdProductionVolume = _logService.CreateLog(Request.Path.Value + "ProductionVolume", JsonConvert.SerializeObject(param.ProductionVolumeData), APPCONSTANT.HISTORY_MBR_TYPE.PRODUCTION_VOLUME, param.Criteria.Scenario, param.Criteria.Cycle, param.Criteria.Case);
                mappingInputWithErrorProductionVolume.Criteria = param.Criteria;
                mappingInputWithErrorProductionVolume.Data = validateModels;
                mappingInputWithErrorProductionVolume.InterfaceId = logIdProductionVolume;
            }

            #endregion Log

            try
            {
                var validateResult = _validationService.ValidateOptience(param);
                validateResult.InterfaceIdFeedPurchase = logIdFeedPurchase ?? null;
                validateResult.InterfaceIdFeedConsumption = logIdFeedConsumption ?? null;
                validateResult.InterfaceIdBeginningInventory = logIdBeginningInventory ?? null;
                validateResult.InterfaceIdProductionVolume = logIdProductionVolume ?? null;
                res.Data = validateResult;
                res.IsSuccess = true;

                #region Set Data

                feedPurchaseData = validateResult.FeedPurchaseData;
                feedConsumptiondata = validateResult.FeedConsumptionData;
                beginningInventoryData = validateResult.BeginningInventoryData;
                productionVolumeData = validateResult.ProductionVolumeData;

                #endregion Set Data

                #region Set Custom msg

                if (validateResult.FeedPurchaseData.Any(a => a.ErrorMsg.Count > 0))
                {
                    #region create custom_msg log

                    int index = 0;
                    mappingInputWithErrorFeedPurchase.Data.ForEach(item =>
                    {
                        int row = index + 1;

                        item.ErrorMsg = new List<string>();
                        var output_row = validateResult.FeedPurchaseData.FirstOrDefault(f => f.Id == row);
                        if (output_row?.ErrorMsg?.Any() ?? false)
                        {
                            // Set Error Msg By Validate ErrorMsg
                            item.ErrorMsg = output_row.ErrorMsg;
                        }

                        index++;
                    });

                    #endregion create custom_msg log
                }
                if (validateResult.FeedConsumptionData.Any(a => a.ErrorMsg.Count > 0))
                {
                    #region create custom_msg log

                    int index = 0;
                    mappingInputWithErrorFeedConsumption.Data.ForEach(item =>
                    {
                        int row = index + 1;

                        item.ErrorMsg = new List<string>();
                        var output_row = validateResult.FeedConsumptionData.FirstOrDefault(f => f.Id == row);
                        if (output_row?.ErrorMsg?.Any() ?? false)
                        {
                            // Set Error Msg By Validate ErrorMsg
                            item.ErrorMsg = output_row.ErrorMsg;
                        }

                        index++;
                    });

                    #endregion create custom_msg log
                }
                if (validateResult.BeginningInventoryData.Any(a => a.ErrorMsg.Count > 0))
                {
                    #region create custom_msg log

                    int index = 0;
                    mappingInputWithErrorBeginningInventory.Data.ForEach(item =>
                    {
                        int row = index + 1;

                        item.ErrorMsg = new List<string>();
                        var output_row = validateResult.BeginningInventoryData.FirstOrDefault(f => f.Id == row);
                        if (output_row?.ErrorMsg?.Any() ?? false)
                        {
                            // Set Error Msg By Validate ErrorMsg
                            item.ErrorMsg = output_row.ErrorMsg;
                        }

                        index++;
                    });

                    #endregion create custom_msg log
                }
                if (validateResult.ProductionVolumeData.Any(a => a.ErrorMsg.Count > 0))
                {
                    #region create custom_msg log

                    int index = 0;
                    mappingInputWithErrorProductionVolume.Data.ForEach(item =>
                    {
                        int row = index + 1;

                        item.ErrorMsg = new List<string>();
                        var output_row = validateResult.ProductionVolumeData.FirstOrDefault(f => f.Id == row);
                        if (output_row?.ErrorMsg?.Any() ?? false)
                        {
                            // Set Error Msg By Validate ErrorMsg
                            item.ErrorMsg = output_row.ErrorMsg;
                        }

                        index++;
                    });

                    #endregion create custom_msg log
                }

                #endregion Set Custom msg
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
                    // Log Error
                    _logService.LogError(logIdFeedPurchase.Value, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithErrorFeedPurchase));
                }
                if (logIdFeedConsumption != null)
                {
                    // Log Error
                    _logService.LogError(logIdFeedConsumption.Value, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithErrorFeedConsumption));
                }
                if (logIdBeginningInventory != null)
                {
                    // Log Error
                    _logService.LogError(logIdBeginningInventory.Value, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithErrorBeginningInventory));
                }
                if (logIdProductionVolume != null)
                {
                    // Log Error
                    _logService.LogError(logIdProductionVolume.Value, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithErrorProductionVolume));
                }

                #endregion Set Log Error

                return new BadRequestObjectResult(res);
            }

            #region Set Log Success

            if (logIdFeedPurchase != null)
            {
                var result = new ResponseModel()
                {
                    Data = feedPurchaseData,
                    IsSuccess = true,
                };
                // Log Error
                _logService.LogSuccessPassValidate(logIdFeedPurchase.Value, JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(mappingInputWithErrorFeedPurchase));
            }
            if (logIdFeedConsumption != null)
            {
                var result = new ResponseModel()
                {
                    Data = feedConsumptiondata,
                    IsSuccess = true,
                };
                // Log Error
                _logService.LogSuccessPassValidate(logIdFeedConsumption.Value, JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(mappingInputWithErrorFeedConsumption));
            }
            if (logIdBeginningInventory != null)
            {
                var result = new ResponseModel()
                {
                    Data = beginningInventoryData,
                    IsSuccess = true,
                };
                // Log Error
                _logService.LogSuccessPassValidate(logIdBeginningInventory.Value, JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(mappingInputWithErrorBeginningInventory));
            }
            if (logIdProductionVolume != null)
            {
                var result = new ResponseModel()
                {
                    Data = productionVolumeData,
                    IsSuccess = true,
                };
                // Log Error
                _logService.LogSuccessPassValidate(logIdProductionVolume.Value, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithErrorProductionVolume));
            }

            #endregion Set Log Success

            return new OkObjectResult(res);
        }

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult UploadOptience([FromBody] DataWitOptienceModel<OptienceCriteriaModel> param)
        {
            ResponseModel res = new ResponseModel();

            #region Log

            long? logIdFeedPurchase = null;
            var mappingInputWithErrorFeedPurchase = new DataWitOptienceDataModel<OptienceCriteriaModel, ValidateFeedPurchaseModel>();
            long? logIdFeedConsumption = null;
            var mappingInputWithErrorFeedConsumption = new DataWitOptienceDataModel<OptienceCriteriaModel, ValidateFeedConsumptionModel>();
            long? logIdBeginningInventory = null;
            var mappingInputWithErrorBeginningInventory = new DataWitOptienceDataModel<OptienceCriteriaModel, ValidateBeginningInventoryModel>();
            long? logIdProductionVolume = null;
            var mappingInputWithErrorProductionVolume = new DataWitOptienceDataModel<OptienceCriteriaModel, ValidateProductionVolumeModel>();

            #region data Result

            var feedPurchaseData = new List<ValidateFeedPurchaseModel>();
            var feedConsumptiondata = new List<ValidateFeedConsumptionModel>();
            var beginningInventoryData = new List<ValidateBeginningInventoryModel>();
            var productionVolumeData = new List<ValidateProductionVolumeModel>();

            #endregion data Result

            if (param.FeedPurchaseData?.Count >= 1)
            {
                #region Create Validate Model & Set Id (RowNo)

                int row = 0;
                var validateModels = new List<ValidateFeedPurchaseModel>();
                param.FeedPurchaseData.ForEach(i =>
                {
                    row++;
                    i.Id = row;
                    i.ErrorMsg = new List<string>();

                    var convertErrorList = new List<string>();
                    var convertDataWarningList = new List<string>();
                    var convertModel = i.TryConvertToModel(out convertErrorList);

                    // create model
                    var validateModel = new ValidateFeedPurchaseModel();
                    validateModel.Id = i.Id;
                    validateModel.SetModel(convertModel);
                    validateModel.ErrorMsg.AddRange(convertErrorList);
                    validateModels.Add(validateModel);
                });

                #endregion Create Validate Model & Set Id (RowNo)

                logIdFeedPurchase = param.InterfaceIdFeedPurchase;
                mappingInputWithErrorFeedPurchase.Criteria = param.Criteria;
                mappingInputWithErrorFeedPurchase.Data = validateModels;
                mappingInputWithErrorFeedPurchase.InterfaceId = logIdFeedPurchase;
            }
            if (param.FeedConsumptionData?.Count >= 1)
            {
                #region Create Validate Model & Set Id (RowNo)

                int row = 0;
                var validateModels = new List<ValidateFeedConsumptionModel>();
                param.FeedConsumptionData.ForEach(i =>
                {
                    row++;
                    i.Id = row;
                    i.ErrorMsg = new List<string>();

                    var convertErrorList = new List<string>();
                    var convertDataWarningList = new List<string>();
                    var convertModel = i.TryConvertToModel(out convertErrorList);

                    // create model
                    var validateModel = new ValidateFeedConsumptionModel();
                    validateModel.Id = i.Id;
                    validateModel.SetModel(convertModel);
                    validateModel.ErrorMsg.AddRange(convertErrorList);
                    validateModels.Add(validateModel);
                });

                #endregion Create Validate Model & Set Id (RowNo)

                logIdFeedConsumption = param.InterfaceIdFeedConsumption;
                mappingInputWithErrorFeedConsumption.Criteria = param.Criteria;
                mappingInputWithErrorFeedConsumption.Data = validateModels;
                mappingInputWithErrorFeedConsumption.InterfaceId = logIdFeedConsumption;
            }
            if (param.BeginningInventoryData?.Count >= 1)
            {
                #region Create Validate Model & Set Id (RowNo)

                int row = 0;
                var validateModels = new List<ValidateBeginningInventoryModel>();
                param.BeginningInventoryData.ForEach(i =>
                {
                    row++;
                    i.Id = row;
                    i.ErrorMsg = new List<string>();

                    var convertErrorList = new List<string>();
                    var convertDataWarningList = new List<string>();
                    var convertModel = i.TryConvertToModel(out convertErrorList);

                    // create model
                    var validateModel = new ValidateBeginningInventoryModel();
                    validateModel.Id = i.Id;
                    validateModel.SetModel(convertModel);
                    validateModel.ErrorMsg.AddRange(convertErrorList);
                    validateModels.Add(validateModel);
                });

                #endregion Create Validate Model & Set Id (RowNo)

                logIdBeginningInventory = param.InterfaceIdBeginningInventory;
                mappingInputWithErrorBeginningInventory.Criteria = param.Criteria;
                mappingInputWithErrorBeginningInventory.Data = validateModels;
                mappingInputWithErrorBeginningInventory.InterfaceId = logIdBeginningInventory;
            }
            if (param.ProductionVolumeData?.Count >= 1)
            {
                #region Create Validate Model & Set Id (RowNo)

                int row = 0;
                var validateModels = new List<ValidateProductionVolumeModel>();
                param.ProductionVolumeData.ForEach(i =>
                {
                    row++;
                    i.Id = row;
                    i.ErrorMsg = new List<string>();

                    var convertErrorList = new List<string>();
                    var convertDataWarningList = new List<string>();
                    var convertModel = i.TryConvertToModel(out convertErrorList);

                    // create model
                    var validateModel = new ValidateProductionVolumeModel();
                    validateModel.Id = i.Id;
                    validateModel.SetModel(convertModel);
                    validateModel.ErrorMsg.AddRange(convertErrorList);
                    validateModels.Add(validateModel);
                });

                #endregion Create Validate Model & Set Id (RowNo)

                logIdProductionVolume = param.InterfaceIdProductionVolume;
                mappingInputWithErrorProductionVolume.Criteria = param.Criteria;
                mappingInputWithErrorProductionVolume.Data = validateModels;
                mappingInputWithErrorProductionVolume.InterfaceId = logIdProductionVolume;
            }

            #endregion Log

            try
            {
                var validateResult = _validationService.ValidateOptience(param);
                if (validateResult.FeedConsumptionData.Any(a => a.ErrorMsg.Count > 0)
                    || validateResult.FeedPurchaseData.Any(a => a.ErrorMsg.Count > 0)
                    || validateResult.ProductionVolumeData.Any(a => a.ErrorMsg.Count > 0)
                    || validateResult.BeginningInventoryData.Any(a => a.ErrorMsg.Count > 0))
                {
                    res = new ResponseModel()
                    {
                        Data = validateResult,
                        Error = "Validate Data Error",
                        IsSuccess = false,
                    };

                    #region Set Data

                    feedPurchaseData = validateResult.FeedPurchaseData;
                    feedConsumptiondata = validateResult.FeedConsumptionData;
                    beginningInventoryData = validateResult.BeginningInventoryData;
                    productionVolumeData = validateResult.ProductionVolumeData;

                    #endregion Set Data

                    #region Set Custom msg

                    if (validateResult.FeedPurchaseData.Any(a => a.ErrorMsg.Count > 0))
                    {
                        #region create custom_msg log

                        int index = 0;
                        mappingInputWithErrorFeedPurchase.Data.ForEach(item =>
                        {
                            int row = index + 1;

                            item.ErrorMsg = new List<string>();
                            var output_row = validateResult.FeedPurchaseData.FirstOrDefault(f => f.Id == row);
                            if (output_row?.ErrorMsg?.Any() ?? false)
                            {
                                // Set Error Msg By Validate ErrorMsg
                                item.ErrorMsg = output_row.ErrorMsg;
                            }

                            index++;
                        });

                        #endregion create custom_msg log
                    }
                    if (validateResult.FeedConsumptionData.Any(a => a.ErrorMsg.Count > 0))
                    {
                        #region create custom_msg log

                        int index = 0;
                        mappingInputWithErrorFeedConsumption.Data.ForEach(item =>
                        {
                            int row = index + 1;

                            item.ErrorMsg = new List<string>();
                            var output_row = validateResult.FeedConsumptionData.FirstOrDefault(f => f.Id == row);
                            if (output_row?.ErrorMsg?.Any() ?? false)
                            {
                                // Set Error Msg By Validate ErrorMsg
                                item.ErrorMsg = output_row.ErrorMsg;
                            }

                            index++;
                        });

                        #endregion create custom_msg log
                    }
                    if (validateResult.BeginningInventoryData.Any(a => a.ErrorMsg.Count > 0))
                    {
                        #region create custom_msg log

                        int index = 0;
                        mappingInputWithErrorBeginningInventory.Data.ForEach(item =>
                        {
                            int row = index + 1;

                            item.ErrorMsg = new List<string>();
                            var output_row = validateResult.BeginningInventoryData.FirstOrDefault(f => f.Id == row);
                            if (output_row?.ErrorMsg?.Any() ?? false)
                            {
                                // Set Error Msg By Validate ErrorMsg
                                item.ErrorMsg = output_row.ErrorMsg;
                            }

                            index++;
                        });

                        #endregion create custom_msg log
                    }
                    if (validateResult.ProductionVolumeData.Any(a => a.ErrorMsg.Count > 0))
                    {
                        #region create custom_msg log

                        int index = 0;
                        mappingInputWithErrorProductionVolume.Data.ForEach(item =>
                        {
                            int row = index + 1;

                            item.ErrorMsg = new List<string>();
                            var output_row = validateResult.ProductionVolumeData.FirstOrDefault(f => f.Id == row);
                            if (output_row?.ErrorMsg?.Any() ?? false)
                            {
                                // Set Error Msg By Validate ErrorMsg
                                item.ErrorMsg = output_row.ErrorMsg;
                            }

                            index++;
                        });

                        #endregion create custom_msg log
                    }

                    #endregion Set Custom msg

                    return new OkObjectResult(res);
                }

                int total;
                res.Data = _optienceService.UploadOptience(param, out total);
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
                    var logId = _logService.UpdateLog(logIdFeedPurchase.Value, Request.Path.Value + "FeedPurchase", JsonConvert.SerializeObject(res), APPCONSTANT.HISTORY_MBR_TYPE.FEED_PURCHASE, param.Criteria.Scenario, param.Criteria.Cycle, param.Criteria.Case);

                    // Log Error
                    _logService.LogError(logIdFeedPurchase.Value, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithErrorFeedPurchase));
                }
                if (logIdFeedConsumption != null)
                {
                    var logId = _logService.UpdateLog(logIdFeedConsumption.Value, Request.Path.Value + "FeedConsumption", JsonConvert.SerializeObject(res), APPCONSTANT.HISTORY_MBR_TYPE.FEED_CONSUMPTION, param.Criteria.Scenario, param.Criteria.Cycle, param.Criteria.Case);

                    // Log Error
                    _logService.LogError(logIdFeedConsumption.Value, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithErrorFeedConsumption));
                }
                if (logIdBeginningInventory != null)
                {
                    var logId = _logService.UpdateLog(logIdBeginningInventory.Value, Request.Path.Value + "BeginningInventory", JsonConvert.SerializeObject(res), APPCONSTANT.HISTORY_MBR_TYPE.BEGINNING_INVENTORY, param.Criteria.Scenario, param.Criteria.Cycle, param.Criteria.Case);

                    // Log Error
                    _logService.LogError(logIdBeginningInventory.Value, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithErrorBeginningInventory));
                }
                if (logIdProductionVolume != null)
                {
                    var logId = _logService.UpdateLog(logIdProductionVolume.Value, Request.Path.Value + "ProductionVolume", JsonConvert.SerializeObject(res), APPCONSTANT.HISTORY_MBR_TYPE.PRODUCTION_VOLUME, param.Criteria.Scenario, param.Criteria.Cycle, param.Criteria.Case);

                    // Log Error
                    _logService.LogError(logIdProductionVolume.Value, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithErrorProductionVolume));
                }

                #endregion Set Log Error

                return new BadRequestObjectResult(res);
            }

            #region Set Log Success

            if (logIdFeedPurchase != null)
            {
                var result = new ResponseModel()
                {
                    Data = feedPurchaseData,
                    IsSuccess = true,
                };
                var logId = _logService.UpdateLog(logIdFeedPurchase.Value, Request.Path.Value + "FeedPurchase", JsonConvert.SerializeObject(result), APPCONSTANT.HISTORY_MBR_TYPE.FEED_PURCHASE, param.Criteria.Scenario, param.Criteria.Cycle, param.Criteria.Case);

                // Log Success
                _logService.LogSuccessPassValidate(logIdFeedPurchase.Value, JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(mappingInputWithErrorFeedPurchase));
            }
            if (logIdFeedConsumption != null)
            {
                var result = new ResponseModel()
                {
                    Data = feedConsumptiondata,
                    IsSuccess = true,
                };
                var logId = _logService.UpdateLog(logIdFeedConsumption.Value, Request.Path.Value + "FeedConsumption", JsonConvert.SerializeObject(result), APPCONSTANT.HISTORY_MBR_TYPE.FEED_CONSUMPTION, param.Criteria.Scenario, param.Criteria.Cycle, param.Criteria.Case);

                // Log Success
                _logService.LogSuccessPassValidate(logIdFeedConsumption.Value, JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(mappingInputWithErrorFeedConsumption));
            }
            if (logIdBeginningInventory != null)
            {
                var result = new ResponseModel()
                {
                    Data = beginningInventoryData,
                    IsSuccess = true,
                };
                var logId = _logService.UpdateLog(logIdBeginningInventory.Value, Request.Path.Value + "BeginningInventory", JsonConvert.SerializeObject(result), APPCONSTANT.HISTORY_MBR_TYPE.BEGINNING_INVENTORY, param.Criteria.Scenario, param.Criteria.Cycle, param.Criteria.Case);

                // Log Success
                _logService.LogSuccessPassValidate(logIdBeginningInventory.Value, JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(mappingInputWithErrorBeginningInventory));
            }
            if (logIdProductionVolume != null)
            {
                var result = new ResponseModel()
                {
                    Data = productionVolumeData,
                    IsSuccess = true,
                };
                var logId = _logService.UpdateLog(logIdProductionVolume.Value, Request.Path.Value + "ProductionVolume", JsonConvert.SerializeObject(result), APPCONSTANT.HISTORY_MBR_TYPE.PRODUCTION_VOLUME, param.Criteria.Scenario, param.Criteria.Cycle, param.Criteria.Case);

                // Log Success
                _logService.LogSuccessPassValidate(logIdProductionVolume.Value, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithErrorProductionVolume));
            }

            #endregion Set Log Success

            return new OkObjectResult(res);
        }

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult PreviewOptience([FromBody] DataWitOptienceModel<OptienceCriteriaModel> param)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                var validateResult = _validationService.ValidateOptience(param);
                if (validateResult.FeedConsumptionData.Any(a => a.ErrorMsg.Count > 0)
                   || validateResult.FeedPurchaseData.Any(a => a.ErrorMsg.Count > 0)
                   || validateResult.ProductionVolumeData.Any(a => a.ErrorMsg.Count > 0)
                   || validateResult.BeginningInventoryData.Any(a => a.ErrorMsg.Count > 0))
                {
                    res = new ResponseModel()
                    {
                        Data = validateResult,
                        Error = "Validate Data Error",
                        IsSuccess = false,
                    };
                    return new OkObjectResult(res);
                }

                res.Data = _optienceService.PreviewOptience(param);
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