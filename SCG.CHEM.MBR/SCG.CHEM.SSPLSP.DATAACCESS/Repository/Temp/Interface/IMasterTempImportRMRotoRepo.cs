using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempImportRMRotoRepo : IRepositoryBase<SSP_TMP_IMPORT_RM_ROTO>
    {
        List<SSP_TMP_IMPORT_RM_ROTO> GetByKey(string rawMatCode);

        void Truncate();
    }
}