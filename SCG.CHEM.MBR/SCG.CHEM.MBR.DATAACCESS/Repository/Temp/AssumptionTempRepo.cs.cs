using Microsoft.EntityFrameworkCore;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class AssumptionTempRepo : RepositoryBase<MBR_TMP_ASSUMPTION>, IAssumptionTempRepo
    {
        #region Inject

        public AssumptionTempRepo(EntitiesMBRContext context, EntitiesMBRReadContext readContext) : base(context, readContext)
        {
        }


        #endregion Inject

        public List<MBR_TMP_ASSUMPTION> GetByRunId(string runid)
        {
            var result = _context.MBR_TMP_ASSUMPTIONs.Where(w => w.RunId == runid).ToList();
            return result;
        }

        public List<MBR_TMP_ASSUMPTION> GetAssumption(string type, string planType, string cycle, string @case)
        {
            var result = _context.MBR_TMP_ASSUMPTIONs.Where(w => w.Type.ToLower() == type.ToLower() && w.PlanType.ToLower() == planType.ToLower() && w.Cycle.ToLower() == cycle.ToLower() && w.Case.ToLower() == @case.ToLower()/*&& w.DeletedFlag == APPCONSTANT.DELETE_FLAG.NO*/).ToList();
            return result;
        }

        public List<MBR_TMP_ASSUMPTION> GetOlderThanOneHourRecord()
        {
            var now = DateTime.Now.AddHours(-1.00);
            var result = _context.MBR_TMP_ASSUMPTIONs.Where(s => s.CreatedDate <= now).ToList();

            return result;
        }

    }
}
