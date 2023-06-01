using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.COMMON.API.AppModels.Datafactory;
using SCG.CHEM.MBR.COMMON.API.AppModels.DataFactory;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.COMMON.API.BusinessLogic.Datafacetory.Interface
{
    public interface IDataFactoryService : IBaseService
    {
        public string GetTokenBearer();

        public Task<string> GetAccessToken();

        string RunPipeline(string tableName, string transactionName, string cycleName, string caseName, string planType, string createBy);

        string RunPipelineOptience(string tableName, string transactionName, string cycleName, string caseName, string planType, List<string> company, string createBy);

        string RunPipelineMultiCriteria(string tableName, string transactionName, RequestCriteriaTransaction criteria, string createBy, string submitStatus);

        public string DWHImportCompleteStatus(string runId, string status);

        public MBR_MST_DATAFACTORY_RUN StatusRunId(string runId);

        ResponseLatestUpdate GetLatestUpdate();

        string WebImportCompleteStatus(string runId);

        string GetNameDatafactory(string runId);

        string GetCompanyDatafactory(string runId);

        public string RunPipelineSalesCriteria(string tableName, string transactionName, RequestCriteriaSales criteria, string submitStatus, string createBy, bool isPreview, Guid webUUID, bool isMerge = false);
    }
}