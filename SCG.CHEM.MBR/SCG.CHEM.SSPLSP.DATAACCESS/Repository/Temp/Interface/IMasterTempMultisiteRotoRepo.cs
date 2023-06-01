using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempMultisiteRotoRepo : IRepositoryBase<SSP_TMP_MULTISITE_ROTO>
    {
        List<SSP_TMP_MULTISITE_ROTO> GetByKey(string planType, string valType, string startMonth);

        void Truncate();
    }
}