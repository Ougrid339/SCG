using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MergeHistory.Interface
{
    public interface IMergeHistoryService : IBaseService
    {
        Task<List<MergeHistoryResponseModel>> GetMergeHistory(MergeHistoryRequestModel request);
    }
}
