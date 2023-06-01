using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterOtherCostRepo : IRepositoryBase<SSP_MST_OTHER_COST>
    {
        List<SSP_MST_OTHER_COST> GetByKey(string planType, string channel, string salesOrg, string startMonth);

        List<SSP_MST_OTHER_COST> GetAllByKeyAndVersion(string planType, string channel, string salesOrg, string startMonth, int versionNo);
    }
}