using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.FeedInfo.Interface
{
    public interface ICopyFeedInfoService : IBaseService
    {
        string CopyFeedInfo(FeedInfoCopyRequest param, out int total, out List<MRB_TMP_FEED_INFO> dataCopy);

        List<FeedInfoPreviewResponse> PreviewCopyFeedInfo(FeedInfoCopyRequest param);

        bool CheckExistData(FeedInfoCopyRequest param);
    }
}