using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterTariffDestinationDeliveryCostRepo : IRepositoryBase<SSP_MST_TARIFF_DESTINATION_DELIVERY_COST>
    {
        List<SSP_MST_TARIFF_DESTINATION_DELIVERY_COST> GetByKey(string planType, string productionSite, string region, string startMonth);

        //List<SSP_MST_TARIFF_DESTINATION_DELIVERY_COST> GetAllByKeyAndVersion(string planType, string productionSite, string region, string startMonth, int versionNo);
        List<SSP_MST_TARIFF_DESTINATION_DELIVERY_COST> GetAllByKeyAndVersion(string planType, string productionSite, string region, string product, string productSub, string startMonth, int versionNo);
    }
}