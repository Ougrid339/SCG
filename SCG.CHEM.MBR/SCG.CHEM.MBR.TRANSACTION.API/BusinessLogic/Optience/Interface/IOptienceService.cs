using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Optience;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Optience.Interface
{
    public interface IOptienceService : IBaseService
    {
        int MoveProductionVolume(string runId, string company);

        int MoveFeedConsumption(string runId, string company);

        int MoveFeedPurchase(string runId, string company);

        int MoveBeginningInventory(string runId, string company);

        List<PriceList> UploadOptience(DataWitOptienceModel<OptienceCriteriaModel> param, out int sum);

        List<OptienceDownloadResponse> PreviewOptience(DataWitOptienceModel<OptienceCriteriaModel> param);
    }
}