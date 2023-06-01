using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterPriceGapRepo : RepositoryBase<SSP_MST_PRICE_GAP>, IMasterPriceGapRepo
    {
        #region Inject

        public MasterPriceGapRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_PRICE_GAP> GetByKey(string planType, string rawMatCode, string startMonth)
        {
            var result = _context.SSP_MST_PRICE_GAPs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.PlanType == planType && s.RawMatCode == rawMatCode && s.StartMonth == startMonth).ToList();
            return result;
        }

        public List<SSP_MST_PRICE_GAP> GetAllByKeyAndVersion(string planType, string rawMatCode, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_PRICE_GAPs.Where(s => s.VersionNo == versionNo && s.PlanType == planType && s.RawMatCode == rawMatCode && s.StartMonth == startMonth).ToList();
            return result;
        }
    }
}