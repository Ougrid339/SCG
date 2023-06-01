using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterFreightRepo : RepositoryBase<SSP_MST_FREIGHT>, IMasterFreightRepo
    {
        #region Inject

        public MasterFreightRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_FREIGHT> GetAllByKeyAndVersion(string productionSite, string regionCode, string planType, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_FREIGHTs.Where(s => s.ProductionSite == productionSite && s.RegionCode == regionCode && s.PlanType == planType && s.StartMonth == startMonth && s.VersionNo == versionNo).ToList();
            return result;
        }

        public List<SSP_MST_FREIGHT> GetByKey(string productionSite, string regionCode, string planType, string startMonth)
        {
            var result = _context.SSP_MST_FREIGHTs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.ProductionSite == productionSite && s.RegionCode == regionCode && s.PlanType == planType && s.StartMonth == startMonth).ToList();
            return result;
        }
    }
}