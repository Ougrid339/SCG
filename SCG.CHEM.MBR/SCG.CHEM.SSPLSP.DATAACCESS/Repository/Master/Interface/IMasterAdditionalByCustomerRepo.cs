using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterAdditionalByCustomerRepo : IRepositoryBase<SSP_MST_ADDITIONAL_BY_CUSTOMER>
    {
        List<SSP_MST_ADDITIONAL_BY_CUSTOMER> GetByKey(string productionSite, string planType, string matPrefix, string product, string productSub, string customer, string startMonth);

        List<SSP_MST_ADDITIONAL_BY_CUSTOMER> GetAllByKeyAndVersion(string productionSite, string planType, string matPrefix, string product, string productSub, string customer, string startMonth, int versionNo);
    }
}