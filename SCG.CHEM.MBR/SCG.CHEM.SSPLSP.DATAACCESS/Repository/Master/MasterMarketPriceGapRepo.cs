using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    internal class MasterMarketPriceGapRepo : RepositoryBase<SSP_MST_MARKET_PRICE_GAP>, IMasterMarketPriceGapRepo
    {
        #region Inject

        public MasterMarketPriceGapRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_MARKET_PRICE_GAP> GetByKey(string productionSite, string plantType, string baseMarketGroup, string marketGroup, string startMonth)
        {
            var result = _context.SSP_MST_MARKET_PRICE_GAPs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.ProductionSite == productionSite && s.PlanType == plantType && s.BaseMarketGroup == baseMarketGroup && s.MarketGroup == marketGroup
                       && s.StartMonth == startMonth).ToList();
            return result;
        }

        public List<SSP_MST_MARKET_PRICE_GAP> GetAllByKeyAndVersion(string productionSite, string plantType, string baseMarketGroup, string marketGroup, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_MARKET_PRICE_GAPs.Where(s => s.VersionNo == versionNo && s.ProductionSite == productionSite && s.PlanType == plantType && s.BaseMarketGroup == baseMarketGroup && s.MarketGroup == marketGroup
                       && s.StartMonth == startMonth).ToList();
            return result;
        }
    }
}