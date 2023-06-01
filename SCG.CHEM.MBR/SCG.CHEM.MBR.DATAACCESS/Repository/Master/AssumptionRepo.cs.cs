using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class AssumptionRepo : RepositoryBase<MBR_MST_ASSUMPTION>, IAssumptionRepo
    {
        #region Inject

        public AssumptionRepo(EntitiesMBRContext context, EntitiesMBRReadContext readContext) : base(context, readContext)
        {
        }

        #endregion Inject
        public List<MBR_MST_ASSUMPTION> GetAssumption(string type, string planType, string cycle, string @case)
        {
            var result = _context.MBR_MST_ASSUMPTIONs.Where(w => w.Type.ToLower() == type.ToLower() && 
                                                                 w.PlanType.ToLower() == planType.ToLower() && 
                                                                 w.Cycle.ToLower() == cycle.ToLower() &&
                                                                 w.Case.ToLower() == @case.ToLower() 
                                                                 && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public List<MBR_MST_ASSUMPTION> GetAllByKeyAndVersion(string type, string planType, string cycle, string @case, int versionNo)
        {
            var result = _context.MBR_MST_ASSUMPTIONs.Where(w => w.Type.ToLower() == type.ToLower() &&
                                                                 w.PlanType.ToLower() == planType.ToLower() &&
                                                                 w.Cycle.ToLower() == cycle.ToLower() &&
                                                                 w.Case.ToLower() == @case.ToLower() && 
                                                                 w.VersionNo == versionNo).ToList();
            return result;
        }
    }
}
