using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction.Interface
{
    public interface ITransactionProductionPlanRepo : IRepositoryBase<SSP_TRN_PRODUCTION_PLAN>
    {
        List<SSP_TRN_PRODUCTION_PLAN> GetByKey(string versionName, string planningGroup, int revId, string plant, string bom, string line, string matCodeMst, string matCodeTrn, int newProductId, string monthNo);

        List<SSP_TRN_PRODUCTION_PLAN> GetByKeyWithoutMonthNo(string versionName, string planningGroup, int revId, string plant, string bom, string line, string matCodeMst, string matCodeTrn, int newProductId);

        List<SSP_TRN_PRODUCTION_PLAN> GetByKeysWithoutMonthNo(List<string> versionName, List<string> planningGroup, List<string> plant, List<string> line, List<string> matCodeMst, List<string> matCodeTrn, List<int> newProductId);

        List<ProductionPlanCycleModel> GetProductionPlanGroup(string planType, string cycle, List<string> planningGroups);

        List<MonthModel> GetProductionPlanMonthQty(string planType, string cycle, List<string> planningGroups);
    }
}