using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Optience;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Optience.Interface
{
    public interface ICopyOptienceService : IBaseService
    {
        List<PriceList> CopyOptience(OptienceCopyRequest param, out int sum, out OptienceData dataCopy);

        public List<OptienceDownloadResponse> PreviewCopyOptience(OptienceCopyRequest param);

        bool CheckExistData(OptienceCopyRequest param);
    }
}