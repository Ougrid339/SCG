using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    internal class MasterTempManualAdjustCostGradeLineRepo : RepositoryBase<SSP_TMP_MANUAL_ADJUST_COST_GRADELINE>, IMasterTempManualAdjustCostGradeLineRepo
    {
        #region Inject

        public MasterTempManualAdjustCostGradeLineRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_MANUAL_ADJUST_COST_GRADELINE> GetByKey(string productionSite, string planType, string matPrefix, string grade, string plant, string productionLine, string startMonth)
        {
            var result = _context.SSP_TMP_MANUAL_ADJUST_COST_GRADELINEs.Where(s => s.ProductionSite == productionSite && s.PlanType == planType
            && s.MatPrefix == matPrefix && s.Grade == grade && s.Plant == plant && s.ProductionLine == productionLine && s.StartMonth == startMonth).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_MANUAL_ADJUST_COST_GRADELINEs.ToList();
            _context.RemoveRange(data);
        }
    }
}