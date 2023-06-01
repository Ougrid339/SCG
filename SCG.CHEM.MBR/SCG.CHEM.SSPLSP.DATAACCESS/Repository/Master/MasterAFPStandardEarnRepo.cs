using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterAFPStandardEarnRepo : RepositoryBase<SSP_MST_AFP_STANDARD_EARN>, IMasterAFPStandardEarnRepo
    {
        #region Inject

        public MasterAFPStandardEarnRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_AFP_STANDARD_EARN> GetByKey(string planType, string matPrefix, string grade, string productionLine, string startMonth)
        {
            var result = _context.SSP_MST_AFP_STANDARD_EARNs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.PlanType == planType && s.MatPrefix == matPrefix && s.Grade == grade && s.ProductionLine == productionLine && s.StartMonth == startMonth).ToList();
            return result;
        }

        public List<SSP_MST_AFP_STANDARD_EARN> GetAllByKeyAndVersion(string planType, string matPrefix, string grade, string productionLine, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_AFP_STANDARD_EARNs.Where(s => s.VersionNo == versionNo && s.PlanType == planType && s.MatPrefix == matPrefix && s.Grade == grade && s.ProductionLine == productionLine && s.StartMonth == startMonth).ToList();
            return result;
        }
    }
}