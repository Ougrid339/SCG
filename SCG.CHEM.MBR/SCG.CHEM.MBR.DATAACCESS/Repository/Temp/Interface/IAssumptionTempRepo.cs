using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IAssumptionTempRepo : IRepositoryBase<MBR_TMP_ASSUMPTION>
    {
        List<MBR_TMP_ASSUMPTION> GetByRunId(string runid);

        List<MBR_TMP_ASSUMPTION> GetAssumption(string type, string planType, string cycle, string @case);

        List<MBR_TMP_ASSUMPTION> GetOlderThanOneHourRecord();
    }
}
