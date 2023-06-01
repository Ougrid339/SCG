using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterWaxAllocationRepo : IRepositoryBase<SSP_MST_WAX_ALLOCATION>
    {
        List<SSP_MST_WAX_ALLOCATION> GetByKey(string planType, string waxGroupId, string fromProductionLine, string toProductionLine, string startMonth);

        List<SSP_MST_WAX_ALLOCATION> GetAllByKeyAndVersion(string planType, string waxGroupId, string fromProductionLine, string toProductionLine, string startMonth, int versionNo);
    }
}