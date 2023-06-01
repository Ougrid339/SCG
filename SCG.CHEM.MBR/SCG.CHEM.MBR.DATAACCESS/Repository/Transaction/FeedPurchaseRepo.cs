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
    internal class FeedPurchaseRepo : RepositoryBase<MBR_TRN_FEED_PURCHASE>, IFeedPurchaseRepo
    {
        public FeedPurchaseRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public List<MBR_TRN_FEED_PURCHASE> FindByCriteria(string scenario, string @case, string cycle)
        {
            return _context.MBR_TRN_FEED_PURCHASEs.Where(w => w.PlanType.ToLower() == scenario.ToLower() && w.Case.ToLower() == @case.ToLower() && w.Cycle.ToLower() == cycle.ToLower()).ToList();
        }

        public List<MBR_TRN_FEED_PURCHASE> FindByCriteria(string scenario, string @case, string cycle, List<string> companys)
        {
            return _context.MBR_TRN_FEED_PURCHASEs.Where(w => w.PlanType.ToLower() == scenario.ToLower() && w.Case.ToLower() == @case.ToLower() && w.Cycle.ToLower() == cycle.ToLower() && companys.Select(s => s.ToLower()).Contains(w.Company)).ToList();
        }

        public List<OptienceMergeScenario> GetMergeScenario()
        {
            var scenarios = _readContext.MBR_MST_PLANTYPE.Select(s => s.PlanTypeName).ToList();
            var typeName = _readContext.MBR_MST_MASTER_EXCELs.FirstOrDefault(s => s.ExcelId == MASTER_EXCEL_TYPE.FEED_PURCHASE)?.MasterName;
            Dictionary<string, List<string>> enumCycle = GetDictionaryCycle(scenarios);
            var data = _context.MBR_TRN_FEED_PURCHASEs
                 .Select(s => new OptienceMergeScenario()
                 {
                     TypeId = MASTER_EXCEL_TYPE.FEED_PURCHASE,
                     TypeName = typeName,
                     Case = s.Case,
                     Cycle = s.Cycle,
                     Scenario = s.PlanType
                 }).Distinct().AsEnumerable()
               .Where(w => enumCycle.Select(s => s.Key.ToLower()).Contains(w.Scenario.ToLower())).ToList();
            return data;
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