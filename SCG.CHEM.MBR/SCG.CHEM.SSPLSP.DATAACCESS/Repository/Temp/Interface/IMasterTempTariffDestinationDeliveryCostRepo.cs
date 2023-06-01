using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempTariffDestinationDeliveryCostRepo : IRepositoryBase<SSP_TMP_TARIFF_DESTINATION_DELIVERY_COST>
    {
        List<SSP_TMP_TARIFF_DESTINATION_DELIVERY_COST> GetByKey(string planType, string productionSite, string region, string startMonth);

        void Truncate();
    }
}