using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterActualHedgingRepo : RepositoryBase<SSP_MST_ACTUAL_HEDGING>, IMasterActualHedgingRepo
    {
        #region Inject

        public MasterActualHedgingRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_ACTUAL_HEDGING> GetByKey(string planType, string productionSite, string customer, string salesGroup, string matCode, string startMonth)
        {
            var result = _context.SSP_MST_ACTUAL_HEDGINGs.Where(s => s.PlanType == planType && s.ProductionSite == productionSite && s.Customer == customer && s.SalesGroup == salesGroup
                                                                  && s.MatCode == matCode && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public List<SSP_MST_ACTUAL_HEDGING> GetAllByKeyAndVersion(string planType, string productionSite, string customer, string salesGroup, string matCode, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_ACTUAL_HEDGINGs.Where(s => s.PlanType == planType && s.ProductionSite == productionSite && s.Customer == customer && s.SalesGroup == salesGroup
                                                                  && s.MatCode == matCode && s.StartMonth == startMonth && s.VersionNo == versionNo).ToList();
            return result;
        }
    }
}