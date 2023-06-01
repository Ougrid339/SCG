using Microsoft.EntityFrameworkCore;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Export;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Export.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterPPRPackageCostByGradePackageRepo : RepositoryBase<SSP_MST_PPR_PACKAGE_COST_BY_GRADE_PACKAGE>, IMasterPPRPackageCostByGradePackageRepo
    {
        #region Inject

        private IViewAdditionalByPackExportRepo _viewAdditionalByPackExportRepo;

        public MasterPPRPackageCostByGradePackageRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
            _viewAdditionalByPackExportRepo = new ViewAdditionalByPackExportRepo(context, readConext);
        }

        #endregion Inject

        public List<PackagingCostMasterSheet> PackagingCost(string planType, string cycle)
        {
            var materialList = (from MAT in _context.SSP_FCT_MATERIALs
                                where MAT.Product != null
                                      && MAT.ProductSub != null
                                      && MAT.Material != null
                                select new
                                {
                                    Material = MAT.Material,
                                    Product = MAT.Product,
                                    ProductSub = MAT.ProductSub
                                })
                                .Where(s => s.Product.ToUpper() == "PP" || s.Product.ToUpper() == "PE" || s.Product.ToUpper() == "PV")
                                .Distinct().ToList();

            Func<string, string, string, bool> IsInFCTMaterial = (mat, product, productSub) =>
            {
                var result = materialList.Find(s => s.Material.Contains(mat));
                if (result != null)
                {
                    if (result.Product.Equals(product, StringComparison.OrdinalIgnoreCase)
                        && result.ProductSub.Equals(productSub, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            };

            // Packaging cost from joined query
            var joinedQuery = (from COST in _context.SSP_MST_PPR_PACKAGE_COST_BY_GRADE_PACKAGEs
                               join REF in _context.SSP_MST_REF_GRADEs on COST.Grade equals REF.RefGrade
                               where COST.FiscalYear == cycle.Substring(0, 4) && REF.PlanType == planType
                               group COST by new { COST.StartYearMonth, COST.EndYearMonth, REF.ProductionSite, REF.Product, REF.PrdSub, REF.RefGrade, COST.Package } into FINAL
                               select new PackagingCostMasterSheet()
                               {
                                   StartYearMonth = FINAL.Key.StartYearMonth,
                                   ProductionSite = FINAL.Key.ProductionSite,
                                   Product = FINAL.Key.Product,
                                   ProductSub = FINAL.Key.PrdSub,
                                   RefGrade = FINAL.Key.RefGrade,
                                   Package = FINAL.Key.Package,
                                   USDPackagingCost = FINAL.Average(o => o.USDPackagingCost)
                               }).ToList();
            // If not found
            if (joinedQuery == null || joinedQuery.Count == 0)
            {
                var packageCost = _context.SSP_MST_PPR_PACKAGE_COST_BY_GRADE_PACKAGEs.ToList().Where(w =>
                                    DateTime.ParseExact(w.StartYearMonth.Substring(0, 4), APPCONSTANT.FORMAT.YEAR, CultureInfo.InvariantCulture) <= DateTime.ParseExact(cycle.Substring(0, 4), APPCONSTANT.FORMAT.YEAR, CultureInfo.InvariantCulture)
                                     && DateTime.ParseExact(w.EndYearMonth.Substring(0, 4), APPCONSTANT.FORMAT.YEAR, CultureInfo.InvariantCulture) >= DateTime.ParseExact(cycle.Substring(0, 4), APPCONSTANT.FORMAT.YEAR, CultureInfo.InvariantCulture)
                               ).ToList();
                joinedQuery = (from COST in packageCost
                               join REF in _context.SSP_MST_REF_GRADEs on COST.Grade equals REF.RefGrade
                               where REF.PlanType == planType
                               group COST by new { COST.StartYearMonth, COST.EndYearMonth, REF.ProductionSite, REF.Product, REF.PrdSub, REF.RefGrade, COST.Package } into FINAL
                               select new PackagingCostMasterSheet()
                               {
                                   StartYearMonth = FINAL.Key.StartYearMonth,
                                   ProductionSite = FINAL.Key.ProductionSite,
                                   Product = FINAL.Key.Product,
                                   ProductSub = FINAL.Key.PrdSub,
                                   RefGrade = FINAL.Key.RefGrade,
                                   Package = FINAL.Key.Package,
                                   USDPackagingCost = FINAL.Average(o => o.USDPackagingCost)
                               }).ToList();
            }
            // Determine H1000PC's Product and ProductSub
            var h1000pcProductAndProductSub = (from MAT in _context.SSP_FCT_MATERIALs
                                               where EF.Functions.Like(MAT.Material, "%" + "H1000PC" + "%")
                                                     && MAT.FlagDelete == "X"
                                                     && !String.IsNullOrEmpty(MAT.Product)
                                                     && !String.IsNullOrEmpty(MAT.ProductSub)
                                               select new { MAT.Product, MAT.ProductSub }).Take(1).FirstOrDefault();

            // Packacking cost for H1000PC (directly determined)
            var h1000pcDirectQuery = (from COST in _context.SSP_MST_PPR_PACKAGE_COST_BY_GRADE_PACKAGEs
                                      where COST.FiscalYear == cycle.Substring(0, 4) && COST.Grade == "H1000PC"
                                      group COST by new { COST.StartYearMonth, COST.EndYearMonth, COST.Grade, COST.Package } into FINAL
                                      select new PackagingCostMasterSheet()
                                      {
                                          StartYearMonth = FINAL.Key.StartYearMonth,
                                          ProductionSite = "TH",
                                          Product = h1000pcProductAndProductSub != null ? h1000pcProductAndProductSub.Product : "",
                                          ProductSub = h1000pcProductAndProductSub != null ? h1000pcProductAndProductSub.ProductSub : "",
                                          RefGrade = FINAL.Key.Grade,
                                          Package = FINAL.Key.Package,
                                          USDPackagingCost = FINAL.Average(o => o.USDPackagingCost)
                                      }).ToList();
            // If not found
            if (h1000pcDirectQuery == null || h1000pcDirectQuery.Count == 0)
            {
                var packageCost = _context.SSP_MST_PPR_PACKAGE_COST_BY_GRADE_PACKAGEs.ToList().Where(w =>
                                    w.Grade == "H1000PC" &&
                                    DateTime.ParseExact(w.StartYearMonth.Substring(0, 4), APPCONSTANT.FORMAT.YEAR, CultureInfo.InvariantCulture) <= DateTime.ParseExact(cycle.Substring(0, 4), APPCONSTANT.FORMAT.YEAR, CultureInfo.InvariantCulture)
                                     && DateTime.ParseExact(w.EndYearMonth.Substring(0, 4), APPCONSTANT.FORMAT.YEAR, CultureInfo.InvariantCulture) >= DateTime.ParseExact(cycle.Substring(0, 4), APPCONSTANT.FORMAT.YEAR, CultureInfo.InvariantCulture)
                               ).ToList();
                h1000pcDirectQuery = (from COST in packageCost
                                      group COST by new { COST.StartYearMonth, COST.EndYearMonth, COST.Grade, COST.Package } into FINAL
                                      select new PackagingCostMasterSheet()
                                      {
                                          StartYearMonth = FINAL.Key.StartYearMonth,
                                          ProductionSite = "TH",
                                          Product = h1000pcProductAndProductSub != null ? h1000pcProductAndProductSub.Product : "",
                                          ProductSub = h1000pcProductAndProductSub != null ? h1000pcProductAndProductSub.ProductSub : "",
                                          RefGrade = FINAL.Key.Grade,
                                          Package = FINAL.Key.Package,
                                          USDPackagingCost = FINAL.Average(o => o.USDPackagingCost)
                                      }).ToList();
            }
            // Additional cost to be added
            var date = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Substring(5, 2)), 01);
            var adjustedPackageCost = (from ADT in _viewAdditionalByPackExportRepo.GetByPlanTypeAndDate(planType, date)
                                       where ADT.ChannelGroup == "Export"
                                       select new
                                       {
                                           ProductionSite = ADT.ProductionSite,
                                           Product = ADT.Product,
                                           ProductSub = ADT.ProductSub,
                                           Package = ADT.Package,
                                           AdjustedPackageCost = ADT.AdjustedPackageCost,
                                       })
                                          .DistinctBy(s => new { s.ProductionSite, s.Product, s.ProductSub, s.Package, s.AdjustedPackageCost }).ToList();

            Func<string, decimal?> GetAdjustedPackageCostByKey = (key) =>
            {
                var result = adjustedPackageCost.Find((i) =>
                    string.Concat(i.ProductionSite, i.Product, i.ProductSub, i.Package).Equals(key));
                if (result != null)
                {
                    return result.AdjustedPackageCost;
                }
                return 0;
            };

            var unionData = joinedQuery.Union(h1000pcDirectQuery);
            return unionData.GroupBy(g => new
            {
                g.StartYearMonth,
                g.ProductionSite,
                g.Product,
                g.ProductSub,
                g.RefGrade,
                g.Package,
                g.USDPackagingCost
            })
                                        .Select(s =>
                                        {
                                            var adjCost = GetAdjustedPackageCostByKey(
                                                    string.Concat(s.Key.ProductionSite, s.Key.Product, s.Key.ProductSub, s.Key.Package));
                                            return new PackagingCostMasterSheet()
                                            {
                                                StartYearMonth = s.Key.StartYearMonth,
                                                ProductionSite = s.Key.ProductionSite,
                                                Product = s.Key.Product,
                                                ProductSub = s.Key.ProductSub,
                                                RefGrade = s.Key.RefGrade,
                                                Package = s.Key.Package,
                                                USDPackagingCost = (s.Key.USDPackagingCost ?? 0) + (adjCost ?? 0)
                                            };
                                        })
                                        .Where(s => s.Product == "PE" || s.Product == "PP" || s.Product == "PV")
                                        .Where(s => IsInFCTMaterial(s.RefGrade, s.Product, s.ProductSub))
                                        .OrderBy(s => s.StartYearMonth)
                                        .ThenBy(s => s.ProductionSite)
                                        .ThenBy(s => s.Product)
                                        .ThenBy(s => s.ProductSub)
                                        .ThenBy(s => s.RefGrade)
                                        .ThenBy(s => s.Package)
                                        .ToList();
        }
    }
}