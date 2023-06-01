using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Optience.Interface
{
    public interface IMergeReportService : IBaseService
    {
        Task<MergeReportResponseModel> GetReport(MergeReportRequestModel request);
    }
}
