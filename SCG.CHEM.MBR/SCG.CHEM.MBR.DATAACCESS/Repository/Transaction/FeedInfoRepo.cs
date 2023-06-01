using Microsoft.EntityFrameworkCore;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
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
    public class FeedInfoRepo : RepositoryBase<MRB_TRN_FEED_INFO>, IFeedInfoRepo
    {
        public FeedInfoRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public List<MRB_TRN_FEED_INFO> FindByCriterias(string planType, string @case, string cycle)
        {
            return _context.MRB_TRN_FEED_INFOs.Where(w => w.PlanType.ToLower() == planType.ToLower() && w.Case.ToLower() == @case.ToLower() && w.Cycle.ToLower() == cycle.ToLower()).ToList();
        }

        public List<MRB_TRN_FEED_INFO> FindByCriteriasAll(string planType, string @case, string cycle, List<string> Company, List<string>? FeedGeoCategoryKey, List<string>? FeedNameKey, List<string>? ProductGroup)
        {
            var resultValue = _context.MRB_TRN_FEED_INFOs.Where(w => w.PlanType.ToLower() == planType.ToLower() && w.Case.ToLower() == @case.ToLower() && w.Cycle.ToLower() == cycle.ToLower()).AsNoTracking().ToList();
            if (Company != null && Company.Count > 0) { resultValue = resultValue.Where(o => Company.Contains(o.Company)).ToList(); }
            if (FeedGeoCategoryKey != null && FeedGeoCategoryKey.Count > 0) { resultValue = resultValue.Where(o => FeedGeoCategoryKey.Contains(o.FeedGeoCategoryKey)).ToList(); }
            if (FeedNameKey != null && FeedNameKey.Count > 0) { resultValue = resultValue.Where(o => FeedNameKey.Contains(o.FeedNameKey)).ToList(); }
            if (ProductGroup != null && ProductGroup.Count > 0) { resultValue = resultValue.Where(o => ProductGroup.Contains(o.ProductGroup)).ToList(); }
            return resultValue;
        }

        public List<MRB_TRN_FEED_INFO> FindByCriteriasAll(string planType, string @case, List<string> cycle, List<string> Company, List<string>? FeedGeoCategoryKey, List<string>? FeedNameKey, List<string>? ProductGroup)
        {
            var resultValue = _context.MRB_TRN_FEED_INFOs.Where(w => w.PlanType.ToLower() == planType.ToLower() && w.Case.ToLower() == @case.ToLower() && cycle.Select(s => s.ToLower()).Contains(w.Cycle.ToLower())).ToList();
            if (Company != null && Company.Count > 0) { resultValue = resultValue.Where(o => Company.Contains(o.Company)).ToList(); }
            if (FeedGeoCategoryKey != null && FeedGeoCategoryKey.Count > 0) { resultValue = resultValue.Where(o => FeedGeoCategoryKey.Contains(o.FeedGeoCategoryKey)).ToList(); }
            if (FeedNameKey != null && FeedNameKey.Count > 0) { resultValue = resultValue.Where(o => FeedNameKey.Contains(o.FeedNameKey)).ToList(); }
            if (ProductGroup != null && ProductGroup.Count > 0) { resultValue = resultValue.Where(o => ProductGroup.Contains(o.ProductGroup)).ToList(); }
            return resultValue;
        }

        public List<MRB_TRN_FEED_INFO> FindByCriteriasAll(string planType, string @case, string cycle, List<string> Company, List<string>? FeedGeoCategoryKey, List<string>? FeedNameKey, List<string>? ProductGroup, List<string>? MaterialCode)
        {
            var resultValue = _context.MRB_TRN_FEED_INFOs.Where(w => w.PlanType.ToLower() == planType.ToLower() && w.Case.ToLower() == @case.ToLower() && w.Cycle.ToLower() == cycle.ToLower()).AsNoTracking().ToList();
            if (Company != null && Company.Count > 0) { resultValue = resultValue.Where(o => Company.Contains(o.Company)).ToList(); }
            if (FeedGeoCategoryKey != null && FeedGeoCategoryKey.Count > 0) { resultValue = resultValue.Where(o => FeedGeoCategoryKey.Contains(o.FeedGeoCategoryKey)).ToList(); }
            //if (FeedNameKey != null && FeedNameKey.Count > 0) { resultValue = resultValue.Where(o => FeedNameKey.Contains(o.FeedNameKey)).ToList(); }
            if (MaterialCode != null && MaterialCode.Count > 0) { resultValue = resultValue.Where(o => MaterialCode.Contains(o.MaterialCode)).ToList(); }
            if (ProductGroup != null && ProductGroup.Count > 0) { resultValue = resultValue.Where(o => ProductGroup.Contains(o.ProductGroup)).ToList(); }
            return resultValue;
        }

        public FeedInfoMergeScenarioModel GetMergeScenario()
        {
            //var scenarios = _readContext.MBR_MST_SCENARIOs.Select(s => s.SceneDesc).ToList();
            //Dictionary<string, List<string>> enumCycle = GetDictionaryCycle(scenarios);
            //var data = _context.MRB_TRN_FEED_INFOs
            //     .Select(s => new FeedInfoMergeScenario()
            //     {
            //         Case = s.Case,
            //         Cycle = s.Cycle,
            //         Scenario = s.PlanType
            //     }).Distinct().AsEnumerable()
            //    .Where(w => enumCycle.ContainsKey(w.Scenario) && enumCycle[w.Scenario].Contains(w.Cycle)).ToList();

            var data = _context.MRB_TRN_FEED_INFOs.Select(s => new FeedInfoMergeScenario()
            {
                Scenario = s.PlanType,
                Cycle = s.Cycle,
                Case = s.Case
            }).Distinct().ToList();

            FeedInfoMergeScenarioModel feedInfoModel = new FeedInfoMergeScenarioModel()
            {
                Available = data
            };
            return feedInfoModel;
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