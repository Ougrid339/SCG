using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.MASTER.API.AppModels.Assumption;
using SCG.CHEM.MBR.MASTER.API.AppModels.DataFactory;
using SCG.CHEM.MBR.MASTER.API.AppModels.Master;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic.Assumption.Interface
{
    public interface IAssumptionService : IBaseService
    {

        List<MBR_MST_ASSUMPTION> GetAssumption(AssumptionRequest req);

        Task<string> AddAssumption(AssumptionModel data);

        int MoveAssumption(RequestMoveMasterModel req);
    }
}
