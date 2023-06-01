using SCG.CHEM.MBR.TRANSACTION.API.AppModels.DataFactory;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.FeedInfo.Interface
{
    public interface IFeedInfoService : IBaseService
    {
        public int MoveFeedInfo(RequestDataFactoryRunIdStatus data);
        string UploadFeedInfo(DataWithFeedInfoModel<FeedInfoCriteriaModel, ValidateFeedInfoModel> data, out int total);
        List<FeedInfoDownloadResponse> PreviewUploadFeedInfo(DataWithFeedInfoModel<FeedInfoCriteriaModel, ValidateFeedInfoModel> data);
    }
}
