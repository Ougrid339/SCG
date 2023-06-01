using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterDeliveryMethodRepo : IRepositoryBase<SSP_MST_DELIVERY_METHOD>
    {
        List<SSP_MST_DELIVERY_METHOD> GetDelivertMethod(List<string> data);
    }
}