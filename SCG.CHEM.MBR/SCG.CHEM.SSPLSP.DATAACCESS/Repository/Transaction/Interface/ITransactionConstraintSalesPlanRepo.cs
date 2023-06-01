using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction.Interface
{
    public interface ITransactionConstraintSalesPlanRepo : IRepositoryBase<SSP_TRN_CONSTRAINT_SALES_PLAN>
    {
        void ExecuteStoreProc(string cycle, List<string> planningGroups, string type = APPCONSTANT.STORE_PROCEDURE_TYPE.CONSTRAINT);

        List<SSP_TRN_CONSTRAINT_SALES_PLAN> GetByKey(string versionName, int scenarioId, int stockId, string prdKey, int revId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string subRegion, int priceTypeId, int priceUnitId, string unit, string hvaCode, string salesDistict, string projectId, string reqProductSite, string inputM1, string monthNo);

        List<SSP_TRN_CONSTRAINT_SALES_PLAN> GetByKeyWithoutInputM1AndMonth(string versionName, int scenarioId, int stockId, string prdKey, int revId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string subRegion, int priceTypeId, int priceUnitId, string unit, string hvaCode, string salesDistict, string projectId, string reqProductSite);

        List<SSP_TRN_CONSTRAINT_SALES_PLAN> GetByKeysWithoutInputM1AndMonth(List<string> versionName, List<int> scenarioId, List<string> matCodeMst, List<string> matCodeTrn, List<int> newProductId, List<string> salesGroupCode, List<string> planningGroup, List<string> region, List<string> subRegion, List<string> hvaCode, List<string> salesDistict, List<string> projectId, List<string> reqProductSite);

        List<ConstraintCycleModel> GetConstraintsView(string planType, string inputM1, List<string> planningGroups);

        List<MonthModel> GetConstraintsMonthQty(string planType, string inputM1, List<string> planningGroups);

        List<MonthModel> GetConstraintsMonthPrice(string planType, string inputM1, List<string> planningGroups);

        List<MonthGroupModel> GetConstraints(string planType, string inputM1, List<string> planningGroups);
    }
}