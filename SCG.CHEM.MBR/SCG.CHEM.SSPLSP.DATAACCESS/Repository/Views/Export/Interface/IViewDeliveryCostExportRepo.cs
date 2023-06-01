using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Export.Interface
{
    public interface IViewDeliveryCostExportRepo : IRepositoryBase<vSSP_MST_DELIVERY_COST_EXPORT>
    {
        List<DeliveryCostMasterSheet> GetDeliveryCostByCycle(string plantype, DateTime yearMonth);
    }
}