using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempDeliveryCostFlagRepo : IRepositoryBase<SSP_TMP_DELIVERY_COST_FLAG>
    {
        List<SSP_TMP_DELIVERY_COST_FLAG> GetByKey(string productionSite, string matPrefix, string product, string productSub, string channelGroup, string deliveryMethod, string startMonth);

        public void Truncate();
    }
}