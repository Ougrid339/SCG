using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Optience;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Optience.Interface
{
    public interface IDowloadOptienceService : IBaseService
    {
        List<OptienceDownloadResponse> DowloadOptience(OptienceDownloadRequest req);
    }
}
