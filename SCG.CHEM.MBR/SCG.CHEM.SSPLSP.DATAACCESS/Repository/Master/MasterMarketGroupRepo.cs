using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterMarketGroupRepo : RepositoryBase<SSP_MST_MARKET_GROUP>, IMasterMarketGroupRepo
    {
        #region Inject

        public MasterMarketGroupRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_MARKET_GROUP> GetByMarketGroup(List<string> data)
        {
            var result = _context.SSP_MST_MARKET_GROUPs.Where(s => data.Contains(s.MarketGroup)).ToList();
            return result;
        }
    }
}