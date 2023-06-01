using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Sales;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Validation;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services.Validation.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Validation.Interface;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Validation
{
    public class ValidateSalesService : IValidateSalesService
    {
        private readonly UnitOfWork _unit;
        private readonly SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork _unitSSP;
        private readonly string userLogin;
        private readonly IValidateShareService _validateShareService;

        public ValidateSalesService(UnitOfWork unitOfWork, SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork unitSSP, IValidateShareService validateShareService)
        {
            this._unit = unitOfWork;
            this._unitSSP = unitSSP;
            this.userLogin = UserUtilities.GetADAccount()?.UserId ?? "";
            _validateShareService = validateShareService;
        }
        public DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel> ValidateSales(DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel> param)
        {
            var result = new DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel>();

            #region Set Id (RowNo) for dataValidates List

            // Set RowId (Row No)
            int row = 0;
            param.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
            });

            #endregion Set Id (RowNo) for dataValidates List

            #region Create Validate Model & Set Id (RowNo)

            var validateModels = new List<ValidateSalesModel>();
            var dataWarnningModels = new List<ValidateSalesModel>();
            List<MBR_TRN_SALES_VOLUME> marketPriceForecastExistingData = new List<MBR_TRN_SALES_VOLUME>();

            var containCompany = _unitSSP.MasterCompanyRepo.GetByShortName(param.Data.Select(s => s.Company).ToList());
            var containProductMapping = _unit.MasterProductMappingRepo.GetProductShortName(param.Data.Select(s => s.Product).ToList());
            var containFormulaName = _unit.MasterFormulaParameterMappingRepo.GetMasterFormulaParameterByFormulaName(param.Data.Select(s => s.FormulaName).ToList());
            var containBusinessPartner = _unitSSP.FCTBusinessPartnerRepo.GetByShortnamepriceweb(param.Data.Select(s => s.Customers).ToList());
            var containCountries = _unitSSP.MasterCountryMasterRepo.GetByCountryCode(param.Data.Select(s => s.Countries).ToList());


            List<MBR_TRN_SALES_VOLUME> SalesExistingData = new List<MBR_TRN_SALES_VOLUME>();

            if (param.Criteria.isMerge && param.Criteria.MergePlaneType != null && param.Criteria.MergeCase != null && param.Criteria.MergeCycle != null)
                SalesExistingData = _unit.SalesVoiumeRepo.FindByCriteria(param.Criteria.MergePlaneType, param.Criteria.MergeCase, param.Criteria.MergeCycle);

            param.Data.ForEach(i =>
            {


                row++;
                List<MBR_TRN_SALES_VOLUME> existingData = null;
                if (SalesExistingData != null)
                    existingData = SalesExistingData.Where(f => f.Company.ToLower() == i.Company.ToLower()
                                                                && f.MCSC.ToLower() == i.MCSC.ToLower()
                                                                && f.Product.ToLower() == i.Product.ToLower()
                                                                && f.Channel.ToLower() == i.Channel.ToLower()
                                                                && f.FormulaName.ToLower() == i.FormulaName.ToLower()
                                                                && f.Customers.ToLower() == i.Customers.ToLower()
                                                                && f.TermSpot.ToLower() == i.TermSpot.ToLower()
                                                                && f.PriceSet.ToLower() == i.PriceSet.ToLower()).ToList();
                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToSalesModel(existingData, containProductMapping, containCompany, containFormulaName, containBusinessPartner, containCountries, param.Criteria.isMerge, out convertErrorList, out convertDataWarningList);

                List<ValidateDecimalConfiguration> config = new()
                {
                    new ValidateDecimalConfiguration(nameof(i.HedgingGainLoss)),
                    new ValidateDecimalConfiguration(nameof(i.Alpha1)),
                    new ValidateDecimalConfiguration(nameof(i.Alpha2)),
                    new ValidateDecimalConfiguration(nameof(i.Premium)),
                    new ValidateDecimalConfiguration(nameof(i.BD)),
                    new ValidateDecimalConfiguration(nameof(i.IB)),
                    new ValidateDecimalConfiguration(nameof(i.Adj1)),
                    new ValidateDecimalConfiguration(nameof(i.Adj2)),
                    new ValidateDecimalConfiguration(nameof(i.Adj3)),
                    new ValidateDecimalConfiguration(nameof(i.Adj4)),
                    new ValidateDecimalConfiguration(nameof(i.Adj5)),
                    new ValidateDecimalConfiguration(nameof(i.Den))
                };

                convertErrorList?.AddRange(_validateShareService.ValidateDecimal(i, config));

                // create model
                var validateModel = new ValidateSalesModel();
                var dataWarnningModel = new ValidateSalesModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateModels.Add(validateModel);

                dataWarnningModel.Id = i.Id;
                dataWarnningModel.SetModel(convertModel);
                dataWarnningModel.ErrorMsg.AddRange(convertDataWarningList);
                dataWarnningModels.Add(dataWarnningModel);
            });


            #endregion Create Validate Model & Set Id (RowNo)


            // set error msg
            param.Data.ForEach(i =>
            {
                bool isError = false;
                bool isWarnning = false;
                //bool isOutError = false;
                //List<string> errorMsg;
                var error = new ValidateSalesModel(i);
                var errorDataWarnning = new ValidateSalesModel(i);


                // Set Error Convert Data
                var checkConvertData = validateModels.Where(w => w.Id == i.Id && w.ErrorMsg.Count > 0);
                var checkDataWarnning = dataWarnningModels.Where(w => w.Id == i.Id && w.ErrorMsg.Count > 0);

                if (checkConvertData.Any())
                {
                    isError = true;

                    var checkData = checkConvertData.FirstOrDefault();
                    error.ErrorMsg.AddRange(checkData.ErrorMsg);

                }

                if (checkDataWarnning.Any())
                {
                    isWarnning = true;
                    var checkData = checkDataWarnning.FirstOrDefault();
                    errorDataWarnning.ErrorMsg.AddRange(checkData.ErrorMsg);
                }

                if (isError)
                    result.Data.Add(error);

                if (isWarnning)
                    result.DataWarnning.Add(errorDataWarnning);
            });

            return result;
        }
    }
}
