using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface;
using SCG.CHEM.MBR.DATAACCESS.Repository.Transaction.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp
{
    internal class MarketPriceForecastTempRepo : RepositoryBase<MBR_TMP_MARKET_PRICE_FORECAST>, IMarketPriceForecastTempRepo
    {
        public MarketPriceForecastTempRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public List<MBR_TMP_MARKET_PRICE_FORECAST> FindByCriteria(string scenario, string revisionCase, string cycle)
        {
            return _context.MBR_TMP_MARKET_PRICE_FORECASTs.Where(w => w.PlanType.ToLower() == scenario.ToLower() && w.Case.ToLower() == revisionCase.ToLower() && w.Cycle.ToLower() == cycle.ToLower()).ToList();
        }

        public List<MBR_TMP_MARKET_PRICE_FORECAST> FindAfter30minute()
        {
            var dateDel = DateTime.Now.AddMinutes(-30);
            return _context.MBR_TMP_MARKET_PRICE_FORECASTs.Where(w => w.CreatedDate <= dateDel).ToList();
        }

        public List<MBR_TMP_MARKET_PRICE_FORECAST> FindByRunId(string runId)
        {
            return _context.MBR_TMP_MARKET_PRICE_FORECASTs.Where(w => w.RunId == runId).ToList();
        }

        public MarketPriceForecastMergeScenarioModel GetMergeScenario()
        {
            var scenarios = _readContext.MBR_MST_PLANTYPE.Select(s => s.PlanTypeName).ToList();
            Dictionary<string, List<string>> enumCycle = GetDictionaryCycle(scenarios);
            var data = _context.MBR_TMP_MARKET_PRICE_FORECASTs
                 .Select(s => new MarketPriceForecastMergeScenario()
                 {
                     Case = s.Case,
                     Cycle = s.Cycle,
                     Scenario = s.PlanType
                 }).Distinct().AsEnumerable()
                .Where(w => enumCycle.Select(s => s.Key.ToLower()).Contains(w.Scenario.ToLower())).ToList();

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
    }
}