using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.CONSTRAINT.API.BusinessLogic;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Validation;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services.Validation.Interface;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services.Validation
{
    public sealed class ValidateTransationService : IValidateTransationService
    {
        private readonly UnitOfWork _unit;
        private readonly SCG.CHEM.SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork _unitLSP;

        private readonly IValidateShareService _validateShareService;

        public ValidateTransationService(UnitOfWork unitOfWork, IValidateShareService validateShareService, SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork unitLSP)
        {
            this._unit = unitOfWork;
            this._validateShareService = validateShareService;
            this._unitLSP = unitLSP;
        }

        public DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel> ValidateMarketPriceForecast(DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel> data)
        {
            var result = new DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel>();

            #region Set Id (RowNo) for dataValidates List

            // Set RowId (Row No)
            int row = 0;
            data.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
            });

            #endregion Set Id (RowNo) for dataValidates List

            #region Create Validate Model & Set Id (RowNo)

            var validateModels = new List<ValidateMarketPriceForecastModel>();
            var dataWarnningModels = new List<ValidateMarketPriceForecastModel>();
            List<MBR_TRN_MARKET_PRICE_FORECAST> marketPriceForecastExistingData = new List<MBR_TRN_MARKET_PRICE_FORECAST>();
            var isZero = _unit.MasterMaintainPriceRepo.GetByMaintainId(MASTER_EXCEL_TYPE.MARKET_PRICE_FORCASET)?.IsZero ?? false;
            var containMarketPriceMapping = _unit.MasterMarketPriceMappingRepo.GetMarketPriceNameByMarketPriceMI(data.Data.Select(s => s.MarketSource).ToList());
            if (data.Criteria.isMerge && data.Criteria.MergeScenario != null && data.Criteria.MergeCase != null && data.Criteria.MergeCycle != null)
                marketPriceForecastExistingData = _unit.MarketPriceForecastRepo.FindByCriteria(data.Criteria.MergeScenario, data.Criteria.MergeCase, data.Criteria.MergeCycle);
            data.Data.ForEach(i =>
            {
                row++;
                List<MBR_TRN_MARKET_PRICE_FORECAST> existingDatas = null;
                if (marketPriceForecastExistingData != null)
                    existingDatas = marketPriceForecastExistingData.Where(f => f.MarketSource.ToLower() == i.MarketSource.ToLower()).ToList();
                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToModel(existingDatas, containMarketPriceMapping, data.Criteria.isMerge, isZero, out convertErrorList, out convertDataWarningList);

                // create model
                var validateModel = new ValidateMarketPriceForecastModel();
                var dataWarnningModel = new ValidateMarketPriceForecastModel();
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
            data.Data.ForEach(i =>
            {
                bool isError = false;
                bool isWarnning = false;
                bool isOutError = false;
                List<string> errorMsg;
                var error = new ValidateMarketPriceForecastModel(i);
                var errorDataWarnning = new ValidateMarketPriceForecastModel(i);

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