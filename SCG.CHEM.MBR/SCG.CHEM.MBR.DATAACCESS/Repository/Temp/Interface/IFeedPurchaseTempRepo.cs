using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface
{
    public interface IFeedPurchaseTempRepo : IRepositoryBase<MBR_TMP_FEED_PURCHASE>
    {
        List<MBR_TMP_FEED_PURCHASE> FindByCriterias(string scenario, string @case, string cycle);

        List<MBR_TMP_FEED_PURCHASE> FindByRunId(string runId);

        List<MBR_TMP_FEED_PURCHASE> FindAfter30minute();
    }
}