using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MarketPriceForecast.Interface
{
    public interface ICopyMarketPriceForecastService : IBaseService
    {
        string CopyMarketPriceForecast(MarketPriceForecastCopyRequest req, out int total, out List<MBR_TMP_MARKET_PRICE_FORECAST> dataCopy);

        List<MarketPriceForecastPreviewResponse> PreviewCopyMarketPriceForecast(MarketPriceForecastCopyRequest param);

        bool CheckExistData(MarketPriceForecastCopyRequest param);
    }
}