using SCG.CHEM.MBR.COMMON.API.AppModels.Tracking;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.COMMON.API.BusinessLogic.Tracking.Interface
{
    public interface ITrackingService : IBaseService
    {
        List<SearchTrackingResModel> SearchTracking(SearchTrackingReqModel data, out int total);

        string Confirm(ConfirmTrackingModel param);

        LockUnlockModel UpdateLockUnlockCycle(LockUnlockModel param);

        bool GetLockUnlock(LockUnlockModel param);

        List<DownloadTrackingResponseModel> DownloadCheckSaleAndProduct(DownloadTrackingRequestModel data);
    }
}