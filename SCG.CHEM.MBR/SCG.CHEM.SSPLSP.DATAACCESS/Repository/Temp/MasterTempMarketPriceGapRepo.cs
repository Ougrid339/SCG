using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    internal class MasterTempMarketPriceGapRepo : RepositoryBase<SSP_TMP_MARKET_PRICE_GAP>, IMasterTempMarketPriceGapRepo
    {
        #region Inject

        public MasterTempMarketPriceGapRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_MARKET_PRICE_GAP> GetByKey(string productionSite, string plantType, string baseMarketGroup, string marketGroup, string startMonth)
        {
            var result = _context.SSP_TMP_MARKET_PRICE_GAPs.Where(s => s.ProductionSite == productionSite && s.PlanType == plantType && s.BaseMarketGroup == baseMarketGroup && s.MarketGroup == marketGroup
                       && s.StartMonth == startMonth).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_MARKET_PRICE_GAPs.ToList();
            _context.RemoveRange(data);
        }
    }
}