using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Datafactory;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.DataFactory;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Datafacetory.Interface
{
    public interface IDataFactoryService : IBaseService
    {
        public string GetTokenBearer();

        public Task<string> GetAccessToken();

        string RunPipeline(string tableName, string transactionName, string cycleName, string caseName, string planType, bool isMerge, string createBy, string MergedWithPlanType = "", string MergedWithCycle = "", string MergedWithCase = "");

        string RunPipelineOptience(string tableName, string transactionName, string cycleName, string caseName, string planType, List<string> company, bool isMerge, string createBy, string MergedWithPlanType = "", string MergedWithCycle = "", string MergedWithCase = "");

        string RunPipelineMultiCriteria(string tableName, string transactionName, RequestCriteriaTransaction criteria, string createBy, string submitStatus, bool isMerge, string MergedWithPlanType = "", string MergedWithCycle = "", string MergedWithCase = "");

        public string DWHImportCompleteStatus(string runId, string status);

        public MBR_MST_DATAFACTORY_RUN StatusRunId(string runId);

        ResponseLatestUpdate GetLatestUpdate();

        string WebImportCompleteStatus(string runId);

        string WebImportFailStatus(string runId);

        string GetNameDatafactory(string runId);

        string GetCompanyDatafactory(string runId);

        Task<string> RunPipelineSalesCriteria(string _tableName, string transactionName, RequestCriteriaSales criteria, string submitStatus, string createBy, Guid webUUID, bool isPreview, bool isMerge, string MergedWithPlanType = "", string MergedWithCycle = "", string MergedWithCase = "");

        string RunPipelineSalesCriteria(string tableName, string transactionName, RequestCriteriaSales criteria, string submitStatus, string createBy, bool isPreview, bool isMerge = false);

        public Task<string> RunPipeLineImportFinalPrice(string runId, bool IsPreview);

        string UpdateSalesPreviewFailed(string runId);

        string UpdateSalesPreviewSucceeded(string runId);

        string UpdateSalesSubmitFailed(string runId);

        string UpdateSalesSubmitSucceeded(string runId);

        void UpdateDatafactoryRunStatus(string runId, string status);
    }
}