using Microsoft.Data.SqlClient;
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
    public class TransactionConstraintSalesPlanRepo : RepositoryBase<SSP_TRN_CONSTRAINT_SALES_PLAN>, ITransactionConstraintSalesPlanRepo
    {
        #region Inject

        public TransactionConstraintSalesPlanRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public void ExecuteStoreProc(string cycle, List<string> planningGroups, string type = APPCONSTANT.STORE_PROCEDURE_TYPE.CONSTRAINT)
        {
            string cycleParam = cycle; // "OPPLAN_2022";
            string planningGroupParam = string.Join(",", planningGroups); // "POLY TG,POLY HD,POLY LD,POLY LL,POLY PP,POLY ROTO,POLY WAX TC,PVC PASTE,PVC RESIN,POLY WAX LP,OTHER";
            string transactionParam = type; //"UNCON,CON";

            string sql = @"DECLARE    @return_value int
                            EXEC    @return_value = [sp_SSP_TRN_CalculatePriceSale_update]
                                    @VersionName = @cycleParam,
                                    @PlanningGroup = @planningGroupParam,
                                    @Transaction = @transactionParam

                            SELECT    'ReturnValue' = @return_value";

            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@cycleParam", cycleParam));
            parameters.Add(new SqlParameter("@planningGroupParam", planningGroupParam));
            parameters.Add(new SqlParameter("@transactionParam", transactionParam));

            ExecuteCommand(sql, parameters);
        }

        public List<SSP_TRN_CONSTRAINT_SALES_PLAN> GetByKey(string versionName, int scenarioId, int stockId, string prdKey, int revId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string subRegion, int priceTypeId, int priceUnitId, string unit, string hvaCode, string salesDistict, string projectId, string reqProductSite, string inputM1, string monthNo)
        {
            var result = _context.SSP_TRN_CONSTRAINT_SALES_PLANs.Where(w => w.VersionName == versionName
                                                            && w.ScenarioId == scenarioId
                                                            && w.StockId == stockId
                                                            && w.PrdKey == prdKey
                                                            && w.RevId == revId
                                                            && w.CustomerCode == customerCode
                                                            && w.Channel == channel
                                                            && w.MatCodeMst == matCodeMst
                                                            && w.MatcodeTrn == matCodeTrn
                                                            && w.NewProductId == newProductId
                                                            && w.SalesGroupCode == salesGroupCode
                                                            && w.PlanningGroup == planningGroup
                                                            && w.Region == region
                                                            && w.SubRegion == subRegion
                                                            && w.PriceTypeId == priceTypeId
                                                            && w.PriceUnitId == priceUnitId
                                                            && w.Unit == unit
                                                            && w.HVASegmentCode == hvaCode
                                                            && w.Unit == unit
                                                            && w.SalesDistrict == salesDistict
                                                            && w.ProjectID == projectId
                                                            && w.ReqProductionSite == reqProductSite
                                                            && w.InputM1 == inputM1
                                                            && w.MonthNo == monthNo).ToList();
            return result;
        }

        public List<SSP_TRN_CONSTRAINT_SALES_PLAN> GetByKeyWithoutInputM1AndMonth(string versionName, int scenarioId, int stockId, string prdKey, int revId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string subRegion, int priceTypeId, int priceUnitId, string unit, string hvaCode, string salesDistict, string projectId, string reqProductSite)
        {
            var result = _context.SSP_TRN_CONSTRAINT_SALES_PLANs.Where(w => w.VersionName == versionName
                                                            && w.ScenarioId == scenarioId
                                                            && w.StockId == stockId
                                                            && w.PrdKey == prdKey
                                                            && w.RevId == revId
                                                            && w.CustomerCode == customerCode
                                                            && w.Channel == channel
                                                            && w.MatCodeMst == matCodeMst
                                                            && w.MatcodeTrn == matCodeTrn
                                                            && w.NewProductId == newProductId
                                                            && w.SalesGroupCode == salesGroupCode
                                                            && w.PlanningGroup == planningGroup
                                                            && w.Region == region
                                                            && w.SubRegion == subRegion
                                                            && w.PriceTypeId == priceTypeId
                                                            && w.PriceUnitId == priceUnitId
                                                            && w.Unit == unit
                                                            && w.HVASegmentCode == hvaCode
                                                            && w.SalesDistrict == salesDistict
                                                            && w.ProjectID == projectId
                                                            && w.ReqProductionSite == reqProductSite).ToList();
            return result;
        }

        public List<SSP_TRN_CONSTRAINT_SALES_PLAN> GetByKeysWithoutInputM1AndMonth(List<string> versionName, List<int> scenarioId, List<string> matCodeMst, List<string> matCodeTrn, List<int> newProductId, List<string> salesGroupCode, List<string> planningGroup, List<string> region, List<string> subRegion, List<string> hvaCode, List<string> salesDistict, List<string> projectId, List<string> reqProductSite)
        {
            var result = _context.SSP_TRN_CONSTRAINT_SALES_PLANs.Where(w => versionName.Contains(w.VersionName)
                                                            && scenarioId.Contains(w.ScenarioId)
                                                            && matCodeMst.Contains(w.MatCodeMst)
                                                            && matCodeTrn.Contains(w.MatcodeTrn)
                                                            && newProductId.Contains(w.NewProductId)
                                                            && salesGroupCode.Contains(w.SalesGroupCode)
                                                            && planningGroup.Contains(w.PlanningGroup)
                                                            && region.Contains(w.Region)
                                                            && subRegion.Contains(w.SubRegion)
                                                            && hvaCode.Contains(w.HVASegmentCode)
                                                            && salesDistict.Contains(w.SalesDistrict)
                                                            && projectId.Contains(w.ProjectID)
                                                            && reqProductSite.Contains(w.ReqProductionSite)).ToList();
            return result;
        }

        public List<ConstraintCycleModel> GetConstraintsView(string planType, string inputM1, List<string> planningGroups)
        {
            var result = new List<ConstraintCycleModel>();

            var query = _context.SSP_TRN_CONSTRAINT_SALES_PLANs.AsQueryable();
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            //var listDB = query.ToList();

            result = (from CON in query
                      join HVAS in _context.SSP_MST_HVA_SEGMENTs on CON.HVASegmentCode equals HVAS.HVACode into hva_join
                      from HVAS in hva_join.DefaultIfEmpty()
                      join MAT in _context.SSP_FCT_MATERIALs on CON.MatCodeMst equals MAT.Material into mat_join
                      from MAT in mat_join.DefaultIfEmpty()
                      join PT in _context.SSP_MST_PRICE_TYPEs on CON.PriceTypeId equals PT.PriceTypeId into pt_join
                      from PT in pt_join.DefaultIfEmpty()
                      join SC in _context.SSP_MST_SCENARIOs on CON.ScenarioId equals SC.SceneId into sc_join
                      from SC in sc_join.DefaultIfEmpty()
                      join NPD in _context.SSP_MST_NEW_PRODUCT_FLAGs on CON.NewProductId equals NPD.NewProductId into npd_join
                      from NPD in npd_join.DefaultIfEmpty()
                      join CUS in _context.SSP_FCT_BUSINESS_PARTNERs on CON.CustomerCode equals CUS.Customer into cus_join
                      from CUS in cus_join.DefaultIfEmpty()
                      join SALE in _context.SSP_MST_SALES_GROUPs on CON.SalesGroupCode equals SALE.SalesGroupCode into sale_join
                      from SALE in sale_join.DefaultIfEmpty()
                      where CON.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && CON.PlanType == planType && CON.InputM1 == inputM1
                      group CON by new
                      {
                          SC.SceneDesc,
                          CON.CustomerCode,
                          CON.Channel,
                          MAT.PackageQuantity,
                          CON.Grade,
                          CON.MatCodeMst,
                          CON.Unit,
                          CON.NewProductId,
                          CON.SalesGroupCode,
                          CON.PlanningGroup,
                          CON.Region,
                          CON.SubRegion,
                          CON.ReqProductionSite,
                          CON.SalesDistrict,
                          CON.PriceTypeId,
                          HVAS.HVALDesc,
                          HVAS.HVACode,
                          PT.PriceTypeDesc,
                          MAT.ProductApplicationDesc,
                          NPD.NewProductLDesc,
                          CUS.Description,
                          SALE.SalesGroupSDesc,
                          MAT.ProductSub,
                          CON.PrdLine
                      } into FINAL
                      select new ConstraintCycleModel()
                      {
                          Scenario = FINAL.Key.SceneDesc,
                          CustomerCode = FINAL.Key.CustomerCode,
                          CustomerName = FINAL.Key.Description,
                          Channel = FINAL.Key.Channel,
                          MatCodeMst = FINAL.Key.MatCodeMst,
                          Grade = FINAL.Key.Grade,
                          Unit = FINAL.Key.Unit,
                          NewProductId = FINAL.Key.NewProductId,
                          Package = FINAL.Key.PackageQuantity,
                          SalesGroupCode = FINAL.Key.SalesGroupCode,
                          SalesGroupName = FINAL.Key.SalesGroupSDesc,
                          PlanningGroup = FINAL.Key.PlanningGroup,
                          Region = FINAL.Key.Region,
                          SubRegion = FINAL.Key.SubRegion,
                          SalesDistrict = FINAL.Key.SalesDistrict,
                          HVASegmentCode = FINAL.Key.HVACode,
                          HVASegmentName = FINAL.Key.HVALDesc,
                          PriceType = FINAL.Key.PriceTypeDesc,
                          ProductSub = FINAL.Key.ProductSub,
                          AppName = FINAL.Key.ProductApplicationDesc,
                          CycleName = FINAL.FirstOrDefault().VersionName,
                          NewProdFlag = FINAL.Key.NewProductLDesc,
                          RequestProdSite = FINAL.Key.ReqProductionSite,
                          RevId = FINAL.FirstOrDefault().RevId,
                          Plant = FINAL.FirstOrDefault().Plant,
                          Bom = FINAL.FirstOrDefault().Bom,
                          Line = FINAL.Key.PrdLine,
                          Remark = FINAL.FirstOrDefault().Remark,
                          RefLine = FINAL.FirstOrDefault().RefLine,
                      }).ToList();
            return result;
        }

        public List<MonthModel> GetConstraintsMonthQty(string planType, string inputM1, List<string> planningGroups)
        {
            List<MonthModel> result = new List<MonthModel>();

            var query = _context.SSP_TRN_CONSTRAINT_SALES_PLANs.AsQueryable();
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            //var listDB = query.ToList();

            result = (from CON in query
                      join MAT in _context.SSP_FCT_MATERIALs on CON.MatCodeMst equals MAT.Material into mat_left
                      from MAT in mat_left.DefaultIfEmpty()
                      join SC in _context.SSP_MST_SCENARIOs on CON.ScenarioId equals SC.SceneId into sc_left
                      from SC in sc_left.DefaultIfEmpty()
                      where CON.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && CON.PlanType == planType && CON.InputM1 == inputM1
                      orderby CON.MonthNo
                      select new MonthModel()
                      {
                          Scenario = SC.SceneDesc,
                          CustomerCode = CON.CustomerCode,
                          Channel = CON.Channel,
                          MatCodeMst = CON.MatCodeMst,
                          Grade = CON.Grade,
                          Package = MAT.PackageQuantity,
                          SalesGroupCode = CON.SalesGroupCode,
                          PlanningGroup = CON.PlanningGroup,
                          NewProductId = CON.NewProductId,
                          Region = CON.Region,
                          SubRegion = CON.SubRegion,
                          SalesDistrict = CON.SalesDistrict,
                          HVASegmentCode = CON.HVASegmentCode,
                          ProductSub = MAT.ProductSub,
                          CycleName = CON.VersionName,
                          RequestProdSite = CON.ReqProductionSite,
                          Plant = CON.Plant,
                          Bom = CON.Bom,
                          Line = CON.PrdLine,
                          Unit = CON.Unit,
                          Name = "QTY-" + CON.MonthIndex,
                          Value = CON.ConQty ?? 0,
                          Year = CON.MonthNo.Substring(0, 4),
                          Month = CON.MonthNo
                      })
                      .GroupBy(g => new
                      {
                          g.CycleName,
                          g.PlanningGroup,
                          g.SalesGroupCode,
                          g.NewProductId,
                          g.Channel,
                          g.Region,
                          g.SubRegion,
                          g.HVASegmentCode,
                          g.CustomerCode,
                          g.ProductSub,
                          g.Grade,
                          g.Package,
                          g.MatCodeMst,
                          g.Scenario,
                          g.SalesDistrict,
                          g.Plant,
                          g.Bom,
                          g.Line,
                          g.Unit,
                          g.RequestProdSite,
                          g.Month,
                          g.Name,
                          g.Year
                      }).OrderBy(o => o.Key.Month).Select(s => new MonthModel
                      {
                          Scenario = s.Key.Scenario,
                          CustomerCode = s.Key.CustomerCode,
                          Channel = s.Key.Channel,
                          MatCodeMst = s.Key.MatCodeMst,
                          Grade = s.Key.Grade,
                          Package = s.Key.Package,
                          SalesGroupCode = s.Key.SalesGroupCode,
                          PlanningGroup = s.Key.PlanningGroup,
                          NewProductId = s.Key.NewProductId,
                          Region = s.Key.Region,
                          SubRegion = s.Key.SubRegion,
                          SalesDistrict = s.Key.SalesDistrict,
                          HVASegmentCode = s.Key.HVASegmentCode,
                          ProductSub = s.Key.ProductSub,
                          CycleName = s.Key.CycleName,
                          RequestProdSite = s.Key.RequestProdSite,
                          Plant = s.Key.Plant,
                          Bom = s.Key.Bom,
                          Line = s.Key.Line,
                          Unit = s.Key.Unit,
                          Name = s.Key.Name,
                          Value = s.Sum(s => s.Value),
                          Year = s.Key.Year,
                          Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(s.Key.Month.Substring(5, 2)))
                      }).ToList();

            return result;
        }

        public List<MonthModel> GetConstraintsMonthPrice(string planType, string inputM1, List<string> planningGroups)
        {
            List<MonthModel> result = new List<MonthModel>();

            var query = _context.SSP_TRN_CONSTRAINT_SALES_PLANs.AsQueryable();
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            var listDB = query.ToList();

            result = (from CON in listDB
                      join MAT in _context.SSP_FCT_MATERIALs on CON.MatCodeMst equals MAT.Material into mat_left
                      from MAT in mat_left.DefaultIfEmpty()
                      join SC in _context.SSP_MST_SCENARIOs on CON.ScenarioId equals SC.SceneId into sc_left
                      from SC in sc_left.DefaultIfEmpty()
                      where CON.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && CON.PlanType == planType && CON.InputM1 == inputM1
                      orderby CON.MonthNo
                      select new MonthModel()
                      {
                          Scenario = SC.SceneDesc,
                          CustomerCode = CON.CustomerCode,
                          Channel = CON.Channel,
                          MatCodeMst = CON.MatCodeMst,
                          Grade = CON.Grade,
                          Package = MAT.PackageQuantity,
                          SalesGroupCode = CON.SalesGroupCode,
                          PlanningGroup = CON.PlanningGroup,
                          NewProductId = CON.NewProductId,
                          Region = CON.Region,
                          SubRegion = CON.SubRegion,
                          SalesDistrict = CON.SalesDistrict,
                          HVASegmentCode = CON.HVASegmentCode,
                          ProductSub = MAT.ProductSub,
                          CycleName = CON.VersionName,
                          RequestProdSite = CON.ReqProductionSite,
                          Plant = CON.Plant,
                          Bom = CON.Bom,
                          Line = CON.PrdLine,
                          Unit = CON.Unit,
                          Name = "InputPrice-" + CON.MonthIndex,
                          Value = CON.InputPrice ?? 0,
                          Year = CON.MonthNo.Substring(0, 4),
                          Month = CON.MonthNo
                      })
                      .GroupBy(g => new
                      {
                          g.CycleName,
                          g.PlanningGroup,
                          g.SalesGroupCode,
                          g.NewProductId,
                          g.Channel,
                          g.Region,
                          g.SubRegion,
                          g.HVASegmentCode,
                          g.CustomerCode,
                          g.ProductSub,
                          g.Grade,
                          g.Package,
                          g.MatCodeMst,
                          g.Scenario,
                          g.SalesDistrict,
                          g.Plant,
                          g.Bom,
                          g.Line,
                          g.Unit,
                          g.RequestProdSite,
                          g.Month,
                          g.Name,
                          g.Year
                      }).OrderBy(o => o.Key.Month).Select(s => new MonthModel
                      {
                          Scenario = s.Key.Scenario,
                          CustomerCode = s.Key.CustomerCode,
                          Channel = s.Key.Channel,
                          MatCodeMst = s.Key.MatCodeMst,
                          Grade = s.Key.Grade,
                          Package = s.Key.Package,
                          SalesGroupCode = s.Key.SalesGroupCode,
                          PlanningGroup = s.Key.PlanningGroup,
                          NewProductId = s.Key.NewProductId,
                          Region = s.Key.Region,
                          SubRegion = s.Key.SubRegion,
                          SalesDistrict = s.Key.SalesDistrict,
                          HVASegmentCode = s.Key.HVASegmentCode,
                          ProductSub = s.Key.ProductSub,
                          CycleName = s.Key.CycleName,
                          RequestProdSite = s.Key.RequestProdSite,
                          Plant = s.Key.Plant,
                          Bom = s.Key.Bom,
                          Line = s.Key.Line,
                          Unit = s.Key.Unit,
                          Name = s.Key.Name,
                          Value = s.Sum(s => s.Value),
                          Year = s.Key.Year,
                          Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(s.Key.Month.Substring(5, 2)))
                      }).ToList();
            return result;
        }

        public List<MonthGroupModel> GetConstraints(string planType, string inputM1, List<string> planningGroups)
        {
            List<MonthGroupModel> result = new List<MonthGroupModel>();

            var query = _context.SSP_TRN_CONSTRAINT_SALES_PLANs.AsQueryable();
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            //var listDB = query.ToList();

            result = (from CON in query
                      join MAT in _context.SSP_FCT_MATERIALs on CON.MatCodeMst equals MAT.Material into mat_left
                      from MAT in mat_left.DefaultIfEmpty()
                      join SC in _context.SSP_MST_SCENARIOs on CON.ScenarioId equals SC.SceneId into sc_left
                      from SC in sc_left.DefaultIfEmpty()
                      where CON.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && CON.PlanType == planType && CON.InputM1 == inputM1
                      orderby CON.MonthNo
                      select new
                      {
                          Scenario = SC.SceneDesc,
                          CustomerCode = CON.CustomerCode,
                          Channel = CON.Channel,
                          MatCodeMst = CON.MatCodeMst,
                          Grade = CON.Grade,
                          Package = MAT.PackageQuantity,
                          SalesGroupCode = CON.SalesGroupCode,
                          PlanningGroup = CON.PlanningGroup,
                          NewProductId = CON.NewProductId,
                          Region = CON.Region,
                          SubRegion = CON.SubRegion,
                          SalesDistrict = CON.SalesDistrict,
                          HVASegmentCode = CON.HVASegmentCode,
                          ProductSub = MAT.ProductSub,
                          CycleName = CON.VersionName,
                          RequestProdSite = CON.ReqProductionSite,
                          Plant = CON.Plant,
                          Bom = CON.Bom,
                          Line = CON.PrdLine,
                          Unit = CON.Unit,
                          Name = CON.MonthIndex,
                          Qty = CON.ConQty ?? 0,
                          InputPrice = CON.InputPrice ?? 0,
                          Year = CON.MonthNo.Substring(0, 4),
                          Month = CON.MonthNo
                      })
                      .GroupBy(g => new
                      {
                          g.CycleName,
                          g.PlanningGroup,
                          g.SalesGroupCode,
                          g.NewProductId,
                          g.Channel,
                          g.Region,
                          g.SubRegion,
                          g.HVASegmentCode,
                          g.CustomerCode,
                          g.ProductSub,
                          g.Grade,
                          g.Package,
                          g.MatCodeMst,
                          g.Scenario,
                          g.SalesDistrict,
                          g.Plant,
                          g.Bom,
                          g.Line,
                          g.Unit,
                          g.RequestProdSite,
                          g.Month,
                          g.Name,
                          g.Year
                      }).OrderBy(o => o.Key.Month).Select(s => new MonthGroupModel
                      {
                          Scenario = s.Key.Scenario,
                          CustomerCode = s.Key.CustomerCode,
                          Channel = s.Key.Channel,
                          MatCodeMst = s.Key.MatCodeMst,
                          Grade = s.Key.Grade,
                          Package = s.Key.Package,
                          SalesGroupCode = s.Key.SalesGroupCode,
                          PlanningGroup = s.Key.PlanningGroup,
                          NewProductId = s.Key.NewProductId,
                          Region = s.Key.Region,
                          SubRegion = s.Key.SubRegion,
                          SalesDistrict = s.Key.SalesDistrict,
                          HVASegmentCode = s.Key.HVASegmentCode,
                          ProductSub = s.Key.ProductSub,
                          CycleName = s.Key.CycleName,
                          RequestProdSite = s.Key.RequestProdSite,
                          Plant = s.Key.Plant,
                          Bom = s.Key.Bom,
                          Line = s.Key.Line,
                          Unit = s.Key.Unit,
                          Name = s.Key.Name,
                          Qty = s.Sum(s => s.Qty),
                          InputPrice = s.Average(s => s.InputPrice),
                          Year = s.Key.Year,
                          Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(s.Key.Month.Substring(5, 2)))
                      }).ToList();

            return result;
        }
    }
}