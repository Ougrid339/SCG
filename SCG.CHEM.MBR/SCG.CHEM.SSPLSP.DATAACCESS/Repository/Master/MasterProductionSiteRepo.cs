using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterProductionSiteRepo : RepositoryBase<SSP_MST_PRODUCTION_SITE>, IMasterProductionSiteRepo
    {
        #region Inject

        public MasterProductionSiteRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_PRODUCTION_SITE> GetProductionSite(List<string> data)
        {
            var result = _context.SSP_MST_PRODUCTION_SITEs.Where(s => data.Contains(s.ProductionSite)).ToList();
            return result;
        }
    }
}