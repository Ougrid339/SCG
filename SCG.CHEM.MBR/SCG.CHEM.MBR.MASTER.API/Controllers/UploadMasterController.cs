using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using System.Net;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services.Validation.Interface;
using SCG.CHEM.MBR.MASTER.API.AppModels.Master;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master.Interface;
using Newtonsoft.Json;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Logging.Interface;

namespace SCG.CHEM.MBR.MASTER.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class UploadMasterController : ControllerBase
    {
        #region Inject

        private readonly IValidateMasterService _validationService;
        private readonly IMasterService _masterService;
        private readonly ILogService _logService;
        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;

        public UploadMasterController(UnitOfWork unit, IValidateMasterService validationService, IMasterService masterService, ILogService logService, AppSettings appSetting)
        {
            _unit = unit;
            _validationService = validationService;
            _masterService = masterService;
            _logService = logService;
            _appSetting = appSetting;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult ValidateMasterProductMapping([FromBody] DataWIthInterface<ValidateProductMappingTempModel> data)
        {
            ResponseModel res = new ResponseModel();
            // Create Log

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateProductMappingModel>();
            data.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateProductMappingModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);

                validateModels.Add(validateModel);
            });
            var newData = new DataWIthInterface<ValidateProductMappingModel>();
            newData.Data = validateModels;

            #endregion Create Validate Model & Set Id (RowNo)

            var logId = _logService.CreateLog(Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.PRODUCT_MAPPING, null, null, null);
            var mappingInputWithError = newData;
            try
            {
                var validateResult = _validationService.ValidateMasterProductMapping(data);
                validateResult.InterfaceId = logId;
                res.Data = validateResult;
                res.IsSuccess = true;
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
        public IActionResult UploadMasterProductMapping([FromBody] DataWIthInterface<ValidateProductMappingTempModel> data)
        {
            ResponseModel res = new ResponseModel();
            // Create Log

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateProductMappingModel>();
            data.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateProductMappingModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);

                validateModels.Add(validateModel);
            });
            var newData = new DataWIthInterface<ValidateProductMappingModel>();
            newData.Data = validateModels;

            #endregion Create Validate Model & Set Id (RowNo)

            // Create Log
            var mappingInputWithError = newData;

            try
            {
                var validateResult = _validationService.ValidateMasterProductMapping(data);
                validateResult.InterfaceId = data.InterfaceId;
                if (validateResult.Data.Any(a => a.ErrorMsg.Count > 0))
                {
                    res = new ResponseModel()
                    {
                        Data = validateResult,
                        Error = "Validate Data Error",
                        IsSuccess = false,
                    };

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
                res.Data = _masterService.UploadMasterProductMapping(data, out total);
                res.Total = total;

                res.IsSuccess = true;
                var logId = _logService.UpdateLog(data.InterfaceId, Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.PRODUCT_MAPPING, null, null, null);

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
                var logId = _logService.UpdateLog(data.InterfaceId, Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.PRODUCT_MAPPING, null, null, null);

                // Log Error
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithError));
                return new BadRequestObjectResult(res);
            }

            return new OkObjectResult(res);
        }

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult ValidateMasterCustomerVendorMapping([FromBody] DataWIthInterface<ValidateCustomerVendorMappingTempModel> data)
        {
            ResponseModel res = new ResponseModel();

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateCustomerVendorMappingModel>();
            data.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateCustomerVendorMappingModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);

                validateModels.Add(validateModel);
            });

            var newData = new DataWIthInterface<ValidateCustomerVendorMappingModel>();
            newData.Data = validateModels;

            #endregion Create Validate Model & Set Id (RowNo)

            // Create Log
            var logId = _logService.CreateLog(Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.PRODUCT_MAPPING, null, null, null);
            var mappingInputWithError = newData;

            try
            {
                var validateResult = _validationService.ValidateMasterCustomerVendorMapping(data);
                validateResult.InterfaceId = logId;
                res.Data = validateResult;
                res.IsSuccess = true;

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
        public IActionResult UploadMasterCustomerVendorMapping([FromBody] DataWIthInterface<ValidateCustomerVendorMappingTempModel> data)
        {
            ResponseModel res = new ResponseModel();

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateCustomerVendorMappingModel>();
            data.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateCustomerVendorMappingModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);

                validateModels.Add(validateModel);
            });

            var newData = new DataWIthInterface<ValidateCustomerVendorMappingModel>();
            newData.Data = validateModels;

            #endregion Create Validate Model & Set Id (RowNo)

            // Create Log
            var mappingInputWithError = newData;
            try
            {
                var validateResult = _validationService.ValidateMasterCustomerVendorMapping(data);
                validateResult.InterfaceId = data.InterfaceId;
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
                res.Data = _masterService.UploadMasterCustomerVendorMapping(data, out total);
                res.Total = total;
                res.IsSuccess = true;

                var logId = _logService.UpdateLog(data.InterfaceId, Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.CUSTOMER_VENDOR_MAPPING, null, null, null);

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
                var logId = _logService.UpdateLog(data.InterfaceId, Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.CUSTOMER_VENDOR_MAPPING, null, null, null);

                // Log Error
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithError));

                return new BadRequestObjectResult(res);
            }
            return new OkObjectResult(res);
        }

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult ValidateMasterLSPPriceFormula([FromBody] DataWIthInterface<ValidateLSPPriceFormulaTempModel> data)
        {
            ResponseModel res = new ResponseModel();

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateLSPPriceFormulaModel>();
            data.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateLSPPriceFormulaModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);

                validateModels.Add(validateModel);
            });

            var newData = new DataWIthInterface<ValidateLSPPriceFormulaModel>();
            newData.Data = validateModels;

            #endregion Create Validate Model & Set Id (RowNo)

            // Create Log
            var logId = _logService.CreateLog(Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.LSP_PRICE_FORMULA, null, null, null);
            var mappingInputWithError = newData;
            try
            {
                var validateResult = _validationService.ValidateMasterLSPPriceFormula(data);
                validateResult.InterfaceId = logId;
                res.Data = validateResult;
                res.IsSuccess = true;

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
        public IActionResult UploadMasterLSPPriceFormula([FromBody] DataWIthInterface<ValidateLSPPriceFormulaTempModel> data)
        {
            ResponseModel res = new ResponseModel();

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateLSPPriceFormulaModel>();
            data.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateLSPPriceFormulaModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);

                validateModels.Add(validateModel);
            });

            var newData = new DataWIthInterface<ValidateLSPPriceFormulaModel>();
            newData.Data = validateModels;

            #endregion Create Validate Model & Set Id (RowNo)

            // Create Log
            var mappingInputWithError = newData;
            try
            {
                var validateResult = _validationService.ValidateMasterLSPPriceFormula(data);
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
                res.Data = _masterService.UploadMasterLSPPriceFormula(data, out total);
                res.Total = total;
                res.IsSuccess = true;
                var logId = _logService.UpdateLog(data.InterfaceId, Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.LSP_PRICE_FORMULA, null, null, null);

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

                var logId = _logService.UpdateLog(data.InterfaceId, Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.CUSTOMER_VENDOR_MAPPING, null, null, null);

                // Log Error
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithError));
                return new BadRequestObjectResult(res);
            }

            return new OkObjectResult(res);
        }

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult ValidateMasterMarketPriceMapping([FromBody] DataWIthInterface<ValidateMarketPriceMappingTempModel> data)
        {
            ResponseModel res = new ResponseModel();

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateMarketPriceMappingModel>();
            data.Data.ForEach(i =>
            {
                row++;

                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateMarketPriceMappingModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);

                validateModels.Add(validateModel);
            });
            var newData = new DataWIthInterface<ValidateMarketPriceMappingModel>();
            newData.Data = validateModels;

            #endregion Create Validate Model & Set Id (RowNo)

            // Create Log
            var logId = _logService.CreateLog(Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.MARKET_PRICE_MAPPING, null, null, null);
            var mappingInputWithError = newData;
            try
            {
                var validateResult = _validationService.ValidateMasterMarketPriceMapping(data);
                validateResult.InterfaceId = logId;
                res.Data = validateResult;
                res.IsSuccess = true;
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
        public IActionResult UploadMasterMarketPriceMapping([FromBody] DataWIthInterface<ValidateMarketPriceMappingTempModel> data)
        {
            ResponseModel res = new ResponseModel();

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateMarketPriceMappingModel>();
            data.Data.ForEach(i =>
            {
                row++;

                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateMarketPriceMappingModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);

                validateModels.Add(validateModel);
            });
            var newData = new DataWIthInterface<ValidateMarketPriceMappingModel>();
            newData.Data = validateModels;

            #endregion Create Validate Model & Set Id (RowNo)

            // Create Log
            var mappingInputWithError = newData;
            try
            {
                var validateResult = _validationService.ValidateMasterMarketPriceMapping(data);
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
                res.Data = _masterService.UploadMasterMarketPriceMapping(data, out total);
                res.Total = total;
                res.IsSuccess = true;
                var logId = _logService.UpdateLog(data.InterfaceId, Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.MARKET_PRICE_MAPPING, null, null, null);

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
                var logId = _logService.UpdateLog(data.InterfaceId, Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.MARKET_PRICE_MAPPING, null, null, null);

                // Log Error
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithError));
                return new BadRequestObjectResult(res);
            }

            return new OkObjectResult(res);
        }
    }
}