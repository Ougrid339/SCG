using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Datafacetory.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MarketPriceForecast.Interface;
using System.Globalization;
using System.Reflection;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MarketPriceForecast
{
    public class CopyMarketPriceForecastService : ICopyMarketPriceForecastService
    {
        private readonly UnitOfWork _unit;
        private readonly string userLogin;
        private readonly IDataFactoryService _dataFactoryService;

        public CopyMarketPriceForecastService(UnitOfWork unitOfWork, IDataFactoryService dataFactoryService)
        {
            this._unit = unitOfWork;
            this.userLogin = UserUtilities.GetADAccount()?.UserId ?? "";
            this._dataFactoryService = dataFactoryService;
        }

        public string CallDataFactory(string tableName, string transactionName, string cycleName, string caseName, string planType, bool isMerge = false)
        {
            string userName = UserUtilities.GetADAccount()?.UserId ?? "";
            string res = _dataFactoryService.RunPipeline(tableName, transactionName, cycleName, caseName, planType, isMerge, userName);

            return res;
        }

        #region copy

        private List<MBR_TMP_MARKET_PRICE_FORECAST> CopyMarketPriceForecastCenter(MarketPriceForecastCopyRequest param, bool IsPreview, out int total, out string runId)
        {
            var marketPriceForecastFromRepo = _unit.MarketPriceForecastRepo.FindByCriteria(param.ScenarioFrom, param.CaseFrom, param.CycleFrom);
            var marketPriceForecastToRepo = _unit.MarketPriceForecastTempRepo.FindByCriteria(param.ScenarioTo, param.CaseTo, param.CycleTo);
            var marketPriceForecastToMainRepo = _unit.MarketPriceForecastRepo.FindByCriteria(param.ScenarioTo, param.CaseTo, param.CycleTo);

            #region save data

            var addMarketDataList = new List<MBR_TMP_MARKET_PRICE_FORECAST>();
            var marketDataList = new List<MBR_TMP_MARKET_PRICE_FORECAST>();
            var markeTrntList = new List<MBR_TRN_MARKET_PRICE_FORECAST>();
            //add
            if (marketPriceForecastFromRepo.Count <= 0)
            {
                throw new Exception("No market price forecast based on your selected criteria.");
            }
            foreach (var item in marketPriceForecastFromRepo)
            {
                var monthNo = ConverseMonthNo(param.ScenarioTo, item.MonthIndex, param.CycleTo);

                //add
                var bind = BindMarketPriceForecastTempModelToDB(new MarketPriceForecastCriteriaModel()
                {
                    Case = param.CaseTo,
                    Cycle = param.CycleTo,
                    Scenario = param.ScenarioTo
                }, item.MarketSource, item.Unit, item.Price, item.MonthIndex, monthNo, item.EBACode);

                bind.CopiedFromCycle = param.CycleFrom;
                bind.CopiedFromPlanType = param.ScenarioFrom;
                bind.CopiedFromCase = param.CaseFrom;
                addMarketDataList.Add(bind);
                marketDataList.Add(bind);
            }

            // set Total record
            total = marketDataList.Count();
            //concat data DB
            //var notUpdate = marketPriceForecastToRepo.Where(w => !marketDataList.Contains(w)).ToList();
            //if (notUpdate != null && notUpdate.Count > 0) marketDataList.AddRange(notUpdate);
            runId = "";
            if (!IsPreview)
            {
                #region Call API

                bool isCallApiSuccess = true;
                runId = CallDataFactory("MBR_TMP_MarketPriceForecast", "MarketPriceForecast", param.CycleTo, param.CaseTo, param.ScenarioTo);
                if (runId != "error")
                {
                    // insert runId to Database
                }
                else
                {
                    throw new Exception("Cannot Run Pipeline.");
                }

                #endregion Call API

                foreach (var item in marketDataList)
                {
                    item.RunId = runId;
                }
                if (addMarketDataList != null && addMarketDataList.Count > 0)
                    _unit.MarketPriceForecastTempRepo.Add(addMarketDataList);

                #region Del Fail DWH Data Temp

                var dataFactDWHFail = _unit.DataFactoryRunRepo.GetDWHFail("MarketPriceForecast")?.Select(s => s.RunId).ToList();
                if (dataFactDWHFail != null && dataFactDWHFail.Count >= 1)
                {
                    var delFailDWH = marketPriceForecastToRepo.Where(w => dataFactDWHFail.Contains(w.RunId)).ToList();
                    _unit.MarketPriceForecastTempRepo.BulkDelete(delFailDWH);
                }

                #endregion Del Fail DWH Data Temp

                _unit.SaveTransaction();
            }

            #endregion save data

            return marketDataList;
        }

        public string CopyMarketPriceForecast(MarketPriceForecastCopyRequest param, out int total, out List<MBR_TMP_MARKET_PRICE_FORECAST> dataCopy)
        {
            string runId;

            dataCopy = CopyMarketPriceForecastCenter(param, false, out total, out runId);

            return runId;
        }

        public List<MarketPriceForecastPreviewResponse> PreviewCopyMarketPriceForecast(MarketPriceForecastCopyRequest param)
        {
            int total = 0;
            string runId = "";
            var dataCopy = CopyMarketPriceForecastCenter(param, true, out total, out runId);

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
                result.Add(mapData);
            }

            return result;
        }

        #endregion copy

        private MBR_TRN_MARKET_PRICE_FORECAST BindMarketPriceForecastModelToDB(MarketPriceForecastCriteriaModel criteria, string marketSource, string unit, decimal? price, string monthIndex, string monthNo, string? ebaCode)
        {
            var cyclePoly = "";
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
                MarketSource = marketSource,
                MonthIndex = monthIndex,
                Price = price,
                Unit = unit,
                MonthNo = monthNo,
                CreatedBy = userLogin,
                CreatedDate = DateTime.Now,
                EBACode = ebaCode
            };
            return newData;
        }

        private MBR_TMP_MARKET_PRICE_FORECAST BindMarketPriceForecastTempModelToDB(MarketPriceForecastCriteriaModel criteria, string marketSource, string unit, decimal? price, string monthIndex, string monthNo, string? ebaCode)
        {
            var cyclePoly = "";
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
                MarketSource = marketSource,
                MonthIndex = monthIndex,
                Price = price,
                Unit = unit,
                MonthNo = monthNo,
                CreatedBy = userLogin,
                CreatedDate = DateTime.Now,
                EBACode = ebaCode
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

        public bool CheckExistData(MarketPriceForecastCopyRequest param)
        {
            #region check exist data

            var marketPriceForecastFromRepo = _unit.MarketPriceForecastRepo.FindByCriteria(param.ScenarioFrom, param.CaseFrom, param.CycleFrom);

            if (marketPriceForecastFromRepo.Count <= 0)
            {
                throw new Exception("No market price forecast based on your selected criteria.");
            }

            #endregion check exist data

            return true;
        }
    }
}