using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterImportRMRotoRepo : IRepositoryBase<SSP_MST_IMPORT_RM_ROTO>
    {
        List<SSP_MST_IMPORT_RM_ROTO> GetByKey(string rawMatCode);

        List<SSP_MST_IMPORT_RM_ROTO> GetImportRMRotoRowMatCodes(List<string> data);

        List<SSP_MST_IMPORT_RM_ROTO> GetAllByKeyAndVersion(string rawMatCode, int versionNo);
    }
}