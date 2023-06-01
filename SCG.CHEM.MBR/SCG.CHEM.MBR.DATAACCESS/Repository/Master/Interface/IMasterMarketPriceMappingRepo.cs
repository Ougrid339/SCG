using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterMarketPriceMappingRepo : IRepositoryBase<MBR_MST_MARKET_PRICE_MAPPING>
    {
        List<string> IsNotContainMarketPriceMIs(List<string> marketPriceMIs);

        List<string> GetMarketPriceMIs(List<string> marketPriceMIs);
        List<MBR_MST_MARKET_PRICE_MAPPING> GetMarketPriceNameByMarketPriceMI(List<string> marketPriceMIs);

        List<MBR_MST_MARKET_PRICE_MAPPING> GetAllByKeyAndVersion(string marketPriceMI, string marketPriceWebPricing, int versionNo, string marketPriceName);

        List<MBR_MST_MARKET_PRICE_MAPPING> GetAllByEBACode(List<string> ebaCode);

        MBR_MST_MARKET_PRICE_MAPPING? GetMarketPriceMIByMarketPriceName(string marketPriceName);
    }
}