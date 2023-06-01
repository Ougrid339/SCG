using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Sales;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.FeedInfo;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.FeedInfo.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Logging.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Sales.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services.Validation.Interface;

namespace SCG.CHEM.MBR.TRANSACTION.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class CopySalesController : ControllerBase
    {
        #region Inject

        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;
        private readonly ICopySalesService _copySalesService;
        private readonly IValidateTransationService _validationService;
        private readonly ILogService _logService;

        public CopySalesController(AppSettings appSetting, ICopySalesService copySalesService, IValidateTransationService validationService, ILogService logService)
        {
            _appSetting = appSetting;
            _copySalesService = copySalesService;
            _validationService = validationService;
            _logService = logService;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public async Task<IActionResult> CopySales([FromBody] SalesCopyRequest data)
        {
            ResponseModel res = new ResponseModel();

            List<MBR_TMP_SALES_VOLUME> dataCopy;
            var check = _copySalesService.CheckExistData(data);
            var logId = _logService.CreateLog(Request.Path.Value, JsonConvert.SerializeObject(data), APPCONSTANT.HISTORY_MBR_TYPE.SALE_VOLUME, data.PlaneTypeTo, data.CycleTo, data.CaseTo);

            try
            {
                var result = await _copySalesService.CopySales(data);
                if (result != null)
                {
                    dataCopy = result.Item3;
                    res.Total = result.Item2;
                    res.Data = result.Item1;
                    res.IsSuccess = true;

                    #region Create Validate Model & Set Id (RowNo)

                    var validateModels = new List<ValidateSalesModel>();
                    var dataGroup = dataCopy?.GroupBy(g => new { g.PlanType, g.Case, g.Cycle, g.Company, g.MCSC, g.Channel, g.Customers, g.FormulaName, g.PriceSet, g.Product, g.TermSpot }).ToList();
                    var lst = new List<ValidateSalesModel>();
                    foreach (var item in dataGroup)
                    {
                        lst.Add(new ValidateSalesModel
                        {
                            Adj1 = item?.FirstOrDefault()?.Adj1.ToString() ?? "",
                            Adj2 = item?.FirstOrDefault()?.Adj2.ToString() ?? "",
                            Adj3 = item?.FirstOrDefault()?.Adj3.ToString() ?? "",
                            Adj4 = item?.FirstOrDefault()?.Adj4.ToString() ?? "",
                            Adj5 = item?.FirstOrDefault()?.Adj5.ToString() ?? "",
                            Alpha1 = item?.FirstOrDefault()?.Alpha1.ToString() ?? "",
                            Alpha2 = item?.FirstOrDefault()?.Alpha2.ToString() ?? "",
                            BD = item?.FirstOrDefault()?.BD.ToString() ?? "",
                            Channel = item?.Key.Channel ?? "",
                            Company = item?.Key.Company ?? "",
                            MCSC = item?.Key.MCSC ?? "",
                            ContractNo = item?.FirstOrDefault()?.ContractNo ?? "",
                            Countries = item?.FirstOrDefault()?.Countries ?? "",
                            CountryPort = item?.FirstOrDefault()?.CountryPort ?? "",
                            Customers = item?.Key.Customers ?? "",
                            Den = item?.FirstOrDefault()?.Den.ToString() ?? "",
                            FinalPrice = item?.FirstOrDefault()?.FinalPrice?.ToString() ?? "",
                            Formula = item?.FirstOrDefault()?.Formula?.ToString() ?? "",
                            FormulaName = item?.Key.FormulaName ?? "",
                            HedgingGainLoss = item?.FirstOrDefault()?.HedgingGainLoss?.ToString() ?? "",
                            IB = item?.FirstOrDefault()?.IB.ToString() ?? "",
                            Margin = item?.FirstOrDefault()?.Margin,
                            MonthIndex = item?.FirstOrDefault()?.MonthIndex?.ToString() ?? "",
                            PaymentCondition = item?.FirstOrDefault()?.PaymentCondition ?? "",
                            Premium = item?.FirstOrDefault()?.Premium.ToString() ?? "",
                            PriceSet = item?.FirstOrDefault()?.PriceSet?.ToString() ?? "",
                            Product = item?.Key.Product ?? "",
                            ReEXP = item?.FirstOrDefault()?.ReEXP ?? "",
                            Remark = item?.FirstOrDefault()?.Remark ?? "",
                            TermSpot = item?.Key.TermSpot ?? "",
                            TransportationMode = item?.FirstOrDefault()?.TransportationMode ?? "",
                            VesselOrderNo = item?.FirstOrDefault()?.VesselOrderNo ?? "",
                            VolTons = item?.FirstOrDefault()?.VolTons.ToString() ?? "",
                        });
                    }

                    #endregion Create Validate Model & Set Id (RowNo)

                    var mappingInputWithError = new DataWitSalesModel<SalesCopyRequest, ValidateSalesModel>();
                    mappingInputWithError.Criteria = data;
                    mappingInputWithError.Data = lst;
                    // Log Success
                    _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(mappingInputWithError));
                }
                else
                {
                    throw new Exception("Error occured in CopySales.");
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
                // Log Error
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(res));

                return new BadRequestObjectResult(res);
            }
            return new OkObjectResult(res);
        }

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public async Task<IActionResult> PreviewCopySales([FromBody] SalesCopyRequest data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                res.Data = await _copySalesService.PreviewCopySales(data);
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