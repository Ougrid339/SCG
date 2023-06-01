using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterAFPStandardEarnRepo : IRepositoryBase<SSP_MST_AFP_STANDARD_EARN>
    {
        List<SSP_MST_AFP_STANDARD_EARN> GetByKey(string planType, string matPrefix, string grade, string productionLine, string startMonth);

        List<SSP_MST_AFP_STANDARD_EARN> GetAllByKeyAndVersion(string planType, string matPrefix, string grade, string productionLine, string startMonth, int versionNo);
    }
}