using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterFreightRepo : IRepositoryBase<SSP_MST_FREIGHT>
    {
        List<SSP_MST_FREIGHT> GetAllByKeyAndVersion(string productionSite, string regionCode, string planType, string startMonth, int versionNo);

        List<SSP_MST_FREIGHT> GetByKey(string productionSite, string regionCode, string planType, string startMonth);
    }
}