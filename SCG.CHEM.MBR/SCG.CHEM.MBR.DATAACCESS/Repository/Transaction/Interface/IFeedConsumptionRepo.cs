using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Transaction.Interface
{
    public interface IFeedConsumptionRepo : IRepositoryBase<MBR_TRN_FEED_CONSUMPTION>
    {
        List<MBR_TRN_FEED_CONSUMPTION> FindByCriterias(string mergeScenario, string mergeCase, string mergeCycle);
        List<MBR_TRN_FEED_CONSUMPTION> FindByCriterias(string scenario, string @case, string cycle, List<string> companys);
        List<OptienceMergeScenario> GetMergeScenario();
    }
}
