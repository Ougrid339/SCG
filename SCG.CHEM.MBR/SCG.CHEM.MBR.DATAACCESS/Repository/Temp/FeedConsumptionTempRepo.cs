using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp
{
    internal class FeedConsumptionTempRepo : RepositoryBase<MBR_TMP_FEED_CONSUMPTION>, IFeedConsumptionTempRepo
    {
        public FeedConsumptionTempRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public List<MBR_TMP_FEED_CONSUMPTION> FindAfter30minute()
        {
            var dateDel = DateTime.Now.AddMinutes(-30);
            return _context.MBR_TMP_FEED_CONSUMPTIONs.Where(w => w.CreatedDate < dateDel).ToList();
        }

        public List<MBR_TMP_FEED_CONSUMPTION> FindByCriterias(string scenario, string @case, string cycle)
        {
            return _context.MBR_TMP_FEED_CONSUMPTIONs.Where(w => w.PlanType.ToLower() == scenario.ToLower() && w.Case.ToLower() == @case.ToLower() && w.Cycle.ToLower() == cycle.ToLower()).ToList();
        }

        public List<MBR_TMP_FEED_CONSUMPTION> FindByCriterias(string scenario, string @case, string cycle, List<string> companys)
        {
            return _context.MBR_TMP_FEED_CONSUMPTIONs.Where(w => w.PlanType.ToLower() == scenario.ToLower() && w.Case.ToLower() == @case.ToLower() && w.Cycle.ToLower() == cycle.ToLower() && companys.Select(s => s.ToLower()).Contains(w.Company)).ToList();
        }

        public List<MBR_TMP_FEED_CONSUMPTION> FindByRunId(string runId)
        {
            return _context.MBR_TMP_FEED_CONSUMPTIONs.Where(w => w.RunId == runId).ToList();
        }
    }
}