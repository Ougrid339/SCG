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
    public class MasterTempPolymerPriceRepo : RepositoryBase<SSP_TMP_POLYMER_PRICE>, IMasterTempPolymerPriceRepo
    {
        #region Inject

        public MasterTempPolymerPriceRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_POLYMER_PRICE> GetByKey(string planType, string marketPrice)
        {
            var result = _context.SSP_TMP_POLYMER_PRICEs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.PlanType == planType && s.MarketGroup == marketPrice).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_POLYMER_PRICEs.ToList();
            _context.RemoveRange(data);
        }
    }
}