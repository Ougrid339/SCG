using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterProductionSiteRepo : IRepositoryBase<SSP_MST_PRODUCTION_SITE>
    {
        List<SSP_MST_PRODUCTION_SITE> GetProductionSite(List<string> data);
    }
}