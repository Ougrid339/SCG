using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction.Interface
{
    public interface ITransactionNonPrimeRepo : IRepositoryBase<SSP_TRN_NON_PRIME>
    {
        List<SSP_TRN_NON_PRIME> GetNonPrimeDB();

        SSP_TRN_NON_PRIME GetLastActiveVersionByKey(string planType, string startMonth, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId);

        SSP_TRN_NON_PRIME GetLastVersionByKey(string planType, string startMonth, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId);
    }
}