using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Sales;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Sales.Interface
{
    public interface IDownloadSalesService : IBaseService
    {
        SalesResponse DownloadSales(SalesDownloadRequest req);
    }
}
