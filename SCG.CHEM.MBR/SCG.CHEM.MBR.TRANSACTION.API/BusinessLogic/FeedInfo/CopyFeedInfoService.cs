using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.DataFactory;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Datafacetory.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.FeedInfo.Interface;
using System.Globalization;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.FeedInfo
{
    public class CopyFeedInfoService : ICopyFeedInfoService
    {
        private readonly UnitOfWork _unit;
        private readonly string userLogin;
        private readonly IDataFactoryService _dataFactoryService;

        public CopyFeedInfoService(UnitOfWork unitOfWork, IDataFactoryService dataFactoryService)
        {
            this._unit = unitOfWork;
            this.userLogin = UserUtilities.GetADAccount()?.UserId ?? "";
            this._dataFactoryService = dataFactoryService;
        }

        public string CallDataFactory(string tableName, string transactionName, RequestCriteriaTransaction criteria, string submitStatus, bool isMerge = false)
        {
            string userName = UserUtilities.GetADAccount()?.UserId ?? "";
            string res = _dataFactoryService.RunPipelineMultiCriteria(tableName, transactionName, criteria, userName, submitStatus, isMerge);

            return res;
        }

        private List<MRB_TMP_FEED_INFO> CopyFeedInfoCenter(FeedInfoCopyRequest param, out int total, out string runId)
        {
            total = 0;
            var feedInfoFromRepo = _unit.FeedInfoRepo.FindByCriteriasAll(param.PlaneTypeFrom, param.CaseFrom, param.CycleFrom, param.CompanyFrom, param.FeedGeoCategoryKeyFrom, param.FeedNameKeyFrom, param.ProductGroupFrom);
            var feedRepo = _unit.FeedInfoTempRepo.FindByCriteriasAll(param.PlaneTypeTo, param.CaseTo, param.CycleTo, param.CompanyFrom, param.FeedGeoCategoryKeyFrom, param.FeedNameKeyFrom, param.ProductGroupFrom);

            var addFeedDataList = new List<MRB_TMP_FEED_INFO>();
            var feedDataList = new List<MRB_TMP_FEED_INFO>();
            var feedList = new List<MRB_TRN_FEED_INFO>();

            if (feedInfoFromRepo.Count <= 0)
            {
                throw new Exception("No feed info based on your selected criteria.");
            }
            foreach (var item in feedInfoFromRepo)
            {
                //add
                var bind = BindFeedInfoTempModelToDB(new FeedInfoCriteriaModel()
                {
                    Case = param.CaseTo,
                    Cycle = param.CycleTo,
                    PlaneType = param.PlaneTypeTo
                }, item, item.ProductGroup, item.Price ?? 0);

                bind.CopiedFromCycle = param.CycleFrom;
                bind.CopiedFromPlanType = param.PlaneTypeFrom;
                bind.CopiedFromCase = param.CaseFrom;
                addFeedDataList.Add(bind);
                feedDataList.Add(bind);
            }

            #region Call API

            var criteria = new RequestCriteriaTransaction();
            criteria.PlaneType = param.PlaneTypeTo;
            criteria.Case = param.CaseTo;
            criteria.Cycle = param.CycleTo;
            criteria.Company = String.Join(",", param.CompanyFrom);
            criteria.FeedGeoCategoryKey = String.Join(",", param.FeedGeoCategoryKeyFrom);
            criteria.FeedNameKey = String.Join(",", param.FeedNameKeyFrom);
            criteria.ProductGroup = String.Join(",", param.ProductGroupFrom);
            runId = CallDataFactory("MBR_TMP_FeedInfo", "FeedInfo", criteria, APPCONSTANT.SUBMIT_STATUS.SUBMIT);
            if (runId != "error")
            {
                // insert runId to Database
            }
            else
            {
                throw new Exception("Cannot Run Pipeline");
            }

            #endregion Call API

            foreach (var item in feedDataList)
            {
                item.RunId = runId;
            }
            if (addFeedDataList != null && addFeedDataList.Count > 0)
                _unit.FeedInfoTempRepo.Add(addFeedDataList);

            #region Del Fail DWH Data Temp

            var dataFactDWHFail = _unit.DataFactoryRunRepo.GetDWHFail("FeedInfo")?.Select(s => s.RunId).ToList();
            if (dataFactDWHFail != null && dataFactDWHFail.Count >= 1)
            {
                var delFailDWH = feedRepo.Where(w => dataFactDWHFail.Contains(w.RunId)).ToList();
                _unit.FeedInfoTempRepo.BulkDelete(delFailDWH);
            }

            #endregion Del Fail DWH Data Temp

            _unit.SaveTransaction();
            return feedDataList;
        }

        public string CopyFeedInfo(FeedInfoCopyRequest param, out int total, out List<MRB_TMP_FEED_INFO> dataCopy)
        {
            string runId;
            dataCopy = CopyFeedInfoCenter(param, out total, out runId);

            _unit.SaveTransaction();

            return runId;
        }

        public List<FeedInfoPreviewResponse> PreviewCopyFeedInfo(FeedInfoCopyRequest param)
        {
            int total = 0;
            string runId = "";
            var dataCopy = CopyFeedInfoCenter(param, out total, out runId);

            var result = new List<FeedInfoPreviewResponse>();

            foreach (var group in dataCopy)
            {
                var mapData = new FeedInfoPreviewResponse(group);

                result.Add(mapData);
            }

            return result;
        }

        private MRB_TMP_FEED_INFO BindFeedInfoTempModelToDB(FeedInfoCriteriaModel criteria, MRB_TRN_FEED_INFO item, string productGroup, decimal price)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.PlaneType == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MRB_TMP_FEED_INFO()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                CyclePoly = cyclePoly,
                PlanType = criteria.PlaneType,
                RefNo = item.RefNo,
                Company = item.Company,
                MCSC = item.MCSC,
                //MonthStatus = item.MonthStatus,
                FeedNameKey = item.FeedNameKey,
                MaterialCode = item.MaterialCode,
                FeedGeoCategoryKey = item.FeedGeoCategoryKey,
                SupplierKey = item.SupplierKey,
                SupplierCode = item.SupplierCode,
                PricingIndexKey = item.PricingIndexKey,
                PricingRefKey = item.PricingRefKey,
                OriginKey = item.OriginKey,
                ContractSpot = item.ContractSpot,
                TransportationKey = item.TransportationKey,
                BuyerRightKey = item.BuyerRightKey,
                PurchasingVolume = item.PurchasingVolume,
                PurchasingPremium = item.PurchasingPremium,
                HedgingGainLoss = item.HedgingGainLoss,
                GITStatus = item.GITStatus,
                Surveyor = item.Surveyor,
                Insurance = item.Insurance,
                Margin = item.Margin,
                MonthIndex = item.MonthIndex,

                //Merge With
                MergedWithCase = criteria.MergeCase,
                MergedWithCycle = criteria.MergeCycle,
                MergedWithPlanType = criteria.MergePlaneType,
                MonthNo = item.MonthNo,
                ProductGroup = productGroup,
                Price = price,

                CreatedBy = userLogin,
                CreatedDate = DateTime.Now
            };
            return newData;
        }

        public bool CheckExistData(FeedInfoCopyRequest param)
        {
            #region check exist data

            var feedInfoFromRepo = _unit.FeedInfoRepo.FindByCriteriasAll(param.PlaneTypeFrom, param.CaseFrom, param.CycleFrom, param.CompanyFrom, param.FeedGeoCategoryKeyFrom, param.FeedNameKeyFrom, param.ProductGroupFrom);

            if (feedInfoFromRepo.Count <= 0)
            {
                throw new Exception("No feed info based on your selected criteria.");
            }

            #endregion check exist data

            return true;
        }
    }
}