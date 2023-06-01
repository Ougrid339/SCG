using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterAdditionalByPackRepo : IRepositoryBase<SSP_MST_ADDITIONAL_BY_PACK>
    {
        List<SSP_MST_ADDITIONAL_BY_PACK> GetByKey(string productionSite, string planType, string matPrefix, string product, string productSub, string package, string channelGroup, string startMonth);

        List<SSP_MST_ADDITIONAL_BY_PACK> GetAllByKeyAndVersion(string productionSite, string planType, string matPrefix, string product, string productSub, string package, string channelGroup, string startMonth, int versionNo);
    }
}