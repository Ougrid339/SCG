using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction
{
    public class TransactionProductionPlanRepo : RepositoryBase<SSP_TRN_PRODUCTION_PLAN>, ITransactionProductionPlanRepo
    {
        #region Inject

        public TransactionProductionPlanRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TRN_PRODUCTION_PLAN> GetByKey(string versionName, string planningGroup, int revId, string plant, string bom, string line, string matCodeMst, string matCodeTrn, int newProductId, string monthNo)
        {
            var result = _context.SSP_TRN_PRODUCTION_PLANs.Where(w => w.VersionName == versionName
                                                            && w.PlanningGroup == planningGroup
                                                            && w.RevId == revId
                                                            && w.Plant == plant
                                                            && w.Bom == bom
                                                            && w.Line == line
                                                            && w.MatCodeMst == matCodeMst
                                                            && w.MatCodeTrn == matCodeTrn
                                                            && w.NewProductId == newProductId
                                                            && w.MonthNo == monthNo).ToList();
            return result;
        }

        public List<SSP_TRN_PRODUCTION_PLAN> GetByKeyWithoutMonthNo(string versionName, string planningGroup, int revId, string plant, string bom, string line, string matCodeMst, string matCodeTrn, int newProductId)
        {
            var result = _context.SSP_TRN_PRODUCTION_PLANs.Where(w => w.VersionName == versionName
                                                            && w.PlanningGroup == planningGroup
                                                            && w.RevId == revId
                                                            && w.Plant == plant
                                                            && w.Bom == bom
                                                            && w.Line == line
                                                            && w.MatCodeMst == matCodeMst
                                                            && w.MatCodeTrn == matCodeTrn
                                                            && w.NewProductId == newProductId).ToList();
            return result;
        }

        public List<SSP_TRN_PRODUCTION_PLAN> GetByKeysWithoutMonthNo(List<string> versionName, List<string> planningGroup, List<string> plant, List<string> line, List<string> matCodeMst, List<string> matCodeTrn, List<int> newProductId)
        {
            var result = _context.SSP_TRN_PRODUCTION_PLANs.Where(w => versionName.Contains(w.VersionName)
                                                            && planningGroup.Contains(w.PlanningGroup)
                                                            && plant.Contains(w.Plant)
                                                            && line.Contains(w.Line)
                                                            && matCodeMst.Contains(w.MatCodeMst)
                                                            && matCodeTrn.Contains(w.MatCodeTrn)
                                                            && newProductId.Contains(w.NewProductId)).ToList();
            return result;
        }

        public List<ProductionPlanCycleModel> GetProductionPlanGroup(string planType, string cycle, List<string> planningGroups)
        {
            var result = new List<ProductionPlanCycleModel>();

            var query = _context.SSP_TRN_PRODUCTION_PLANs.AsQueryable();
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            //var listDB  = query.ToList();

            result = (from PRD in query
                      join MAT in _context.SSP_FCT_MATERIALs on PRD.MatCodeMst equals MAT.Material into mat_left
                      from MAT in mat_left.DefaultIfEmpty()
                      join NPD in _context.SSP_MST_NEW_PRODUCT_FLAGs on PRD.NewProductId equals NPD.NewProductId into npd_left
                      from NPD in npd_left.DefaultIfEmpty()
                      where PRD.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && PRD.VersionName == cycle
                      group PRD by new
                      {
                          PRD.VersionName,
                          PRD.PlanningGroup,
                          PRD.RevId,
                          PRD.Plant,
                          PRD.Bom,
                          PRD.Line,
                          PRD.MatCodeMst,
                          MAT.GradeCustomization,
                          MAT.PackageQuantity,
                          PRD.Unit,
                          NPD.NewProductLDesc,
                      } into FINAL
                      select new ProductionPlanCycleModel()
                      {
                          VersionName = FINAL.Key.VersionName,
                          PlanningGroup = FINAL.Key.PlanningGroup,
                          RevId = FINAL.Key.RevId,
                          Plant = FINAL.Key.Plant,
                          Bom = FINAL.Key.Bom,
                          Line = FINAL.Key.Line,
                          MatCode = FINAL.Key.MatCodeMst,
                          Grade = FINAL.Key.GradeCustomization,
                          Package = FINAL.Key.PackageQuantity,
                          Unit = FINAL.Key.Unit,
                          NewProductLDesc = FINAL.Key.NewProductLDesc,
                          Remark = FINAL.FirstOrDefault().Remark,
                      }).ToList();

            return result;
        }

        public List<MonthModel> GetProductionPlanMonthQty(string planType, string cycle, List<string> planningGroups)
        {
            List<MonthModel> result = new List<MonthModel>();

            var query = _context.SSP_TRN_PRODUCTION_PLANs.AsQueryable();
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            //var listDB = query.ToList();

            result = (from PRD in query
                      join MAT in _context.SSP_FCT_MATERIALs on PRD.MatCodeMst equals MAT.Material into mat_left
                      from MAT in mat_left.DefaultIfEmpty()
                      join NPD in _context.SSP_MST_NEW_PRODUCT_FLAGs on PRD.NewProductId equals NPD.NewProductId into npd_left
                      from NPD in npd_left.DefaultIfEmpty()
                      where PRD.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && PRD.VersionName == cycle
                      orderby PRD.MonthNo
                      select new MonthModel()
                      {
                          CycleName = PRD.VersionName,
                          PlanningGroup = PRD.PlanningGroup,
                          RevId = PRD.RevId,
                          Plant = PRD.Plant,
                          Bom = PRD.Bom,
                          Line = PRD.Line,
                          MatCodeMst = PRD.MatCodeMst,
                          Grade = MAT.Grade,
                          Package = MAT.PackageQuantity,
                          Unit = PRD.Unit,
                          NewProductDesc = NPD.NewProductLDesc,
                          Name = "QTY-" + PRD.MonthIndex,
                          Value = PRD.PrdQty ?? 0,
                          Year = PRD.MonthNo.Substring(0, 4),
                          Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(PRD.MonthNo.Substring(5, 2)))
                      }).ToList();

            return result;
        }
    }
}