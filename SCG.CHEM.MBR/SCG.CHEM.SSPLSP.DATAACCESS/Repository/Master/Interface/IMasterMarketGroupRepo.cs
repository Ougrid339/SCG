using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterMarketGroupRepo : IRepositoryBase<SSP_MST_MARKET_GROUP>
    {
        List<SSP_MST_MARKET_GROUP> GetByMarketGroup(List<string> data);
    }
}