using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempActualHedgingRepo : RepositoryBase<SSP_TMP_ACTUAL_HEDGING>, IMasterTempActualHedgingRepo
    {
        #region Inject

        public MasterTempActualHedgingRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_ACTUAL_HEDGING> GetByKey(string planType, string productionSite, string customer, string salesGroup, string matCode, string startMonth)
        {
            var result = _context.SSP_TMP_ACTUAL_HEDGINGs.Where(s => s.PlanType == planType && s.ProductionSite == productionSite && s.Customer == customer && s.SalesGroup == salesGroup
                                                                  && s.MatCode == matCode && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_ACTUAL_HEDGINGs.ToList();
            _context.RemoveRange(data);
        }
    }
}