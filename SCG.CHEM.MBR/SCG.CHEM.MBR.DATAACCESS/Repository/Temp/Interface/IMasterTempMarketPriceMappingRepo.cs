using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempMarketPriceMappingRepo : IRepositoryBase<MBR_TMP_MARKET_PRICE_MAPPING>
    {
        void Truncate();
    }
}