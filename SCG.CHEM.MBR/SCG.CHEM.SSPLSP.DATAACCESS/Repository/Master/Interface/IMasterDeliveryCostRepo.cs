using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterDeliveryCostRepo : IRepositoryBase<SSP_MST_DELIVERY_COST>
    {
        List<SSP_MST_DELIVERY_COST> GetByKey(string productionSite, string planType, string matPrefix, string product, string productSub, string channelGroup, string startMonth);

        List<SSP_MST_DELIVERY_COST> GetAllByKeyAndVersion(string productionSite, string planType, string matPrefix, string product, string productSub, string channelGroup, string startMonth, int versionNo);
    }
}