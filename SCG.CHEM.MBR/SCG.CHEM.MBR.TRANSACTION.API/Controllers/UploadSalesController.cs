using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Sales;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Logging.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Sales.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Validation.Interface;

namespace SCG.CHEM.MBR.TRANSACTION.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class UploadSalesController : ControllerBase
    {
        #region Inject

        private readonly AppSettings _appSetting;

        private readonly IValidateSalesService _validationService;
        private readonly ISalesService _salesService;
        private readonly ILogService _logService;

        public UploadSalesController(AppSettings appSetting, ISalesService salesService, IValidateSalesService validationService, ILogService logService)
        {
            _appSetting = appSetting;
            _validationService = validationService;
            _salesService = salesService;
            _logService = logService;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult ValidateSales([FromBody] DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel> param)
        {
            ResponseModel res = new ResponseModel();

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateSalesModel>();
            param.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();

                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateSalesModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateModels.Add(validateModel);
            });
            var newData = new DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel>();
            newData.Data = validateModels;
            newData.Criteria = param.Criteria;

            #endregion Create Validate Model & Set Id (RowNo)

            var logId = _logService.CreateLog(Request.Path.Value, JsonConvert.SerializeObject(param), APPCONSTANT.HISTORY_MBR_TYPE.SALE_VOLUME, param.Criteria.PlaneType, param.Criteria.Cycle, param.Criteria.Case);
            var mappingInputWithError = newData;
            try
            {
                var validateResult = _validationService.ValidateSales(param);
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
        public async Task<IActionResult> UploadSales([FromBody] DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel> param)
        {
            ResponseModel res = new ResponseModel();

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateSalesModel>();
            param.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();

                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateSalesModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateModels.Add(validateModel);
            });
            var newData = new DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel>();
            newData.Data = validateModels;
            newData.Criteria = param.Criteria;

            #endregion Create Validate Model & Set Id (RowNo)

            var mappingInputWithError = newData;
            try
            {
                var validateResult = _validationService.ValidateSales(param);
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
                    _logService.LogSuccess(param.InterfaceId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithError));
                    return new OkObjectResult(res);
                }

                int total;
                var data = await _salesService.UploadSales(param);
                res.Data = data.Item1;
                res.Total = data.Item2;
                res.IsSuccess = true;
                var logId = _logService.UpdateLog(param.InterfaceId, Request.Path.Value, JsonConvert.SerializeObject(param), APPCONSTANT.HISTORY_MBR_TYPE.SALE_VOLUME, param.Criteria.PlaneType, param.Criteria.Cycle, param.Criteria.Case);

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
                var logId = _logService.UpdateLog(param.InterfaceId, Request.Path.Value, JsonConvert.SerializeObject(param), APPCONSTANT.HISTORY_MBR_TYPE.SALE_VOLUME, param.Criteria.PlaneType, param.Criteria.Cycle, param.Criteria.Case);

                // Log Error
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithError));

                return new BadRequestObjectResult(res);
            }

            return new OkObjectResult(res);
        }

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public async Task<IActionResult> PreviewSales([FromBody] DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel> param)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                var validateResult = _validationService.ValidateSales(param);
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

                var data = await _salesService.PreviewSales(param);
                res.Data = data;
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