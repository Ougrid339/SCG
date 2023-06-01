using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempExchangeRateRepo : RepositoryBase<SSP_TMP_EXCHANGE_RATE>, IMasterTempExchangeRateRepo
    {
        #region Inject

        public MasterTempExchangeRateRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_EXCHANGE_RATE> GetByKey(string planType, string startMonth)
        {
            var result = _context.SSP_TMP_EXCHANGE_RATEs.Where(s => s.PlanType == planType && s.StartMonth == startMonth).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_EXCHANGE_RATEs.ToList();
            _context.RemoveRange(data);
        }
    }
}