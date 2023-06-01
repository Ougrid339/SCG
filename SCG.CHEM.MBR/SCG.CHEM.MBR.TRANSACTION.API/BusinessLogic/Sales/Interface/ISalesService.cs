using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.DataFactory;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Sales;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Sales.Interface
{
    public interface ISalesService : IBaseService
    {
        Task<Tuple<string, int>> UploadSales(DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel> param);

        Task<List<SalesPreviewResponse>> PreviewSales(DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel> param);

        public int MoveSales(RequestDataFactoryRunIdStatus criteria, string previewRunIdOrSubmitRunId);

        public string GetPreviewRunIdFromSubmitRunId(string previewRunId);

        public Guid GetUUIDFromSubmitRunId(string submitRunId);

        public Task<bool> KeepCheckingForStatus(string status, Guid webUuid);

        Task<string> CallDataFactory(string tableName, string transactionName, RequestCriteriaSales criteria, string submitStatus, Guid webUUID, bool isPreview, bool isMerge = false, string MergedWithPlanType = "", string MergedWithCycle = "", string MergedWithCase = "");

        Task<SalesFormulaValidationModel> FormulaValidation(ValidateSalesModel saleModel);
    }
}