using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.MASTER.API.AppModels.DataFactory;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master.Interface
{
    public interface IDataFactoryService : IBaseService
    {
        public string GetTokenBearer();

        public Task<string> GetAccessToken();

        public Task<string> RunAssumptionPipeLineAsync(RequestCreateRunPipeline req);

        public string RunPipeline(string masterId, string createBy);

        string RunPipelineImportFormula(string masterName, string createBy);

        public string DWHImportCompleteStatus(string runId, string status);

        public string DWHImportCompleteStatus(string runId, string status, int masterId);

        string WebImportCompleteStatus(string runId);

        string WebImportCompleteStatus(string runId, int masterId);

        public MBR_MST_DATAFACTORY_RUN StatusRunId(string runId);
    }
}