using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempAdditionalByCustomerRepo : IRepositoryBase<SSP_TMP_ADDITIONAL_BY_CUSTOMER>
    {
        List<SSP_TMP_ADDITIONAL_BY_CUSTOMER> GetByKey(string productionSite, string planType, string matPrefix, string product, string productSub, string customer, string startMonth);

        void Truncate();
    }
}