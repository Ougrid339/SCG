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
    public class MasterRefGradeRepo : RepositoryBase<SSP_MST_REF_GRADE>, IMasterRefGradeRepo
    {
        #region Inject

        public MasterRefGradeRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<PackagingRefGradeMasterSheet> GetMasterRefGradeByPlanType(string plantype)
        {
            var result = _context.SSP_MST_REF_GRADEs.Where(o => o.PlanType == plantype).Select(s => new
            PackagingRefGradeMasterSheet
            {
                PlanType = s.PlanType,
                ProductionSite = s.ProductionSite,
                MatPrefix = s.MatPrefix,
                Product = s.Product,
                PrdSub = s.PrdSub,
                RefMatPrefix = s.RefMatPrefix,
                RefGrade = s.RefGrade,
                RefPackage = s.RefPackage,
                RefMarketGroup = s.RefMarketGroup,
                RefMarketSource = s.RefMarketSource,
                RefPlant = s.RefPlant,
                RefLine = s.RefLine,
                MainMonomer = s.MainMonomer
            })
            .OrderBy(o => o.ProductionSite)
            .ThenBy(o => o.MatPrefix)
            .ThenBy(o => o.Product)
            .ThenBy(o => o.PrdSub)
            .ThenBy(o => o.RefMatPrefix)
            .ThenBy(o => o.RefGrade)
            .ThenBy(o => o.RefPackage)
            .ThenBy(o => o.RefMarketGroup)
            .ThenBy(o => o.RefMarketSource)
            .ThenBy(o => o.RefPlant)
            .ThenBy(o => o.RefLine)
            .ThenBy(o => o.MainMonomer)
            .ToList();
            return result;
        }
    }
}