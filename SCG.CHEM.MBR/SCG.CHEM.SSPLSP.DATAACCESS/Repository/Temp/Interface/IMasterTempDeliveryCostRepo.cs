using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempDeliveryCostRepo : IRepositoryBase<SSP_TMP_DELIVERY_COST>
    {
        List<SSP_TMP_DELIVERY_COST> GetByKey(string productionSite, string planType, string matPrefix, string product, string productSub, string channelGroup, string startMonth);

        void Truncate();
    }
}