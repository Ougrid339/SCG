using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Optience;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Datafacetory.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Optience.Interface;
using System.Globalization;
using System.Reflection;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Optience
{
    public class OptienceService : IOptienceService
    {
        private readonly UnitOfWork _unit;
        private readonly string userLogin;
        private readonly SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork _unitSSP;
        private readonly IDataFactoryService _dataFactoryService;

        public OptienceService(UnitOfWork unitOfWork, IDataFactoryService dataFactoryService, SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork unitSSP)
        {
            this._unit = unitOfWork;
            this.userLogin = UserUtilities.GetADAccount()?.UserId ?? "";
            this._dataFactoryService = dataFactoryService;
            this._unitSSP = unitSSP;
        }

        #region Move

        public string CallDataFactory(string tableName, string transactionName, string cycleName, string caseName, string planType, List<string> company, bool isMerge = false, string MergedWithPlanType = "", string MergedWithCycle = "", string MergedWithCase = "")
        {
            string userName = UserUtilities.GetADAccount()?.UserId ?? "";
            string res = _dataFactoryService.RunPipelineOptience(tableName, transactionName, cycleName, caseName, planType, company, isMerge, userName, MergedWithPlanType, MergedWithCycle, MergedWithCase);

            return res;
        }

        public int MoveProductionVolume(string runId, string company)
        {
            var newMasterDB = new List<MBR_TRN_PRODUCTION_VOLUME>();
            var listTempDB = _unit.ProductionVolumeTempRepo.FindByRunId(runId);

            var addProductionVolumeDataList = new List<MBR_TRN_PRODUCTION_VOLUME>();
            var productionVolumeList = new List<MBR_TRN_PRODUCTION_VOLUME>();

            List<string> monthIndexs = Enum.GetValues(typeof(MONTH_INDEX)).Cast<MONTH_INDEX>().Select(v => v.ToString()).ToList();
            var delTmp = new List<MBR_TMP_PRODUCTION_VOLUME>();

            //add
            var group = listTempDB.GroupBy(g => new { g.PlanType, g.Case, g.Cycle, g.Company, g.MCSC, g.ProductName }).ToList();
            foreach (var cycle in group)
            {
                //var marketPriceRepo = _unit.ProductionVolumeRepo.FindByCriterias(cycle.Key.PlanType, cycle.Key.Case, cycle.Key.Cycle);
                foreach (var item in cycle)
                {
                    decimal? monthIndexData = item.Price;
                    //var dbUpdate = marketPriceRepo.FirstOrDefault(f => f.MonthIndex == item.MonthIndex && f.Company.ToUpper() == item.Company.ToUpper() && f.MCSC.ToUpper() == item.MCSC.ToUpper() && f.ProductName.ToUpper() == item.ProductName.ToUpper());

                    //if (dbUpdate != null)
                    //{
                    //    //update
                    //    dbUpdate.ElementCodeEBA = item.ElementCodeEBA;
                    //    dbUpdate.ProductShortName = item.ProductShortName;
                    //    dbUpdate.Price = monthIndexData;
                    //    dbUpdate.MergedWithCase = item.MergedWithCase;
                    //    dbUpdate.MergedWithCycle = item.MergedWithCycle;
                    //    dbUpdate.MergedWithPlanType = item.MergedWithPlanType;
                    //    dbUpdate.CopiedFromCase = item.CopiedFromCase;
                    //    dbUpdate.CopiedFromCycle = item.CopiedFromCycle;
                    //    dbUpdate.CopiedFromPlanType = item.CopiedFromPlanType;
                    //    dbUpdate.UpdatedBy = userLogin;
                    //    dbUpdate.UpdatedDate = DateTime.Now;
                    //    productionVolumeList.Add(dbUpdate);
                    //}
                    //else
                    //{
                    //add
                    var bind = BindProductionVolumeModelToDB(new OptienceCriteriaModel
                    {
                        Cycle = item.Cycle,
                        Case = item.Case,
                        Scenario = item.PlanType,
                    }, new ProductionVolumeModel
                    {
                        MCSC = item.MCSC,
                        Company = item.Company,
                        ProductName = item.ProductName,
                        ElementCode = item.ElementCodeEBA,
                        ProductShortName = item.ProductShortName,
                        MaterialCode = item.MaterialCode
                    }, monthIndexData, item.MonthIndex, item.MonthNo);

                    bind.MergedWithCase = item.MergedWithCase;
                    bind.MergedWithCycle = item.MergedWithCycle;
                    bind.MergedWithPlanType = item.MergedWithPlanType;
                    bind.CopiedFromCase = item.CopiedFromCase;
                    bind.CopiedFromCycle = item.CopiedFromCycle;
                    bind.CopiedFromPlanType = item.CopiedFromPlanType;
                    bind.UpdatedBy = item.UpdatedBy;
                    bind.UpdatedDate = item.UpdatedDate;
                    addProductionVolumeDataList.Add(bind);
                    //productionVolumeList.Add(bind);
                    //}
                }
            }

            #region Delete Trn

            //var companyDel = _dataFactoryService.GetCompanyDatafactory(runId)?.SplitToList(",") ?? new List<string>();
            var companyDel = string.IsNullOrEmpty(company) ? new List<string>() : company.SplitToList(",");
            var delTrn = companyDel != null && companyDel.Count >= 1 ?
                _unit.ProductionVolumeRepo.FindByCriterias(listTempDB.FirstOrDefault().PlanType, listTempDB.FirstOrDefault().Case, listTempDB.FirstOrDefault().Cycle, companyDel)
                : _unit.ProductionVolumeRepo.FindByCriterias(listTempDB.FirstOrDefault().PlanType, listTempDB.FirstOrDefault().Case, listTempDB.FirstOrDefault().Cycle);
            if (delTrn != null && delTrn.Count >= 1)

                _unit.ProductionVolumeRepo.BulkDelete(delTrn);

            #endregion Delete Trn

            if (addProductionVolumeDataList != null && addProductionVolumeDataList.Count > 0)
            {
                _unit.ProductionVolumeRepo.BulkInsert(addProductionVolumeDataList);
                var dataFac = _unit.DataFactoryRunRepo.GetByRunId(runId);
                if (dataFac is not null && dataFac.IsMerge == true)
                {
                    var typeName = _unit.MasterExcelRepo.GetByExcelId(MASTER_EXCEL_TYPE.PRODUCTION_VOLUME)?.MasterName?.Replace(" ", "") ?? "";
                    var data = addProductionVolumeDataList.FirstOrDefault();
                    var request = new MergeHistoryRequestModel()
                    {
                        Cycle = dataFac.Cycle,
                        Case = dataFac.Case
                    };
                    var mergeData = _unit.MergeHistoryRepo.GetDataByCriteria(request, MASTER_EXCEL_TYPE.PRODUCTION_VOLUME);
                    if (mergeData is null)
                    {
                        var mergeHistory = new MBR_TRN_MERGE_HISTORY()
                        {
                            ExcelId = MASTER_EXCEL_TYPE.PRODUCTION_VOLUME,
                            Type = typeName,
                            Case = dataFac.Case,
                            Cycle = dataFac.Cycle,
                            MergedWithCase = dataFac.MergedWithCase ?? "",
                            MergedWithCycle = dataFac.MergedWithCycle ?? "",
                            CreatedBy = userLogin,
                            CreatedDate = DateTime.Now
                        };
                        _unit.MergeHistoryRepo.Add(mergeHistory);
                    }
                }
            }

            if (listTempDB != null && listTempDB.Count >= 1)
                _unit.ProductionVolumeTempRepo.BulkDelete(listTempDB);

            // set Total record

            int total = addProductionVolumeDataList?.Count ?? 0;
            _unit.SaveTransaction();
            return total;
        }

        public int MoveFeedConsumption(string runId, string company)
        {
            var newMasterDB = new List<MBR_TRN_FEED_CONSUMPTION>();
            var listTempDB = _unit.FeedConsumptionTempRepo.FindByRunId(runId);

            var addFeedConsumptionDataList = new List<MBR_TRN_FEED_CONSUMPTION>();
            var feedConsumptionList = new List<MBR_TRN_FEED_CONSUMPTION>();

            List<string> monthIndexs = Enum.GetValues(typeof(MONTH_INDEX)).Cast<MONTH_INDEX>().Select(v => v.ToString()).ToList();
            var delTmp = new List<MBR_TMP_FEED_CONSUMPTION>();

            //add
            var group = listTempDB.GroupBy(g => new { g.PlanType, g.Case, g.Cycle, g.Company, g.MCSC, g.FeedName }).ToList();
            foreach (var cycle in group)
            {
                foreach (var item in cycle)
                {
                    decimal? monthIndexData = item.Price;
                    //var feedConsumptionUpdate = feedConsumptionRepo.FirstOrDefault(f => f.MonthIndex == item.MonthIndex && f.Company.ToUpper() == item.Company.ToUpper() && f.MCSC.ToUpper() == item.MCSC.ToUpper() && f.FeedName.ToUpper() == item.FeedName.ToUpper());

                    //if (feedConsumptionUpdate != null)
                    //{
                    //    //update
                    //    feedConsumptionUpdate.FeedShortName = item.FeedShortName;
                    //    feedConsumptionUpdate.SupplierKey = item.SupplierKey;
                    //    feedConsumptionUpdate.ElementCodeEBA = item.ElementCodeEBA;
                    //    feedConsumptionUpdate.Price = monthIndexData;

                    //    feedConsumptionUpdate.MergedWithCase = item.MergedWithCase;
                    //    feedConsumptionUpdate.MergedWithCycle = item.MergedWithCycle;
                    //    feedConsumptionUpdate.MergedWithPlanType = item.MergedWithPlanType;
                    //    feedConsumptionUpdate.CopiedFromCase = item.CopiedFromCase;
                    //    feedConsumptionUpdate.CopiedFromCycle = item.CopiedFromCycle;
                    //    feedConsumptionUpdate.CopiedFromPlanType = item.CopiedFromPlanType;
                    //    feedConsumptionUpdate.UpdatedBy = userLogin;
                    //    feedConsumptionUpdate.UpdatedDate = DateTime.Now;
                    //    feedConsumptionList.Add(feedConsumptionUpdate);
                    //}
                    //else
                    //{
                    //add
                    var bind = BindFeedConsumptionModelToDB(new OptienceCriteriaModel
                    {
                        Cycle = item.Cycle,
                        Case = item.Case,
                        Scenario = item.PlanType,
                    }, new FeedConsumptionModel
                    {
                        MCSC = item.MCSC,
                        Company = item.Company,
                        FeedName = item.FeedName,
                        ElementCode = item.ElementCodeEBA,
                        FeedShortName = item.FeedShortName,
                        SupplierKey = item.SupplierKey,
                        SupplierCode = item.SupplierCode,
                        MaterialCode = item.MaterialCode
                    }, monthIndexData, item.MonthIndex, item.MonthNo);
                    bind.MergedWithCase = item.MergedWithCase;
                    bind.MergedWithCycle = item.MergedWithCycle;
                    bind.MergedWithPlanType = item.MergedWithPlanType;
                    bind.CopiedFromCase = item.CopiedFromCase;
                    bind.CopiedFromCycle = item.CopiedFromCycle;
                    bind.CopiedFromPlanType = item.CopiedFromPlanType;
                    bind.UpdatedBy = item.UpdatedBy;
                    bind.UpdatedDate = item.UpdatedDate;
                    addFeedConsumptionDataList.Add(bind);
                    //productionVolumeList.Add(bind);
                    //}
                }
            }

            #region Delete Trn

            var companyDel = string.IsNullOrEmpty(company) ? new List<string>() : company.SplitToList(",");
            var delTrn = companyDel != null && companyDel.Count >= 1 ?
                _unit.FeedConsumptionRepo.FindByCriterias(listTempDB.FirstOrDefault().PlanType, listTempDB.FirstOrDefault().Case, listTempDB.FirstOrDefault().Cycle, companyDel)
                : _unit.FeedConsumptionRepo.FindByCriterias(listTempDB.FirstOrDefault().PlanType, listTempDB.FirstOrDefault().Case, listTempDB.FirstOrDefault().Cycle);

            if (delTrn != null && delTrn.Count >= 1)

                _unit.FeedConsumptionRepo.BulkDelete(delTrn);

            #endregion Delete Trn

            if (addFeedConsumptionDataList != null && addFeedConsumptionDataList.Count > 0)
            {
                _unit.FeedConsumptionRepo.BulkInsert(addFeedConsumptionDataList);
                var dataFac = _unit.DataFactoryRunRepo.GetByRunId(runId);
                if (dataFac is not null && dataFac.IsMerge == true)
                {
                    var data = addFeedConsumptionDataList.FirstOrDefault();
                    var typeName = _unit.MasterExcelRepo.GetByExcelId(MASTER_EXCEL_TYPE.FEED_CONSUMPTION)?.MasterName?.Replace(" ", "") ?? "";
                    var request = new MergeHistoryRequestModel()
                    {
                        Cycle = dataFac.Cycle,
                        Case = dataFac.Case
                    };
                    var mergeData = _unit.MergeHistoryRepo.GetDataByCriteria(request, MASTER_EXCEL_TYPE.FEED_CONSUMPTION);
                    if (mergeData is null)
                    {
                        var mergeHistory = new MBR_TRN_MERGE_HISTORY()
                        {
                            ExcelId = MASTER_EXCEL_TYPE.FEED_CONSUMPTION,
                            Type = typeName,
                            Case = dataFac.Case,
                            Cycle = dataFac.Cycle,
                            MergedWithCase = dataFac.MergedWithCase ?? "",
                            MergedWithCycle = dataFac.MergedWithCycle ?? "",
                            CreatedBy = userLogin,
                            CreatedDate = DateTime.Now
                        };
                        _unit.MergeHistoryRepo.Add(mergeHistory);
                    }
                }
            }

            if (listTempDB != null && listTempDB.Count >= 1)
                _unit.FeedConsumptionTempRepo.BulkDelete(listTempDB);

            // set Total record

            int total = addFeedConsumptionDataList?.Count ?? 0;
            _unit.SaveTransaction();
            return total;
        }

        public int MoveFeedPurchase(string runId, string company)
        {
            var newMasterDB = new List<MBR_TRN_FEED_PURCHASE>();
            var listTempDB = _unit.FeedPurchaseTempRepo.FindByRunId(runId);

            var addFeedPurchaseDataList = new List<MBR_TRN_FEED_PURCHASE>();
            var feedPurchaseList = new List<MBR_TRN_FEED_PURCHASE>();

            List<string> monthIndexs = Enum.GetValues(typeof(MONTH_INDEX)).Cast<MONTH_INDEX>().Select(v => v.ToString()).ToList();
            var delTmp = new List<MBR_TMP_FEED_PURCHASE>();

            //add
            var group = listTempDB.GroupBy(g => new { g.PlanType, g.Case, g.Cycle, g.Company, g.MCSC, g.FeedName }).ToList();
            foreach (var cycle in group)
            {
                foreach (var item in cycle)
                {
                    decimal? monthIndexData = item.Price;

                    //if (feedPurchaseUpdate != null)
                    //{
                    //    //update
                    //    feedPurchaseUpdate.FeedShortName = item.FeedShortName;
                    //    feedPurchaseUpdate.SupplierKey = item.SupplierKey;
                    //    feedPurchaseUpdate.ElementCodeEBA = item.ElementCodeEBA;
                    //    feedPurchaseUpdate.Price = monthIndexData;
                    //    feedPurchaseUpdate.CopiedFromCase = item.CopiedFromCase;
                    //    feedPurchaseUpdate.CopiedFromCycle = item.CopiedFromCycle;
                    //    feedPurchaseUpdate.CopiedFromPlanType = item.CopiedFromPlanType;
                    //    feedPurchaseUpdate.UpdatedBy = userLogin;
                    //    feedPurchaseUpdate.UpdatedDate = DateTime.Now;
                    //    feedPurchaseList.Add(feedPurchaseUpdate);
                    //}
                    //else
                    //{
                    //add
                    var bind = BindFeedPurchaseModelToDB(new OptienceCriteriaModel
                    {
                        Cycle = item.Cycle,
                        Case = item.Case,
                        Scenario = item.PlanType,
                    }, new FeedPurchaseModel
                    {
                        MCSC = item.MCSC,
                        Company = item.Company,
                        FeedName = item.FeedName,
                        ElementCode = item.ElementCodeEBA,
                        FeedShortName = item.FeedShortName,
                        SupplierKey = item.SupplierKey,
                        SupplierCode = item.SupplierCode,
                        MaterialCode = item.MaterialCode
                    }, monthIndexData, item.MonthIndex, item.MonthNo);
                    bind.CopiedFromCase = item.CopiedFromCase;
                    bind.CopiedFromCycle = item.CopiedFromCycle;
                    bind.CopiedFromPlanType = item.CopiedFromPlanType;
                    bind.UpdatedBy = item.UpdatedBy;
                    bind.UpdatedDate = item.UpdatedDate;
                    addFeedPurchaseDataList.Add(bind);
                    //productionVolumeList.Add(bind);
                    //}
                }
            }

            #region Delete Trn

            var companyDel = string.IsNullOrEmpty(company) ? new List<string>() : company.SplitToList(",");
            var delTrn = companyDel != null && companyDel.Count >= 1 ?
                _unit.FeedPurchaseRepo.FindByCriteria(listTempDB.FirstOrDefault().PlanType, listTempDB.FirstOrDefault().Case, listTempDB.FirstOrDefault().Cycle, companyDel)
                : _unit.FeedPurchaseRepo.FindByCriteria(listTempDB.FirstOrDefault().PlanType, listTempDB.FirstOrDefault().Case, listTempDB.FirstOrDefault().Cycle);

            if (delTrn != null && delTrn.Count >= 1)
                _unit.FeedPurchaseRepo.BulkDelete(delTrn);

            #endregion Delete Trn

            if (addFeedPurchaseDataList != null && addFeedPurchaseDataList.Count > 0)
            {
                _unit.FeedPurchaseRepo.BulkInsert(addFeedPurchaseDataList);
            }

            if (listTempDB != null && listTempDB.Count >= 1)
                _unit.FeedPurchaseTempRepo.BulkDelete(listTempDB);

            // set Total record

            int total = addFeedPurchaseDataList?.Count ?? 0;
            _unit.SaveTransaction();
            return total;
        }

        public int MoveBeginningInventory(string runId, string company)
        {
            var newMasterDB = new List<MBR_TRN_BEGINING_INVENTORY>();
            var listTempDB = _unit.BeginningInventoryTempRepo.FindByRunId(runId);

            var addBeginningInventorytDataList = new List<MBR_TRN_BEGINING_INVENTORY>();
            var beginningInventorytList = new List<MBR_TRN_BEGINING_INVENTORY>();

            List<string> monthIndexs = Enum.GetValues(typeof(MONTH_INDEX)).Cast<MONTH_INDEX>().Select(v => v.ToString()).ToList();
            var delTmp = new List<MBR_TMP_BEGINING_INVENTORY>();

            //add
            var group = listTempDB.GroupBy(g => new { g.PlanType, g.Case, g.Cycle, g.Company, g.MCSC, g.ProductShortName }).ToList();
            foreach (var cycle in group)
            {
                foreach (var item in cycle)
                {
                    decimal? monthIndexData = item.Price;
                    //if (monthIndexData != null && monthIndexData != 0)
                    //{
                    //    if (dbUpdate != null)
                    //    {
                    //        //update
                    //        dbUpdate.Price = monthIndexData;

                    //        dbUpdate.CopiedFromCase = item.CopiedFromCase;
                    //        dbUpdate.CopiedFromCycle = item.CopiedFromCycle;
                    //        dbUpdate.CopiedFromPlanType = item.CopiedFromPlanType;
                    //        dbUpdate.UpdatedBy = userLogin;
                    //        dbUpdate.UpdatedDate = DateTime.Now;
                    //        beginningInventorytList.Add(dbUpdate);
                    //    }
                    //    else
                    //    {
                    //add
                    var bind = BindBeginningInventoryModelToDB(new OptienceCriteriaModel
                    {
                        Cycle = item.Cycle,
                        Case = item.Case,
                        Scenario = item.PlanType,
                    }, new BeginningInventoryModel
                    {
                        MCSC = item.MCSC,
                        Company = item.Company,
                        ProductShortName = item.ProductShortName,
                        MaterialCode = item.MaterialCode,
                        SupplierKey = item.SupplierKey,
                        ElementCode = item.ElementCodeEBA,
                        InventoryName = item.InventoryName,
                        TankNumber = item.TankNumber,
                        SupplierCode = item.SupplierCode
                    }, monthIndexData, item.MonthIndex, item.MonthNo); ;

                    bind.CopiedFromCase = item.CopiedFromCase;
                    bind.CopiedFromCycle = item.CopiedFromCycle;
                    bind.CopiedFromPlanType = item.CopiedFromPlanType;
                    bind.UpdatedBy = item.UpdatedBy;
                    bind.UpdatedDate = item.UpdatedDate;
                    addBeginningInventorytDataList.Add(bind);
                    //productionVolumeList.Add(bind);
                    //    }
                    //}
                }
            }

            #region Delete Trn

            var companyDel = string.IsNullOrEmpty(company) ? new List<string>() : company.SplitToList(",");
            var delTrn = companyDel != null && companyDel.Count >= 1 ?
                _unit.BeginningInventoryRepo.FindByCriterias(listTempDB.FirstOrDefault().PlanType, listTempDB.FirstOrDefault().Case, listTempDB.FirstOrDefault().Cycle, companyDel)
                : _unit.BeginningInventoryRepo.FindByCriterias(listTempDB.FirstOrDefault().PlanType, listTempDB.FirstOrDefault().Case, listTempDB.FirstOrDefault().Cycle);

            if (delTrn != null && delTrn.Count >= 1)
                _unit.BeginningInventoryRepo.BulkDelete(delTrn);

            #endregion Delete Trn

            if (addBeginningInventorytDataList != null && addBeginningInventorytDataList.Count > 0)
            {
                _unit.BeginningInventoryRepo.BulkInsert(addBeginningInventorytDataList);
            }

            if (listTempDB != null && listTempDB.Count >= 1)
                _unit.BeginningInventoryTempRepo.BulkDelete(listTempDB);

            // set Total record

            int total = addBeginningInventorytDataList?.Count ?? 0;
            _unit.SaveTransaction();
            return total;
        }

        #endregion Move

        public List<PriceList> UploadOptience(DataWitOptienceModel<OptienceCriteriaModel> param, out int sum)
        {
            var result = new List<PriceList>();
            int total = 0;
            sum = 0;
            PriceList runId = new PriceList();

            var dataFeedPurchase = new List<MBR_TMP_FEED_PURCHASE>();
            var dataFeedConsumptionData = new List<MBR_TMP_FEED_CONSUMPTION>();
            var dataProductionVolumeData = new List<MBR_TMP_PRODUCTION_VOLUME>();
            var dataBeginningInventoryData = new List<MBR_TMP_BEGINING_INVENTORY>();
            if (param.FeedPurchaseData.Count >= 1)
            {
                dataFeedPurchase = UploadFeedPurchase(param, false, out total, out runId);
                sum = sum + total;
                result.Add(runId);
            }
            if (param.FeedConsumptionData.Count >= 1)
            {
                dataFeedConsumptionData = UploadFeedConsumptionData(param, false, out total, out runId);
                sum = sum + total;
                result.Add(runId);
            }
            if (param.ProductionVolumeData.Count >= 1)
            {
                dataProductionVolumeData = UploadProductionVolume(param, false, out total, out runId);
                sum = sum + total;
                result.Add(runId);
            }
            if (param.BeginningInventoryData.Count >= 1)
            {
                dataBeginningInventoryData = UploadBeginningInventory(param, false, out total, out runId);
                sum = sum + total;
                result.Add(runId);
            }

            return result;
        }

        public List<MBR_TMP_FEED_CONSUMPTION> UploadFeedConsumptionData(DataWitOptienceModel<OptienceCriteriaModel> param, bool IsPreview, out int total, out PriceList runId)
        {
            // Set RowId (Row No)
            int row = 0;
            runId = new PriceList();

            param.FeedConsumptionData.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
            });

            #region Create Validate Model & Set Id (RowNo)

            var validateFeedConsumptionModels = new List<FeedConsumptionModel>();
            List<PriceList> priceLst = new List<PriceList>();
            var isZero = _unit.MasterMaintainPriceRepo.GetByMaintainId(MASTER_EXCEL_TYPE.FEED_CONSUMPTION)?.IsZero ?? false;
            var containCompany = _unitSSP.MasterCompanyRepo.GetByShortName(param.FeedConsumptionData.Select(s => s.Company).ToList());
            var containProductMapping = _unit.MasterProductMappingRepo.GetMaterialCode(param.FeedConsumptionData.Select(s => s.MaterialCode).ToList());
            var contaiCustomerVendorMapping = _unit.MasterCustomerVendorMappingRepo.GetCustomerShortName(param.FeedConsumptionData.Select(s => s.SupplierKey).ToList());
            List<MBR_TRN_FEED_CONSUMPTION> feedConsumptionExistingData = new List<MBR_TRN_FEED_CONSUMPTION>();
            if (param.Criteria.isMerge && param.Criteria.MergeScenario != null && param.Criteria.MergeCase != null && param.Criteria.MergeCycle != null)
            {
                feedConsumptionExistingData = _unit.FeedConsumptionRepo.FindByCriterias(param.Criteria.MergeScenario, param.Criteria.MergeCase, param.Criteria.MergeCycle);
            }
            param.FeedConsumptionData.ForEach(i =>
            {
                row++;
                List<MBR_TRN_FEED_CONSUMPTION> existingDatas = null;
                if (feedConsumptionExistingData != null)
                    existingDatas = feedConsumptionExistingData.Where(f => f.Company.ToLower() == i.Company.ToLower() && f.MCSC.ToLower() == i.MCSC.ToLower() && f.FeedName.ToLower() == i.FeedName.ToLower()).ToList();
                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToFeedConsumptionModel(existingDatas, containProductMapping, contaiCustomerVendorMapping, containCompany, param.Criteria.isMerge, isZero, out convertErrorList, out convertDataWarningList);

                validateFeedConsumptionModels.Add(convertModel);

                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M0 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M1 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M2 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M3 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M4 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M5 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M6 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M7 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M8 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M9 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M10 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M11 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M12 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M13 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M14 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M15 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M16 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M17 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M18 ?? "" });
            });

            #endregion Create Validate Model & Set Id (RowNo)

            #region Save Data

            var addFeedConsumptionDataList = new List<MBR_TMP_FEED_CONSUMPTION>();
            var feedConsumptionList = new List<MBR_TMP_FEED_CONSUMPTION>();

            var feedConsumptionMainRepo = _unit.FeedConsumptionRepo.FindByCriterias(param.Criteria.Scenario, param.Criteria.Case, param.Criteria.Cycle);
            var feedConsumptionTempRepo = _unit.FeedConsumptionTempRepo.FindByCriterias(param.Criteria.Scenario, param.Criteria.Case, param.Criteria.Cycle);

            List<string> monthIndexs = Enum.GetValues(typeof(MONTH_INDEX)).Cast<MONTH_INDEX>().Select(v => v.ToString()).ToList();
            var lstData = new List<OptienceList>();

            //add

            foreach (var item in validateFeedConsumptionModels)
            {
                var indexes = priceLst.Where(w => w.name.SplitToList(",")[0] == item.Company
                                           && w.name.SplitToList(",")[1] == item.MCSC
                                           && w.name.SplitToList(",")[2] == item.FeedName.ToUpper()
                                           && w.name.SplitToList(",")[3] == item.FeedShortName.ToUpper()).Select(s => s.value).Select((v, i) => new { v, i })
                      .Where(x => x.v.Any(y => y != null))
                      .Select(x => "M" + x.i).ToList();
                var maxM = indexes.Max(x => Convert.ToInt32(x.Replace("M", "")));
                List<string> mIndexs = new List<string>();
                int m = 0;
                while (m <= maxM)
                {
                    mIndexs.Add(string.Format("M{0}", m));
                    m++;
                }
                foreach (var monthIndex in monthIndexs)
                {
                    var monthNo = ConverseMonthNo(param.Criteria.Scenario, monthIndex, param.Criteria.Cycle);
                    var month = int.Parse(monthIndex.Substring(1));

                    var monthIndexDataString = (string?)item.GetType().GetProperty(monthIndex).GetValue(item, null);
                    decimal? monthIndexData = indexes.FirstOrDefault(f => f == monthIndex) != null ? decimal.Parse(monthIndexDataString) :
                        (mIndexs.Contains(monthIndex) ? 0 : !string.IsNullOrEmpty(monthIndexDataString) ? decimal.Parse(monthIndexDataString) : null);
                    //if ((monthIndexData != null && monthIndexData != 0) || isZero)
                    //{
                    //add
                    var bind = BindFeedConsumptionTempModelToDB(param.Criteria, item, monthIndexData, monthIndex, monthNo);
                    if (param.Criteria.isMerge && month > maxM)
                    {
                        bind.MergedWithCycle = param.Criteria.MergeCycle;
                        bind.MergedWithCase = param.Criteria.MergeCase;
                        bind.MergedWithPlanType = param.Criteria.MergeScenario;
                    }
                    addFeedConsumptionDataList.Add(bind);
                    feedConsumptionList.Add(bind);
                    lstData.Add(new OptienceList { company = item.Company, mcsc = item.MCSC, name = item.FeedName, value = monthIndex });
                    //}
                }
            }

            // set Total record
            total = feedConsumptionList.Count();

            #region Call Api

            if (!IsPreview)
            {
                bool isCallApiSuccess = true;
                var pipeLine = param.Criteria.isMerge ? CallDataFactory("MBR_TMP_FeedConsumption", "FeedConsumption", param.Criteria.Cycle, param.Criteria.Case, param.Criteria.Scenario, param.Criteria.Company, param.Criteria.isMerge, param.Criteria.MergeScenario, param.Criteria.MergeCycle, param.Criteria.MergeCase)
                    : CallDataFactory("MBR_TMP_FeedConsumption", "FeedConsumption", param.Criteria.Cycle, param.Criteria.Case, param.Criteria.Scenario, param.Criteria.Company, param.Criteria.isMerge);
                if (pipeLine != "error")
                {
                    runId = new PriceList
                    {
                        name = "FeedConsumption",
                        value = pipeLine
                    };
                }
                else
                {
                    isCallApiSuccess = false;
                    runId = new PriceList { name = "FeedConsumption", value = pipeLine, error = "Cannot Run Pipeline." };
                }
                if (isCallApiSuccess)
                {
                    foreach (var item in feedConsumptionList)
                    {
                        item.RunId = pipeLine;
                    }

                    addFeedConsumptionDataList = addFeedConsumptionDataList.Where(x => x.Price is not null).ToList();
                    if (addFeedConsumptionDataList != null && addFeedConsumptionDataList.Count > 0)
                        _unit.FeedConsumptionTempRepo.BulkInsert(addFeedConsumptionDataList);

                    #region Del Fail DWH Data Temp

                    var dataFactDWHFail = _unit.DataFactoryRunRepo.GetDWHFail("FeedConsumption")?.Select(s => s.RunId).ToList();
                    if (dataFactDWHFail != null && dataFactDWHFail.Count >= 1)
                    {
                        var delFailDWH = feedConsumptionTempRepo.Where(w => dataFactDWHFail.Contains(w.RunId)).ToList();
                        _unit.FeedConsumptionTempRepo.BulkDelete(delFailDWH);
                    }

                    #endregion Del Fail DWH Data Temp

                    #region del tmep after 30 minute

                    var delAfter30minute = _unit.FeedConsumptionTempRepo.FindAfter30minute();
                    if (delAfter30minute != null && delAfter30minute.Count >= 1)
                    {
                        _unit.FeedConsumptionTempRepo.BulkDelete(delAfter30minute);
                    }

                    #endregion del tmep after 30 minute

                    _unit.SaveTransaction();
                }
            }

            //concat data DB

            var groupData = lstData.GroupBy(g => new { g.company, g.mcsc, g.name }).ToList();
            var lstNotUpdate = new List<MBR_TMP_FEED_CONSUMPTION>();
            foreach (var item in groupData)
            {
                lstNotUpdate.AddRange(feedConsumptionMainRepo.Where(w => w.Company == item.Key.company && w.MCSC == item.Key.mcsc && w.FeedName == item.Key.name && !item.Select(s => s.value).Contains(w.MonthIndex)).Select(s => new MBR_TMP_FEED_CONSUMPTION(s)).ToList());
            }
            if (lstNotUpdate != null && lstNotUpdate.Count > 0)
            {
                feedConsumptionList.AddRange(lstNotUpdate);
            };

            #endregion Call Api

            #endregion Save Data

            return feedConsumptionList;
        }

        public List<MBR_TMP_FEED_PURCHASE> UploadFeedPurchase(DataWitOptienceModel<OptienceCriteriaModel> param, bool IsPreview, out int total, out PriceList runId)
        {
            runId = new PriceList();

            #region Set Id (RowNo) for dataValidates List

            // Set RowId (Row No)
            int row = 0;
            param.FeedPurchaseData.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
            });

            #endregion Set Id (RowNo) for dataValidates List

            #region Create Validate Model & Set Id (RowNo)

            var validateFeedPurchaseModels = new List<FeedPurchaseModel>();
            var validateFeedConsumptionModels = new List<FeedConsumptionModel>();
            List<PriceList> priceLst = new List<PriceList>();

            var isZero = _unit.MasterMaintainPriceRepo.GetByMaintainId(MASTER_EXCEL_TYPE.FEED_PURCHASE)?.IsZero ?? false;
            var containCompany = _unitSSP.MasterCompanyRepo.GetByShortName(param.FeedPurchaseData.Select(s => s.Company).ToList());
            var containProductMapping = _unit.MasterProductMappingRepo.GetMaterialCode(param.FeedPurchaseData.Select(s => s.MaterialCode).ToList());
            var contaiCustomerVendorMapping = _unit.MasterCustomerVendorMappingRepo.GetCustomerShortName(param.FeedPurchaseData.Select(s => s.SupplierKey).ToList());
            List<MBR_TRN_FEED_PURCHASE> feedPurchaseExistingData = new List<MBR_TRN_FEED_PURCHASE>();
            if (param.Criteria.isMerge && param.Criteria.MergeScenario != null && param.Criteria.MergeCase != null && param.Criteria.MergeCycle != null)
            {
                feedPurchaseExistingData = _unit.FeedPurchaseRepo.FindByCriteria(param.Criteria.MergeScenario, param.Criteria.MergeCase, param.Criteria.MergeCycle);
            }
            param.FeedPurchaseData.ForEach(i =>
            {
                row++;
                List<MBR_TRN_FEED_PURCHASE> existingDatas = null;
                if (feedPurchaseExistingData != null)
                    existingDatas = feedPurchaseExistingData.Where(f => f.Company.ToLower() == i.Company.ToLower() && f.MCSC.ToLower() == i.MCSC.ToLower() && f.FeedName.ToLower() == i.FeedName.ToLower()).ToList();
                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToFeedPurchaseModel(existingDatas, containProductMapping, contaiCustomerVendorMapping, containCompany, param.Criteria.isMerge, isZero, out convertErrorList, out convertDataWarningList);

                validateFeedPurchaseModels.Add(convertModel);

                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M0 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M1 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M2 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M3 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M4 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M5 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M6 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M7 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M8 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M9 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M10 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M11 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M12 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M13 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M14 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M15 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M16 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M17 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.FeedName.ToUpper() + "," + convertModel.FeedShortName.ToUpper(), value = i.M18 ?? "" });
            });

            #endregion Create Validate Model & Set Id (RowNo)

            #region Save Data

            var addFeedPurchaseDataList = new List<MBR_TMP_FEED_PURCHASE>();
            var feedPurchaseList = new List<MBR_TMP_FEED_PURCHASE>();

            var feedPurchaseTempRepo = _unit.FeedPurchaseTempRepo.FindByCriterias(param.Criteria.Scenario, param.Criteria.Case, param.Criteria.Cycle);
            var feedPurchaseMainRepo = _unit.FeedPurchaseRepo.FindByCriteria(param.Criteria.Scenario, param.Criteria.Case, param.Criteria.Cycle);

            List<string> monthIndexs = Enum.GetValues(typeof(MONTH_INDEX)).Cast<MONTH_INDEX>().Select(v => v.ToString()).ToList();
            //add

            var lstData = new List<OptienceList>();
            foreach (var item in validateFeedPurchaseModels)
            {
                var indexes = priceLst.Where(w => w.name.SplitToList(",")[0] == item.Company
                                          && w.name.SplitToList(",")[1] == item.MCSC
                                          && w.name.SplitToList(",")[2] == item.FeedName.ToUpper()
                                          && w.name.SplitToList(",")[3] == item.FeedShortName.ToUpper()).Select(s => s.value).Select((v, i) => new { v, i })
                     .Where(x => x.v.Any(y => y != null))
                     .Select(x => "M" + x.i).ToList();
                var maxM = indexes.Max(x => Convert.ToInt32(x.Replace("M", "")));
                List<string> mIndexs = new List<string>();
                int m = 0;
                while (m <= maxM)
                {
                    mIndexs.Add(string.Format("M{0}", m));
                    m++;
                }
                //if ((monthIndexData != null && monthIndexData != 0) || isZero)
                //{
                foreach (var monthIndex in monthIndexs)
                {
                    var monthNo = ConverseMonthNo(param.Criteria.Scenario, monthIndex, param.Criteria.Cycle);
                    var monthIndexDataString = (string?)item.GetType().GetProperty(monthIndex).GetValue(item, null);
                    //decimal? monthIndexData = !string.IsNullOrEmpty(monthIndexDataString) ? decimal.Parse(monthIndexDataString) : mIndexs.Contains(monthIndex) ? 0 : null;

                    decimal? monthIndexData = indexes.FirstOrDefault(f => f == monthIndex) != null ? decimal.Parse(monthIndexDataString) :
                        (mIndexs.Contains(monthIndex) ? 0 : !string.IsNullOrEmpty(monthIndexDataString) ? decimal.Parse(monthIndexDataString) : null);
                    //add
                    var bind = BindFeedPurchaseTempModelToDB(param.Criteria, item, monthIndexData, monthIndex, monthNo);
                    addFeedPurchaseDataList.Add(bind);
                    feedPurchaseList.Add(bind);
                    lstData.Add(new OptienceList { company = item.Company, mcsc = item.MCSC, name = item.FeedName, value = monthIndex });
                }
                //}
            }

            // set Total record
            total = feedPurchaseList.Count();

            #region Call Api

            if (!IsPreview)
            {
                bool isCallApiSuccess = true;
                var pipeLine = CallDataFactory("MBR_TMP_FeedPurchase", "FeedPurchase", param.Criteria.Cycle, param.Criteria.Case, param.Criteria.Scenario, param.Criteria.Company, param.Criteria.isMerge);
                if (pipeLine != "error")
                {
                    runId = new PriceList
                    {
                        name = "FeedPurchase",
                        value = pipeLine
                    };
                }
                else
                {
                    isCallApiSuccess = false;
                    runId = new PriceList { name = "FeedPurchase", value = pipeLine, error = "Cannot Run Pipeline." };
                }
                if (isCallApiSuccess)
                {
                    foreach (var item in feedPurchaseList)
                    {
                        item.RunId = pipeLine;
                    }
                    addFeedPurchaseDataList = addFeedPurchaseDataList.Where(x => x.Price is not null).ToList();
                    if (addFeedPurchaseDataList != null && addFeedPurchaseDataList.Count > 0)
                        _unit.FeedPurchaseTempRepo.BulkInsert(addFeedPurchaseDataList);

                    #region Del Fail DWH Data Temp

                    var dataFactDWHFail = _unit.DataFactoryRunRepo.GetDWHFail("FeedPurchase")?.Select(s => s.RunId).ToList();
                    if (dataFactDWHFail != null && dataFactDWHFail.Count >= 1)
                    {
                        var delFailDWH = feedPurchaseTempRepo.Where(w => dataFactDWHFail.Contains(w.RunId)).ToList();
                        _unit.FeedPurchaseTempRepo.BulkDelete(delFailDWH);
                    }

                    #endregion Del Fail DWH Data Temp

                    #region del tmep after 30 minute

                    var delAfter30minute = _unit.FeedPurchaseTempRepo.FindAfter30minute();
                    if (delAfter30minute != null && delAfter30minute.Count >= 1)
                    {
                        _unit.FeedPurchaseTempRepo.BulkDelete(delAfter30minute);
                    }

                    #endregion del tmep after 30 minute

                    _unit.SaveTransaction();
                }
            }

            //concat data DB

            var groupData = lstData.GroupBy(g => new { g.company, g.mcsc, g.name }).ToList();
            var lstNotUpdate = new List<MBR_TMP_FEED_PURCHASE>();
            foreach (var item in groupData)
            {
                lstNotUpdate.AddRange(feedPurchaseMainRepo.Where(w => w.Company == item.Key.company && w.MCSC == item.Key.mcsc && w.FeedName == item.Key.name && !item.Select(s => s.value).Contains(w.MonthIndex)).Select(s => new MBR_TMP_FEED_PURCHASE(s)).ToList());
            }
            if (lstNotUpdate != null && lstNotUpdate.Count > 0)
            {
                feedPurchaseList.AddRange(lstNotUpdate);
            };

            #endregion Call Api

            #endregion Save Data

            return feedPurchaseList;
        }

        public List<MBR_TMP_PRODUCTION_VOLUME> UploadProductionVolume(DataWitOptienceModel<OptienceCriteriaModel> param, bool IsPreview, out int total, out PriceList runId)
        {
            runId = new PriceList();

            #region Set Id (RowNo) for dataValidates List

            // Set RowId (Row No)
            int row = 0;
            param.ProductionVolumeData.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
            });

            #endregion Set Id (RowNo) for dataValidates List

            #region Create Validate Model & Set Id (RowNo)

            var validateProductionVolumeModels = new List<ProductionVolumeModel>();

            List<PriceList> priceLst = new List<PriceList>();

            var isZero = _unit.MasterMaintainPriceRepo.GetByMaintainId(MASTER_EXCEL_TYPE.PRODUCTION_VOLUME)?.IsZero ?? false;
            var containCompany = _unitSSP.MasterCompanyRepo.GetByShortName(param.ProductionVolumeData.Select(s => s.Company).ToList());
            var containProductMapping = _unit.MasterProductMappingRepo.GetMaterialCode(param.ProductionVolumeData.Select(s => s.MaterialCode).ToList());
            List<MBR_TRN_PRODUCTION_VOLUME> productionVolumeExistingData = new List<MBR_TRN_PRODUCTION_VOLUME>();
            if (param.Criteria.isMerge && param.Criteria.MergeScenario != null && param.Criteria.MergeCase != null && param.Criteria.MergeCycle != null)
            {
                productionVolumeExistingData = _unit.ProductionVolumeRepo.FindByCriterias(param.Criteria.MergeScenario, param.Criteria.MergeCase, param.Criteria.MergeCycle);
            }
            param.ProductionVolumeData.ForEach(i =>
            {
                row++;
                List<MBR_TRN_PRODUCTION_VOLUME> existingDatas = null;
                if (productionVolumeExistingData != null)
                    existingDatas = productionVolumeExistingData.Where(f => f.Company.ToLower() == i.Company.ToLower() && f.ProductName.ToLower() == i.ProductName.ToLower() && f.MCSC.ToLower() == i.MCSC.ToLower()).ToList();
                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToProductionVolumeModel(existingDatas, containProductMapping, containCompany, param.Criteria.isMerge, isZero, out convertErrorList, out convertDataWarningList);

                #region add Price List

                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M0 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M1 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M2 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M3 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M4 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M5 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M6 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M7 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M8 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M9 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M10 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M11 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M12 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M13 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M14 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M15 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M16 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M17 ?? "" });
                priceLst.Add(new PriceList { name = i.Company + "," + i.MCSC + "," + i.ProductName.ToUpper() + "," + convertModel.ProductShortName.ToUpper(), value = i.M18 ?? "" }); ;

                #endregion add Price List

                validateProductionVolumeModels.Add(convertModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            #region Save Data

            #region upload temp

            // Temp

            var addProductionVolumeDataList = new List<MBR_TMP_PRODUCTION_VOLUME>();
            var productionVolumeList = new List<MBR_TMP_PRODUCTION_VOLUME>();

            var productionVolumeRepo = _unit.ProductionVolumeTempRepo.FindByCriterias(param.Criteria.Scenario, param.Criteria.Case, param.Criteria.Cycle);
            var productionVolumeMainRepo = _unit.ProductionVolumeRepo.FindByCriterias(param.Criteria.Scenario, param.Criteria.Case, param.Criteria.Cycle);

            List<string> monthIndexs = Enum.GetValues(typeof(MONTH_INDEX)).Cast<MONTH_INDEX>().Select(v => v.ToString()).ToList();
            var lstData = new List<OptienceList>();

            //add

            foreach (var item in validateProductionVolumeModels)
            {
                var indexes = priceLst.Where(w => w.name.SplitToList(",")[0] == item.Company
                                            && w.name.SplitToList(",")[1] == item.MCSC
                                            && w.name.SplitToList(",")[2] == item.ProductName.ToUpper()
                                            && w.name.SplitToList(",")[3] == item.ProductShortName.ToUpper()).Select(s => s.value).Select((v, i) => new { v, i })
                       .Where(x => x.v.Any(y => y != null))
                       .Select(x => "M" + x.i).ToList();
                var maxM = indexes.Max(x => Convert.ToInt32(x.Replace("M", "")));
                List<string> mIndexs = new List<string>();
                int m = 0;
                while (m <= maxM)
                {
                    mIndexs.Add(string.Format("M{0}", m));
                    m++;
                }
                foreach (var monthIndex in monthIndexs)
                {
                    var monthNo = ConverseMonthNo(param.Criteria.Scenario, monthIndex, param.Criteria.Cycle);
                    var month = int.Parse(monthIndex.Substring(1));

                    var monthIndexDataString = (string?)item.GetType().GetProperty(monthIndex).GetValue(item, null);
                    //decimal? monthIndexData = !string.IsNullOrEmpty(monthIndexDataString) ? decimal.Parse(monthIndexDataString) : (isZero ? 0 : null);

                    decimal? monthIndexData = indexes.FirstOrDefault(f => f == monthIndex) != null ? decimal.Parse(monthIndexDataString) :
                        (mIndexs.Contains(monthIndex) ? 0 : !string.IsNullOrEmpty(monthIndexDataString) ? decimal.Parse(monthIndexDataString) : null);
                    //if ((monthIndexData != null && monthIndexData != 0) || isZero)
                    //{
                    //add
                    var bind = BindProductionVolumeTempModelToDB(param.Criteria, item, monthIndexData, monthIndex, monthNo);
                    if (param.Criteria.isMerge && month > maxM)
                    {
                        bind.MergedWithCycle = param.Criteria.MergeCycle;
                        bind.MergedWithCase = param.Criteria.MergeCase;
                        bind.MergedWithPlanType = param.Criteria.MergeScenario;
                    }
                    addProductionVolumeDataList.Add(bind);
                    productionVolumeList.Add(bind);
                    lstData.Add(new OptienceList { company = item.Company, mcsc = item.MCSC, name = item.ProductName, value = monthIndex });
                    //}
                }
            }

            // set Total record
            total = productionVolumeList.Count();

            #region Call Api

            if (!IsPreview)
            {
                bool isCallApiSuccess = true;

                var pipeLine = param.Criteria.isMerge ?
                               CallDataFactory("MBR_TMP_ProductionVolume", "ProductionVolume", param.Criteria.Cycle, param.Criteria.Case, param.Criteria.Scenario, param.Criteria.Company, param.Criteria.isMerge, param.Criteria.MergeScenario, param.Criteria.MergeCycle, param.Criteria.MergeCase)
                    : CallDataFactory("MBR_TMP_ProductionVolume", "ProductionVolume", param.Criteria.Cycle, param.Criteria.Case, param.Criteria.Scenario, param.Criteria.Company, param.Criteria.isMerge);
                if (pipeLine != "error")
                {
                    runId = new PriceList
                    {
                        name = "ProductionVolume",
                        value = pipeLine
                    };
                }
                else
                {
                    isCallApiSuccess = false;
                    runId = new PriceList { name = "ProductionVolume", value = pipeLine, error = "Cannot Run Pipeline." };
                }
                if (isCallApiSuccess)
                {
                    foreach (var item in productionVolumeList)
                    {
                        item.RunId = pipeLine;
                    }

                    addProductionVolumeDataList = addProductionVolumeDataList.Where(x => x.Price is not null).ToList();
                    if (addProductionVolumeDataList != null && addProductionVolumeDataList.Count > 0)
                        _unit.ProductionVolumeTempRepo.BulkInsert(addProductionVolumeDataList);

                    #region Del Fail DWH Data Temp

                    var dataFactDWHFail = _unit.DataFactoryRunRepo.GetDWHFail("ProductionVolume")?.Select(s => s.RunId).ToList();
                    if (dataFactDWHFail != null && dataFactDWHFail.Count >= 1)
                    {
                        var delFailDWH = productionVolumeRepo.Where(w => dataFactDWHFail.Contains(w.RunId)).ToList();
                        _unit.ProductionVolumeTempRepo.BulkDelete(delFailDWH);
                    }

                    #endregion Del Fail DWH Data Temp

                    #region del tmep after 30 minute

                    var delAfter30minute = _unit.ProductionVolumeTempRepo.FindAfter30minute();
                    if (delAfter30minute != null && delAfter30minute.Count >= 1)
                    {
                        _unit.ProductionVolumeTempRepo.BulkDelete(delAfter30minute);
                    }

                    #endregion del tmep after 30 minute

                    _unit.SaveTransaction();
                }
            }

            //concat data DB

            var groupData = lstData.GroupBy(g => new { g.company, g.mcsc, g.name }).ToList();
            var lstNotUpdate = new List<MBR_TMP_PRODUCTION_VOLUME>();
            foreach (var item in groupData)
            {
                lstNotUpdate.AddRange(productionVolumeMainRepo.Where(w => w.Company == item.Key.company && w.MCSC == item.Key.mcsc && w.ProductName == item.Key.name && !item.Select(s => s.value).Contains(w.MonthIndex)).Select(s => new MBR_TMP_PRODUCTION_VOLUME(s)).ToList());
            }
            if (lstNotUpdate != null && lstNotUpdate.Count > 0)
            {
                productionVolumeList.AddRange(lstNotUpdate);
            };

            #endregion Call Api

            #endregion upload temp

            #endregion Save Data

            return productionVolumeList;
        }

        public List<MBR_TMP_BEGINING_INVENTORY> UploadBeginningInventory(DataWitOptienceModel<OptienceCriteriaModel> param, bool IsPreview, out int total, out PriceList runId)
        {
            runId = new PriceList();

            #region Set Id (RowNo) for dataValidates List

            // Set RowId (Row No)
            int row = 0;
            param.BeginningInventoryData.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
            });

            #endregion Set Id (RowNo) for dataValidates List

            #region Create Validate Model & Set Id (RowNo)

            var isZero = _unit.MasterMaintainPriceRepo.GetByMaintainId(MASTER_EXCEL_TYPE.BEGINNING_INVENTORY)?.IsZero ?? false;
            var validateBeginningInventoryModels = new List<BeginningInventoryModel>();
            var containCompany = _unitSSP.MasterCompanyRepo.GetByShortName(param.BeginningInventoryData.Select(s => s.Company).ToList());
            //var containProductMapping = _unit.MasterProductMappingRepo.GetProductShortName(param.BeginningInventoryData.Select(s => s.ProductShortName).ToList());
            var containProductMapping = _unit.MasterProductMappingRepo.GetMaterialCode(param.BeginningInventoryData.Select(s => s.MaterialCode).ToList());
            var contaiCustomerVendorMapping = _unit.MasterCustomerVendorMappingRepo.GetCustomerShortName(param.BeginningInventoryData.Select(s => s.SupplierKey).ToList());
            List<MBR_TRN_BEGINING_INVENTORY> beginningInventoryExistingData = new List<MBR_TRN_BEGINING_INVENTORY>();
            if (param.Criteria.isMerge && param.Criteria.MergeScenario != null && param.Criteria.MergeCase != null && param.Criteria.MergeCycle != null)
            {
                beginningInventoryExistingData = _unit.BeginningInventoryRepo.FindByCriterias(param.Criteria.MergeScenario, param.Criteria.MergeCase, param.Criteria.MergeCycle);
            }
            param.BeginningInventoryData.ForEach(i =>
            {
                row++;
                List<MBR_TRN_BEGINING_INVENTORY> existingDatas = null;
                if (beginningInventoryExistingData != null)
                    existingDatas = beginningInventoryExistingData.Where(f => f.ProductShortName.ToLower() == i.ProductShortName.ToLower() && f.MCSC.ToLower() == i.MCSC.ToLower() && f.MaterialCode.ToLower() == i.MaterialCode.ToLower() && f.SupplierKey.ToLower() == i.SupplierKey.ToLower()).ToList();
                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToBeginningInventoryModel(existingDatas, containProductMapping, containCompany, contaiCustomerVendorMapping, param.Criteria.isMerge, isZero, out convertErrorList, out convertDataWarningList);

                validateBeginningInventoryModels.Add(convertModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            #region Save Data

            #region upload temp

            // Temp

            var addBeginningInventoryDataList = new List<MBR_TMP_BEGINING_INVENTORY>();
            var beginningInventoryList = new List<MBR_TMP_BEGINING_INVENTORY>();

            var beginningInventoryRepo = _unit.BeginningInventoryTempRepo.FindByCriterias(param.Criteria.Scenario, param.Criteria.Case, param.Criteria.Cycle);
            var beginningInventoryMainRepo = _unit.BeginningInventoryRepo.FindByCriterias(param.Criteria.Scenario, param.Criteria.Case, param.Criteria.Cycle);
            var lstData = new List<BeginningInventoryList>();

            //add
            foreach (var item in validateBeginningInventoryModels)
            {
                var monthIndexDataString = item.M0;
                var monthIndex = "M0";
                var monthNo = ConverseMonthNo(param.Criteria.Scenario, monthIndex, param.Criteria.Cycle);
                decimal? monthIndexData = !string.IsNullOrEmpty(monthIndexDataString) ? decimal.Parse(monthIndexDataString) : null;
                //var dbUpdate = beginningInventoryRepo.FirstOrDefault(f => f.Company.ToLower() == item.Company.ToLower() && f.ProductShortName == item.ProductShortName && f.MCSC.ToLower() == item.MCSC.ToLower() && f.MonthIndex == monthIndex);
                //var dbMainUpdate = beginningInventoryMainRepo.FirstOrDefault(f => f.Company.ToLower() == item.Company.ToLower() && f.ProductShortName == item.ProductShortName && f.MCSC.ToLower() == item.MCSC.ToLower() && f.MonthIndex == monthIndex);
                //if ((monthIndexData != null && monthIndexData != 0) || isZero)
                //{
                //add
                var bind = BindBeginningInventoryTempModelToDB(param.Criteria, item, monthIndexData, monthIndex, monthNo);

                addBeginningInventoryDataList.Add(bind);
                beginningInventoryList.Add(bind);
                lstData.Add(new BeginningInventoryList { mcsc = item.MCSC, name = item.ProductShortName, materialCode = item.MaterialCode, supplierKey = item.SupplierKey, value = monthIndex });
                //}
            }

            // set Total record
            total = beginningInventoryList.Count();

            #region Call Api

            if (!IsPreview)
            {
                bool isCallApiSuccess = true;
                var pipeLine = CallDataFactory("MBR_TMP_BeginningInventory", "BeginningInventory", param.Criteria.Cycle, param.Criteria.Case, param.Criteria.Scenario, param.Criteria.Company, param.Criteria.isMerge);
                if (pipeLine != "error")
                {
                    runId = new PriceList
                    {
                        name = "BeginningInventory",
                        value = pipeLine
                    };
                }
                else
                {
                    isCallApiSuccess = false;
                    runId = new PriceList { name = "BeginningInventory", value = pipeLine, error = "Cannot Run Pipeline." };
                }
                if (isCallApiSuccess)
                {
                    foreach (var item in beginningInventoryList)
                    {
                        item.RunId = pipeLine;
                    }

                    addBeginningInventoryDataList = addBeginningInventoryDataList.Where(x => x.Price is not null).ToList();
                    if (addBeginningInventoryDataList != null && addBeginningInventoryDataList.Count > 0)
                        _unit.BeginningInventoryTempRepo.BulkInsert(addBeginningInventoryDataList);

                    #region Del Fail DWH Data Temp

                    var dataFactDWHFail = _unit.DataFactoryRunRepo.GetDWHFail("BeginningInventory")?.Select(s => s.RunId).ToList();
                    if (dataFactDWHFail != null && dataFactDWHFail.Count >= 1)
                    {
                        var delFailDWH = beginningInventoryRepo.Where(w => dataFactDWHFail.Contains(w.RunId)).ToList();
                        _unit.BeginningInventoryTempRepo.BulkDelete(delFailDWH);
                    }

                    #endregion Del Fail DWH Data Temp

                    #region del tmep after 30 minute

                    var delAfter30minute = _unit.BeginningInventoryTempRepo.FindAfter30minute();
                    if (delAfter30minute != null && delAfter30minute.Count >= 1)
                    {
                        _unit.BeginningInventoryTempRepo.BulkDelete(delAfter30minute);
                    }

                    #endregion del tmep after 30 minute

                    _unit.SaveTransaction();
                }
            }

            //concat data DB

            var groupData = lstData.GroupBy(g => new { g.mcsc, g.name, g.materialCode, g.supplierKey }).ToList();
            var lstNotUpdate = new List<MBR_TMP_BEGINING_INVENTORY>();
            foreach (var item in groupData)
            {
                lstNotUpdate.AddRange(beginningInventoryMainRepo.Where(w => w.MCSC == item.Key.mcsc && w.ProductShortName == item.Key.name && w.MaterialCode == item.Key.materialCode && w.SupplierKey == item.Key.supplierKey && !item.Select(s => s.value).Contains(w.MonthIndex)).Select(s => new MBR_TMP_BEGINING_INVENTORY(s)).ToList());
            }
            if (lstNotUpdate != null && lstNotUpdate.Count > 0)
            {
                beginningInventoryList.AddRange(lstNotUpdate);
            };

            #endregion Call Api

            #endregion upload temp

            #endregion Save Data

            return beginningInventoryList;
        }

        private MBR_TRN_BEGINING_INVENTORY BindBeginningInventoryModelToDB(OptienceCriteriaModel criteria, BeginningInventoryModel item, decimal? price, string monthIndex, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.Scenario == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TRN_BEGINING_INVENTORY()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                PlanType = criteria.Scenario,
                MCSC = item.MCSC,
                Company = item.Company,
                InventoryName = item.InventoryName,
                TankNumber = item.TankNumber,
                ProductShortName = item.ProductShortName,
                MaterialCode = item.MaterialCode,
                SupplierKey = item.SupplierKey,
                SupplierCode = item.SupplierCode,
                ElementCodeEBA = item.ElementCode,
                MonthIndex = monthIndex,
                MonthNo = monthNo,
                Price = price,
                CreatedBy = userLogin,
                CyclePoly = cyclePoly,
                CreatedDate = DateTime.Now
            };
            return newData;
        }

        private MBR_TMP_BEGINING_INVENTORY BindBeginningInventoryTempModelToDB(OptienceCriteriaModel criteria, BeginningInventoryModel item, decimal? price, string monthIndex, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.Scenario == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TMP_BEGINING_INVENTORY()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                PlanType = criteria.Scenario,
                MCSC = item.MCSC,
                Company = item.Company,
                InventoryName = item.InventoryName,
                TankNumber = item.TankNumber,
                ProductShortName = item.ProductShortName,
                MaterialCode = item.MaterialCode,
                SupplierKey = item.SupplierKey,
                SupplierCode = item.SupplierCode,
                ElementCodeEBA = item.ElementCode,
                MonthIndex = monthIndex,
                MonthNo = monthNo,
                Price = price,
                CreatedBy = userLogin,
                CyclePoly = cyclePoly,
                CreatedDate = DateTime.Now
            };
            return newData;
        }

        private MBR_TRN_PRODUCTION_VOLUME BindProductionVolumeModelToDB(OptienceCriteriaModel criteria, ProductionVolumeModel item, decimal? price, string monthIndex, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.Scenario == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TRN_PRODUCTION_VOLUME()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                PlanType = criteria.Scenario,
                MCSC = item.MCSC,
                Company = item.Company,
                ProductName = item.ProductName,
                ElementCodeEBA = item.ElementCode,
                ProductShortName = item.ProductShortName,
                MonthIndex = monthIndex,
                MonthNo = monthNo,
                Price = price,
                CreatedBy = userLogin,
                CyclePoly = cyclePoly,
                CreatedDate = DateTime.Now,
                MaterialCode = item.MaterialCode
            };
            return newData;
        }

        private MBR_TMP_PRODUCTION_VOLUME BindProductionVolumeTempModelToDB(OptienceCriteriaModel criteria, ProductionVolumeModel item, decimal? price, string monthIndex, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.Scenario == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TMP_PRODUCTION_VOLUME()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                PlanType = criteria.Scenario,
                MCSC = item.MCSC,
                Company = item.Company,
                ProductName = item.ProductName,
                ElementCodeEBA = item.ElementCode,
                ProductShortName = item.ProductShortName,
                MonthIndex = monthIndex,
                MonthNo = monthNo,
                Price = price,
                CreatedBy = userLogin,
                CyclePoly = cyclePoly,
                CreatedDate = DateTime.Now,
                MaterialCode = item.MaterialCode
            };
            return newData;
        }

        private MBR_TMP_FEED_PURCHASE BindFeedPurchaseTempModelToDB(OptienceCriteriaModel criteria, FeedPurchaseModel item, decimal? price, string monthIndex, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.Scenario == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TMP_FEED_PURCHASE()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                PlanType = criteria.Scenario,
                MCSC = item.MCSC,
                Company = item.Company,
                SupplierKey = item.SupplierKey,
                SupplierCode = item.SupplierCode,
                FeedShortName = item.FeedShortName,
                ElementCodeEBA = item.ElementCode,
                FeedName = item.FeedName,
                MonthIndex = monthIndex,
                Price = price,
                CreatedBy = userLogin,
                CyclePoly = cyclePoly,
                MonthNo = monthNo,
                CreatedDate = DateTime.Now,
                MaterialCode = item.MaterialCode
            };
            return newData;
        }

        private MBR_TRN_FEED_PURCHASE BindFeedPurchaseModelToDB(OptienceCriteriaModel criteria, FeedPurchaseModel item, decimal? price, string monthIndex, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.Scenario == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TRN_FEED_PURCHASE()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                PlanType = criteria.Scenario,
                MCSC = item.MCSC,
                Company = item.Company,
                SupplierKey = item.SupplierKey,
                SupplierCode = item.SupplierCode,
                FeedShortName = item.FeedShortName,
                ElementCodeEBA = item.ElementCode,
                FeedName = item.FeedName,
                MonthIndex = monthIndex,
                MonthNo = monthNo,
                Price = price,
                CreatedBy = userLogin,
                CyclePoly = cyclePoly,
                CreatedDate = DateTime.Now,
                MaterialCode = item.MaterialCode
            };
            return newData;
        }

        private MBR_TMP_FEED_CONSUMPTION BindFeedConsumptionTempModelToDB(OptienceCriteriaModel criteria, FeedConsumptionModel item, decimal? price, string monthIndex, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.Scenario == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TMP_FEED_CONSUMPTION()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                PlanType = criteria.Scenario,
                MCSC = item.MCSC,
                Company = item.Company,
                SupplierKey = item.SupplierKey,
                SupplierCode = item.SupplierCode,
                FeedShortName = item.FeedShortName,
                ElementCodeEBA = item.ElementCode,
                FeedName = item.FeedName,
                MonthIndex = monthIndex,
                MonthNo = monthNo,
                Price = price,
                CreatedBy = userLogin,
                CyclePoly = cyclePoly,
                CreatedDate = DateTime.Now,
                MaterialCode = item.MaterialCode
            };
            return newData;
        }

        private MBR_TRN_FEED_CONSUMPTION BindFeedConsumptionModelToDB(OptienceCriteriaModel criteria, FeedConsumptionModel item, decimal? price, string monthIndex, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.Scenario == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TRN_FEED_CONSUMPTION()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                PlanType = criteria.Scenario,
                MCSC = item.MCSC,
                Company = item.Company,
                SupplierKey = item.SupplierKey,
                SupplierCode = item.SupplierCode,
                FeedShortName = item.FeedShortName,
                ElementCodeEBA = item.ElementCode,
                FeedName = item.FeedName,
                MonthIndex = monthIndex,
                MonthNo = monthNo,
                Price = price,
                CreatedBy = userLogin,
                CyclePoly = cyclePoly,
                CreatedDate = DateTime.Now,
                MaterialCode = item.MaterialCode
            };
            return newData;
        }

        public List<OptienceDownloadResponse> PreviewOptience(DataWitOptienceModel<OptienceCriteriaModel> param)
        {
            var res = new List<OptienceDownloadResponse>();
            var result = new OptiencePreviewResponse();
            int total = 0;
            PriceList runId = new PriceList();
            if (param.ProductionVolumeData.Count >= 1)
            {
                var dataProductionVolume = UploadProductionVolume(param, true, out total, out runId);
                var excelMapping = _unit.MasterExcelMappingRepo.GetMapping(APPCONSTANT.MASTER_EXCEL_TYPE.PRODUCTION_VOLUME).OrderBy(o => o.Sequence).ToList();
                var resultProductionVolume = new List<ProductionVolumePreviewModel>();

                var proGroup = dataProductionVolume.GroupBy(g => new { g.Company, g.MCSC, g.ProductName, g.ProductShortName, g.ElementCodeEBA }).ToList();
                foreach (var data in proGroup)
                {
                    var mapData = new ProductionVolumePreviewModel();
                    //foreach (var item in group)
                    //{
                    //    PropertyInfo prop = mapData.GetType().GetProperty(item.MonthIndex, BindingFlags.Public | BindingFlags.Instance);
                    //    if (null != prop && prop.CanWrite)
                    //    {
                    //        prop.SetValue(mapData, item.Price, null);
                    //    }
                    //}

                    mapData.HeaderList = (from g in data
                                          select new HeaderListItem()
                                          {
                                              Cycle = String.IsNullOrEmpty(g.MergedWithCycle) ? g.Cycle : g.MergedWithCycle,
                                              MonthNo = g.MonthNo,
                                              Header = excelMapping.Where(x => x.ExcelHeader == g.MonthIndex).Select(s => s.Variable).FirstOrDefault() ?? g.MonthIndex?.ToLower(),
                                              Value = g.Price
                                          }
                                    ).ToList();

                    var lastUpdate = data.OrderByDescending(b => b.UpdatedDate).FirstOrDefault();

                    mapData.Company = lastUpdate?.Company;
                    mapData.MCSC = lastUpdate?.MCSC;
                    mapData.ElementCode = lastUpdate?.ElementCodeEBA;
                    mapData.ProductName = lastUpdate?.ProductName;
                    mapData.ProductShortName = lastUpdate?.ProductShortName;
                    mapData.MaterialCode = lastUpdate?.MaterialCode;
                    resultProductionVolume.Add(mapData);
                }
                result.ProductionVolumeData = resultProductionVolume;
                res.Add(new OptienceDownloadResponse
                {
                    OptienceData = resultProductionVolume,
                    OptienceTypeId = MASTER_EXCEL_TYPE.PRODUCTION_VOLUME,
                    OptienceMapping = _unit.MasterExcelMappingRepo.GetMapping(MASTER_EXCEL_TYPE.PRODUCTION_VOLUME, true)
                });
            }
            if (param.FeedConsumptionData.Count >= 1)
            {
                var dataCopyConsumption = UploadFeedConsumptionData(param, true, out total, out runId);
                var excelMapping = _unit.MasterExcelMappingRepo.GetMapping(APPCONSTANT.MASTER_EXCEL_TYPE.FEED_CONSUMPTION).OrderBy(o => o.Sequence).ToList();

                var resultFeedConsumption = new List<FeedConsumptionPreviewModel>();

                var proGroup = dataCopyConsumption.GroupBy(g => new { g.Company, g.MCSC, g.FeedName, g.FeedShortName, g.SupplierKey, g.ElementCodeEBA }).ToList();
                foreach (var data in proGroup)
                {
                    var mapData = new FeedConsumptionPreviewModel();
                    //foreach (var item in group)
                    //{
                    //    PropertyInfo prop = mapData.GetType().GetProperty(item.MonthIndex, BindingFlags.Public | BindingFlags.Instance);
                    //    if (null != prop && prop.CanWrite)
                    //    {
                    //        prop.SetValue(mapData, item.Price, null);
                    //    }
                    //}

                    mapData.HeaderList = (from g in data
                                          select new HeaderListItem()
                                          {
                                              Cycle = String.IsNullOrEmpty(g.MergedWithCycle) ? g.Cycle : g.MergedWithCycle,
                                              MonthNo = g.MonthNo,
                                              Header = excelMapping.Where(x => x.ExcelHeader == g.MonthIndex).Select(s => s.Variable).FirstOrDefault() ?? g.MonthIndex?.ToLower(),
                                              Value = g.Price
                                          }
                                    ).ToList();

                    var lastUpdate = data.OrderByDescending(b => b.UpdatedDate).FirstOrDefault();

                    mapData.Company = lastUpdate?.Company;
                    mapData.MCSC = lastUpdate?.MCSC;
                    mapData.ElementCode = lastUpdate?.ElementCodeEBA;
                    mapData.FeedName = lastUpdate?.FeedName;
                    mapData.FeedShortName = lastUpdate?.FeedShortName;
                    mapData.SupplierKey = lastUpdate?.SupplierKey;
                    mapData.SupplierCode = lastUpdate?.SupplierCode;
                    mapData.MaterialCode = lastUpdate?.MaterialCode;
                    resultFeedConsumption.Add(mapData);
                }
                result.FeedConsumptionData = resultFeedConsumption;
                res.Add(new OptienceDownloadResponse
                {
                    OptienceData = resultFeedConsumption,
                    OptienceTypeId = MASTER_EXCEL_TYPE.FEED_CONSUMPTION,
                    OptienceMapping = _unit.MasterExcelMappingRepo.GetMapping(MASTER_EXCEL_TYPE.FEED_CONSUMPTION, true)
                });
            }
            if (param.BeginningInventoryData.Count >= 1)
            {
                var dataCopyBeginningInventory = UploadBeginningInventory(param, true, out total, out runId);
                var excelMapping = _unit.MasterExcelMappingRepo.GetMapping(APPCONSTANT.MASTER_EXCEL_TYPE.BEGINNING_INVENTORY).OrderBy(o => o.Sequence).ToList();

                var resultBeginningInventory = new List<BeginningInventoryPreviewModel>();

                var proGroup = dataCopyBeginningInventory.GroupBy(g => new { g.MCSC, g.ProductShortName, g.MaterialCode, g.SupplierKey }).ToList();
                foreach (var data in proGroup)
                {
                    var mapData = new BeginningInventoryPreviewModel();
                    //foreach (var item in group)
                    //{
                    //    PropertyInfo prop = mapData.GetType().GetProperty(item.MonthIndex, BindingFlags.Public | BindingFlags.Instance);
                    //    if (null != prop && prop.CanWrite)
                    //    {
                    //        prop.SetValue(mapData, item.Price, null);
                    //    }
                    //}

                    mapData.HeaderList = (from g in data
                                          select new HeaderListItem()
                                          {
                                              Cycle = g.Cycle,
                                              MonthNo = g.MonthNo,
                                              Header = excelMapping.Where(x => x.ExcelHeader == g.MonthIndex).Select(s => s.Variable).FirstOrDefault() ?? g.MonthIndex?.ToLower(),
                                              Value = g.Price
                                          }
                                    ).ToList();

                    var lastUpdate = data.OrderByDescending(b => b.UpdatedDate).FirstOrDefault();

                    mapData.Company = lastUpdate?.Company;
                    mapData.MCSC = lastUpdate?.MCSC;
                    mapData.ProductShortName = lastUpdate?.ProductShortName;
                    mapData.InventoryName = lastUpdate?.InventoryName;
                    mapData.TankNumber = lastUpdate?.TankNumber;
                    mapData.MaterialCode = lastUpdate?.MaterialCode;
                    mapData.SupplierKey = lastUpdate?.SupplierKey;
                    mapData.SupplierCode = lastUpdate?.SupplierCode;
                    mapData.ElementCode = lastUpdate?.ElementCodeEBA;
                    resultBeginningInventory.Add(mapData);
                }
                result.BeginningInventoryData = resultBeginningInventory;
                res.Add(new OptienceDownloadResponse
                {
                    OptienceData = resultBeginningInventory,
                    OptienceTypeId = MASTER_EXCEL_TYPE.BEGINNING_INVENTORY,
                    OptienceMapping = _unit.MasterExcelMappingRepo.GetMapping(MASTER_EXCEL_TYPE.BEGINNING_INVENTORY, true)
                });
            }
            if (param.FeedPurchaseData.Count >= 1)
            {
                var dataCopyPurchase = UploadFeedPurchase(param, true, out total, out runId);
                var excelMapping = _unit.MasterExcelMappingRepo.GetMapping(APPCONSTANT.MASTER_EXCEL_TYPE.FEED_PURCHASE).OrderBy(o => o.Sequence).ToList();
                var resultFeedPurchase = new List<FeedPurchasePreviewModel>();

                var proGroup = dataCopyPurchase.GroupBy(g => new { g.Company, g.MCSC, g.FeedName, g.FeedShortName, g.SupplierKey, g.ElementCodeEBA }).ToList();
                foreach (var data in proGroup)
                {
                    var mapData = new FeedPurchasePreviewModel();
                    //foreach (var item in group)
                    //{
                    //    PropertyInfo prop = mapData.GetType().GetProperty(item.MonthIndex, BindingFlags.Public | BindingFlags.Instance);
                    //    if (null != prop && prop.CanWrite)
                    //    {
                    //        prop.SetValue(mapData, item.Price, null);
                    //    }
                    //}

                    mapData.HeaderList = (from g in data
                                          select new HeaderListItem()
                                          {
                                              Cycle = g.Cycle,
                                              MonthNo = g.MonthNo,
                                              Header = excelMapping.Where(x => x.ExcelHeader == g.MonthIndex).Select(s => s.Variable).FirstOrDefault() ?? g.MonthIndex?.ToLower(),
                                              Value = g.Price
                                          }
                                    ).ToList();

                    var lastUpdate = data.OrderByDescending(b => b.UpdatedDate).FirstOrDefault();

                    mapData.Company = lastUpdate?.Company;
                    mapData.MCSC = lastUpdate?.MCSC;
                    mapData.ElementCode = lastUpdate?.ElementCodeEBA;
                    mapData.FeedName = lastUpdate?.FeedName;
                    mapData.FeedShortName = lastUpdate?.FeedShortName;
                    mapData.SupplierKey = lastUpdate?.SupplierKey;
                    mapData.SupplierCode = lastUpdate?.SupplierCode;
                    mapData.MaterialCode = lastUpdate?.MaterialCode;
                    resultFeedPurchase.Add(mapData);
                }
                result.FeedPurchaseData = resultFeedPurchase;
                res.Add(new OptienceDownloadResponse
                {
                    OptienceData = resultFeedPurchase,
                    OptienceTypeId = MASTER_EXCEL_TYPE.FEED_PURCHASE,
                    OptienceMapping = _unit.MasterExcelMappingRepo.GetMapping(MASTER_EXCEL_TYPE.FEED_PURCHASE, true)
                });
            }

            return res;
        }

        private string ConverseMonthNo(string scenario, string monthIndex, string cycle)
        {
            var format = "{0}-{1}";
            var month = int.Parse(monthIndex.Substring(1));
            cycle = cycle.Substring(cycle.IndexOf("_") + 1);
            if (scenario == SCENATIO.M18 || scenario == SCENATIO.W1 || scenario == SCENATIO.W3 || scenario.ToUpper() == SCENATIO.WEEKLY.ToUpper())
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
    }
}