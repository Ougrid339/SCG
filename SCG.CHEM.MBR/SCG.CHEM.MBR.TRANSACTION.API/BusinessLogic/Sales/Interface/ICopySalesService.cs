using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Sales;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Sales.Interface
{
    public interface ICopySalesService : IBaseService
    {
        public Task<Tuple<string, int, List<MBR_TMP_SALES_VOLUME>>> CopySales(SalesCopyRequest param);

        bool CheckExistData(SalesCopyRequest param);

        Task<List<SalesPreviewResponse>> PreviewCopySales(SalesCopyRequest param);
    }
}
