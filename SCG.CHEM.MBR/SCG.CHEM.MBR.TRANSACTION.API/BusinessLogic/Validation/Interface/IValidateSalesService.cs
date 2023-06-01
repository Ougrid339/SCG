using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Sales;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Validation.Interface
{
    public interface IValidateSalesService : IBaseService
    {
        DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel> ValidateSales(DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel> data);
    }
}
