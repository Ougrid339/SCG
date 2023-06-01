using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterTempOperationChargeRepo : IRepositoryBase<SSP_TMP_OPERATION_CHARGE>
    {
        List<SSP_TMP_OPERATION_CHARGE> GetByKey(string planType, string sourceCompany, string product, string productSub, string channel, string saleOrg, string startMonth);

        void Truncate();
    }
}