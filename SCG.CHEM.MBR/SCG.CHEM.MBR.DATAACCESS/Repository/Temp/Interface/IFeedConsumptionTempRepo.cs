using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface
{
    public interface IFeedConsumptionTempRepo : IRepositoryBase<MBR_TMP_FEED_CONSUMPTION>
    {
        List<MBR_TMP_FEED_CONSUMPTION> FindByCriterias(string scenario, string @case, string cycle);

        List<MBR_TMP_FEED_CONSUMPTION> FindByCriterias(string scenario, string @case, string cycle, List<string> companys);

        List<MBR_TMP_FEED_CONSUMPTION> FindByRunId(string runId);

        List<MBR_TMP_FEED_CONSUMPTION> FindAfter30minute();
    }
}