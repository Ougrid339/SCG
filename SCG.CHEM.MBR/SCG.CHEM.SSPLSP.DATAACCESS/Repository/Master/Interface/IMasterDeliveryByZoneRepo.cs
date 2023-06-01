using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterDeliveryByZoneRepo : IRepositoryBase<SSP_MST_DELIVERY_BY_ZONE>
    {
        List<SSP_MST_DELIVERY_BY_ZONE> GetByKey(string productionSite, string plantType, string channel, string Zone, string product, string productSub, string startMonth);

        List<SSP_MST_DELIVERY_BY_ZONE> GetAllByKeyAndVersion(string productionSite, string plantType, string channelGroup, string Zone, string product, string productSub, string startMonth, int versionNo);
    }
}