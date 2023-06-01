using SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.FeedInfo.Interface
{
    public interface IDowloadFeedInfoService : IBaseService
    {
        dynamic DownloadFeedInfo(FeedInfoDownloadRequest req);
    }
}
