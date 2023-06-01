using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempMultisiteRotoRepo : RepositoryBase<SSP_TMP_MULTISITE_ROTO>, IMasterTempMultisiteRotoRepo
    {
        #region Inject

        public MasterTempMultisiteRotoRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_MULTISITE_ROTO> GetByKey(string planType, string valType, string startMonth)
        {
            var result = _context.SSP_TMP_MULTISITE_ROTOs.Where(s => s.PlanType == planType && s.ValType == valType && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_MULTISITE_ROTOs.ToList();
            _context.RemoveRange(data);
        }
    }
}