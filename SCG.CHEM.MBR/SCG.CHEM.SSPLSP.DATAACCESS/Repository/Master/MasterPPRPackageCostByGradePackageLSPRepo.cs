using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterPPRPackageCostByGradePackageLSPRepo : RepositoryBase<SSP_MST_PPR_PACKAGE_COST_BY_GRADE_PACKAGE_LSP>, IMasterPPRPackageCostByGradePackageLSPRepo
    {
        #region Inject

        public MasterPPRPackageCostByGradePackageLSPRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<PackagingCostModel> PackagingCost(string planType, string cycle)
        {
            var result = (from COST in _context.SSP_MST_PPR_PACKAGE_COST_BY_GRADE_PACKAGE_LSPs
                          join REF in _context.SSP_MST_REF_GRADEs on COST.Grade equals REF.RefGrade
                          where COST.FiscalYear == cycle.Substring(0, 4) && REF.PlanType == planType
                          group COST by new { COST.StartYearMonth, COST.EndYearMonth, REF.RefGrade, COST.Package } into FINAL
                          select new PackagingCostModel()
                          {
                              StartYearMonth = FINAL.Key.StartYearMonth,
                              EndYearMonth = FINAL.Key.EndYearMonth,
                              RefGrade = FINAL.Key.RefGrade,
                              Package = FINAL.Key.Package,
                              USDPackagingCost = FINAL.Average(o => o.USDPackagingCost)
                          }).ToList();

            var union = (from COST in _context.SSP_MST_PPR_PACKAGE_COST_BY_GRADE_PACKAGE_LSPs
                         where COST.Grade == "H1000PC"
                         group COST by new { COST.StartYearMonth, COST.EndYearMonth, COST.Grade, COST.Package } into FINAL
                         select new PackagingCostModel()
                         {
                             StartYearMonth = FINAL.Key.StartYearMonth,
                             EndYearMonth = FINAL.Key.EndYearMonth,
                             RefGrade = FINAL.Key.Grade,
                             Package = FINAL.Key.Package,
                             USDPackagingCost = FINAL.Average(o => o.USDPackagingCost)
                         }).ToList();

            result = result.Union(union).ToList();
            return result;
        }
    }
}