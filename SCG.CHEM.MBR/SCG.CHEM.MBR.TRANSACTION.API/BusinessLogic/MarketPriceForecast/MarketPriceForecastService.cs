using SCG.CHEM.MBR.COMMON.Utilities;

using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;
using System.Transactions;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MarketPriceForecast.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;
using System.Reflection;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Datafacetory.Interface;
using System.Globalization;
using Microsoft.Data.SqlClient;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using Azure.Core;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MarketPriceForecast
{
    public sealed class MarketPriceForecastService : IMarketPriceForecastService
    {
        private readonly UnitOfWork _unit;
        private readonly string userLogin;
        private readonly IDataFactoryService _dataFactoryService;

        public MarketPriceForecastService(UnitOfWork unitOfWork, IDataFactoryService dataFactoryService)
        {
            this._unit = unitOfWork;
            this.userLogin = UserUtilities.GetADAccount()?.UserId ?? "";
            this._dataFactoryService = dataFactoryService;
        }

        public string CallDataFactory(string tableName, string transactionName, string cycleName, string caseName, string planType, bool isMerge = false, string MergedWithPlanType = "", string MergedWithCycle = "", string MergedWithCase = "")
        {
            string userName = UserUtilities.GetADAccount()?.UserId ?? "";
            string res = _dataFactoryService.RunPipeline(tableName, transactionName, cycleName, caseName, planType, isMerge, userName, MergedWithPlanType, MergedWithCycle, MergedWithCase);

            return res;
        }

        #region Move

        public int MoveMarketPriceForecast(string runId, out bool status)
        {
            var newMasterDB = new List<MBR_TRN_MARKET_PRICE_FORECAST>();
            var listTempDB = _unit.MarketPriceForecastTempRepo.FindByRunId(runId);

            var addMarketDataList = new List<MBR_TRN_MARKET_PRICE_FORECAST>();
            var marketList = new List<MBR_TRN_MARKET_PRICE_FORECAST>();

            List<string> monthIndexs = Enum.GetValues(typeof(MONTH_INDEX)).Cast<MONTH_INDEX>().Select(v => v.ToString()).ToList();

            //add
            var group = listTempDB.GroupBy(g => new { g.PlanType, g.Case, g.Cycle, g.MarketSource }).ToList();
            using (var Transaction = _unit.BeginTransaction())
            {
                try
                {
                    foreach (var cycle in group)
                    {
                        var marketPriceRepo = _unit.MarketPriceForecastRepo.FindByCriteria(cycle.Key.PlanType, cycle.Key.Case, cycle.Key.Cycle);
                        foreach (var item in cycle)
                        {
                            decimal? monthIndexData = item.Price;
                            //var marketPriceUpdate = marketPriceRepo.FirstOrDefault(f => f.MonthNo == item.MonthNo && f.MonthIndex == item.MonthIndex && f.MarketSource == item.MarketSource);
                            //if (monthIndexData != null && monthIndexData != 0)
                            //{
                            //if (marketPriceUpdate != null)
                            //{
                            //    //update
                            //    marketPriceUpdate.MergedWithCase = item.MergedWithCase;
                            //    marketPriceUpdate.MergedWithCycle = item.MergedWithCycle;
                            //    marketPriceUpdate.MergedWithPlanType = item.MergedWithPlanType;
                            //    marketPriceUpdate.CopiedFromCase = item.CopiedFromCase;
                            //    marketPriceUpdate.CopiedFromCycle = item.CopiedFromCycle;
                            //    marketPriceUpdate.CopiedFromPlanType = item.CopiedFromPlanType;
                            //    marketPriceUpdate.Price = monthIndexData;
                            //    marketPriceUpdate.UpdatedBy = userLogin;
                            //    marketPriceUpdate.UpdatedDate = DateTime.Now;
                            //    marketList.Add(marketPriceUpdate);
                            //}
                            //else
                            //{
                            //add
                            var bind = BindMarketPriceForecastModelToDB(new MarketPriceForecastCriteriaModel
                            {
                                Cycle = item.Cycle,
                                Case = item.Case,
                                Scenario = item.PlanType,
                            }, new MarketPriceForecastDataModel
                            {
                                Unit = item.Unit,
                                MarketSource = item.MarketSource,
                                EBACode = item.EBACode
                            }, monthIndexData, item.MonthIndex, item.MonthNo);

                            bind.MergedWithCase = item.MergedWithCase;
                            bind.MergedWithCycle = item.MergedWithCycle;
                            bind.MergedWithPlanType = item.MergedWithPlanType;
                            bind.CopiedFromCase = item.CopiedFromCase;
                            bind.CopiedFromCycle = item.CopiedFromCycle;
                            bind.CopiedFromPlanType = item.CopiedFromPlanType;
                            bind.UpdatedBy = item.UpdatedBy;
                            bind.UpdatedDate = item.UpdatedDate;
                            addMarketDataList.Add(bind);
                            //marketList.Add(bind);
                            //}
                            //}
                        }
                    }

                    #region Delete Trn

                    var delTrn = _unit.MarketPriceForecastRepo.FindByCriteria(listTempDB.FirstOrDefault().PlanType, listTempDB.FirstOrDefault().Case, listTempDB.FirstOrDefault().Cycle);
                    if (delTrn != null && delTrn.Count >= 1)

                        _unit.MarketPriceForecastRepo.BulkDelete(delTrn);
                    _unit.Save();

                    #endregion Delete Trn

                    #region Insert merge history

                    var DataFactoryRun = _unit.DataFactoryRunRepo.GetByRunId(runId);

                    //var groupMergeWith = _unit.MarketPriceForecastTempRepo.FindByRunId(runId).Where(w => w.MergedWithCycle != null).FirstOrDefault();
                    if (DataFactoryRun is not null)
                    {
                        if (DataFactoryRun.IsMerge == true)
                        {
                            var request = new MergeHistoryRequestModel();
                            //request.ExcelId = MASTER_EXCEL_TYPE.MARKET_PRICE_FORCASET;
                            request.Cycle = DataFactoryRun.Cycle;
                            request.Case = DataFactoryRun.Case;

                            var mergeData = _unit.MergeHistoryRepo.GetDataByCriteria(request, MASTER_EXCEL_TYPE.MARKET_PRICE_FORCASET);
                            if (mergeData is null)
                            {
                                var dataInsMergeHistory = new MBR_TRN_MERGE_HISTORY()
                                {
                                    Type = "Market Price Forecast",
                                    Cycle = DataFactoryRun.Cycle,
                                    Case = DataFactoryRun.Case,
                                    MergedWithCycle = DataFactoryRun.MergedWithCycle,
                                    MergedWithCase = DataFactoryRun.MergedWithCase,
                                    CreatedBy = userLogin,
                                    CreatedDate = DateTime.Now,
                                    ExcelId = MASTER_EXCEL_TYPE.MARKET_PRICE_FORCASET
                                };

                                _unit.MergeHistoryRepo.Add(dataInsMergeHistory);
                                _unit.Save();
                            }
                            else
                            {
                                var chkMergeHistory = addMarketDataList.Where(x => x.MergedWithCase == mergeData.MergedWithCase && x.MergedWithCycle == mergeData.MergedWithCycle).ToList();
                                if (chkMergeHistory.Count == 0)
                                {
                                    throw new Exception("Data Can't Merge");
                                }
                            }
                        }
                    }

                    #endregion Insert merge history

                    if (addMarketDataList != null && addMarketDataList.Count > 0)
                        _unit.MarketPriceForecastRepo.BulkInsert(addMarketDataList);
                    _unit.Save();
                    if (listTempDB != null && listTempDB.Count >= 1)
                        _unit.MarketPriceForecastTempRepo.BulkDelete(listTempDB);
                    _unit.Save();
                    //throw new Exception("error");
                    Transaction.Commit();
                    status = true;
                }
                catch (Exception ex)
                {
                    status = false;
                    Transaction.Rollback();
                }
            }

            // set Total record

            int total = addMarketDataList.Count();
            //_unit.SaveTransaction();
            return total;
        }

        #endregion Move

        #region upload

        private List<MBR_TMP_MARKET_PRICE_FORECAST> UploadMarketPriceForecastCenter(DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel> param, bool IsPreview, out int total, out string runId)
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

            List<PriceList> priceLst = new List<PriceList>();

            var validateModels = new List<MarketPriceForecastDataModel>();
            var containMarketPriceMapping = _unit.MasterMarketPriceMappingRepo.GetMarketPriceNameByMarketPriceMI(param.Data.Select(s => s.MarketSource).ToList());
            var isZero = _unit.MasterMaintainPriceRepo.GetByMaintainId(MASTER_EXCEL_TYPE.MARKET_PRICE_FORCASET)?.IsZero ?? false;
            List<MBR_TRN_MARKET_PRICE_FORECAST> marketPriceForecastExistingData = new List<MBR_TRN_MARKET_PRICE_FORECAST>();
            if (param.Criteria.isMerge && param.Criteria.MergeScenario != null && param.Criteria.MergeCase != null && param.Criteria.MergeCycle != null)
                marketPriceForecastExistingData = _unit.MarketPriceForecastRepo.FindByCriteria(param.Criteria.MergeScenario, param.Criteria.MergeCase, param.Criteria.MergeCycle);
            param.Data.ForEach(i =>
            {
                #region add Price List

                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M0 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M1 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M2 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M3 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M4 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M5 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M6 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M7 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M8 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M9 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M10 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M11 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M12 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M13 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M14 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M15 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M16 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M17 ?? "" });
                priceLst.Add(new PriceList { name = i.MarketSource, value = i.M18 ?? "" });

                #endregion add Price List

                row++;
                List<MBR_TRN_MARKET_PRICE_FORECAST> existingData = null;
                if (marketPriceForecastExistingData != null)
                    existingData = marketPriceForecastExistingData.Where(f => f.MarketSource.ToLower() == i.MarketSource.ToLower()).ToList();
                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToModel(existingData, containMarketPriceMapping, param.Criteria.isMerge, isZero, out convertErrorList, out convertDataWarningList);

                validateModels.Add(convertModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            #region Save Data

            // Temp
            var addMarketDataList = new List<MBR_TMP_MARKET_PRICE_FORECAST>();
            var marketList = new List<MBR_TMP_MARKET_PRICE_FORECAST>();
            var markeTrntList = new List<MBR_TRN_MARKET_PRICE_FORECAST>();

            var marketPriceRepo = _unit.MarketPriceForecastTempRepo.FindByCriteria(param.Criteria.Scenario, param.Criteria.Case, param.Criteria.Cycle);
            var marketPriceMainRepo = _unit.MarketPriceForecastRepo.FindByCriteria(param.Criteria.Scenario, param.Criteria.Case, param.Criteria.Cycle);

            List<string> monthIndexs = Enum.GetValues(typeof(MONTH_INDEX)).Cast<MONTH_INDEX>().Select(v => v.ToString()).ToList();

            var lstData = new List<PriceList>();
            //add

            foreach (var item in validateModels)
            {
                var indexes = priceLst.Where(w => w.name == item.MarketSource).Select(s => s.value).Select((v, i) => new { v, i })
                        .Where(x => x.v.Any(y => y != null))
                        .Select(x => "M" + x.i).ToList();
                foreach (var monthIndex in monthIndexs)
                {
                    var monthNo = ConverseMonthNo(param.Criteria.Scenario, monthIndex, param.Criteria.Cycle);
                    var monthIndexDataString = (string?)item.GetType().GetProperty(monthIndex).GetValue(item, null);
                    decimal? monthIndexData = !string.IsNullOrEmpty(monthIndexDataString) ? decimal.Parse(monthIndexDataString) : (isZero ? 0 : null);
                    //var marketPriceUpdate = marketPriceRepo.FirstOrDefault(f => f.MonthNo == monthNo && f.MonthIndex == monthIndex && f.MarketSource == item.MarketSource);
                    //var marketPriceMainUpdate = marketPriceMainRepo.FirstOrDefault(f => f.MonthNo == monthNo && f.MonthIndex == monthIndex && f.MarketSource == item.MarketSource);

                    if ((monthIndexData != null /*&& monthIndexData != 0*/) || isZero)
                    {
                        //add
                        var bind = BindMarketPriceForecastTempModelToDB(param.Criteria, item, monthIndexData, monthIndex, monthNo);
                        if (param.Criteria.isMerge && !indexes.Contains(bind.MonthIndex))
                        {
                            bind.MergedWithCycle = param.Criteria.MergeCycle;
                            bind.MergedWithCase = param.Criteria.MergeCase;
                            bind.MergedWithPlanType = param.Criteria.MergeScenario;
                        }
                        addMarketDataList.Add(bind);
                        marketList.Add(bind);
                        lstData.Add(new PriceList { name = item.MarketSource, value = monthIndex });
                    }
                }
            }

            // set Total record
            total = marketList.Count();
            //_unit.SaveTransaction();
            if (!IsPreview)
            {
                #region Call API

                bool isCallApiSuccess = true;

                runId = param.Criteria.isMerge ? CallDataFactory("MBR_TMP_MarketPriceForecast", "MarketPriceForecast", param.Criteria.Cycle, param.Criteria.Case, param.Criteria.Scenario, param.Criteria.isMerge, param.Criteria.MergeScenario, param.Criteria.MergeCycle, param.Criteria.MergeCase)
                    : CallDataFactory("MBR_TMP_MarketPriceForecast", "MarketPriceForecast", param.Criteria.Cycle, param.Criteria.Case, param.Criteria.Scenario, param.Criteria.isMerge);
                if (runId != "error")
                {
                    // insert runId to Database
                }
                else
                {
                    isCallApiSuccess = false;
                    throw new Exception("Cannot Run Pipeline");
                }

                #endregion Call API

                foreach (var item in marketList)
                {
                    item.RunId = runId;
                }
                if (addMarketDataList != null && addMarketDataList.Count > 0)
                    _unit.MarketPriceForecastTempRepo.Add(addMarketDataList);

                #region Del Fail DWH Data Temp

                var dataFactDWHFail = _unit.DataFactoryRunRepo.GetDWHFail("MarketPriceForecast")?.Select(s => s.RunId).ToList();
                if (dataFactDWHFail != null && dataFactDWHFail.Count >= 1)
                {
                    var delFailDWH = marketPriceRepo.Where(w => dataFactDWHFail.Contains(w.RunId)).ToList();
                    _unit.MarketPriceForecastTempRepo.BulkDelete(delFailDWH);
                }

                #endregion Del Fail DWH Data Temp

                #region del tmep after 30 minute

                var delAfter30minute = _unit.MarketPriceForecastTempRepo.FindAfter30minute();
                if (delAfter30minute != null && delAfter30minute.Count >= 1)
                {
                    _unit.MarketPriceForecastTempRepo.BulkDelete(delAfter30minute);
                }

                #endregion del tmep after 30 minute

                _unit.SaveTransaction();
            }

            //concat data DB

            var groupData = lstData.GroupBy(g => g.name).ToList();
            var lstNotUpdate = new List<MBR_TMP_MARKET_PRICE_FORECAST>();
            foreach (var item in groupData)
            {
                lstNotUpdate.AddRange(marketPriceMainRepo.Where(w => w.MarketSource == item.Key && !item.Select(s => s.value).Contains(w.MonthIndex)).Select(s => new MBR_TMP_MARKET_PRICE_FORECAST(s)).ToList());
            }
            if (lstNotUpdate != null && lstNotUpdate.Count > 0)
            {
                marketList.AddRange(lstNotUpdate);
            };

            #endregion Save Data

            return marketList;
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

        public string UploadMarketPriceForecast(DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel> param, out int total)
        {
            string runId;
            var data = UploadMarketPriceForecastCenter(param, false, out total, out runId);
            return runId;
        }

        public List<MarketPriceForecastPreviewResponse> PreviewUploadMarketPriceForecast(DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel> param)
        {
            int total = 0;
            string runId = "";
            var dataCopy = UploadMarketPriceForecastCenter(param, true, out total, out runId);

            var result = new List<MarketPriceForecastPreviewResponse>();
            var marketSourceGroup = dataCopy.GroupBy(g => g.MarketSource).ToList();
            foreach (var group in marketSourceGroup)
            {
                var mapData = new MarketPriceForecastPreviewResponse();
                var headerLists = new List<HeaderListPreview>();
                foreach (var item in group)
                {
                    //PropertyInfo prop = mapData.GetType().GetProperty(item.MonthIndex, BindingFlags.Public | BindingFlags.Instance);
                    //if (null != prop && prop.CanWrite)
                    //{
                    //    prop.SetValue(mapData, item.Price, null);
                    //}
                    var DataLists = new HeaderListPreview();
                    DataLists.Cycle = String.IsNullOrEmpty(item.MergedWithCycle) ? item.Cycle : item.MergedWithCycle;
                    DataLists.MonthNo = item.MonthNo.Replace("-", "");
                    DataLists.Header = item.MonthIndex.ToLower().ToString();
                    DataLists.Value = item.Price;
                    headerLists.Add(DataLists);
                }
                mapData.HeaderList = headerLists;
                var lastUpdate = group.OrderByDescending(b => b.UpdatedDate).FirstOrDefault();

                mapData.MarketSource = lastUpdate?.MarketSource;
                mapData.Unit = lastUpdate?.Unit;
                mapData.EBACode = lastUpdate?.EBACode;

                result.Add(mapData);
            }

            return result;
        }

        #endregion upload

        private MBR_TRN_MARKET_PRICE_FORECAST BindMarketPriceForecastModelToDB(MarketPriceForecastCriteriaModel criteria, MarketPriceForecastDataModel item, decimal? price, string monthIndex, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.Scenario == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TRN_MARKET_PRICE_FORECAST()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                CyclePoly = cyclePoly,
                PlanType = criteria.Scenario,
                MarketSource = item.MarketSource,
                MonthIndex = monthIndex,
                Price = price,
                Unit = item.Unit,
                MonthNo = monthNo,
                CreatedBy = userLogin,
                CreatedDate = DateTime.Now,
                EBACode = item.EBACode
            };
            return newData;
        }

        private MBR_TMP_MARKET_PRICE_FORECAST BindMarketPriceForecastTempModelToDB(MarketPriceForecastCriteriaModel criteria, MarketPriceForecastDataModel item, decimal? price, string monthIndex, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.Scenario == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TMP_MARKET_PRICE_FORECAST()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                CyclePoly = cyclePoly,
                PlanType = criteria.Scenario,
                MarketSource = item.MarketSource,
                MonthIndex = monthIndex,
                Price = price,
                Unit = item.Unit,
                MonthNo = monthNo,
                CreatedBy = userLogin,
                CreatedDate = DateTime.Now,
                EBACode = item.EBACode
            };
            return newData;
        }
    }
}