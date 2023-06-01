using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempRMRollingRepo : RepositoryBase<SSP_TMP_RM_ROLLING>, IMasterTempRMRollingRepo
    {
        #region Inject

        public MasterTempRMRollingRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_RM_ROLLING> GetByKey(string planType, string inputM1, string versionName, string companyCode, string matCode, string unitId, string dataPart, string monthNo)
        {
            var result = _context.SSP_TMP_RM_ROLLINGs.Where(s => s.PlanType == planType && s.InputM1 == inputM1 && s.VersionName == versionName && s.CompanyCode == companyCode && s.MatCode == matCode && s.UnitId == unitId && s.DataPart == dataPart && s.MonthNo == monthNo).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_RM_ROLLINGs.ToList();
            _context.RemoveRange(data);
        }
    }
}