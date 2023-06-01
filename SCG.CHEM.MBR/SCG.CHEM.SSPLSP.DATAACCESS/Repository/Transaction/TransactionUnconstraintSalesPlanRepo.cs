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
    public class TransactionUnconstraintSalesPlanRepo : RepositoryBase<SSP_TRN_UNCONSTRAINT_SALES_PLAN>, ITransactionUnconstraintSalesPlanRepo
    {
        #region Inject

        public TransactionUnconstraintSalesPlanRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public void ExecuteStoreProc(string cycle, List<string> planningGroups, string type = APPCONSTANT.STORE_PROCEDURE_TYPE.UNCONSTRAINT)
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

        //public SSP_TRN_UNCONSTRAINT_SALES_PLAN GetLastActiveVersionByKey(string planType, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId, string inputM1, string monthNo)
        //{
        //    var result = _context.SSP_TRN_UNCONSTRAINT_SALES_PLANs.Where(w => w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES
        //                                                    && w.PlanType == planType
        //                                                    && w.ScenarioId == scenarioId
        //                                                    && w.CustomerCode == customerCode
        //                                                    && w.Channel == channel
        //                                                    && w.MatCodeMst == matCodeMst
        //                                                    && w.MatCodeTrn == matCodeTrn
        //                                                    && w.NewProductId == newProductId
        //                                                    && w.SalesGroupCode == salesGroupCode
        //                                                    && w.PlanningGroup == planningGroup
        //                                                    && w.Region == region
        //                                                    && w.ReqProductionSite == reqProductSite
        //                                                    && w.SubRegion == subRegion
        //                                                    && w.SalesDistrict == salesDistrict
        //                                                    && w.Unit == unit
        //                                                    && w.ProjectID == projectId
        //                                                    && w.PriceUnitId == priceUnitId
        //                                                    && w.InputM1 == inputM1
        //                                                    && w.MonthNo == monthNo).OrderByDescending(o => o.VersionNo).FirstOrDefault();
        //    return result;
        //}

        //public SSP_TRN_UNCONSTRAINT_SALES_PLAN GetLastVersionByKey(string planType, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId, string inputM1, string monthNo)
        //{
        //    var result = _context.SSP_TRN_UNCONSTRAINT_SALES_PLANs.Where(w => w.PlanType == planType
        //                                                    && w.ScenarioId == scenarioId
        //                                                    && w.CustomerCode == customerCode
        //                                                    && w.Channel == channel
        //                                                    && w.MatCodeMst == matCodeMst
        //                                                    && w.MatCodeTrn == matCodeTrn
        //                                                    && w.NewProductId == newProductId
        //                                                    && w.SalesGroupCode == salesGroupCode
        //                                                    && w.PlanningGroup == planningGroup
        //                                                    && w.Region == region
        //                                                    && w.ReqProductionSite == reqProductSite
        //                                                    && w.SubRegion == subRegion
        //                                                    && w.SalesDistrict == salesDistrict
        //                                                    && w.Unit == unit
        //                                                    && w.ProjectID == projectId
        //                                                    && w.PriceUnitId == priceUnitId
        //                                                    && w.InputM1 == inputM1
        //                                                    && w.MonthNo == monthNo).OrderByDescending(o => o.VersionNo).FirstOrDefault();
        //    return result;
        //}

        public SSP_TRN_UNCONSTRAINT_SALES_PLAN GetByKey(string planType, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId, string inputM1, string monthNo)
        {
            var result = _context.SSP_TRN_UNCONSTRAINT_SALES_PLANs.Where(w => w.PlanType == planType
                                                            && w.ScenarioId == scenarioId
                                                            && w.CustomerCode == customerCode
                                                            && w.Channel == channel
                                                            && w.MatCodeMst == matCodeMst
                                                            && w.MatCodeTrn == matCodeTrn
                                                            && w.NewProductId == newProductId
                                                            && w.SalesGroupCode == salesGroupCode
                                                            && w.PlanningGroup == planningGroup
                                                            && w.Region == region
                                                            && w.ReqProductionSite == reqProductSite
                                                            && w.SubRegion == subRegion
                                                            && w.SalesDistrict == salesDistrict
                                                            && w.Unit == unit
                                                            && w.ProjectID == projectId
                                                            && w.PriceUnitId == priceUnitId
                                                            && w.InputM1 == inputM1
                                                            && w.MonthNo == monthNo
                                                            //&& w.AutoGenFlag == false
                                                            ).FirstOrDefault();
            return result;
        }

        //public SSP_TRN_UNCONSTRAINT_SALES_PLAN GetByKeyAutoGen(string planType, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId, string inputM1, string monthNo)
        //{
        //    var result = _context.SSP_TRN_UNCONSTRAINT_SALES_PLANs.Where(w => w.PlanType == planType
        //                                                    && w.ScenarioId == scenarioId
        //                                                    && w.CustomerCode == customerCode
        //                                                    && w.Channel == channel
        //                                                    && w.MatCodeMst == matCodeMst
        //                                                    && w.MatCodeTrn == matCodeTrn
        //                                                    && w.NewProductId == newProductId
        //                                                    && w.SalesGroupCode == salesGroupCode
        //                                                    && w.PlanningGroup == planningGroup
        //                                                    && w.Region == region
        //                                                    && w.ReqProductionSite == reqProductSite
        //                                                    && w.SubRegion == subRegion
        //                                                    && w.SalesDistrict == salesDistrict
        //                                                    && w.Unit == unit
        //                                                    && w.ProjectID == projectId
        //                                                    && w.PriceUnitId == priceUnitId
        //                                                    && w.InputM1 == inputM1
        //                                                    && w.MonthNo == monthNo
        //                                                    && w.AutoGenFlag == true).FirstOrDefault();
        //    return result;
        //}

        public List<SSP_TRN_UNCONSTRAINT_SALES_PLAN> GetActiveByKeyIgnoreMonth(string planType, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId, string inputM1)
        {
            var result = _context.SSP_TRN_UNCONSTRAINT_SALES_PLANs.Where(w => w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES
                                                            && w.PlanType == planType
                                                            && w.ScenarioId == scenarioId
                                                            && w.CustomerCode == customerCode
                                                            && w.Channel == channel
                                                            && w.MatCodeMst == matCodeMst
                                                            && w.MatCodeTrn == matCodeTrn
                                                            && w.NewProductId == newProductId
                                                            && w.SalesGroupCode == salesGroupCode
                                                            && w.PlanningGroup == planningGroup
                                                            && w.Region == region
                                                            && w.ReqProductionSite == reqProductSite
                                                            && w.SubRegion == subRegion
                                                            && w.SalesDistrict == salesDistrict
                                                            && w.Unit == unit
                                                            && w.ProjectID == projectId
                                                            && w.PriceUnitId == priceUnitId
                                                            && w.InputM1 == inputM1).ToList();
            return result;
        }

        public List<SSP_TRN_UNCONSTRAINT_SALES_PLAN> GetByKeyWithoutInputM1AndMonth(string planType, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId)
        {
            var result = _context.SSP_TRN_UNCONSTRAINT_SALES_PLANs.Where(w => w.PlanType == planType
                                                            && w.ScenarioId == scenarioId
                                                            && w.CustomerCode == customerCode
                                                            && w.Channel == channel
                                                            && w.MatCodeMst == matCodeMst
                                                            && w.MatCodeTrn == matCodeTrn
                                                            && w.NewProductId == newProductId
                                                            && w.SalesGroupCode == salesGroupCode
                                                            && w.PlanningGroup == planningGroup
                                                            && w.Region == region
                                                            && w.ReqProductionSite == reqProductSite
                                                            && w.SubRegion == subRegion
                                                            && w.SalesDistrict == salesDistrict
                                                            && w.Unit == unit
                                                            && w.ProjectID == projectId
                                                            && w.PriceUnitId == priceUnitId).ToList();
            return result;
        }

        public List<SSP_TRN_UNCONSTRAINT_SALES_PLAN> GetByKeysWithoutInputM1AndMonth(List<string> planType, List<int> scenarioId, List<string> customerCode, List<string> channel, List<string> matCodeMst, List<string> matCodeTrn, List<int> newProductId, List<string> salesGroupCode, List<string> planningGroup, List<string> region, List<string> reqProductSite, List<string> subRegion, List<string> salesDistrict, List<string> projectId, List<int> priceTypeId)
        {
            var result = _context.SSP_TRN_UNCONSTRAINT_SALES_PLANs.Where(w => planType.Contains(w.PlanType)
                                                            && scenarioId.Contains(w.ScenarioId)
                                                            && customerCode.Contains(w.CustomerCode)
                                                            && channel.Contains(w.Channel)
                                                            && matCodeMst.Contains(w.MatCodeMst)
                                                            && matCodeTrn.Contains(w.MatCodeTrn)
                                                            && newProductId.Contains(w.NewProductId)
                                                            && salesGroupCode.Contains(w.SalesGroupCode)
                                                            && planningGroup.Contains(w.PlanningGroup)
                                                            && region.Contains(w.Region)
                                                            && reqProductSite.Contains(w.ReqProductionSite)
                                                            && subRegion.Contains(w.SubRegion)
                                                            && salesDistrict.Contains(w.SalesDistrict)
                                                            //&& unit.Contains(w.Unit)
                                                            && projectId.Contains(w.ProjectID)
                                                            //&& priceUnitId.Contains(w.PriceUnitId)
                                                            && priceTypeId.Contains(w.PriceTypeId)
                                                            ).ToList();
            return result;
        }

        public List<UnconstraintCycleModel> GetUnconstraintsView(string planType, string inputM1, List<string> planningGroups)
        {
            var result = new List<UnconstraintCycleModel>();

            var query = _context.SSP_TRN_UNCONSTRAINT_SALES_PLANs.Where(w => w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && w.PlanType == planType && w.InputM1 == inputM1);
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            var listDB = query.ToList();

            result = (from UCON in listDB
                      group UCON by new
                      {
                          UCON.ScenarioDesc,
                          UCON.CustomerCode,
                          UCON.Channel,
                          UCON.MatPrefix,
                          UCON.Grade,
                          UCON.Package,
                          UCON.Unit,
                          UCON.NewProductId,
                          UCON.SalesGroupCode,
                          UCON.PlanningGroup,
                          UCON.Region,
                          UCON.SubRegion,
                          UCON.ProjectID,
                          UCON.ReqProductionSite,
                          UCON.SalesDistrict,
                          //UCON.PriceTypeId,
                          UCON.HVASegmentCode,
                          //HVAS.HVALDesc,
                          //PT.PriceTypeDesc,
                          //MAT.ProductApplicationDesc,
                          UCON.MatCodeMst
                      } into FINAL
                      select new UnconstraintCycleModel()
                      {
                          Scenario = FINAL.Key.ScenarioDesc,
                          CustomerCode = FINAL.Key.CustomerCode,
                          CustomerName = FINAL.FirstOrDefault().CustomerName,
                          Channel = FINAL.Key.Channel,
                          Grade = FINAL.Key.Grade,
                          Package = FINAL.Key.Package,
                          SalesGroupCode = FINAL.Key.SalesGroupCode,
                          SalesGroupName = FINAL.FirstOrDefault().SalesGroupName,
                          PlanningGroup = FINAL.Key.PlanningGroup,
                          Region = FINAL.Key.Region,
                          SubRegion = FINAL.Key.SubRegion,
                          ProductSub = FINAL.FirstOrDefault().ProductSub,
                          SalesDistrict = FINAL.Key.SalesDistrict,
                          HVASegmentCode = FINAL.Key.HVASegmentCode,
                          //HVASegmentName = FINAL.Key.HVALDesc,
                          //PriceType = FINAL.Key.PriceTypeDesc,
                          //AppName = FINAL.Key.ProductApplicationDesc,
                          CycleName = FINAL.FirstOrDefault().VersionName,
                          NewProductId = FINAL.Key.NewProductId,
                          NewProdFlag = FINAL.FirstOrDefault()?.NewProductDesc,
                          RequestProdSite = FINAL.Key.ReqProductionSite,
                          MatCodeMst = FINAL.Key.MatCodeMst,
                          Unit = FINAL.Key.Unit,
                          Plant = FINAL.FirstOrDefault().ProductSub,
                          ProjectId = FINAL.FirstOrDefault().ProjectID,
                          PriceTypeId = FINAL.FirstOrDefault()?.PriceTypeId ?? 0,
                      }).ToList();

            var hvaCodeList = result.Select(s => s.HVASegmentCode).Distinct().ToList();
            var materialCodeList = result.Select(s => s.MatCodeMst).Distinct().ToList();
            var priceTypeIdList = result.Select(s => s.PriceTypeId).Distinct().ToList();

            var hvaListDB = _context.SSP_MST_HVA_SEGMENTs.Where(w => hvaCodeList.Contains(w.HVACode)).ToList();
            var materialListDB = _context.SSP_FCT_MATERIALs.Where(w => materialCodeList.Contains(w.Material)).ToList();
            var priceTypeListDB = _context.SSP_MST_PRICE_TYPEs.Where(w => priceTypeIdList.Contains(w.PriceTypeId)).ToList();

            // Set Description
            result.ForEach(i =>
            {
                i.HVASegmentName = hvaListDB.Where(w => String.Equals(w.HVACode, i.HVASegmentCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()?.HVALDesc ?? "";
                i.AppName = materialListDB.Where(w => String.Equals(w.Material, i.MatCodeMst, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()?.ProductApplicationDesc ?? "";
                i.PriceType = priceTypeListDB.Where(w => w.PriceTypeId == i.PriceTypeId).FirstOrDefault()?.PriceTypeDesc ?? "";
            });

            return result;
        }

        public List<MonthModel> GetUnconstraintsMonthQty(string planType, string inputM1, string name, List<string> planningGroups)
        {
            List<MonthModel> result = new List<MonthModel>();

            var query = _context.SSP_TRN_UNCONSTRAINT_SALES_PLANs.Where(w => w.PlanType == planType && w.InputM1 == inputM1 && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES);
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            var listDB = query.ToList();

            result = listDB
            .GroupBy(g => new
            {
                g.ScenarioDesc,
                g.CustomerCode,
                g.Channel,
                g.Grade,
                g.Package,
                g.SalesGroupCode,
                g.PlanningGroup,
                g.Region,
                g.SubRegion,
                g.SalesDistrict,
                g.HVASegmentCode,
                g.ProductSub,
                g.ReqProductionSite,
                g.PlanType,
                g.VersionName,
                g.InputM1,
                g.MonthIndex,
                g.MonthNo,
                g.MatCodeMst,
                g.PriceUnitId,
                g.NewProductId,
                g.Unit,
                g.ProjectID
            }).OrderBy(o => o.Key.MonthNo).Select(s => new MonthModel()
            {
                Scenario = s.Key.ScenarioDesc,
                CustomerCode = s.Key.CustomerCode,
                Channel = s.Key.Channel,
                Grade = s.Key.Grade,
                Package = s.Key.Package,
                SalesGroupCode = s.Key.SalesGroupCode,
                PlanningGroup = s.Key.PlanningGroup,
                Region = s.Key.Region,
                SubRegion = s.Key.SubRegion,
                SalesDistrict = s.Key.SalesDistrict,
                HVASegmentCode = s.Key.HVASegmentCode,
                ProductSub = s.Key.ProductSub,
                CycleName = s.Key.VersionName,
                RequestProdSite = s.Key.ReqProductionSite,
                MatCodeMst = s.Key.MatCodeMst,
                ProjectId = s.Key.ProjectID,
                PriceUnitId = s.Key.PriceUnitId,
                NewProductId = s.Key.NewProductId,
                NewProductDesc = s.FirstOrDefault()?.NewProductDesc,
                Unit = s.Key.Unit,
                Name = name + s.Key.MonthIndex,
                //Value =  s.Qty ?? 0,
                Value = s.Sum(q => q.Qty ?? 0),
                Year = s.Key.MonthNo.Substring(0, 4),
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(s.Key.MonthNo.Substring(5, 2)))
            }).ToList();

            return result;
        }

        public List<MonthModel> GetUnconstraintsMonthPrice(string planType, string inputM1, List<string> planningGroups)
        {
            List<MonthModel> result = new List<MonthModel>();

            var query = _context.SSP_TRN_UNCONSTRAINT_SALES_PLANs.Where(w => w.PlanType == planType && w.InputM1 == inputM1 && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES);
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            var listDB = query.ToList();

            result = listDB
            .GroupBy(g => new
            {
                g.ScenarioDesc,
                g.CustomerCode,
                g.Channel,
                g.Grade,
                g.Package,
                g.SalesGroupCode,
                g.PlanningGroup,
                g.Region,
                g.SubRegion,
                g.SalesDistrict,
                g.HVASegmentCode,
                g.ProductSub,
                g.ReqProductionSite,
                g.PlanType,
                g.VersionName,
                g.InputM1,
                g.MonthIndex,
                g.MonthNo,
                g.MatCodeMst,
                g.PriceUnitId,
                g.NewProductId,
                g.Unit,
                g.ProjectID
            }).OrderBy(o => o.Key.MonthNo).Select(s => new MonthModel()
            {
                Scenario = s.Key.ScenarioDesc,
                CustomerCode = s.Key.CustomerCode,
                Channel = s.Key.Channel,
                Grade = s.Key.Grade,
                Package = s.Key.Package,
                SalesGroupCode = s.Key.SalesGroupCode,
                PlanningGroup = s.Key.PlanningGroup,
                Region = s.Key.Region,
                SubRegion = s.Key.SubRegion,
                SalesDistrict = s.Key.SalesDistrict,
                HVASegmentCode = s.Key.HVASegmentCode,
                ProductSub = s.Key.ProductSub,
                CycleName = s.Key.VersionName,
                RequestProdSite = s.Key.ReqProductionSite,
                MatCodeMst = s.Key.MatCodeMst,
                ProjectId = s.Key.ProjectID,
                PriceUnitId = s.Key.PriceUnitId,
                NewProductId = s.Key.NewProductId,
                NewProductDesc = s.FirstOrDefault()?.NewProductDesc,
                Unit = s.Key.Unit,
                Name = "InputPrice-" + s.Key.MonthIndex,
                Value = s.Sum(q => q.Price) ?? 0,
                //Value =  s.Sum(q => q.Qty ?? 0) == 0 ? 0 : s.Sum(q => (q.Qty ?? 0) * (q.Price ?? 0)) / s.Sum(q => q.Qty ?? 0),
                Year = s.Key.MonthNo.Substring(0, 4),
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(s.Key.MonthNo.Substring(5, 2)))
            }).ToList();
            return result;
        }

        public List<MonthModel> GetUnconstraintsMonthFullFill(string planType, string inputM1, List<string> planningGroups)
        {
            List<MonthModel> result = new List<MonthModel>();

            var query = _context.SSP_TRN_UNCONSTRAINT_SALES_PLANs.Where(w => w.PlanType == planType && w.InputM1 == inputM1 && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES);
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            var listDB = query.ToList();

            result = listDB
            .GroupBy(g => new
            {
                g.ScenarioDesc,
                g.CustomerCode,
                g.Channel,
                g.Grade,
                g.Package,
                g.SalesGroupCode,
                g.PlanningGroup,
                g.Region,
                g.SubRegion,
                g.SalesDistrict,
                g.HVASegmentCode,
                g.ProductSub,
                g.ReqProductionSite,
                g.PlanType,
                g.VersionName,
                g.InputM1,
                g.MonthIndex,
                g.MonthNo,
                g.MatCodeMst,
                g.PriceUnitId,
                g.NewProductId,
                g.Unit,
                g.ProjectID
            }).OrderBy(o => o.Key.MonthNo).Select(s => new MonthModel()
            {
                Scenario = s.Key.ScenarioDesc,
                CustomerCode = s.Key.CustomerCode,
                Channel = s.Key.Channel,
                Grade = s.Key.Grade,
                Package = s.Key.Package,
                SalesGroupCode = s.Key.SalesGroupCode,
                PlanningGroup = s.Key.PlanningGroup,
                Region = s.Key.Region,
                SubRegion = s.Key.SubRegion,
                SalesDistrict = s.Key.SalesDistrict,
                HVASegmentCode = s.Key.HVASegmentCode,
                ProductSub = s.Key.ProductSub,
                CycleName = s.Key.VersionName,
                RequestProdSite = s.Key.ReqProductionSite,
                MatCodeMst = s.Key.MatCodeMst,
                Name = "FullFill-" + s.Key.MonthIndex,
                ProjectId = s.Key.ProjectID,
                PriceUnitId = s.Key.PriceUnitId,
                NewProductId = s.Key.NewProductId,
                NewProductDesc = s.FirstOrDefault()?.NewProductDesc,
                Unit = s.Key.Unit,
                //Value = s.Price ?? 0,
                Value = 0,
                Year = s.Key.MonthNo.Substring(0, 4),
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(s.Key.MonthNo.Substring(5, 2)))
            }).ToList();
            return result;
        }

        public List<MonthModel> GetUnConstraintsQtyAndPrice(string planType, string inputM1, List<string> planningGroups)
        {
            List<MonthModel> result = new List<MonthModel>();

            var query = _context.SSP_TRN_UNCONSTRAINT_SALES_PLANs.Where(w => w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && w.PlanType == planType && w.InputM1 == inputM1);
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            var listDB = query.ToList();

            var qtyLs = listDB.OrderBy(o => o.MonthNo)
                        .Select(UNCON =>
                         new MonthModel()
                         {
                             Scenario = UNCON.ScenarioDesc,
                             CustomerCode = UNCON.CustomerCode,
                             Channel = UNCON.Channel,
                             Grade = UNCON.Grade,
                             Package = UNCON.Package,
                             SalesGroupCode = UNCON.SalesGroupCode,
                             PlanningGroup = UNCON.PlanningGroup,
                             Region = UNCON.Region,
                             SubRegion = UNCON.SubRegion,
                             SalesDistrict = UNCON.SalesDistrict,
                             HVASegmentCode = UNCON.HVASegmentCode,
                             ProductSub = UNCON.ProductSub,
                             CycleName = UNCON.VersionName,
                             MatCodeMst = UNCON.MatCodeMst,
                             NewProductId = UNCON.NewProductId,
                             NewProductDesc = UNCON.NewProductDesc,
                             PriceUnitId = UNCON.PriceUnitId,
                             Unit = UNCON.Unit,
                             RequestProdSite = UNCON.ReqProductionSite,
                             Name = "QTY_" + UNCON.MonthIndex,
                             Value = UNCON.Qty ?? 0,
                             Year = UNCON.MonthNo.Substring(0, 4),
                             Month = UNCON.MonthNo,
                             ProjectId = UNCON.ProjectID
                         }).ToList();

            var priceLs = listDB.OrderBy(o => o.MonthNo)
                        .Select(UNCON =>
                        new MonthModel()
                        {
                            Scenario = UNCON.ScenarioDesc,
                            CustomerCode = UNCON.CustomerCode,
                            Channel = UNCON.Channel,
                            Grade = UNCON.Grade,
                            Package = UNCON.Package,
                            SalesGroupCode = UNCON.SalesGroupCode,
                            PlanningGroup = UNCON.PlanningGroup,
                            Region = UNCON.Region,
                            SubRegion = UNCON.SubRegion,
                            SalesDistrict = UNCON.SalesDistrict,
                            HVASegmentCode = UNCON.HVASegmentCode,
                            ProductSub = UNCON.ProductSub,
                            CycleName = UNCON.VersionName,
                            MatCodeMst = UNCON.MatCodeMst,
                            NewProductId = UNCON.NewProductId,
                            NewProductDesc = UNCON.NewProductDesc,
                            PriceUnitId = UNCON.PriceUnitId,
                            Unit = UNCON.Unit,
                            RequestProdSite = UNCON.ReqProductionSite,
                            Name = "PM_" + UNCON.MonthIndex,
                            Value = UNCON.Price ?? 0,
                            Year = UNCON.MonthNo.Substring(0, 4),
                            Month = UNCON.MonthNo,
                            ProjectId = UNCON.ProjectID,
                        }).ToList();

            result = qtyLs.Union(priceLs).ToList();
            return result;
        }

        public List<MonthModel> GetUnConstraintsQtyAndPriceMarkDelete(string planType, string inputM1, List<string> planningGroups)
        {
            List<MonthModel> result = new List<MonthModel>();

            var query = _context.SSP_TRN_UNCONSTRAINT_SALES_PLANs.Where(w => w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && w.PlanType == planType && w.InputM1 == inputM1);
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            var listDB = query.ToList();

            var qtyLs = listDB.OrderBy(o => o.MonthNo)
                        .Select(UNCON =>
                        new MonthModel()
                        {
                            Scenario = UNCON.ScenarioDesc,
                            CustomerCode = UNCON.CustomerCode,
                            Channel = UNCON.Channel,
                            Grade = UNCON.Grade,
                            Package = UNCON.Package,
                            SalesGroupCode = UNCON.SalesGroupCode,
                            PlanningGroup = UNCON.PlanningGroup,
                            Region = UNCON.Region,
                            SubRegion = UNCON.SubRegion,
                            SalesDistrict = UNCON.SalesDistrict,
                            HVASegmentCode = UNCON.HVASegmentCode,
                            ProductSub = UNCON.ProductSub,
                            CycleName = UNCON.VersionName,
                            MatCodeMst = UNCON.MatCodeMst,
                            NewProductId = UNCON.NewProductId,
                            NewProductDesc = UNCON.NewProductDesc,
                            PriceUnitId = UNCON.PriceUnitId,
                            Unit = UNCON.Unit,
                            RequestProdSite = UNCON.ReqProductionSite,
                            Name = "QTY_" + UNCON.MonthIndex,
                            Value = UNCON.IsMarkDeletedByDMO == true ? UNCON.MarkDeleteQty ?? 0 : UNCON.Qty ?? 0,
                            Year = UNCON.MonthNo.Substring(0, 4),
                            Month = UNCON.MonthNo,
                            ProjectId = UNCON.ProjectID
                        }).ToList();

            var priceLs = listDB.OrderBy(o => o.MonthNo)
                        .Select(UNCON =>
                        new MonthModel()
                        {
                            Scenario = UNCON.ScenarioDesc,
                            CustomerCode = UNCON.CustomerCode,
                            Channel = UNCON.Channel,
                            Grade = UNCON.Grade,
                            Package = UNCON.Package,
                            SalesGroupCode = UNCON.SalesGroupCode,
                            PlanningGroup = UNCON.PlanningGroup,
                            Region = UNCON.Region,
                            SubRegion = UNCON.SubRegion,
                            SalesDistrict = UNCON.SalesDistrict,
                            HVASegmentCode = UNCON.HVASegmentCode,
                            ProductSub = UNCON.ProductSub,
                            CycleName = UNCON.VersionName,
                            MatCodeMst = UNCON.MatCodeMst,
                            NewProductId = UNCON.NewProductId,
                            NewProductDesc = UNCON.NewProductDesc,
                            PriceUnitId = UNCON.PriceUnitId,
                            Unit = UNCON.Unit,
                            RequestProdSite = UNCON.ReqProductionSite,
                            Name = "PM_" + UNCON.MonthIndex,
                            Value = UNCON.IsMarkDeletedByDMO == true ? UNCON.MarkDeletePrice ?? 0 : UNCON.Price ?? 0,
                            Year = UNCON.MonthNo.Substring(0, 4),
                            Month = UNCON.MonthNo,
                            ProjectId = UNCON.ProjectID,
                        }).ToList();

            result = qtyLs.Union(priceLs).ToList();
            return result;
        }

        public IQueryable<SSP_TRN_UNCONSTRAINT_SALES_PLAN> GetUnconstraintsOrderBy(string inputM1)
        {
            var result = (from UNCON in _context.SSP_TRN_UNCONSTRAINT_SALES_PLANs
                          where UNCON.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && UNCON.InputM1 == inputM1
                          orderby UNCON.PlanningGroup, UNCON.SalesGroupCode, UNCON.Channel, UNCON.Region, UNCON.CustomerCode, UNCON.Grade, UNCON.Package, UNCON.InputM1
                          select UNCON);
            return result;
        }
    }
}