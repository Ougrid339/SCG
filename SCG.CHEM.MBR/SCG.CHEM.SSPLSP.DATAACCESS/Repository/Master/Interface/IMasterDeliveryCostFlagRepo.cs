using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterDeliveryCostFlagRepo : IRepositoryBase<SSP_MST_DELIVERY_COST_FLAG>
    {
        List<SSP_MST_DELIVERY_COST_FLAG> GetByKey(string productionSite, string plantType, string matPrefix, string product, string productSub, string channelGroup, string deliveryMethod, string startMonth);

        List<SSP_MST_DELIVERY_COST_FLAG> GetAllByKeyAndVersion(string productionSite, string plantType, string matPrefix, string product, string productSub, string channelGroup, string deliveryMethod, string startMonth, int versionNo);
    }
}