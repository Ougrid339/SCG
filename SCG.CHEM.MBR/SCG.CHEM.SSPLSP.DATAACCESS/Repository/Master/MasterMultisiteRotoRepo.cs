using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterMultisiteRotoRepo : RepositoryBase<SSP_MST_MULTISITE_ROTO>, IMasterMultisiteRotoRepo
    {
        #region Inject

        public MasterMultisiteRotoRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_MULTISITE_ROTO> GetByKey(string planType, string valType, string startMonth)
        {
            var result = _context.SSP_MST_MULTISITE_ROTOs.Where(s => s.PlanType == planType && s.ValType == valType && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public List<SSP_MST_MULTISITE_ROTO> GetAllByKeyAndVersion(string planType, string valType, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_MULTISITE_ROTOs.Where(s => s.PlanType == planType && s.ValType == valType && s.StartMonth == startMonth && s.VersionNo == versionNo).ToList();
            return result;
        }
    }
}