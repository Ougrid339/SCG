using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterCustomerVendorMappingRepo : IRepositoryBase<MBR_MST_CUSTOMER_VENDOR_MAPPING>
    {
        List<MBR_MST_CUSTOMER_VENDOR_MAPPING> GetAllByKeyAndVersion(string customerShortName, string type, string sourceSystem, int versionNo);

        List<MBR_MST_CUSTOMER_VENDOR_MAPPING> GetCustomerShortName(List<string> data);

        List<MBR_MST_CUSTOMER_VENDOR_MAPPING> GetCustomerShortNameByCustomerCode(List<string> data);
    }
}