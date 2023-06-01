using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Optience;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Validation.Interface;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Validation
{
    public class ValidateFeedInfoService : IValidateFeedInfoService
    {
        private readonly UnitOfWork _unit;
        private readonly SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork _unitSSP;

        public ValidateFeedInfoService(UnitOfWork unitOfWork, SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork unitSSP)
        {
            this._unit = unitOfWork;
            this._unitSSP = unitSSP;
        }

        public DataWithFeedInfoModel<FeedInfoCriteriaModel, ValidateFeedInfoModel> ValidateFeedInfo(DataWithFeedInfoModel<FeedInfoCriteriaModel, ValidateFeedInfoModel> data)
        {
            var result = new DataWithFeedInfoModel<FeedInfoCriteriaModel, ValidateFeedInfoModel>();

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

            var validateModels = new List<ValidateFeedInfoModel>();
            var dataWarnningModels = new List<ValidateFeedInfoModel>();
            List<MRB_TRN_FEED_INFO> FeedInfoExistingData = new List<MRB_TRN_FEED_INFO>();
            var containCompany = _unitSSP.MasterCompanyRepo.GetByShortName(data.Data.Select(s => s.Company).ToList());
            var containProductMapping = _unit.MasterProductMappingRepo.GetMaterialCode(data.Data.Select(s => s.MaterialCode).ToList());
            var contaiCustomerVendorMapping = _unit.MasterCustomerVendorMappingRepo.GetCustomerShortName(data.Data.Select(s => s.SupplierKey).ToList());
            var containMarketPriceMapping = _unit.MasterMarketPriceMappingRepo.GetMarketPriceMIs(data.Data.Select(s => s.PricingIndexKey).ToList());

            if (data.Criteria.isMerge && data.Criteria.MergePlaneType != null && data.Criteria.MergeCase != null && data.Criteria.MergeCycle != null)
                FeedInfoExistingData = _unit.FeedInfoRepo.FindByCriteriasAll(data.Criteria.MergePlaneType, data.Criteria.MergeCase, data.Criteria.MergeCycle, data.Criteria.Company, data.Criteria.FeedGeoCategoryKey, data.Criteria.FeedNameKey, data.Criteria.ProductGroup);
            //FeedInfoExistingData = null; //not yet Dev Merge

            data.Data.ForEach(i =>
            {
                row++;
                List<MRB_TRN_FEED_INFO> existingDatas = null;
                if (FeedInfoExistingData != null)
                    existingDatas = FindMatchItem(FeedInfoExistingData, i);
                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToModel(existingDatas, containProductMapping, contaiCustomerVendorMapping, containCompany, containMarketPriceMapping, data.Criteria.ProductGroup, data.Criteria.isMerge, out convertErrorList, out convertDataWarningList);

                // create model
                var validateModel = new ValidateFeedInfoModel();
                var dataWarnningModel = new ValidateFeedInfoModel();
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
                var error = new ValidateFeedInfoModel(i);
                var errorDataWarnning = new ValidateFeedInfoModel(i);

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

        private List<MRB_TRN_FEED_INFO> FindMatchItem(List<MRB_TRN_FEED_INFO> ExistingData, ValidateFeedInfoModel item)
        {
            var result = new List<MRB_TRN_FEED_INFO>();
            result = ExistingData.Where(
                x => x.Company == item.Company
                && x.MCSC == item.MCSC
                && x.MonthIndex == item.MonthStatus
                && x.FeedNameKey == item.FeedNameKey
                && x.FeedGeoCategoryKey == item.FeedGeoCategoryKey
                && x.SupplierKey == item.SupplierKey
                && x.PricingIndexKey == item.PricingIndexKey
                && x.PricingRefKey == item.PricingRefKey
                && x.OriginKey == item.OriginKey
                && x.ContractSpot == item.ContractSpot
                && x.TransportationKey == item.TransportationKey
                && x.BuyerRightKey == item.BuyerRightKey
                //&& x.RefNo == item.RefNo
                //&& x.PurchasingVolume == Decimal.Parse(item.PurchasingVolume ?? "0")
                //&& x.PurchasingPremium == Decimal.Parse(item.PurchasingPremium ?? "0")
                //&& x.HedgingGainLoss == Decimal.Parse(item.HedgingGainLoss ?? "0")
                //&& x.GITStatus == item.GITStatus
                //&& x.Surveyor == Decimal.Parse(item.Surveyor ?? "0")
                //&& x.Insurance == Decimal.Parse(item.Insurance ?? "0")
                //&& x.Margin == Decimal.Parse(item.Margin ?? "0")
                //&& x.TR == Decimal.Parse(item.TR ?? "0")
            ).ToList();

            return result;
        }
    }
}