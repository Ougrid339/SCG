using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterPriceUnitRepo : RepositoryBase<SSP_MST_PRICE_UNIT>, IMasterPriceUnitRepo
    {
        #region Inject

        public MasterPriceUnitRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_PRICE_UNIT> GetByPriceUnitId(List<int> data)
        {
            var result = _context.SSP_MST_PRICE_UNITs.Where(s => data.Contains(s.PriceUnitId)).ToList();
            return result;
        }

        public List<SSP_MST_PRICE_UNIT> GetByPriceUnitDesc(List<string> data)
        {
            var result = _context.SSP_MST_PRICE_UNITs.Where(s => data.Contains(s.PriceUnitDesc)).ToList();
            return result;
        }
    }
}