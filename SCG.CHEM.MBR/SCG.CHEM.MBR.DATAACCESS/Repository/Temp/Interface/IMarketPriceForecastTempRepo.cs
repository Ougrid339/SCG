using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface
{
    public interface IMarketPriceForecastTempRepo : IRepositoryBase<MBR_TMP_MARKET_PRICE_FORECAST>
    {
        List<MBR_TMP_MARKET_PRICE_FORECAST> FindByCriteria(string scenario, string revisionCase, string cycle);

        List<MBR_TMP_MARKET_PRICE_FORECAST> FindByRunId(string runId);

        MarketPriceForecastMergeScenarioModel GetMergeScenario();

        List<MBR_TMP_MARKET_PRICE_FORECAST> FindAfter30minute();
    }
}