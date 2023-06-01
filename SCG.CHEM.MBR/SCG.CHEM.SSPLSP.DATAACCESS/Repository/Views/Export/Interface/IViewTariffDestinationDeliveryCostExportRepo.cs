using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Export.Interface
{
    public interface IViewTariffDestinationDeliveryCostExportRepo : IRepositoryBase<vSSP_MST_TARIFF_DESTINATION_DELIVERY_COST_EXPORT>
    {
        decimal GetTariff(string? product, string? productSub, string planType, string productSite, string region, DateTime yearMonth);
    }
}