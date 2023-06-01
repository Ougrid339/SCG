using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterFreightSubRegionRepo : RepositoryBase<SSP_MST_FREIGHT_SUBREGION>, IMasterFreightSubRegionRepo
    {
        #region Inject

        public MasterFreightSubRegionRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_FREIGHT_SUBREGION> GetByKey(string productionSite, string regionCode, string subRegion, string planType, string startMonth)
        {
            var result = _context.SSP_MST_FREIGHT_SUBREGIONs.Where(s => s.ProductionSite == productionSite && s.RegionCode == regionCode && s.SubRegion == subRegion && s.PlanType == planType && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public List<SSP_MST_FREIGHT_SUBREGION> GetAllByKeyAndVersion(string productionSite, string regionCode, string subRegion, string planType, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_FREIGHT_SUBREGIONs.Where(s => s.ProductionSite == productionSite && s.RegionCode == regionCode && s.SubRegion == subRegion && s.PlanType == planType && s.StartMonth == startMonth && s.VersionNo == versionNo).ToList();
            return result;
        }

        public List<SSP_MST_FREIGHT_SUBREGION> GetBySubRegions(List<string> subRegion)
        {
            var result = _context.SSP_MST_FREIGHT_SUBREGIONs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && subRegion.Contains(s.SubRegion)).ToList();
            return result;
        }
    }
}