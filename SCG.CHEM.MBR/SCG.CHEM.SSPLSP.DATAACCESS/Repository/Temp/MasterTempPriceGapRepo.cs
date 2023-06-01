using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempPriceGapRepo : RepositoryBase<SSP_TMP_PRICE_GAP>, IMasterTempPriceGapRepo
    {
        #region Inject

        public MasterTempPriceGapRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_PRICE_GAP> GetByKey(string planType, string rawMatCode, string startMonth)
        {
            var result = _context.SSP_TMP_PRICE_GAPs.Where(s => s.PlanType == planType && s.RawMatCode == rawMatCode && s.StartMonth == startMonth).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_PRICE_GAPs.ToList();
            _context.RemoveRange(data);
        }
    }
}