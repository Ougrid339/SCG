using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempFreightSubRegionRepo : IRepositoryBase<SSP_TMP_FREIGHT_SUBREGION>
    {
        List<SSP_TMP_FREIGHT_SUBREGION> GetByKey(string productionSite, string regionCode, string subRegion, string planType, string startMonth);

        void Truncate();
    }
}