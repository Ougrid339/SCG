using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterMultisiteRotoRepo : IRepositoryBase<SSP_MST_MULTISITE_ROTO>
    {
        List<SSP_MST_MULTISITE_ROTO> GetByKey(string planType, string valType, string startMonth);

        List<SSP_MST_MULTISITE_ROTO> GetAllByKeyAndVersion(string planType, string valType, string startMonth, int versionNo);
    }
}