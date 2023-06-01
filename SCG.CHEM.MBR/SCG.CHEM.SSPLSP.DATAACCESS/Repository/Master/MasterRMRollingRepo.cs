using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterRMRollingRepo : RepositoryBase<SSP_MST_RM_ROLLING>, IMasterRMRollingRepo
    {
        #region Inject

        public MasterRMRollingRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_RM_ROLLING> GetByKey(string planType, string inputM1, string versionName, string companyCode, string matCode, string unitId, string dataPart, string monthNo)
        {
            var result = _context.SSP_MST_RM_ROLLINGs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.PlanType == planType && s.InputM1 == inputM1 && s.VersionName == versionName && s.CompanyCode == companyCode && s.MatCode == matCode && s.UnitId == unitId && s.DataPart == dataPart && s.MonthNo == monthNo).ToList();
            return result;
        }

        public List<SSP_MST_RM_ROLLING> GetAllByKeyAndVersion(string planType, string inputM1, string versionName, string companyCode, string matCode, string unitId, string dataPart, string monthNo, int versionNo)
        {
            var result = _context.SSP_MST_RM_ROLLINGs.Where(s => s.VersionNo == versionNo && s.PlanType == planType && s.InputM1 == inputM1 && s.VersionName == versionName && s.CompanyCode == companyCode && s.MatCode == matCode && s.UnitId == unitId && s.DataPart == dataPart && s.MonthNo == monthNo).ToList();
            return result;
        }
    }
}