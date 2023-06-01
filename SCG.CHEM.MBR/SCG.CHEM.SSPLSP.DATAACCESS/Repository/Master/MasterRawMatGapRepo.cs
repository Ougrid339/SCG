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
    public class MasterRawMatGapRepo : RepositoryBase<SSP_MST_RAW_MAT_GAP>, IMasterRawMatGapRepo
    {
        #region Inject

        public MasterRawMatGapRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_RAW_MAT_GAP> GetByKey(string productionSite, string planType, string company, string matCode, string startMonth)
        {
            var result = _context.SSP_MST_RAW_MAT_GAPs.Where(s => s.ProductionSite == productionSite && s.PlanType == planType && s.Company == company && s.MatCode == matCode
                        && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public List<SSP_MST_RAW_MAT_GAP> GetAllByKeyAndVersion(string productionSite, string planType, string company, string matCode, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_RAW_MAT_GAPs.Where(s => s.ProductionSite == productionSite && s.PlanType == planType && s.Company == company && s.MatCode == matCode
                        && s.StartMonth == startMonth && s.VersionNo == versionNo).ToList();
            return result;
        }
    }
}