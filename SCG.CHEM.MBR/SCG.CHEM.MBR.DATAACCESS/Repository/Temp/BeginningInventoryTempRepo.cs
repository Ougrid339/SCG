using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface;
using SCG.CHEM.MBR.DATAACCESS.Repository.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Transaction
{
    internal class BeginningInventoryTempRepo : RepositoryBase<MBR_TMP_BEGINING_INVENTORY>, IBeginningInventoryTempRepo
    {
        public BeginningInventoryTempRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public List<MBR_TMP_BEGINING_INVENTORY> FindAfter30minute()
        {
            var dateDel = DateTime.Now.AddMinutes(-30);
            return _context.MBR_TMP_BEGINING_INVENTORYs.Where(w => w.CreatedDate < dateDel).ToList();
        }

        public List<MBR_TMP_BEGINING_INVENTORY> FindByCriterias(string scenario, string @case, string cycle)
        {
            return _context.MBR_TMP_BEGINING_INVENTORYs.Where(w => w.PlanType.ToLower() == scenario.ToLower() && w.Case.ToLower() == @case.ToLower() && w.Cycle.ToLower() == cycle.ToLower()).ToList();
        }

        public List<MBR_TMP_BEGINING_INVENTORY> FindByRunId(string runId)
        {
            return _context.MBR_TMP_BEGINING_INVENTORYs.Where(w => w.RunId == runId).ToList();
        }
    }
}