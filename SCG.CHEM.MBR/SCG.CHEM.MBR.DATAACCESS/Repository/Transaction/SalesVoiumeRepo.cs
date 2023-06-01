using Microsoft.EntityFrameworkCore;
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
    public class SalesVoiumeRepo : RepositoryBase<MBR_TRN_SALES_VOLUME>, ISalesVoiumeRepo
    {
        public SalesVoiumeRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public List<MBR_TRN_SALES_VOLUME> FindByCriteria(string scenario, string @case, string cycle)
        {
            return _context.MBR_TRN_SALES_VOLUMEs.Where(w => w.PlanType.ToLower() == scenario.ToLower() && w.Case.ToLower() == @case.ToLower() && w.Cycle.ToLower() == cycle.ToLower()).ToList();
        }

        public List<MBR_TRN_SALES_VOLUME> FindByCriteria(string scenario, string @case, string cycle, string product)
        {
            return _context.MBR_TRN_SALES_VOLUMEs.Where(w => w.PlanType.ToLower() == scenario.ToLower() && w.Case.ToLower() == @case.ToLower() && w.Cycle.ToLower() == cycle.ToLower() && w.Product.ToLower() == product.ToLower()).ToList();
        }
        public List<MBR_TRN_SALES_VOLUME> FindByCriteriaProductGroup(string scenario, string @case, string cycle, string productGroup)
        {
            return _context.MBR_TRN_SALES_VOLUMEs.Where(w => w.PlanType.ToLower() == scenario.ToLower() && w.Case.ToLower() == @case.ToLower() && w.Cycle.ToLower() == cycle.ToLower() && w.ProductGroup.ToLower() == productGroup.ToLower()).ToList();
        }

        public List<MBR_TRN_SALES_VOLUME> FindByCriterias(string cycle, string @case,  List<string>? company, List<string>? product, List<string>? productGroup, List<string>? channel)
        {
            var query = _context.MBR_TRN_SALES_VOLUMEs.Where(w => w.Case.ToLower() == @case.ToLower() &&
                                                                  w.Cycle.ToLower() == cycle.ToLower()).AsNoTracking();

            if (company != null && company.Count > 0) {
                query = query.Where(o => company.Contains(o.Company));
            }

            if (product != null && product.Count > 0) {
                query = query.Where(o => product.Contains(o.Product));
            }

            if (productGroup != null && productGroup.Count > 0) {
                query = query.Where(o => productGroup.Contains(o.ProductGroup));
            }

            if (channel != null && channel.Count > 0) { 
                query = query.Where(o => channel.Contains(o.Channel));
            
            }
            return query.ToList();
        }

        public SalesMergeScenarioModel GetMergeScenario()
        {
            var scenarios = _readContext.MBR_MST_PLANTYPE.Select(s => s.PlanTypeName).ToList();
            scenarios.Add(SCENATIO.ACTUAL);
            Dictionary<string, List<string>> enumCycle = GetDictionaryCycle(scenarios);
            var data = _context.MBR_TRN_SALES_VOLUMEs
                 .Select(s => new SalesMergeScenario()
                 {
                     Case = s.Case,
                     Cycle = s.Cycle,
                     Scenario = s.PlanType
                 }).Distinct().AsEnumerable()
                .Where(w => enumCycle.Select(s => s.Key.ToLower()).Contains(w.Scenario.ToLower()))
                .ToList();

            SalesMergeScenarioModel salesMergeScenarioModel = new SalesMergeScenarioModel()
            {
                Available = data
            };
            return salesMergeScenarioModel;
        }

        private Dictionary<string, List<string>> GetDictionaryCycle(List<string> scenarios)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            var now = DateTime.Now;
            var format = "";
            foreach (var scenario in scenarios)
            {
                if (scenario == SCENATIO.M18 || scenario == SCENATIO.W1 || scenario == SCENATIO.W3 || scenario.ToUpper() == SCENATIO.ACTUAL.ToUpper())
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