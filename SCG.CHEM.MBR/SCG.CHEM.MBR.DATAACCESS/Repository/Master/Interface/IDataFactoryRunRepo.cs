using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IDataFactoryRunRepo : IRepositoryBase<MBR_MST_DATAFACTORY_RUN>
    {
        public MBR_MST_DATAFACTORY_RUN GetByRunId(string runId);

        public MBR_MST_DATAFACTORY_RUN GetSalesPlanLatestUpdate();

        MBR_MST_DATAFACTORY_RUN GetTransactionLatestUpdate(string transactionName);

        List<MBR_MST_DATAFACTORY_RUN> GetTransactionByCriteria(string planType, string cycle);

        MBR_MST_DATAFACTORY_RUN GetTransactionByCriteriaAndTransactionName(string planType, string cycle, string caseName, string transactionname);

        List<MBR_MST_DATAFACTORY_RUN> GetDWHFail(string transactionName);

        List<MBR_MST_DATAFACTORY_RUN> GetTransactionByCriteriaAndTransactionNameList(string planType, string cycle, string caseName, string transactionname);
        MBR_MST_DATAFACTORY_RUN? GetTransactionByMergeCriteria(MergeHistoryRequestModel criteria);
    }
}