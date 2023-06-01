using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IAssumptionRepo : IRepositoryBase<MBR_MST_ASSUMPTION>
    {
        List<MBR_MST_ASSUMPTION> GetAssumption(string type, string planType, string cycle, string @case);

        List<MBR_MST_ASSUMPTION> GetAllByKeyAndVersion(string type, string planType, string cycle, string @case, int versionNo);
    }
}
