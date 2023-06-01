using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class LockUnlockCycleRepo : RepositoryBase<MBR_MST_LOCKUNLOCKCYCLE>, ILockUnlockCycleRepo
    {
        public LockUnlockCycleRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public MBR_MST_LOCKUNLOCKCYCLE GetByCriteria(string scenario, string cycle, string caseName)
        {
            var result = _context.MBR_MST_LOCKUNLOCKCYCLEs.Where(w => w.PlanType.ToLower() == scenario.ToLower() && w.Case.ToLower() == caseName.ToLower() && w.Cycle.ToLower() == cycle.ToLower() && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).FirstOrDefault();

            return result;
        }
    }
}