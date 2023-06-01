using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MarketPriceForecast.Interface
{
    public interface IDownloadMarketPriceForecastService : IBaseService
    {
        List<MarketPriceForecastDownloadResponse> DownloadMarketPriceForecast(MarketPriceForecastDownloadRequest req);

    }
}
