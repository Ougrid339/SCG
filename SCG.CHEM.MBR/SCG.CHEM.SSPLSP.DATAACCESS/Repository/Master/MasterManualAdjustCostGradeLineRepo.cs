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
    public class MasterManualAdjustCostGradeLineRepo : RepositoryBase<SSP_MST_MANUAL_ADJUST_COST_GRADELINE>, IMasterManualAdjustCostGradeLineRepo
    {
        #region Inject

        public MasterManualAdjustCostGradeLineRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_MANUAL_ADJUST_COST_GRADELINE> GetByKey(string productionSite, string planType, string matPrefix, string grade, string plant, string productionLine, string startMonth)
        {
            var result = _context.SSP_MST_MANUAL_ADJUST_COST_GRADELINEs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.ProductionSite == productionSite && s.PlanType == planType
            && s.MatPrefix == matPrefix && s.Grade == grade && s.Plant == plant && s.ProductionLine == productionLine && s.StartMonth == startMonth).ToList();
            return result;
        }

        public List<SSP_MST_MANUAL_ADJUST_COST_GRADELINE> GetAllByKeyAndVersion(string productionSite, string planType, string matPrefix, string grade, string plant, string productionLine, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_MANUAL_ADJUST_COST_GRADELINEs.Where(s => s.VersionNo == versionNo && s.ProductionSite == productionSite && s.PlanType == planType
            && s.MatPrefix == matPrefix && s.Grade == grade && s.Plant == plant && s.ProductionLine == productionLine && s.StartMonth == startMonth).ToList();
            return result;
        }
    }
}