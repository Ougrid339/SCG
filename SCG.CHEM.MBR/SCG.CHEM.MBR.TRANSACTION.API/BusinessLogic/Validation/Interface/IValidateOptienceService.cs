using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Optience;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Validation.Interface
{
    public interface IValidateOptienceService : IBaseService
    {
        DataWitOptienceModel<OptienceCriteriaModel> ValidateOptience(DataWitOptienceModel<OptienceCriteriaModel> data);
    }
}
