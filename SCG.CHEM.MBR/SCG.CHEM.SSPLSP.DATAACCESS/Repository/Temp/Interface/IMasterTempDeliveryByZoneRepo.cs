using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterTempDeliveryByZoneRepo : IRepositoryBase<SSP_TMP_DELIVERY_BY_ZONE>
    {
        List<SSP_TMP_DELIVERY_BY_ZONE> GetByKey(string productionSite, string plantType, string channel, string Zone, string product, string productSub, string startMonth);

        void Truncate();
    }
}