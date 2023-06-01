using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterMarketPriceGapRepo : IRepositoryBase<SSP_MST_MARKET_PRICE_GAP>
    {
        List<SSP_MST_MARKET_PRICE_GAP> GetByKey(string productionSite, string plantType, string baseMarketGroup, string marketGroup, string startMonth);

        List<SSP_MST_MARKET_PRICE_GAP> GetAllByKeyAndVersion(string productionSite, string plantType, string baseMarketGroup, string marketGroup, string startMonth, int versionNo);
    }
}