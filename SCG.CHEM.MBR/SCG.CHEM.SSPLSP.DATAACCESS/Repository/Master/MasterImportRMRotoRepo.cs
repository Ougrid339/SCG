using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterImportRMRotoRepo : RepositoryBase<SSP_MST_IMPORT_RM_ROTO>, IMasterImportRMRotoRepo
    {
        #region Inject

        public MasterImportRMRotoRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_IMPORT_RM_ROTO> GetByKey(string rawMatCode)
        {
            var result = _context.SSP_MST_IMPORT_RM_ROTOs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.RawMatCode == rawMatCode).ToList();
            return result;
        }

        public List<SSP_MST_IMPORT_RM_ROTO> GetImportRMRotoRowMatCodes(List<string> data)
        {
            var result = _context.SSP_MST_IMPORT_RM_ROTOs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && data.Contains(s.RawMatCode)).ToList();
            return result;
        }

        public List<SSP_MST_IMPORT_RM_ROTO> GetAllByKeyAndVersion(string rawMatCode, int versionNo)
        {
            var result = _context.SSP_MST_IMPORT_RM_ROTOs.Where(s => s.VersionNo == versionNo && s.RawMatCode == rawMatCode).ToList();
            return result;
        }
    }
}