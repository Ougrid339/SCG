using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IFCTBusinessPartnerRepo : IRepositoryBase<SSP_FCT_BUSINESS_PARTNER>
    {
        List<CustomerModel> GetCustomers();

        List<SSP_FCT_BUSINESS_PARTNER> GetByBusinessPartners(List<string> data);

        List<SSP_FCT_BUSINESS_PARTNER> GetCustomersSelect();
        List<SSP_FCT_BUSINESS_PARTNER> GetByShortnamepriceweb(List<string> list);
    }
}