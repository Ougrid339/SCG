using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class DataFactoryRunRepo : RepositoryBase<MBR_MST_DATAFACTORY_RUN>, IDataFactoryRunRepo
    {
        public DataFactoryRunRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public MBR_MST_DATAFACTORY_RUN GetByRunId(string runId)
        {
            var result = _context.MBR_MST_DATAFACTORY_RUNs.Where(s => s.RunId == runId).FirstOrDefault();

            return result;
        }

        public List<MBR_MST_DATAFACTORY_RUN> GetDWHFail(string transactionName)
        {
            var result = _context.MBR_MST_DATAFACTORY_RUNs.Where(s => s.Status.Equals("DWH-Fail") && s.MasterName.Contains(transactionName)).ToList();

            return result;
        }

        public MBR_MST_DATAFACTORY_RUN GetSalesPlanLatestUpdate()
        {
            var result = _context.MBR_MST_DATAFACTORY_RUNs.Where(s => s.Status.Equals("Complete") && s.MasterName.Contains("SalesPlan|")).OrderByDescending(x => x.CreatedDate).FirstOrDefault();

            return result;
        }

        public MBR_MST_DATAFACTORY_RUN GetTransactionLatestUpdate(string transactionName)
        {
            var result = _context.MBR_MST_DATAFACTORY_RUNs.Where(s => s.Status.Equals("Complete") && s.MasterName.Contains(transactionName)).OrderByDescending(x => x.CreatedDate).FirstOrDefault();

            return result;
        }

        public List<MBR_MST_DATAFACTORY_RUN> GetTransactionByCriteria(string planType, string cycle)
        {
            var result = _context.MBR_MST_DATAFACTORY_RUNs.Where(s => s.Status.Equals("Complete") && s.MasterName.Contains(planType) && s.MasterName.Contains(cycle)).OrderByDescending(x => x.UpdatedDate.HasValue).ThenBy(x => x.CreatedDate).ToList();

            return result;
        }

        public MBR_MST_DATAFACTORY_RUN GetTransactionByCriteriaAndTransactionName(string planType, string cycle, string caseName, string transactionname)
        {
            var result = _context.MBR_MST_DATAFACTORY_RUNs.Where(s => s.Status.Equals("Complete") && s.MasterName.Contains(planType) && s.MasterName.Contains(cycle) && s.MasterName.Contains(caseName) && s.MasterName.ToUpper().Contains(transactionname)).OrderByDescending(x => x.UpdatedDate.HasValue).ThenBy(x => x.CreatedDate).FirstOrDefault();

            return result;
        }

        public List<MBR_MST_DATAFACTORY_RUN> GetTransactionByCriteriaAndTransactionNameList(string planType, string cycle, string caseName, string transactionname)
        {
            var result = _context.MBR_MST_DATAFACTORY_RUNs.Where(s => s.Status.Equals("Complete") && s.MasterName.Contains(planType) && s.MasterName.Contains(cycle) && s.MasterName.Contains(caseName) && s.MasterName.ToUpper().Contains(transactionname)).OrderByDescending(x => x.UpdatedDate.HasValue).ThenBy(x => x.CreatedDate).ToList();

            return result;
        }

        public MBR_MST_DATAFACTORY_RUN? GetTransactionByMergeCriteria(MergeHistoryRequestModel criteria)
        {
            var result = _context.MBR_MST_DATAFACTORY_RUNs.Where(s =>
            s.Status.ToUpper() == APPCONSTANT.DATAFAC_STATUS.IN_PROGRESS
            && (!string.IsNullOrEmpty(criteria.Type) && s.MasterName.ToUpper().Contains(criteria.Type.ToUpper()))
            && (!string.IsNullOrEmpty(s.Cycle) && s.Cycle.ToUpper() == criteria.Cycle.ToUpper())
            && (!string.IsNullOrEmpty(s.Case) && s.Case.ToUpper() == criteria.Case.ToUpper())
            ).OrderByDescending(x => x.CreatedDate).FirstOrDefault();
            return result;
        }
    }
}