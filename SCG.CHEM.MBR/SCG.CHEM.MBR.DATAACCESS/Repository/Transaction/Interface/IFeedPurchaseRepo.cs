using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Transaction.Interface
{
    public interface IFeedPurchaseRepo : IRepositoryBase<MBR_TRN_FEED_PURCHASE>
    {
        List<MBR_TRN_FEED_PURCHASE> FindByCriteria(string scenario, string @case, string cycle);
        List<MBR_TRN_FEED_PURCHASE> FindByCriteria(string scenario, string @case, string cycle,List<string> companys);
        List<OptienceMergeScenario> GetMergeScenario();
    }
}
