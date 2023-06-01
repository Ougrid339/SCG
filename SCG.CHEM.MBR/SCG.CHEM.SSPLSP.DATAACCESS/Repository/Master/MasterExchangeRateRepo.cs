using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterExchangeRateRepo : RepositoryBase<SSP_MST_EXCHANGE_RATE>, IMasterExchangeRateRepo
    {
        #region Inject

        public MasterExchangeRateRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_EXCHANGE_RATE> GetAllByKeyAndVersion(string planType, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_EXCHANGE_RATEs.Where(s => s.PlanType == planType && s.StartMonth == startMonth && s.VersionNo == versionNo).ToList();
            return result;
        }

        public List<SSP_MST_EXCHANGE_RATE> GetByKey(string planType, string startMonth)
        {
            var result = _context.SSP_MST_EXCHANGE_RATEs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.PlanType == planType && s.StartMonth == startMonth).ToList();
            return result;
        }
        public List<SSP_MST_EXCHANGE_RATE> GetByKey(string planType, List<string> startMonth)
        {
            var result = _context.SSP_MST_EXCHANGE_RATEs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.PlanType == planType && startMonth.Contains(s.StartMonth)).ToList();
            return result;
        }
    }
}