using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Datafacetory.Interface;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;
using System.Linq;
using System.Reflection;
using System.Globalization;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.FeedInfo.Interface;
using Newtonsoft.Json.Linq;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.DataFactory;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Optience;
using SCG.CHEM.MBR.DATAACCESS.Repository.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Repository.Transaction.Interface;
using static SCG.CHEM.SSPLSP.DATAACCESS.APPCONSTANT;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Xml.Linq;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.FeedInfo
{
    public sealed class FeedInfoService : IFeedInfoService
    {
        private readonly UnitOfWork _unit;
        private readonly string userLogin;
        private readonly IDataFactoryService _dataFactoryService;
        private readonly SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork _unitSSP;

        public FeedInfoService(UnitOfWork unitOfWork, IDataFactoryService dataFactoryService, SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork unitSSP)
        {
            this._unit = unitOfWork;
            this.userLogin = UserUtilities.GetADAccount()?.UserId ?? "";
            this._dataFactoryService = dataFactoryService;
            this._unitSSP = unitSSP;
        }

        public string CallDataFactory(string tableName, string transactionName, RequestCriteriaTransaction criteria, string submitStatus, bool isMerge = false, string MergedWithPlanType = "", string MergedWithCycle = "", string MergedWithCase = "")
        {
            string userName = UserUtilities.GetADAccount()?.UserId ?? "";
            string res = _dataFactoryService.RunPipelineMultiCriteria(tableName, transactionName, criteria, userName, submitStatus, isMerge
                        , MergedWithPlanType, MergedWithCycle, MergedWithCase);

            return res;
        }

        #region Move

        public int MoveFeedInfo(RequestDataFactoryRunIdStatus data)
        {
            var newMasterDB = new List<MRB_TRN_FEED_INFO>();
            var listTempDB = _unit.FeedInfoTempRepo.GetAll().Where(x => x.RunId == data.RunId).ToList();

            var addInfoList = new List<MRB_TRN_FEED_INFO>();
            var delTmp = new List<MRB_TMP_FEED_INFO>();
            var delTrn = new List<MRB_TRN_FEED_INFO>();
            var findCriteriaDel = new FeedInfoCriteriaModel();

            if (data != null)
            {
                findCriteriaDel.PlaneType = data.planTypeName;
                findCriteriaDel.Case = data.caseName;
                findCriteriaDel.Cycle = data.cycleName;
                findCriteriaDel.Company = string.IsNullOrEmpty(data.company) ? new List<string>() : data.company.SplitToList(",");
                findCriteriaDel.FeedNameKey = string.IsNullOrEmpty(data.feedNameKey) ? new List<string>() : data.feedNameKey.SplitToList(",");
                findCriteriaDel.FeedGeoCategoryKey = string.IsNullOrEmpty(data.feedGeoCategoryKey) ? new List<string>() : data.feedGeoCategoryKey.SplitToList(",");
                findCriteriaDel.ProductGroup = string.IsNullOrEmpty(data.productGroup) ? new List<string>() : data.productGroup.SplitToList(",");
            }

            //Set DEL TMP and TRN
            delTmp = _unit.FeedInfoTempRepo.GetAll().Where(x => x.RunId == data.RunId).ToList();
            delTrn = _unit.FeedInfoRepo.FindByCriteriasAll(findCriteriaDel.PlaneType, findCriteriaDel.Case, findCriteriaDel.Cycle, findCriteriaDel.Company, findCriteriaDel.FeedGeoCategoryKey, findCriteriaDel.FeedNameKey, findCriteriaDel.ProductGroup);
            //add

            foreach (var item in listTempDB)
            {
                //add
                var bind = BindFeedInfoModelToDB(new FeedInfoCriteriaModel
                {
                    Cycle = item.Cycle,
                    Case = item.Case,
                    PlaneType = item.PlanType,
                }, item, item.ProductGroup, item.Price);

                bind.CreatedBy = item.CreatedBy;
                bind.CreatedDate = item.CreatedDate;
                addInfoList.Add(bind);
            }
            //Del TRN
            if (delTrn != null && delTrn.Count >= 1)
                _unit.FeedInfoRepo.BulkDelete(delTrn);

            //Add TRN
            if (addInfoList != null && addInfoList.Count > 0)
                _unit.FeedInfoRepo.BulkInsert(addInfoList);

            //Del TMP
            if (delTmp != null && delTmp.Count >= 1)
                _unit.FeedInfoTempRepo.BulkDelete(delTmp);

            var dataFac = _unit.DataFactoryRunRepo.GetByRunId(data.RunId);
            var infoData = addInfoList?.FirstOrDefault();
            if (dataFac is not null && dataFac.IsMerge == true && infoData is not null)
            {
                var request = new MergeHistoryRequestModel()
                {
                    Cycle = dataFac.Cycle,
                    Case = dataFac.Case
                };
                var mergeData = _unit.MergeHistoryRepo.GetDataByCriteria(request, MASTER_EXCEL_TYPE.FEED_INFO);
                if (mergeData is null)
                {
                    var typeName = _unit.MasterExcelRepo.GetByExcelId(MASTER_EXCEL_TYPE.FEED_INFO)?.MasterName?.Replace(" ", "") ?? "";
                    var mergeHistory = new MBR_TRN_MERGE_HISTORY()
                    {
                        ExcelId = MASTER_EXCEL_TYPE.FEED_INFO,
                        Type = typeName,
                        Case = dataFac.Case,
                        Cycle = dataFac.Cycle,
                        MergedWithCase = dataFac.MergedWithCase ?? "",
                        MergedWithCycle = dataFac.MergedWithCycle ?? "",
                        CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                        CreatedDate = DateTime.Now
                    };
                    _unit.MergeHistoryRepo.Add(mergeHistory);
                }
            }

            // set Total record
            int total = addInfoList.Count();
            _unit.SaveTransaction();
            return total;
        }

        #endregion Move

        #region upload

        private List<MRB_TMP_FEED_INFO> UploadFeedInfoCenter(DataWithFeedInfoModel<FeedInfoCriteriaModel, ValidateFeedInfoModel> param, bool IsPreview, out int total, out string runId)
        {
            runId = "";

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

            var validateModels = new List<FeedInfoModel>();
            //var containMarketPriceMapping = _unit.MasterMarketPriceMappingRepo.GetMarketPriceMIs(param.Data.Select(s => s.MarketSource).ToList());
            var containCompany = _unitSSP.MasterCompanyRepo.GetByShortName(param.Data.Select(s => s.Company).ToList());
            var containProductMapping = _unit.MasterProductMappingRepo.GetMaterialCode(param.Data.Select(s => s.MaterialCode).ToList());
            var contaiCustomerVendorMapping = _unit.MasterCustomerVendorMappingRepo.GetCustomerShortName(param.Data.Select(s => s.SupplierKey).ToList());
            var containMarketPriceMapping = _unit.MasterMarketPriceMappingRepo.GetMarketPriceMIs(param.Data.Select(s => s.PricingIndexKey).ToList());

            //var isZero = _unit.MasterMaintainPriceRepo.GetByMaintainId(MASTER_EXCEL_TYPE.FEED_DATA)?.IsZero ?? false;
            List<MRB_TRN_FEED_INFO> feedInfoExistingData = new List<MRB_TRN_FEED_INFO>();
            if (param.Criteria.isMerge && param.Criteria.MergePlaneType != null && param.Criteria.MergeCase != null && param.Criteria.MergeCycle != null)
                feedInfoExistingData = _unit.FeedInfoRepo.FindByCriteriasAll(param.Criteria.MergePlaneType, param.Criteria.MergeCase, param.Criteria.MergeCycle, param.Criteria.Company, param.Criteria.FeedGeoCategoryKey, param.Criteria.FeedNameKey, param.Criteria.ProductGroup);
            //feedInfoExistingData = null; // Not yet develop merge
            param.Data.ForEach(i =>
            {
                row++;
                List<MRB_TRN_FEED_INFO> existingData = null;
                if (feedInfoExistingData != null)
                    existingData = FindMatchItem(feedInfoExistingData, i);
                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToModel(existingData, containProductMapping, contaiCustomerVendorMapping, containCompany, containMarketPriceMapping, param.Criteria.ProductGroup, param.Criteria.isMerge, out convertErrorList, out convertDataWarningList);

                validateModels.Add(convertModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            #region Save Data

            // Temp
            var feedInfoList = new List<MRB_TMP_FEED_INFO>();
            var feedInfoRepo = _unit.FeedInfoTempRepo.FindByCriteriasAll(param.Criteria.PlaneType, param.Criteria.Case, param.Criteria.Cycle, param.Criteria.Company, param.Criteria.FeedGeoCategoryKey, param.Criteria.FeedNameKey, param.Criteria.ProductGroup);

            //add
            foreach (var item in validateModels)
            {
                //add
                //find productGroup with FeedNameKey
                var productGroup = _unit.MasterProductMappingRepo.GetProductGroup(item.FeedNameKey).FirstOrDefault();

                decimal price = 0;
                //find Price with calculate

                var monthNo = ConverseMonthNo(param.Criteria.PlaneType, item.MonthStatus, param.Criteria.Cycle);
                //item.MonthNo = monthNo;

                item.PurchasingVolume = String.IsNullOrEmpty(item.PurchasingVolume) ? "0" : item.PurchasingVolume;
                item.PurchasingPremium = String.IsNullOrEmpty(item.PurchasingPremium) ? "0" : item.PurchasingPremium;
                item.HedgingGainLoss = String.IsNullOrEmpty(item.HedgingGainLoss) ? "0" : item.HedgingGainLoss;
                item.Surveyor = String.IsNullOrEmpty(item.Surveyor) ? "0" : item.Surveyor;
                item.Insurance = String.IsNullOrEmpty(item.Insurance) ? "0" : item.Insurance;
                item.Margin = String.IsNullOrEmpty(item.Margin) ? "0" : item.Margin;
                item.TR = String.IsNullOrEmpty(item.TR) ? "0" : item.TR;

                var bind = BindFeedInfoTempModelToDB(param.Criteria, item, productGroup.ProductGroup, price, monthNo);

                feedInfoList.Add(bind);
            }

            //Auto Generate
            /*var autogenData = UploadAutoGenerateMonthIndex(feedInfoList);
            feedInfoList = new List<MRB_TMP_FEED_INFO>();
            feedInfoList = autogenData;*/

            if (param.Criteria.isMerge)
            {
                var feedInfoMainRepo = _unit.FeedInfoRepo.FindByCriteriasAll(param.Criteria.MergePlaneType, param.Criteria.MergeCase, param.Criteria.MergeCycle, param.Criteria.Company, param.Criteria.FeedGeoCategoryKey, param.Criteria.FeedNameKey, param.Criteria.ProductGroup);
                var mergeExistingData = MergeExistingData(param.Criteria, feedInfoList, feedInfoMainRepo);
                feedInfoList = new List<MRB_TMP_FEED_INFO>();
                feedInfoList = mergeExistingData;
            }
            /*else
            {
                var autogenData = UploadAutoGenerateMonthIndex(feedInfoList);
                feedInfoList = new List<MRB_TMP_FEED_INFO>();
                feedInfoList = autogenData;
            }*/

            //Calculate Data
            var calculateData = feedInfoList;
            feedInfoList = new List<MRB_TMP_FEED_INFO>();
            feedInfoList = CalculateData(calculateData, param);

            // set Total record
            total = feedInfoList.Count();
            if (!IsPreview)
            {
                #region Call API

                bool isCallApiSuccess = true;
                var criteria = new RequestCriteriaTransaction();
                criteria.PlaneType = param.Criteria.PlaneType;
                criteria.Case = param.Criteria.Case;
                criteria.Cycle = param.Criteria.Cycle;
                criteria.Company = String.Join(",", param.Criteria.Company);
                criteria.FeedGeoCategoryKey = String.Join(",", param.Criteria.FeedGeoCategoryKey);
                criteria.FeedNameKey = String.Join(",", param.Criteria.FeedNameKey);
                criteria.ProductGroup = String.Join(",", param.Criteria.ProductGroup);

                runId = CallDataFactory("MBR_TMP_FeedInfo", "FeedInfo", criteria, APPCONSTANT.SUBMIT_STATUS.SUBMIT, param.Criteria.isMerge);
                runId = param.Criteria.isMerge ? CallDataFactory("MBR_TMP_FeedInfo", "FeedInfo", criteria, APPCONSTANT.SUBMIT_STATUS.SUBMIT, param.Criteria.isMerge, param.Criteria.MergePlaneType, param.Criteria.MergeCycle, param.Criteria.MergeCase)
                   : CallDataFactory("MBR_TMP_FeedInfo", "FeedInfo", criteria, APPCONSTANT.SUBMIT_STATUS.SUBMIT, param.Criteria.isMerge);

                if (isCallApiSuccess)
                {
                    // insert runId to Database
                }
                else
                {
                    throw new Exception("Error after call api.");
                }

                #endregion Call API

                //runId = "SystemGen-01"; //HardCode
                foreach (var item in feedInfoList)
                {
                    item.RunId = runId;
                }

                if (feedInfoList.Count > 0)
                    _unit.FeedInfoTempRepo.BulkInsert(feedInfoList);

                #region Del Fail DWH Data Temp

                var dataFactDWHFail = _unit.DataFactoryRunRepo.GetDWHFail("FeedInfo")?.Select(s => s.RunId).ToList();
                if (dataFactDWHFail != null && dataFactDWHFail.Count >= 1)
                {
                    var delFailDWH = feedInfoRepo.Where(w => dataFactDWHFail.Contains(w.RunId)).ToList();
                    _unit.FeedInfoTempRepo.BulkDelete(delFailDWH);
                }

                #endregion Del Fail DWH Data Temp

                _unit.SaveTransaction();

                #endregion Save Data
            }
            return feedInfoList;
        }

        public string UploadFeedInfo(DataWithFeedInfoModel<FeedInfoCriteriaModel, ValidateFeedInfoModel> param, out int total)
        {
            string runId;
            var data = UploadFeedInfoCenter(param, false, out total, out runId);
            //MoveFeedInfo(runId);
            return runId;
        }

        private string ConverseMonthNo(string scenario, string monthIndex, string cycle)
        {
            var format = "{0}-{1}";
            var month = int.Parse(monthIndex.Substring(1));
            cycle = cycle.Substring(cycle.IndexOf("_") + 1);
            if (scenario == SCENATIO.M18 || scenario == SCENATIO.W1 || scenario == SCENATIO.W3 || scenario.ToUpper() == SCENATIO.ACTUAL.ToUpper() || scenario.ToUpper() == SCENATIO.WEEKLY.ToUpper())
            {
                var now = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                var date = now.AddMonths(month);
                return string.Format(format, date.Year, date.Month.ToString("00"));
            }
            else if (scenario.ToUpper() == SCENATIO.OPPLAN.ToUpper())
            {
                var now = new DateTime(int.Parse(cycle.Substring(0, 4)), 1, 1);
                var date = now.AddMonths(month);
                return string.Format(format, date.Year, date.Month.ToString("00"));
            }
            else if (scenario.ToUpper() == SCENATIO.MTP.ToUpper())
            {
                var now = new DateTime(int.Parse(cycle.Substring(0, 4)), 1, 1);
                var date = now.AddYears(month);
                return string.Format(format, date.Year, date.Month.ToString("00"));
            }

            return null;
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

            ).ToList();

            return result;
        }

        public List<FeedInfoDownloadResponse> PreviewUploadFeedInfo(DataWithFeedInfoModel<FeedInfoCriteriaModel, ValidateFeedInfoModel> param)
        {
            int total = 0;
            string runId = "";
            var dataCopy = new List<MRB_TRN_FEED_INFO>();
            var dataTMPCopy = UploadFeedInfoCenter(param, true, out total, out runId);
            //Set to TRN
            foreach (var item in dataTMPCopy)
            {
                //add
                var bind = BindFeedInfoModelToDB(new FeedInfoCriteriaModel
                {
                    Cycle = item.Cycle,
                    Case = item.Case,
                    PlaneType = item.PlanType,
                }, item, item.ProductGroup, item.Price);

                bind.CreatedBy = item.CreatedBy;
                bind.CreatedDate = item.CreatedDate;
                dataCopy.Add(bind);
            }

            var result = new List<FeedInfoDownloadResponse>();
            var mPositive = dataCopy.Where(w => int.Parse(w.MonthIndex.Substring(1)) + int.Parse(w.PricingRefKey.Substring(1)) >= 0).ToList();
            var mNegative = dataCopy.Where(w => int.Parse(w.MonthIndex.Substring(1)) + int.Parse(w.PricingRefKey.Substring(1)) < 0).ToList();
            var FirstOrDefault = dataCopy.FirstOrDefault();

            //cal M +
            var marketPriceRepo = _unit.MarketPriceForecastRepo.FindByFeedInfo(param.Criteria.PlaneType, param.Criteria.Case, param.Criteria.Cycle, mPositive);
            var mopjRepo = _unit.MarketPriceForecastRepo.FindByMOPJ(param.Criteria.PlaneType, param.Criteria.Case, param.Criteria.Cycle, mPositive);

            //cal M-
            List<FeedInfoMarketPriceName> feedInfoMarketPriceNames = new List<FeedInfoMarketPriceName>();
            var marketPriceName = _unit.MasterMarketPriceMappingRepo.GetMarketPriceNameByMarketPriceMI(mNegative.Select(s => s.PricingIndexKey).ToList());
            var marketPriceNameMOPJ = _unit.MasterMarketPriceMappingRepo.GetMarketPriceNameByMarketPriceMI(new List<string>() { "MOPJ" });
            //mi=productweb pricing month
            var olefins = _unit.FctMarketPriceOlefinsRepo.GetFctMarketPriceOlefinsByFeedInfo(mNegative, marketPriceName);
            var olefinsMOPJ = _unit.FctMarketPriceOlefinsRepo.GetFctMarketPriceOlefinsByFeedInfo(mNegative, marketPriceNameMOPJ);

            //ExchangeRate (fx)
            List<DateTime> startMonth = new List<DateTime>();
            foreach (var item in dataCopy)
            {
                var cycle = string.Empty;
                var date = new DateTime();
                var month = int.Parse(item.MonthIndex.Substring(1)) + int.Parse(item.PricingRefKey.Substring(1));
                if (item.PlanType.ToUpper() == SCENATIO.OPPLAN.ToUpper() || item.PlanType.ToUpper() == SCENATIO.MTP.ToUpper())
                {
                    cycle = item.MonthNo;
                    date = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                    date = date.AddMonths(int.Parse(item.PricingRefKey.Substring(1)));
                }
                else
                {
                    cycle = item.Cycle.Substring(item.Cycle.IndexOf("_") + 1);
                    date = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                    date = date.AddMonths(month);
                }

                startMonth.Add(date);
            }
            var fxList = _unitSSP.ViewExchangeRateExportRepo.GetByFirstDate(startMonth);
            foreach (var group in dataCopy)
            {
                var cycle = string.Empty;
                var date = new DateTime();
                var marketPrice = marketPriceRepo.FirstOrDefault(f => f.MarketSource == group.PricingIndexKey && f.MonthIndex == group.PricingRefKey);
                var marketPriceMOPJ = mopjRepo.FirstOrDefault(f => f.MarketSource == group.PricingIndexKey);

                var ole = olefins.FirstOrDefault(f => f.Key == group).Value;
                var oleMOPJ = olefinsMOPJ.FirstOrDefault(f => f.Key == group).Value;
                bool isPositive = mPositive.FirstOrDefault(f => f == group) != null;

                //fx
                var month = int.Parse(group.MonthIndex.Substring(1)) + int.Parse(group.PricingRefKey.Substring(1));
                if (group.PlanType.ToUpper() == SCENATIO.OPPLAN.ToUpper() || group.PlanType.ToUpper() == SCENATIO.MTP.ToUpper())
                {
                    cycle = group.MonthNo;
                    date = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                    date = date.AddMonths(int.Parse(group.PricingRefKey.Substring(1)));
                }
                else
                {
                    cycle = group.Cycle.Substring(group.Cycle.IndexOf("_") + 1);
                    date = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                    date = date.AddMonths(month);
                }
                var prict = marketPriceName.FirstOrDefault(f => f.MarketPriceMI == group.PricingIndexKey);
                var fx = fxList.Where(f => f.FirstDate.Value.Date == date.Date)
                                .FirstOrDefault()
                                ?.ExchangeRate;
                var mapData = new FeedInfoDownloadResponse(group, marketPrice, isPositive, marketPriceMOPJ, ole, oleMOPJ, fx);

                result.Add(mapData);
            }

            return result;
        }

        // This function MERGE user uploaded data with existing data (if can be merged)
        // Time complexity should be O(n^2) or worse.
        public List<MRB_TMP_FEED_INFO> MergeExistingData(FeedInfoCriteriaModel criteria, List<MRB_TMP_FEED_INFO> uploadedData, List<MRB_TRN_FEED_INFO> existingTransactionData)
        {
            var result = new List<MRB_TMP_FEED_INFO>();

            Action<MRB_TMP_FEED_INFO, bool> AddOrReplaceToResult = (data, isPreemptive) =>
            {
                // Chcek if data to be added is in the result
                int existingDataInResultIndex = result.FindIndex(x =>
                {
                    return x.MonthIndex == data.MonthIndex &&
                           x.Company == data.Company &&
                           x.MCSC == data.MCSC &&
                           x.FeedNameKey == data.FeedNameKey &&
                           x.FeedGeoCategoryKey == data.FeedGeoCategoryKey &&
                           x.SupplierKey == data.SupplierKey &&
                           x.PricingIndexKey == data.PricingIndexKey &&
                           x.PricingRefKey == data.PricingRefKey &&
                           x.OriginKey == data.OriginKey &&
                           x.ContractSpot == data.ContractSpot &&
                           x.TransportationKey == data.TransportationKey &&
                           x.BuyerRightKey == data.BuyerRightKey;
                });

                if (existingDataInResultIndex != -1)
                {
                    // User uploaded data can replace existing data. But not vice versa.
                    if (isPreemptive)
                    {
                        result[existingDataInResultIndex] = data;
                    }
                }
                else
                {
                    result.Add(data);
                }
            };

            var cyclePoly = uploadedData.FirstOrDefault().CyclePoly;

            foreach (var data in uploadedData)
            {
                var existingTransactionDataWithTheSameKeys = existingTransactionData.Where(
                    x => x.Company == data.Company &&
                         x.MCSC == data.MCSC &&
                         x.FeedNameKey == data.FeedNameKey &&
                         x.FeedGeoCategoryKey == data.FeedGeoCategoryKey &&
                         x.SupplierKey == data.SupplierKey &&
                         x.PricingIndexKey == data.PricingIndexKey &&
                         x.PricingRefKey == data.PricingRefKey &&
                         x.OriginKey == data.OriginKey &&
                         x.ContractSpot == data.ContractSpot &&
                         x.TransportationKey == data.TransportationKey &&
                         x.BuyerRightKey == data.BuyerRightKey
                ).ToList();

                // No record to be merged, just add uploaded data to result e.g., NOT mergable
                if (existingTransactionDataWithTheSameKeys.Count == 0)
                {
                    AddOrReplaceToResult(data, true);
                }

                // There is more than 1 record to be merged e.g., mergable
                else
                {
                    existingTransactionDataWithTheSameKeys.ForEach((extData) =>
                    {
                        // If MonthIndex is the same, add/replace user uploaded data to result (user uploaded data is preemtive)
                        if (extData.MonthIndex == data.MonthIndex)
                        {
                            AddOrReplaceToResult(data, true);
                        }

                        // Otherwise, try to add existing data to the result (but not guarantee to be added)
                        else
                        {
                            extData.PlanType = criteria.PlaneType;
                            extData.Cycle = criteria.Cycle;
                            extData.Case = criteria.Case;
                            extData.CyclePoly = cyclePoly;
                            extData.MergedWithPlanType = criteria.MergePlaneType;
                            extData.MergedWithCycle = criteria.MergeCycle;
                            extData.MergedWithCase = criteria.MergeCase;
                            AddOrReplaceToResult(new MRB_TMP_FEED_INFO(extData), false);
                        }
                    });
                }
            }

            return result;
        }

        public List<MRB_TMP_FEED_INFO> UploadAutoGenerateMonthIndex(List<MRB_TMP_FEED_INFO> uploadedData)
        {
            var result = new List<MRB_TMP_FEED_INFO>();

            Action<MRB_TMP_FEED_INFO, bool> AddOrReplaceToResult = (data, isPreemptive) =>
            {
                // Chcek if data to be added is in the result
                int existingDataInResultIndex = result.FindIndex(x =>
                {
                    return x.MonthIndex == data.MonthIndex &&
                           x.Company == data.Company &&
                           x.MCSC == data.MCSC &&
                           x.FeedNameKey == data.FeedNameKey &&
                           x.FeedGeoCategoryKey == data.FeedGeoCategoryKey &&
                           x.SupplierKey == data.SupplierKey &&
                           x.PricingIndexKey == data.PricingIndexKey &&
                           x.PricingRefKey == data.PricingRefKey &&
                           x.OriginKey == data.OriginKey &&
                           x.ContractSpot == data.ContractSpot &&
                           x.TransportationKey == data.TransportationKey &&
                           x.BuyerRightKey == data.BuyerRightKey;
                });

                if (existingDataInResultIndex != -1)
                {
                    // User uploaded data can replace existing data. But not vice versa.
                    if (isPreemptive)
                    {
                        result[existingDataInResultIndex] = data;
                    }
                }
                else
                {
                    result.Add(data);
                }
            };

            var groupuploadedData = uploadedData.GroupBy(g => new { g.Company, g.MCSC, g.FeedNameKey, g.FeedGeoCategoryKey, g.SupplierKey, g.PricingIndexKey, g.PricingRefKey, g.OriginKey, g.ContractSpot, g.TransportationKey, g.BuyerRightKey }).ToList();

            foreach (var uploadData in groupuploadedData)
            {
                List<string> monthIndexs = Enum.GetValues(typeof(MONTH_INDEX)).Cast<MONTH_INDEX>().Select(v => v.ToString()).ToList();
                var numMaxMonthIndex = 0;
                foreach (var data in uploadData)
                {
                    var index = monthIndexs.FindIndex(x => x.Equals(data.MonthIndex));
                    if (index > numMaxMonthIndex)
                    {
                        numMaxMonthIndex = index;
                    }
                }

                var dataGenCondition = uploadedData.Where(
                 x => x.Company == uploadData.Key.Company &&
                 x.MCSC == uploadData.Key.MCSC &&
                 x.FeedNameKey == uploadData.Key.FeedNameKey &&
                 x.FeedGeoCategoryKey == uploadData.Key.FeedGeoCategoryKey &&
                 x.SupplierKey == uploadData.Key.SupplierKey &&
                 x.PricingIndexKey == uploadData.Key.PricingIndexKey &&
                 x.PricingRefKey == uploadData.Key.PricingRefKey &&
                 x.OriginKey == uploadData.Key.OriginKey &&
                 x.ContractSpot == uploadData.Key.ContractSpot &&
                 x.TransportationKey == uploadData.Key.TransportationKey &&
                 x.BuyerRightKey == uploadData.Key.BuyerRightKey &&
                 x.MonthIndex == ((MONTH_INDEX)numMaxMonthIndex).ToString()
                 ).FirstOrDefault();

                var dataGen = new MRB_TMP_FEED_INFO(dataGenCondition);

                for (int i = 0; i <= numMaxMonthIndex; i++)
                {
                    var existingTransactionData = uploadedData.Where(
                         x => x.Company == uploadData.Key.Company &&
                         x.MCSC == uploadData.Key.MCSC &&
                         x.FeedNameKey == uploadData.Key.FeedNameKey &&
                         x.FeedGeoCategoryKey == uploadData.Key.FeedGeoCategoryKey &&
                         x.SupplierKey == uploadData.Key.SupplierKey &&
                         x.PricingIndexKey == uploadData.Key.PricingIndexKey &&
                         x.PricingRefKey == uploadData.Key.PricingRefKey &&
                         x.OriginKey == uploadData.Key.OriginKey &&
                         x.ContractSpot == uploadData.Key.ContractSpot &&
                         x.TransportationKey == uploadData.Key.TransportationKey &&
                         x.BuyerRightKey == uploadData.Key.BuyerRightKey &&
                         x.MonthIndex == ((MONTH_INDEX)i).ToString()
                    ).FirstOrDefault();
                    if (existingTransactionData is not null)
                    {
                        AddOrReplaceToResult(existingTransactionData, true);
                        //result.Add(existingTransactionData);
                    }
                    else
                    {
                        dataGen.MonthIndex = ((MONTH_INDEX)i).ToString();
                        dataGen.MonthNo = ConverseMonthNo(dataGen.PlanType, ((MONTH_INDEX)i).ToString(), dataGen.Cycle);
                        dataGen.PurchasingVolume = 0;
                        dataGen.PurchasingPremium = 0;
                        dataGen.HedgingGainLoss = 0;
                        dataGen.GITStatus = "";
                        dataGen.Surveyor = 0;
                        dataGen.Insurance = 0;
                        dataGen.Margin = 0;
                        dataGen.TR = 0;
                        dataGen.Price = 0;
                        //result.Add(new MRB_TMP_FEED_INFO(dataGen));
                        AddOrReplaceToResult(new MRB_TMP_FEED_INFO(dataGen), false);
                    }
                }
            }

            return result;
        }

        //public List<MRB_TMP_FEED_INFO> MergeExistingData(List<MRB_TMP_FEED_INFO> data, List<MRB_TRN_FEED_INFO> dataExisting)
        //{
        //    var result = new List<MRB_TMP_FEED_INFO>();
        //    var resultKey = data.FirstOrDefault();
        //    var dataExistingLst = dataExisting.Where(
        //        x => x.Company == resultKey.Company
        //        && x.MCSC == resultKey.MCSC
        //        && x.FeedNameKey == resultKey.FeedNameKey
        //        && x.FeedGeoCategoryKey == resultKey.FeedGeoCategoryKey
        //        && x.SupplierKey == resultKey.SupplierKey
        //        && x.PricingIndexKey == resultKey.PricingIndexKey
        //        && x.PricingRefKey == resultKey.PricingRefKey
        //        && x.OriginKey == resultKey.OriginKey
        //        && x.ContractCategoryKey == resultKey.ContractCategoryKey
        //        && x.TransportationKey == resultKey.TransportationKey
        //        && x.BuyerRightKey == resultKey.BuyerRightKey
        //    ).ToList();
        //    foreach (var item in dataExistingLst)
        //    {
        //        var resultFeedInfo = data.Where(x => x.MonthIndex == item.MonthIndex && x.MonthNo == item.MonthNo).FirstOrDefault();
        //        if (resultFeedInfo != null)
        //        {
        //            result.Add(resultFeedInfo);
        //        }
        //        else
        //        {
        //            item.MergedWithCase = resultKey.MergedWithCase;
        //            item.MergedWithCycle = resultKey.MergedWithCycle;
        //            item.MergedWithPlanType = resultKey.MergedWithPlanType;
        //            var mergeToTemp = MergeFeedInfoModelToDB(item);
        //            result.Add(mergeToTemp);
        //        }
        //    }

        //    return result;
        //}

        #endregion upload

        private MRB_TMP_FEED_INFO BindFeedInfoTempModelToDB(FeedInfoCriteriaModel criteria, FeedInfoModel item, string productGroup, decimal price, string monthNo)
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
                PurchasingVolume = Decimal.Parse(item.PurchasingVolume ?? "0"),
                PurchasingPremium = Decimal.Parse(item.PurchasingPremium ?? "0"),
                HedgingGainLoss = Decimal.Parse(item.HedgingGainLoss ?? "0"),
                GITStatus = item.GITStatus ?? "",
                Surveyor = Decimal.Parse(item.Surveyor ?? "0"),
                Insurance = Decimal.Parse(item.Insurance ?? "0"),
                Margin = Decimal.Parse(item.Margin ?? "0"),
                TR = Decimal.Parse(item.TR ?? "0"),
                MonthIndex = item.MonthStatus,
                //Merge With
                MergedWithCase = criteria.MergeCase,
                MergedWithCycle = criteria.MergeCycle,
                MergedWithPlanType = criteria.MergePlaneType,
                MonthNo = monthNo,
                ProductGroup = productGroup,
                Price = price,
                //RunId = "SystemGen",

                CreatedBy = userLogin,
                CreatedDate = DateTime.Now
            };
            return newData;
        }

        private MRB_TRN_FEED_INFO BindFeedInfoModelToDB(FeedInfoCriteriaModel criteria, MRB_TMP_FEED_INFO item, string? productGroup, decimal? price)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.PlaneType == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MRB_TRN_FEED_INFO()
            {
                ID = item.ID,
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
                TR = item.TR,
                MonthIndex = item.MonthIndex,
                //Merge With
                MergedWithCase = item.MergedWithCase,
                MergedWithCycle = item.MergedWithCycle,
                MergedWithPlanType = item.MergedWithPlanType,
                MonthNo = item.MonthNo,
                ProductGroup = productGroup,
                Price = price,
                MarketPrice = item.MarketPrice,
                SurveyorUSDPerTon = item.SurveyorUSDPerTon,
                InsuranceUSDPerTon = item.InsuranceUSDPerTon,
                PriceUSDPerTon = item.PriceUSDPerTon,
                MOPJM0 = item.MOPJM0,
                ExchangeRate = item.ExchangeRate,

                CreatedBy = userLogin,
                CreatedDate = DateTime.Now
            };
            return newData;
        }

        private MRB_TMP_FEED_INFO MergeFeedInfoModelToDB(MRB_TRN_FEED_INFO item)
        {
            var newData = new MRB_TMP_FEED_INFO()
            {
                Case = item.Case,
                Cycle = item.Cycle,
                CyclePoly = item.CyclePoly,
                PlanType = item.PlanType,
                RefNo = item.RefNo,
                Company = item.Company,
                MCSC = item.MCSC,
                FeedNameKey = item.FeedNameKey,
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
                TR = item.TR,
                MonthIndex = item.MonthIndex,
                MergedWithCase = item.MergedWithCase,
                MergedWithCycle = item.MergedWithCycle,
                MergedWithPlanType = item.MergedWithPlanType,
                MonthNo = item.MonthNo,
                ProductGroup = item.ProductGroup,
                Price = item.Price,
                CreatedBy = userLogin,
                CreatedDate = DateTime.Now
            };
            return newData;
        }

        private List<MRB_TMP_FEED_INFO> CalculateData(List<MRB_TMP_FEED_INFO> data, DataWithFeedInfoModel<FeedInfoCriteriaModel, ValidateFeedInfoModel> param)
        {
            var itemData = new List<MRB_TRN_FEED_INFO>();
            foreach (var item in data)
            {
                //add
                var bind = BindFeedInfoModelToDB(new FeedInfoCriteriaModel
                {
                    Cycle = item.Cycle,
                    Case = item.Case,
                    PlaneType = item.PlanType,
                }, item, item.ProductGroup, item.Price);

                bind.CreatedBy = item.CreatedBy;
                bind.CreatedDate = item.CreatedDate;
                itemData.Add(bind);
            }

            var result = new List<MRB_TMP_FEED_INFO>();
            var mPositive = itemData.Where(w => int.Parse(w.MonthIndex.Substring(1)) + int.Parse(w.PricingRefKey.Substring(1)) >= 0).ToList();
            var mNegative = itemData.Where(w => int.Parse(w.MonthIndex.Substring(1)) + int.Parse(w.PricingRefKey.Substring(1)) < 0).ToList();
            var FirstOrDefault = itemData.FirstOrDefault();

            //cal M +
            var marketPriceRepo = _unit.MarketPriceForecastRepo.FindByFeedInfo(param.Criteria.PlaneType, param.Criteria.Case, param.Criteria.Cycle, mPositive);
            var mopjRepo = _unit.MarketPriceForecastRepo.FindByMOPJ(param.Criteria.PlaneType, param.Criteria.Case, param.Criteria.Cycle, mPositive);

            //cal M-
            List<FeedInfoMarketPriceName> feedInfoMarketPriceNames = new List<FeedInfoMarketPriceName>();
            var marketPriceName = _unit.MasterMarketPriceMappingRepo.GetMarketPriceNameByMarketPriceMI(mNegative.Select(s => s.PricingIndexKey).ToList());
            var marketPriceNameMOPJ = _unit.MasterMarketPriceMappingRepo.GetMarketPriceNameByMarketPriceMI(new List<string>() { "MOPJ" });
            //mi=productweb pricing month
            var olefins = _unit.FctMarketPriceOlefinsRepo.GetFctMarketPriceOlefinsByFeedInfo(mNegative, marketPriceName);
            var olefinsMOPJ = _unit.FctMarketPriceOlefinsRepo.GetFctMarketPriceOlefinsByFeedInfo(mNegative, marketPriceNameMOPJ);

            //ExchangeRate (fx)
            List<DateTime> startMonth = new List<DateTime>();
            foreach (var item in itemData)
            {
                var cycle = string.Empty;
                var date = new DateTime();
                var month = int.Parse(item.MonthIndex.Substring(1)) + int.Parse(item.PricingRefKey.Substring(1));
                if (item.PlanType.ToUpper() == SCENATIO.OPPLAN.ToUpper() || item.PlanType.ToUpper() == SCENATIO.MTP.ToUpper())
                {
                    cycle = item.MonthNo;
                    date = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                    date = date.AddMonths(int.Parse(item.PricingRefKey.Substring(1)));
                }
                else
                {
                    cycle = item.Cycle.Substring(item.Cycle.IndexOf("_") + 1);
                    date = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                    date = date.AddMonths(month);
                }

                startMonth.Add(date);
            }
            var fxList = _unitSSP.ViewExchangeRateExportRepo.GetByFirstDate(startMonth);
            foreach (var group in itemData)
            {
                var cycle = string.Empty;
                var date = new DateTime();
                var marketPrice = marketPriceRepo.FirstOrDefault(f => f.MarketSource == group.PricingIndexKey && f.MonthIndex == group.PricingRefKey);
                var marketPriceMOPJ = mopjRepo.FirstOrDefault(f => f.MarketSource == group.PricingIndexKey);

                var ole = olefins.FirstOrDefault(f => f.Key == group).Value;
                var oleMOPJ = olefinsMOPJ.FirstOrDefault(f => f.Key == group).Value;
                bool isPositive = mPositive.FirstOrDefault(f => f == group) != null;

                //fx
                var month = int.Parse(group.MonthIndex.Substring(1)) + int.Parse(group.PricingRefKey.Substring(1));
                if (group.PlanType.ToUpper() == SCENATIO.OPPLAN.ToUpper() || group.PlanType.ToUpper() == SCENATIO.MTP.ToUpper())
                {
                    cycle = group.MonthNo;
                    date = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                    date = date.AddMonths(int.Parse(group.PricingRefKey.Substring(1)));
                }
                else
                {
                    cycle = group.Cycle.Substring(group.Cycle.IndexOf("_") + 1);
                    date = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                    date = date.AddMonths(month);
                }
                var prict = marketPriceName.FirstOrDefault(f => f.MarketPriceMI == group.PricingIndexKey);
                var fx = fxList.Where(f => f.FirstDate.Value.Date == date.Date)
                                .FirstOrDefault()
                                ?.ExchangeRate;

                var mapData = new MRB_TMP_FEED_INFO(group, marketPrice, isPositive, marketPriceMOPJ, ole, oleMOPJ, fx);

                result.Add(mapData);
            }

            return result;
        }
    }
}