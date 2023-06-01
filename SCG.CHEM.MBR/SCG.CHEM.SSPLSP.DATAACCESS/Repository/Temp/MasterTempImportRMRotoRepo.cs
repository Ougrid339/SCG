using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempImportRMRotoRepo : RepositoryBase<SSP_TMP_IMPORT_RM_ROTO>, IMasterTempImportRMRotoRepo
    {
        #region Inject

        public MasterTempImportRMRotoRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_IMPORT_RM_ROTO> GetByKey(string rawMatCode)
        {
            var result = _context.SSP_TMP_IMPORT_RM_ROTOs.Where(s => s.RawMatCode == rawMatCode).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_IMPORT_RM_ROTOs.ToList();
            _context.RemoveRange(data);
        }
    }
}