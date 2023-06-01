using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempOtherCostRepo : IRepositoryBase<SSP_TMP_OTHER_COST>
    {
        List<SSP_TMP_OTHER_COST> GetByKey(string planType, string channel, string salesOrg, string startMonth);

        void Truncate();
    }
}