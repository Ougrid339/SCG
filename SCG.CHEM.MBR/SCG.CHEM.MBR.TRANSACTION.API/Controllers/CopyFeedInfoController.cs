using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.FeedInfo.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Logging.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services.Validation.Interface;

namespace SCG.CHEM.MBR.TRANSACTION.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class CopyFeedInfoController : ControllerBase
    {
        #region Inject

        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;
        private readonly ICopyFeedInfoService _copyFeedInfoService;
        private readonly IValidateTransationService _validationService;
        private readonly ILogService _logService;

        public CopyFeedInfoController(AppSettings appSetting, ICopyFeedInfoService copyFeedInfoService, IValidateTransationService validationService, ILogService logService)
        {
            _appSetting = appSetting;
            _copyFeedInfoService = copyFeedInfoService;
            _validationService = validationService;
            _logService = logService;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult CopyFeedInfo([FromBody] FeedInfoCopyRequest data)
        {
            ResponseModel res = new ResponseModel();

            List<MRB_TMP_FEED_INFO> dataCopy;
            var check = _copyFeedInfoService.CheckExistData(data);
            var logId = _logService.CreateLog(Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.FEED_DATA, data.PlaneTypeTo, data.CycleTo, data.CaseTo);

            try
            {
                int total;
                res.Data = _copyFeedInfoService.CopyFeedInfo(data, out total, out dataCopy);
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

            var validateModels = new List<ValidateFeedInfoModel>();
            var lst = new List<ValidateFeedInfoModel>();

            foreach (var item in dataCopy ?? new List<MRB_TMP_FEED_INFO>())
            {
                lst.Add(new ValidateFeedInfoModel
                {
                    BuyerRightKey = item.BuyerRightKey,
                    Company = item.Company,
                    ContractSpot = item.ContractSpot,
                    FeedGeoCategoryKey = item.FeedGeoCategoryKey,
                    FeedNameKey = item.FeedNameKey,
                    GITStatus = item.GITStatus,
                    HedgingGainLoss = item.HedgingGainLoss?.ToString() ?? "",
                    Insurance = item.Insurance?.ToString() ?? "",
                    Margin = item.Margin?.ToString() ?? "",
                    MaterialCode = item.MaterialCode,
                    MCSC = item.MCSC,
                    MonthStatus = item.MonthIndex,
                    OriginKey = item.OriginKey,
                    PricingIndexKey = item.PricingIndexKey,
                    PricingRefKey = item.PricingRefKey,
                    PurchasingPremium = item.PurchasingPremium?.ToString() ?? "",
                    PurchasingVolume = item.PurchasingVolume?.ToString() ?? "",
                    RefNo = item.RefNo,
                    SupplierKey = item.SupplierKey,
                    Surveyor = item.Surveyor?.ToString() ?? "",
                    TR = item.TR?.ToString() ?? "",
                    TransportationKey = item.TransportationKey,
                    SupplierCode = item.SupplierCode,
                });
            }

            #endregion Create Validate Model & Set Id (RowNo)

            var mappingInputWithError = new DataWithFeedInfoModel<FeedInfoCopyRequest, ValidateFeedInfoModel>();
            mappingInputWithError.Criteria = data;
            mappingInputWithError.Data = lst;
            // Log Success
            _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithError));
            return new OkObjectResult(res);
        }

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult PreviewCopyFeedInfo([FromBody] FeedInfoCopyRequest data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                res.Data = _copyFeedInfoService.PreviewCopyFeedInfo(data);
                res.Status = 200;
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