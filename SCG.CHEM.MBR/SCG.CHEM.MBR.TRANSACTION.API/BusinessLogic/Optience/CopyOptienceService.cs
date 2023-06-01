using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
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
    public class CopyOptienceService : ICopyOptienceService
    {
        private readonly UnitOfWork _unit;
        private readonly string userLogin;
        private readonly IDataFactoryService _dataFactoryService;

        public CopyOptienceService(UnitOfWork unitOfWork, IDataFactoryService dataFactoryService)
        {
            this._unit = unitOfWork;
            this.userLogin = UserUtilities.GetADAccount()?.UserId ?? "";
            this._dataFactoryService = dataFactoryService;
        }

        public string CallDataFactory(string tableName, string transactionName, string cycleName, string caseName, string planType, List<String> company, bool isMerge = false)
        {
            string userName = UserUtilities.GetADAccount()?.UserId ?? "";
            string res = _dataFactoryService.RunPipelineOptience(tableName, transactionName, cycleName, caseName, planType, company, isMerge, userName);

            return res;
        }

        #region CopyOptience

        private List<MBR_TMP_FEED_CONSUMPTION> CopyFeedConsumption(OptienceCopyRequest param, bool IsPreview, out int total, out PriceList runId)
        {
            runId = new PriceList();
            var company = param.CompanyFrom;
            if (company.Count == 0)
            {
                company = _unit.MasterCompanyRepo.GetCompany().Where(w => w.text != APPCONSTANT.DROPDOWN.ALL).Select(s => s.text).ToList();
            }
            var feedConsumptionFromRepo = _unit.FeedConsumptionRepo.FindByCriterias(param.ScenarioFrom, param.CaseFrom, param.CycleFrom, company);
            var feedConsumptionToRepo = _unit.FeedConsumptionTempRepo.FindByCriterias(param.ScenarioTo, param.CaseTo, param.CycleTo);
            var feedConsumptionToMainRepo = _unit.FeedConsumptionRepo.FindByCriterias(param.ScenarioTo, param.CaseTo, param.CycleTo);

            #region save data

            var addMarketDataList = new List<MBR_TMP_FEED_CONSUMPTION>();
            var feedDataList = new List<MBR_TMP_FEED_CONSUMPTION>();
            var feedTrntList = new List<MBR_TRN_FEED_CONSUMPTION>();
            //add
            if (feedConsumptionFromRepo.Count <= 0)
            {
                throw new Exception("No feed consumption based on your selected criteria.");
            }

            foreach (var item in feedConsumptionFromRepo)
            {
                //var feedConsumptionUpdate = feedConsumptionToRepo.FirstOrDefault(f => f.MonthIndex == item.MonthIndex && f.Company.ToLower() == item.Company.ToLower() && f.MCSC.ToLower() == item.MCSC.ToLower() && f.FeedName.ToLower() == item.FeedName.ToLower());

                //var feedConsumptionMainUpdate = feedConsumptionToMainRepo.FirstOrDefault(f => f.MonthIndex == item.MonthIndex && f.Company.ToLower() == item.Company.ToLower() && f.MCSC.ToLower() == item.MCSC.ToLower() && f.FeedName.ToLower() == item.FeedName.ToLower());

                var bind = BindFeedConsumptionTempModelToDB(new OptienceCriteriaModel()
                {
                    Case = param.CaseTo,
                    Cycle = param.CycleTo,
                    Scenario = param.ScenarioTo
                }, item, item.Price, item.MonthIndex, item.MonthNo);

                bind.CopiedFromCycle = param.CycleFrom;
                bind.CopiedFromPlanType = param.ScenarioFrom;
                bind.CopiedFromCase = param.CaseFrom;
                addMarketDataList.Add(bind);
                feedDataList.Add(bind);
            }
            // set Total record
            total = feedDataList.Count();

            #region Call Api

            if (!IsPreview)
            {
                bool isCallApiSuccess = true;
                var pipeLine = CallDataFactory("MBR_TMP_FeedConsumption", "FeedConsumption", param.CycleTo, param.CaseTo, param.ScenarioTo, param.CompanyFrom);
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
                    foreach (var item in feedDataList)
                    {
                        item.RunId = pipeLine;
                    }

                    if (addMarketDataList != null && addMarketDataList.Count > 0)
                        _unit.FeedConsumptionTempRepo.Add(addMarketDataList);

                    #region Del Fail DWH Data Temp

                    var dataFactDWHFail = _unit.DataFactoryRunRepo.GetDWHFail("FeedConsumption")?.Select(s => s.RunId).ToList();
                    if (dataFactDWHFail != null && dataFactDWHFail.Count >= 1)
                    {
                        var delFailDWH = feedConsumptionToRepo.Where(w => dataFactDWHFail.Contains(w.RunId)).ToList();
                        _unit.FeedConsumptionTempRepo.BulkDelete(delFailDWH);
                    }

                    #endregion Del Fail DWH Data Temp

                    _unit.SaveTransaction();
                }
            }

            //concat data DB

            #endregion Call Api

            #endregion save data

            return feedDataList;
        }

        private List<MBR_TMP_FEED_PURCHASE> CopyFeedPurchase(OptienceCopyRequest param, bool IsPreview, out int total, out PriceList runId)
        {
            runId = new PriceList();
            var company = param.CompanyFrom;
            if (company.Count == 0)
            {
                company = _unit.MasterCompanyRepo.GetCompany().Where(w => w.text != APPCONSTANT.DROPDOWN.ALL).Select(s => s.text).ToList();
            }
            var feedPurchaseFromRepo = _unit.FeedPurchaseRepo.FindByCriteria(param.ScenarioFrom, param.CaseFrom, param.CycleFrom, company);
            var feedPurchaseToRepo = _unit.FeedPurchaseTempRepo.FindByCriterias(param.ScenarioTo, param.CaseTo, param.CycleTo);
            var feedPurchaseToMainRepo = _unit.FeedPurchaseRepo.FindByCriteria(param.ScenarioTo, param.CaseTo, param.CycleTo);

            #region save data

            var addFeedDataList = new List<MBR_TMP_FEED_PURCHASE>();
            var feedDataList = new List<MBR_TMP_FEED_PURCHASE>();
            var feedTrntList = new List<MBR_TRN_FEED_PURCHASE>();
            //add
            if (feedPurchaseFromRepo.Count <= 0)
            {
                throw new Exception("No feed purchase based on your selected criteria.");
            }
            foreach (var item in feedPurchaseFromRepo)
            {
                var monthNo = ConverseMonthNo(param.ScenarioTo, item.MonthIndex, param.CycleTo);

                //var feedPurchasepdate = feedPurchaseToRepo.FirstOrDefault(f => f.MonthIndex == item.MonthIndex && f.Company.ToLower() == item.Company.ToLower() && f.MCSC.ToLower() == item.MCSC.ToLower() && f.FeedName.ToLower() == item.FeedName.ToLower());

                //var feedPurchaseMainUpdate = feedPurchaseToMainRepo.FirstOrDefault(f => f.MonthIndex == item.MonthIndex && f.Company.ToLower() == item.Company.ToLower() && f.MCSC.ToLower() == item.MCSC.ToLower() && f.FeedName.ToLower() == item.FeedName.ToLower());

                //add
                var bind = BindFeedPurchaseTempModelToDB(new OptienceCriteriaModel()
                {
                    Case = param.CaseTo,
                    Cycle = param.CycleTo,
                    Scenario = param.ScenarioTo
                }, item, item.Price, item.MonthIndex, item.MonthNo);

                bind.CopiedFromCycle = param.CycleFrom;
                bind.CopiedFromPlanType = param.ScenarioFrom;
                bind.CopiedFromCase = param.CaseFrom;
                addFeedDataList.Add(bind);
                feedDataList.Add(bind);
            }

            // set Total record
            total = feedDataList.Count();

            #region Call Api

            if (!IsPreview)
            {
                bool isCallApiSuccess = true;
                var pipeLine = CallDataFactory("MBR_TMP_FeedPurchase", "FeedPurchase", param.CycleTo, param.CaseTo, param.ScenarioTo, param.CompanyFrom.ToList());
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
                    foreach (var item in feedDataList)
                    {
                        item.RunId = pipeLine;
                    }

                    if (addFeedDataList != null && addFeedDataList.Count > 0)
                        _unit.FeedPurchaseTempRepo.Add(addFeedDataList);

                    #region Del Fail DWH Data Temp

                    var dataFactDWHFail = _unit.DataFactoryRunRepo.GetDWHFail("FeedPurchase")?.Select(s => s.RunId).ToList();
                    if (dataFactDWHFail != null && dataFactDWHFail.Count >= 1)
                    {
                        var delFailDWH = feedPurchaseToRepo.Where(w => dataFactDWHFail.Contains(w.RunId)).ToList();
                        _unit.FeedPurchaseTempRepo.BulkDelete(delFailDWH);
                    }

                    #endregion Del Fail DWH Data Temp

                    _unit.SaveTransaction();
                }
            }

            //concat data DB

            #endregion Call Api

            #endregion save data

            return feedDataList;
        }

        private List<MBR_TMP_PRODUCTION_VOLUME> CopyProductionVolume(OptienceCopyRequest param, bool IsPreview, out int total, out PriceList runId)
        {
            runId = new PriceList();
            var company = param.CompanyFrom;
            if (company.Count == 0)
            {
                company = _unit.MasterCompanyRepo.GetCompany().Where(w => w.text != APPCONSTANT.DROPDOWN.ALL).Select(s => s.text).ToList();
            }
            var productionVolumeFromRepo = _unit.ProductionVolumeRepo.FindByCriterias(param.ScenarioFrom, param.CaseFrom, param.CycleFrom, company);
            var productionVolumeToRepo = _unit.ProductionVolumeTempRepo.FindByCriterias(param.ScenarioTo, param.CaseTo, param.CycleTo);
            var productionVolumeToMainRepo = _unit.ProductionVolumeRepo.FindByCriterias(param.ScenarioTo, param.CaseTo, param.CycleTo);

            #region save data

            var addFeedDataList = new List<MBR_TMP_PRODUCTION_VOLUME>();
            var proDataList = new List<MBR_TMP_PRODUCTION_VOLUME>();
            var proTrntList = new List<MBR_TRN_PRODUCTION_VOLUME>();
            //add
            if (productionVolumeFromRepo.Count <= 0)
            {
                throw new Exception("No production volume on your selected criteria.");
            }
            foreach (var item in productionVolumeFromRepo)
            {
                //add
                var bind = BindProductionVolumeTempModelToDB(new OptienceCriteriaModel()
                {
                    Case = param.CaseTo,
                    Cycle = param.CycleTo,
                    Scenario = param.ScenarioTo
                }, item, item.Price, item.MonthIndex, item.MonthNo);

                bind.CopiedFromCycle = param.CycleFrom;
                bind.CopiedFromPlanType = param.ScenarioFrom;
                bind.CopiedFromCase = param.CaseFrom;
                addFeedDataList.Add(bind);
                proDataList.Add(bind);
            }

            // set Total record
            total = proDataList.Count();

            #region Call Api

            if (!IsPreview)
            {
                bool isCallApiSuccess = true;
                var pipeLine = CallDataFactory("MBR_TMP_ProductionVolume", "ProductionVolume", param.CycleTo, param.CaseTo, param.ScenarioTo, param.CompanyFrom.ToList());
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
                    foreach (var item in proDataList)
                    {
                        item.RunId = pipeLine;
                    }

                    if (addFeedDataList != null && addFeedDataList.Count > 0)
                        _unit.ProductionVolumeTempRepo.Add(addFeedDataList);

                    #region Del Fail DWH Data Temp

                    var dataFactDWHFail = _unit.DataFactoryRunRepo.GetDWHFail("ProductionVolume")?.Select(s => s.RunId).ToList();
                    if (dataFactDWHFail != null && dataFactDWHFail.Count >= 1)
                    {
                        var delFailDWH = productionVolumeToRepo.Where(w => dataFactDWHFail.Contains(w.RunId)).ToList();
                        _unit.ProductionVolumeTempRepo.BulkDelete(delFailDWH);
                    }

                    #endregion Del Fail DWH Data Temp

                    _unit.SaveTransaction();
                }
            }

            //concat data DB

            #endregion Call Api

            #endregion save data

            return proDataList;
        }

        private List<MBR_TMP_BEGINING_INVENTORY> CopyBeginningInventory(OptienceCopyRequest param, bool IsPreview, out int total, out PriceList runId)
        {
            runId = new PriceList();
            var company = param.CompanyFrom;
            if (company.Count == 0)
            {
                company = _unit.MasterCompanyRepo.GetCompany().Where(w => w.text != APPCONSTANT.DROPDOWN.ALL).Select(s => s.text).ToList();
            }
            var beginningInventoryFromRepo = _unit.BeginningInventoryRepo.FindByCriterias(param.ScenarioFrom, param.CaseFrom, param.CycleFrom, company);
            var beginningInventoryToRepo = _unit.BeginningInventoryTempRepo.FindByCriterias(param.ScenarioTo, param.CaseTo, param.CycleTo);
            var beginningInventoryToMainRepo = _unit.BeginningInventoryRepo.FindByCriterias(param.ScenarioTo, param.CaseTo, param.CycleTo);

            #region save data

            var addBegDataList = new List<MBR_TMP_BEGINING_INVENTORY>();
            var begDataList = new List<MBR_TMP_BEGINING_INVENTORY>();
            var begTrntList = new List<MBR_TRN_BEGINING_INVENTORY>();
            //add
            if (beginningInventoryFromRepo.Count <= 0)
            {
                throw new Exception("No beginning inventory on your selected criteria.");
            }
            foreach (var item in beginningInventoryFromRepo)
            {
                //add
                var bind = BindBeginningInventoryTempModelToDB(new OptienceCriteriaModel()
                {
                    Case = param.CaseTo,
                    Cycle = param.CycleTo,
                    Scenario = param.ScenarioTo
                }, item, item.Price, item.MonthIndex, item.MonthNo);

                bind.CopiedFromCycle = param.CycleFrom;
                bind.CopiedFromPlanType = param.ScenarioFrom;
                bind.CopiedFromCase = param.CaseFrom;
                addBegDataList.Add(bind);
                begDataList.Add(bind);
            }

            // set Total record
            total = begDataList.Count();

            #region Call Api

            if (!IsPreview)
            {
                bool isCallApiSuccess = true;
                var pipeLine = CallDataFactory("MBR_TMP_BeginningInventory", "BeginningInventory", param.CycleTo, param.CaseTo, param.ScenarioTo, param.CompanyFrom.ToList());
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
                    foreach (var item in begDataList)
                    {
                        item.RunId = pipeLine;
                    }

                    if (addBegDataList != null && addBegDataList.Count > 0)
                        _unit.BeginningInventoryTempRepo.Add(addBegDataList);

                    #region Del Fail DWH Data Temp

                    var dataFactDWHFail = _unit.DataFactoryRunRepo.GetDWHFail("BeginningInventory")?.Select(s => s.RunId).ToList();
                    if (dataFactDWHFail != null && dataFactDWHFail.Count >= 1)
                    {
                        var delFailDWH = beginningInventoryToRepo.Where(w => dataFactDWHFail.Contains(w.RunId)).ToList();
                        _unit.BeginningInventoryTempRepo.BulkDelete(delFailDWH);
                    }

                    #endregion Del Fail DWH Data Temp

                    _unit.SaveTransaction();
                }
            }
            //concat data DB

            #endregion Call Api

            #endregion save data

            return begDataList;
        }

        public List<PriceList> CopyOptience(OptienceCopyRequest param, out int sum, out OptienceData dataCopy)
        {
            var result = new List<PriceList>();
            var runId = new PriceList();
            int total = 0;
            sum = 0;

            dataCopy = new OptienceData();
            var dataProductionVolume = new List<MBR_TMP_PRODUCTION_VOLUME>();
            var dataCopyConsumption = new List<MBR_TMP_FEED_CONSUMPTION>();
            var dataCopyBeginningInventory = new List<MBR_TMP_BEGINING_INVENTORY>();
            var dataCopyPurchase = new List<MBR_TMP_FEED_PURCHASE>();

            foreach (var OptienceTypeId in param.TypeTo)
            {
                if (OptienceTypeId == 2)
                {
                    dataProductionVolume = CopyProductionVolume(param, false, out total, out runId);
                    dataCopy.productionVolumeData = dataProductionVolume;
                    sum = sum + total;
                    result.Add(runId);
                }
                else if (OptienceTypeId == 3)
                {
                    dataCopyConsumption = CopyFeedConsumption(param, false, out total, out runId);
                    dataCopy.feedConsumptionData = dataCopyConsumption;
                    sum = sum + total;
                    result.Add(runId);
                }
                else if (OptienceTypeId == 4)
                {
                    dataCopyBeginningInventory = CopyBeginningInventory(param, false, out total, out runId);
                    dataCopy.beginningInventoryData = dataCopyBeginningInventory;
                    sum = sum + total;
                    result.Add(runId);
                }
                else if (OptienceTypeId == 5)
                {
                    dataCopyPurchase = CopyFeedPurchase(param, false, out total, out runId);
                    dataCopy.feedPurchaseData = dataCopyPurchase;
                    sum = sum + total;
                    result.Add(runId);
                }
            }

            return result;
        }

        #endregion CopyOptience

        #region Preview

        public List<OptienceDownloadResponse> PreviewCopyOptience(OptienceCopyRequest param)
        {
            var res = new List<OptienceDownloadResponse>();
            var result = new OptiencePreviewResponse();
            int total = 0;
            PriceList runId = new PriceList();
            foreach (var OptienceTypeId in param.TypeTo)
            {
                if (OptienceTypeId == MASTER_EXCEL_TYPE.PRODUCTION_VOLUME)
                {
                    var dataProductionVolume = CopyProductionVolume(param, true, out total, out runId);
                    var resultProductionVolume = new List<ProductionVolumePreviewModel>();
                    var excelMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId).OrderBy(o => o.Sequence).ToList();

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
                        OptienceTypeId = OptienceTypeId,
                        OptienceMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId, true)
                    });
                }
                else if (OptienceTypeId == MASTER_EXCEL_TYPE.FEED_CONSUMPTION)
                {
                    var dataCopyConsumption = CopyFeedConsumption(param, true, out total, out runId);
                    var excelMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId).OrderBy(o => o.Sequence).ToList();
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
                        OptienceTypeId = OptienceTypeId,
                        OptienceMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId, true)
                    });
                }
                else if (OptienceTypeId == MASTER_EXCEL_TYPE.BEGINNING_INVENTORY)
                {
                    var dataCopyBeginningInventory = CopyBeginningInventory(param, true, out total, out runId);
                    var excelMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId).OrderBy(o => o.Sequence).ToList();
                    var resultProductionVolume = new List<ProductionVolumePreviewModel>();
                    var proGroup = dataCopyBeginningInventory.GroupBy(g => new { g.Company, g.MCSC, g.ProductShortName }).ToList();
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
                                                  Cycle = g.Cycle,
                                                  MonthNo = g.MonthNo,
                                                  Header = excelMapping.Where(x => x.ExcelHeader == g.MonthIndex).Select(s => s.Variable).FirstOrDefault() ?? g.MonthIndex?.ToLower(),
                                                  Value = g.Price
                                              }
                                   ).ToList();

                        var lastUpdate = data.OrderByDescending(b => b.UpdatedDate).FirstOrDefault();

                        mapData.ElementCode = lastUpdate?.ElementCodeEBA;
                        mapData.Company = lastUpdate?.Company;
                        mapData.MCSC = lastUpdate?.MCSC;
                        mapData.ProductShortName = lastUpdate?.ProductShortName;
                        resultProductionVolume.Add(mapData);
                    }
                    result.ProductionVolumeData = resultProductionVolume;
                    res.Add(new OptienceDownloadResponse
                    {
                        OptienceData = resultProductionVolume,
                        OptienceTypeId = OptienceTypeId,
                        OptienceMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId, true)
                    });
                }
                else if (OptienceTypeId == MASTER_EXCEL_TYPE.FEED_PURCHASE)
                {
                    var dataCopyPurchase = CopyFeedPurchase(param, true, out total, out runId);
                    var excelMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId).OrderBy(o => o.Sequence).ToList();
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
                        OptienceTypeId = OptienceTypeId,
                        OptienceMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId, true)
                    });
                }
            }

            return res;
        }

        #endregion Preview

        private MBR_TMP_FEED_CONSUMPTION BindFeedConsumptionTempModelToDB(OptienceCriteriaModel criteria, MBR_TRN_FEED_CONSUMPTION item, decimal? price, string monthIndex, string monthNo)
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
                ElementCodeEBA = item.ElementCodeEBA,
                FeedName = item.FeedName,
                MonthIndex = monthIndex,
                MonthNo = monthNo,
                Price = price ?? 0,
                CreatedBy = userLogin,
                CyclePoly = cyclePoly,
                MaterialCode = item.MaterialCode,
                CreatedDate = DateTime.Now
            };
            return newData;
        }

        private MBR_TMP_FEED_PURCHASE BindFeedPurchaseTempModelToDB(OptienceCriteriaModel criteria, MBR_TRN_FEED_PURCHASE item, decimal? price, string monthIndex, string monthNo)
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
                ElementCodeEBA = item.ElementCodeEBA,
                FeedName = item.FeedName,
                MonthIndex = monthIndex,
                MonthNo = monthNo,
                Price = price ?? 0,
                CreatedBy = userLogin,
                CyclePoly = cyclePoly,
                MaterialCode = item.MaterialCode,
                CreatedDate = DateTime.Now
            };
            return newData;
        }

        private MBR_TMP_PRODUCTION_VOLUME BindProductionVolumeTempModelToDB(OptienceCriteriaModel criteria, MBR_TRN_PRODUCTION_VOLUME item, decimal? price, string monthIndex, string monthNo)
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
                ElementCodeEBA = item.ElementCodeEBA,
                ProductShortName = item.ProductShortName,
                MonthIndex = monthIndex,
                MonthNo = monthNo,
                Price = price ?? 0,
                CreatedBy = userLogin,
                CyclePoly = cyclePoly,
                MaterialCode = item.MaterialCode,
                CreatedDate = DateTime.Now
            };
            return newData;
        }

        private MBR_TMP_BEGINING_INVENTORY BindBeginningInventoryTempModelToDB(OptienceCriteriaModel criteria, MBR_TRN_BEGINING_INVENTORY item, decimal? price, string monthIndex, string monthNo)
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
                ElementCodeEBA = item.ElementCodeEBA,
                MonthIndex = monthIndex,
                MonthNo = monthNo,
                Price = price ?? 0,
                CreatedBy = userLogin,
                CyclePoly = cyclePoly,
                CreatedDate = DateTime.Now
            };
            return newData;
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

        public bool CheckExistData(OptienceCopyRequest param)
        {
            #region check data

            var company = param.CompanyFrom;
            if (company.Count == 0)
            {
                company = _unit.MasterCompanyRepo.GetCompany().Where(w => w.text != APPCONSTANT.DROPDOWN.ALL).Select(s => s.text).ToList();
            }
            var feedConsumptionFromRepo = _unit.FeedConsumptionRepo.FindByCriterias(param.ScenarioFrom, param.CaseFrom, param.CycleFrom, company);
            if (feedConsumptionFromRepo.Count <= 0)
            {
                throw new Exception("No feed consumption based on your selected criteria.");
            }
            var beginningInventoryFromRepo = _unit.BeginningInventoryRepo.FindByCriterias(param.ScenarioFrom, param.CaseFrom, param.CycleFrom, company);
            if (beginningInventoryFromRepo.Count <= 0)
            {
                throw new Exception("No beginning inventory on your selected criteria.");
            }
            var productionVolumeFromRepo = _unit.ProductionVolumeRepo.FindByCriterias(param.ScenarioFrom, param.CaseFrom, param.CycleFrom, company);
            if (productionVolumeFromRepo.Count <= 0)
            {
                throw new Exception("No production volume on your selected criteria.");
            }
            var feedPurchaseFromRepo = _unit.FeedPurchaseRepo.FindByCriteria(param.ScenarioFrom, param.CaseFrom, param.CycleFrom, company);
            if (feedPurchaseFromRepo.Count <= 0)
            {
                throw new Exception("No feed purchase based on your selected criteria.");
            }

            #endregion check data

            return true;
        }
    }
}