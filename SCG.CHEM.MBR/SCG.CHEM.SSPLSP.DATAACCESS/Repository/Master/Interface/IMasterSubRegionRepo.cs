using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterSubRegionRepo : IRepositoryBase<SSP_MST_SUB_REGION>
    {
        List<SSP_MST_SUB_REGION> GetByKey(List<string> region, List<string> subRegion);

        List<SSP_MST_SUB_REGION> GetBySubRegion(List<string> subRegion);
    }
}