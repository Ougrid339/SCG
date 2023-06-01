using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterWaxViscosityPercentRepo : RepositoryBase<SSP_MST_WAX_VISCOSITY_PERCENT>, IMasterWaxViscosityPercentRepo
    {
        #region Inject

        public MasterWaxViscosityPercentRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_WAX_VISCOSITY_PERCENT> GetByKey(string planType, string matPrefix, string grade, string gradeComp, string plant, string productionLine, string startMonth)
        {
            var result = _context.SSP_MST_WAX_VISCOSITY_PERCENTs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.PlanType == planType && s.MatPrefix == matPrefix && s.Grade == grade && s.GradeComp == gradeComp && s.Plant == plant && s.ProductionLine == productionLine
                         && s.StartMonth == startMonth).ToList();
            return result;
        }

        public List<SSP_MST_WAX_VISCOSITY_PERCENT> GetAllByKeyAndVersion(string planType, string matPrefix, string grade, string gradeComp, string plant, string productionLine, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_WAX_VISCOSITY_PERCENTs.Where(s => s.VersionNo == versionNo && s.PlanType == planType && s.MatPrefix == matPrefix && s.Grade == grade && s.GradeComp == gradeComp && s.Plant == plant && s.ProductionLine == productionLine
                         && s.StartMonth == startMonth).ToList();
            return result;
        }
    }
}