using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IFctMarketPriceOlefinsRepo : IRepositoryBase<MBR_FCT_MARKETPRICEOLEFINS>
    {
        List<MBR_FCT_MARKETPRICEOLEFINS> GetFctMarketPriceOlefinsByMarketPriceName(List<string?> marketPriceNames);
        List<MBR_FCT_MARKETPRICEOLEFINS> GetMergeReportData(MergeReportRequestModel criteria);
        List<MBR_FCT_MARKETPRICEOLEFINS> GetMTDByProduct(string product);
        Dictionary<MRB_TRN_FEED_INFO, MBR_FCT_MARKETPRICEOLEFINS> GetFctMarketPriceOlefinsByFeedInfo(List<Entities.Transaction.MRB_TRN_FEED_INFO> mNegative, List<MBR_MST_MARKET_PRICE_MAPPING> marketPriceName);
        List<MBR_FCT_MARKETPRICEOLEFINS> GetLastWeekByProductWeb(string productWeb);
    }
}
