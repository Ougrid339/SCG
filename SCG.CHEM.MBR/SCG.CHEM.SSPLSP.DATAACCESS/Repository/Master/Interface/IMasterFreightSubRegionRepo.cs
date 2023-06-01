using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterFreightSubRegionRepo : IRepositoryBase<SSP_MST_FREIGHT_SUBREGION>
    {
        List<SSP_MST_FREIGHT_SUBREGION> GetByKey(string productionSite, string regionCode, string subRegion, string planType, string startMonth);

        List<SSP_MST_FREIGHT_SUBREGION> GetAllByKeyAndVersion(string productionSite, string regionCode, string subRegion, string planType, string startMonth, int versionNo);

        List<SSP_MST_FREIGHT_SUBREGION> GetBySubRegions(List<string> subRegion);
    }
}