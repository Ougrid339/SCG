using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Repository.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Transaction
{
    internal class MarketPriceForecastRepo : RepositoryBase<MBR_TRN_MARKET_PRICE_FORECAST>, IMarketPriceForecastRepo
    {
        public MarketPriceForecastRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public List<MBR_TRN_MARKET_PRICE_FORECAST> FindByCriteria(string scenario, string revisionCase, string cycle)
        {
            return _context.MBR_TRN_MARKET_PRICE_FORECASTs.Where(w => w.PlanType.ToLower() == scenario.ToLower() && w.Case.ToLower() == revisionCase.ToLower() && w.Cycle.ToLower() == cycle.ToLower()).ToList();
        }
        public List<MBR_TRN_MARKET_PRICE_FORECAST> FindByFeedInfo(string scenario, string revisionCase, List<string> cycle, List<MRB_TRN_FEED_INFO> feedInfo) {
            Dictionary<int, int> res = new Dictionary<int, int>();
            var marketPriceByPK = _context.MBR_TRN_MARKET_PRICE_FORECASTs.Where(w => w.PlanType.ToLower() == scenario.ToLower() 
                                                                    && w.Case.ToLower() == revisionCase.ToLower() 
                                                                    && cycle.Select(s=>s.ToLower()).Contains(w.Cycle.ToLower())

                                                                    ).ToList();

            var bmarketPriceEnum = marketPriceByPK.AsEnumerable();

            var data = bmarketPriceEnum.Where(w => feedInfo.Select(s => new { PricingIndexKey = s.PricingIndexKey, PricingRefKey = s.PricingRefKey }).Contains(new { PricingIndexKey = w.MarketSource, PricingRefKey = w.MonthIndex }));

            return data.ToList();

        }
        public List<MBR_TRN_MARKET_PRICE_FORECAST> FindByFeedInfo(string scenario, string revisionCase, string cycle, List<MRB_TRN_FEED_INFO> feedInfo)
        {
            Dictionary<int, int> res = new Dictionary<int, int>();
            var marketPriceByPK = _context.MBR_TRN_MARKET_PRICE_FORECASTs.Where(w => w.PlanType.ToLower() == scenario.ToLower()
                                                                    && w.Case.ToLower() == revisionCase.ToLower()
                                                                    && cycle.ToLower()==w.Cycle.ToLower()

                                                                    ).ToList();

            var bmarketPriceEnum = marketPriceByPK.AsEnumerable();

            var data = bmarketPriceEnum.Where(w => feedInfo.Select(s => new { PricingIndexKey = s.PricingIndexKey, PricingRefKey = s.PricingRefKey }).Contains(new { PricingIndexKey = w.MarketSource, PricingRefKey = w.MonthIndex }));

            return data.ToList();

        }
        public List<MBR_TRN_MARKET_PRICE_FORECAST> FindByMOPJ(string scenario, string revisionCase, List<string> cycle, List<MRB_TRN_FEED_INFO> feedInfo)
        {
            Dictionary<int, int> res = new Dictionary<int, int>();
            var marketPriceByPK = _context.MBR_TRN_MARKET_PRICE_FORECASTs.Where(w => w.PlanType.ToLower() == scenario.ToLower()
                                                                    && w.Case.ToLower() == revisionCase.ToLower()
                                                                    && cycle.Select(s=>s.ToLower()).Contains(w.Cycle.ToLower())

                                                                    ).ToList();

            var bmarketPriceEnum = marketPriceByPK.AsEnumerable();

            var data = bmarketPriceEnum.Where(w => feedInfo.Select(s => new { PricingIndexKey = "MOPJ", PricingRefKey = s.PricingRefKey }).Contains(new { PricingIndexKey = w.MarketSource, PricingRefKey = w.MonthIndex }));

            return data.ToList();
        }
        public List<MBR_TRN_MARKET_PRICE_FORECAST> FindByMOPJ(string scenario, string revisionCase, string cycle, List<MRB_TRN_FEED_INFO> feedInfo)
        {
            Dictionary<int, int> res = new Dictionary<int, int>();
            var marketPriceByPK = _context.MBR_TRN_MARKET_PRICE_FORECASTs.Where(w => w.PlanType.ToLower() == scenario.ToLower()
                                                                    && w.Case.ToLower() == revisionCase.ToLower()
                                                                    && cycle.ToLower()==w.Cycle.ToLower()

                                                                    ).ToList();

            var bmarketPriceEnum = marketPriceByPK.AsEnumerable();

            var data = bmarketPriceEnum.Where(w => feedInfo.Select(s => new { PricingIndexKey = "MOPJ", PricingRefKey = s.PricingRefKey }).Contains(new { PricingIndexKey = w.MarketSource, PricingRefKey = w.MonthIndex }));

            return data.ToList();
        }
        public MarketPriceForecastMergeScenarioModel GetMergeScenario()
        {
            var scenarios = _readContext.MBR_MST_PLANTYPE.Select(s => s.PlanTypeName).ToList();
            Dictionary<string, List<string>> enumCycle = GetDictionaryCycle(scenarios);
            var data = _context.MBR_TRN_MARKET_PRICE_FORECASTs
                 .Select(s => new MarketPriceForecastMergeScenario()
                 {
                     Case = s.Case,
                     Cycle = s.Cycle,
                     Scenario = s.PlanType
                 }).Distinct().AsEnumerable()
                .Where(w => enumCycle.Select(s=>s.Key.ToLower()).Contains(w.Scenario.ToLower()) )
                .ToList();

            MarketPriceForecastMergeScenarioModel marketPriceForecastModel = new MarketPriceForecastMergeScenarioModel()
            {
                Available = data
            };
            return marketPriceForecastModel;
        }

        private Dictionary<string, List<string>> GetDictionaryCycle(List<string> scenarios)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            var now = DateTime.Now;
            var format = "";
            foreach (var scenario in scenarios)
            {
                if (scenario == SCENATIO.M18 || scenario == SCENATIO.W1 || scenario == SCENATIO.W3)
                {
                    format = FORMAT_CYCLE.MONTHLY;
                    GenerateCycle(scenario, map, now.AddMonths(-1), format);
                    GenerateCycle(scenario, map, now, format);
                    GenerateCycle(scenario, map, now.AddMonths(1), format);
                }
                else if (scenario == SCENATIO.OPPLAN)
                {
                    format = FORMAT_CYCLE.YEAR;
                    GenerateCycle(scenario, map, now, format);
                    GenerateCycle(scenario, map, now.AddYears(1), format);
                }
                else if (scenario == SCENATIO.MTP)
                {
                    format = FORMAT_CYCLE.YEAR;
                    GenerateCycle(scenario, map, now, format);
                }
                else if (scenario == SCENATIO.WEEKLY)
                {
                    format = FORMAT_CYCLE.WEEKLY;
                    var monday = StartOfWeek(now);
                    GenerateCycle(scenario, map, monday.AddDays(-7), format);
                    GenerateCycle(scenario, map, monday, format);
                    GenerateCycle(scenario, map, monday.AddDays(7), format);
                }
            }
            return map;
        }

        private void GenerateCycle(string scenarioKey, Dictionary<string, List<string>> map, DateTime date, string format)
        {
            var scenario = scenarioKey;
            if (scenarioKey == SCENATIO.WEEKLY)
            {
                scenario = "W";
            }
            var data = string.Format(format, scenario, date.Year, date.Month.ToString("00"), date.Day.ToString("00"));
            if (!map.ContainsKey(scenarioKey))
                map.Add(scenarioKey, new List<string>() { data });
            else
                map[scenarioKey].Add(data);
        }

        private DateTime StartOfWeek(DateTime dt)
        {
            int diff = (7 + (dt.DayOfWeek - DayOfWeek.Monday)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public List<MBR_TRN_MARKET_PRICE_FORECAST> GetMergeReportData(MergeReportRequestModel criteria)
        {
            if (string.IsNullOrEmpty(criteria.Scenario))
            {
                return new List<MBR_TRN_MARKET_PRICE_FORECAST>();
            }
            else
            {
                return _readContext.MBR_TRN_MARKET_PRICE_FORECASTs.Where(w =>
                w.PlanType.ToUpper() == criteria.Scenario.ToUpper()
                && w.Cycle.ToUpper() == criteria.Cycle.ToUpper()
                && w.Case.ToUpper() == criteria.Case.ToUpper()
                ).ToList();
            }
        }

      
    }
}