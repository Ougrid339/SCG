using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterCustomerRepo : IRepositoryBase<SSP_FCT_BUSINESS_PARTNER>
    {
        List<SSP_FCT_BUSINESS_PARTNER> GetCustomer(List<string> data);
    }
}