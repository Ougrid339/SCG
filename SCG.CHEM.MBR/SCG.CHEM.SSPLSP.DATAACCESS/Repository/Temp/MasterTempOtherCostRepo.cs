using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempOtherCostRepo : RepositoryBase<SSP_TMP_OTHER_COST>, IMasterTempOtherCostRepo
    {
        #region Inject

        public MasterTempOtherCostRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_OTHER_COST> GetByKey(string planType, string channel, string salesOrg, string startMonth)
        {
            var result = _context.SSP_TMP_OTHER_COSTs.Where(s => s.PlanType == planType && s.Channel == channel && s.SalesOrg == salesOrg && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_OTHER_COSTs.ToList();
            _context.RemoveRange(data);
        }
    }
}