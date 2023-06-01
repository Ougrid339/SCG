using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MarketPriceForecast.Interface
{
    public interface IMarketPriceForecastService : IBaseService
    {
        List<MarketPriceForecastPreviewResponse> PreviewUploadMarketPriceForecast(DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel> param);

        string UploadMarketPriceForecast(DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel> data, out int tota);

        string CallDataFactory(string tableName, string transactionName, string cycleName, string caseName, string planType, bool isMerge = false, string MergedWithPlanType = "", string MergedWithCycle = "", string MergedWithCase = "");

        public int MoveMarketPriceForecast(string runId, out bool status);
    }
}