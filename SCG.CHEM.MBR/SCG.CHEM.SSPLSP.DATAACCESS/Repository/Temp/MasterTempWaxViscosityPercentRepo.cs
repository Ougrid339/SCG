using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempWaxViscosityPercentRepo : RepositoryBase<SSP_TMP_WAX_VISCOSITY_PERCENT>, IMasterTempWaxViscosityPercentRepo
    {
        #region Inject

        public MasterTempWaxViscosityPercentRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_WAX_VISCOSITY_PERCENT> GetByKey(string planType, string matPrefix, string grade, string gradeComp, string plant, string productionLine, string startMonth)
        {
            var result = _context.SSP_TMP_WAX_VISCOSITY_PERCENTs.Where(s => s.PlanType == planType && s.MatPrefix == matPrefix && s.Grade == grade && s.GradeComp == gradeComp && s.Plant == plant && s.ProductionLine == productionLine
                         && s.StartMonth == startMonth).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_WAX_VISCOSITY_PERCENTs.ToList();
            _context.RemoveRange(data);
        }
    }
}