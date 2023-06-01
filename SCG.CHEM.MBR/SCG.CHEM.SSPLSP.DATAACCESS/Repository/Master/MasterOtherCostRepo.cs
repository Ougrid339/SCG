using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterOtherCostRepo : RepositoryBase<SSP_MST_OTHER_COST>, IMasterOtherCostRepo
    {
        #region Inject

        public MasterOtherCostRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_OTHER_COST> GetByKey(string planType, string channel, string salesOrg, string startMonth)
        {
            var result = _context.SSP_MST_OTHER_COSTs.Where(s => s.PlanType == planType && s.Channel == channel && s.SalesOrg == salesOrg && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public List<SSP_MST_OTHER_COST> GetAllByKeyAndVersion(string planType, string channel, string salesOrg, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_OTHER_COSTs.Where(s => s.VersionNo == versionNo && s.PlanType == planType && s.Channel == channel && s.SalesOrg == salesOrg && s.StartMonth == startMonth).ToList();
            return result;
        }
    }
}