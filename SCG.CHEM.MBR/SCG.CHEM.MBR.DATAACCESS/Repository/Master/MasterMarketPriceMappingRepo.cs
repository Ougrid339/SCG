using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterMarketPriceMappingRepo : RepositoryBase<MBR_MST_MARKET_PRICE_MAPPING>, IMasterMarketPriceMappingRepo
    {
        #region Inject

        public MasterMarketPriceMappingRepo(EntitiesMBRContext context, EntitiesMBRReadContext readContext) : base(context, readContext)
        {
        }

        #endregion Inject

        public List<string> IsNotContainMarketPriceMIs(List<string> marketPriceMIs)
        {
            return marketPriceMIs.Select(s => s.ToLower()).Where(d => !_readContext.MBR_MST_MARKET_PRICE_MAPPINGs.Select(s => s.MarketPriceMI.ToLower()).Contains(d)).Select(s => s).ToList();
        }

        public List<string> GetMarketPriceMIs(List<string> marketPriceMIs)
        {
            return _readContext.MBR_MST_MARKET_PRICE_MAPPINGs.Where(d => marketPriceMIs.Select(s => s.ToLower()).Contains(d.MarketPriceMI.ToLower())).Select(s => s.MarketPriceMI).ToList();
        }
        public List<MBR_MST_MARKET_PRICE_MAPPING> GetMarketPriceNameByMarketPriceMI(List<string> marketPriceMIs)
        {
            return _readContext.MBR_MST_MARKET_PRICE_MAPPINGs.Where(d => marketPriceMIs.Select(s => s.ToLower()).Contains(d.MarketPriceMI.ToLower())).ToList();
        }

        public List<MBR_MST_MARKET_PRICE_MAPPING> GetAllByKeyAndVersion(string marketPriceMI, string marketPriceWebPricing, int versionNo, string marketPriceName)
        {
            var result = _context.MBR_MST_MARKET_PRICE_MAPPINGs
                .Where(s => s.MarketPriceMI == marketPriceMI &&
                            s.MarketPriceWebPricing == marketPriceWebPricing && 
                            s.VersionNo == versionNo && 
                            s.MarketPriceName == marketPriceName)
                .ToList();

            return result;
        }

        public List<MBR_MST_MARKET_PRICE_MAPPING> GetAllByEBACode(List<string> ebaCode)
        {
            var result = _context.MBR_MST_MARKET_PRICE_MAPPINGs.Where(s => ebaCode.Contains(s.EBACode) && s.DeletedFlag == APPCONSTANT.DELETE_FLAG.NO).ToList();
            return result;
        }
        public MBR_MST_MARKET_PRICE_MAPPING? GetMarketPriceMIByMarketPriceName(string marketPriceName)
        {
            //if (string.IsNullOrEmpty(marketPriceName))
            //{
            //    marketPriceName = "none";
            //}
            return _context.MBR_MST_MARKET_PRICE_MAPPINGs.Where(s => !string.IsNullOrEmpty(marketPriceName) && s.MarketPriceName.ToUpper() == marketPriceName.ToUpper()).FirstOrDefault();
        }
    }
}