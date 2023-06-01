using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempMarketPriceGapRepo : IRepositoryBase<SSP_TMP_MARKET_PRICE_GAP>
    {
        List<SSP_TMP_MARKET_PRICE_GAP> GetByKey(string productionSite, string plantType, string baseMarketGroup, string marketGroup, string startMonth);

        void Truncate();
    }
}