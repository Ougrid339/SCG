using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Transaction.Interface
{
    public interface IMarketPriceForecastRepo : IRepositoryBase<MBR_TRN_MARKET_PRICE_FORECAST>
    {
        List<MBR_TRN_MARKET_PRICE_FORECAST> FindByCriteria(string scenario, string revisionCase, string cycle);
        public List<MBR_TRN_MARKET_PRICE_FORECAST> FindByFeedInfo(string scenario, string revisionCase, List<string> cycle, List<MRB_TRN_FEED_INFO> feedInfo);
        public List<MBR_TRN_MARKET_PRICE_FORECAST> FindByFeedInfo(string scenario, string revisionCase, string cycle, List<MRB_TRN_FEED_INFO> feedInfo);
        public List<MBR_TRN_MARKET_PRICE_FORECAST> FindByMOPJ(string scenario, string revisionCase, List<string> cycle, List<MRB_TRN_FEED_INFO> feedInfo);
        public List<MBR_TRN_MARKET_PRICE_FORECAST> FindByMOPJ(string scenario, string revisionCase, string cycle, List<MRB_TRN_FEED_INFO> feedInfo);

            MarketPriceForecastMergeScenarioModel GetMergeScenario();
        List<MBR_TRN_MARKET_PRICE_FORECAST> GetMergeReportData(MergeReportRequestModel criteria);
        }
}