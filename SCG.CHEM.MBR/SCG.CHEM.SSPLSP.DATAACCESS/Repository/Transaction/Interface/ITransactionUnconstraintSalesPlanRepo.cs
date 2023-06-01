using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction.Interface
{
    public interface ITransactionUnconstraintSalesPlanRepo : IRepositoryBase<SSP_TRN_UNCONSTRAINT_SALES_PLAN>
    {
        void ExecuteStoreProc(string cycle, List<string> planningGroups, string type = APPCONSTANT.STORE_PROCEDURE_TYPE.UNCONSTRAINT);

        //SSP_TRN_UNCONSTRAINT_SALES_PLAN GetLastActiveVersionByKey(string planType, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId, string inputM1, string monthNo);
        //SSP_TRN_UNCONSTRAINT_SALES_PLAN GetLastVersionByKey(string planType, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId, string inputM1, string monthNo);
        SSP_TRN_UNCONSTRAINT_SALES_PLAN GetByKey(string planType, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId, string inputM1, string monthNo);

        //SSP_TRN_UNCONSTRAINT_SALES_PLAN GetByKeyAutoGen(string planType, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId, string inputM1, string monthNo);
        List<SSP_TRN_UNCONSTRAINT_SALES_PLAN> GetActiveByKeyIgnoreMonth(string planType, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId, string inputM1);

        List<SSP_TRN_UNCONSTRAINT_SALES_PLAN> GetByKeyWithoutInputM1AndMonth(string planType, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId);

        List<SSP_TRN_UNCONSTRAINT_SALES_PLAN> GetByKeysWithoutInputM1AndMonth(List<string> planType, List<int> scenarioId, List<string> customerCode, List<string> channel, List<string> matCodeMst, List<string> matCodeTrn, List<int> newProductId, List<string> salesGroupCode, List<string> planningGroup, List<string> region, List<string> reqProductSite, List<string> subRegion, List<string> salesDistrict, List<string> projectId, List<int> priceTypeId);

        List<UnconstraintCycleModel> GetUnconstraintsView(string planType, string inputM1, List<string> planningGroups);

        List<MonthModel> GetUnconstraintsMonthQty(string planType, string inputM1, string name, List<string> planningGroups);

        List<MonthModel> GetUnconstraintsMonthPrice(string planType, string inputM1, List<string> planningGroups);

        List<MonthModel> GetUnconstraintsMonthFullFill(string planType, string inputM1, List<string> planningGroups);

        List<MonthModel> GetUnConstraintsQtyAndPrice(string planType, string inputM1, List<string> planningGroups);

        List<MonthModel> GetUnConstraintsQtyAndPriceMarkDelete(string planType, string inputM1, List<string> planningGroups);

        IQueryable<SSP_TRN_UNCONSTRAINT_SALES_PLAN> GetUnconstraintsOrderBy(string inputM1);
    }
}