using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterSubRegionRepo : RepositoryBase<SSP_MST_SUB_REGION>, IMasterSubRegionRepo
    {
        #region Inject

        public MasterSubRegionRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_SUB_REGION> GetByKey(List<string> region, List<string> subRegion)
        {
            var result = _context.SSP_MST_SUB_REGIONs.Where(s => subRegion.Contains(s.SubRegion) && region.Contains(s.Region)).ToList();
            return result;
        }

        public List<SSP_MST_SUB_REGION> GetBySubRegion(List<string> subRegion)
        {
            var result = _context.SSP_MST_SUB_REGIONs.Where(s => subRegion.Contains(s.SubRegion)).ToList();
            return result;
        }
    }
}