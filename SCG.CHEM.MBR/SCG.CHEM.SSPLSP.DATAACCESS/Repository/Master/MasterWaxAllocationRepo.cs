using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterWaxAllocationRepo : RepositoryBase<SSP_MST_WAX_ALLOCATION>, IMasterWaxAllocationRepo
    {
        #region Inject

        public MasterWaxAllocationRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_WAX_ALLOCATION> GetByKey(string planType, string waxGroupId, string fromProductionLine, string toProductionLine, string startMonth)
        {
            var result = _context.SSP_MST_WAX_ALLOCATIONs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.PlanType == planType && s.WaxGroupId == waxGroupId && s.FromProductionLine == fromProductionLine && s.ToProductionLine == toProductionLine
                         && s.StartMonth == startMonth).ToList();
            return result;
        }

        public List<SSP_MST_WAX_ALLOCATION> GetAllByKeyAndVersion(string planType, string waxGroupId, string fromProductionLine, string toProductionLine, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_WAX_ALLOCATIONs.Where(s => s.VersionNo == versionNo && s.PlanType == planType && s.WaxGroupId == waxGroupId && s.FromProductionLine == fromProductionLine && s.ToProductionLine == toProductionLine
                         && s.StartMonth == startMonth).ToList();
            return result;
        }
    }
}