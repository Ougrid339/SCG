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
    public class TransactionCalculatePriceSaleRepo : RepositoryBase<SSP_TRN_CALCULATE_PRICE_SALE>, ITransactionCalculatePriceSaleRepo
    {
        #region Inject

        public TransactionCalculatePriceSaleRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<MonthModel> GetUnconstraintsSellingPriceSiloTH(string planType, string inputM1, string name, List<string> planningGroups)
        {
            List<MonthModel> result = new List<MonthModel>();

            var query = _context.SSP_TRN_CALCULATE_PRICE_SALEs.Where(w => w.PlanType == planType && w.InputM1 == inputM1 && w.TransactionSalesPlan == APPCONSTANT.TRANSACTION_SALESPLAN.UNCONSTRAINT);
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            var listDB = query.ToList();

            result = listDB
            .GroupBy(g => new
            {
                g.SceneDesc,
                g.CustomerCode,
                g.Channel,
                g.Grade,
                g.Package,
                g.SalesGroupCode,
                g.PlanningGroup,
                g.NewProductId,
                g.Region,
                g.SubRegion,
                g.SalesDistrict,
                g.HVASegmentCode,
                g.ProductSub,
                g.PlanType,
                g.VersionName,
                g.InputM1,
                g.MonthIndex,
                g.MonthNo,
                g.MatCodeMst,
                g.ProjectID
            }).OrderBy(o => o.Key.MonthNo).Select(s => new MonthModel()
            {
                Scenario = s.Key.SceneDesc,
                CustomerCode = s.Key.CustomerCode,
                Channel = s.Key.Channel,
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
                CycleName = s.Key.VersionName,
                RequestProdSite = s.FirstOrDefault()?.ReqProductionSite,
                Name = name + s.Key.MonthIndex,
                MatCodeMst = s.Key.MatCodeMst,
                ProjectId = s.Key.ProjectID,
                //Value = s.FirstOrDefault().SellingPriceSiloTH ?? 0,
                Value = s.Sum(q => q.UnconQty ?? 0) == 0 ? 0 : s.Sum(q => (q.SellingPriceSiloTH ?? 0) * (q.UnconQty ?? 0)) / s.Sum(q => q.UnconQty ?? 0),
                Year = s.Key.MonthNo.Substring(0, 4),
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(s.Key.MonthNo.Substring(5, 2)))
            }).ToList();

            return result;
        }

        public List<MonthModel> GetUnconstraintsSellingPriceSiloVN(string planType, string inputM1, string name, List<string> planningGroups)
        {
            List<MonthModel> result = new List<MonthModel>();

            var query = _context.SSP_TRN_CALCULATE_PRICE_SALEs.Where(w => w.PlanType == planType && w.InputM1 == inputM1 && w.TransactionSalesPlan == APPCONSTANT.TRANSACTION_SALESPLAN.UNCONSTRAINT);
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            var listDB = query.ToList();

            result = listDB
            .GroupBy(g => new
            {
                g.SceneDesc,
                g.CustomerCode,
                g.Channel,
                g.Grade,
                g.Package,
                g.SalesGroupCode,
                g.PlanningGroup,
                g.NewProductId,
                g.Region,
                g.SubRegion,
                g.SalesDistrict,
                g.HVASegmentCode,
                g.ProductSub,
                //g.ReqProductionSite,
                g.PlanType,
                g.VersionName,
                g.InputM1,
                g.MonthIndex,
                g.MonthNo,
                g.MatCodeMst,
                g.ProjectID
            }).OrderBy(o => o.Key.MonthNo).Select(s => new MonthModel()
            {
                Scenario = s.Key.SceneDesc,
                CustomerCode = s.Key.CustomerCode,
                Channel = s.Key.Channel,
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
                CycleName = s.Key.VersionName,
                RequestProdSite = s.FirstOrDefault()?.ReqProductionSite,
                Name = name + s.Key.MonthIndex,
                MatCodeMst = s.Key.MatCodeMst,
                ProjectId = s.Key.ProjectID,
                //Value = s.FirstOrDefault().SellingPriceSiloTH ?? 0,
                Value = s.Sum(q => q.UnconQty ?? 0) == 0 ? 0 : s.Sum(q => (q.SellingPriceSiloVN ?? 0) * (q.UnconQty ?? 0)) / s.Sum(q => q.UnconQty ?? 0),
                Year = s.Key.MonthNo.Substring(0, 4),
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(s.Key.MonthNo.Substring(5, 2)))
            }).ToList();

            return result;
        }

        public List<MonthModel> GetConstraintsSellingPriceSiloTH(string planType, string inputM1, List<string> planningGroups)
        {
            List<MonthModel> result = new List<MonthModel>();

            var query = _context.SSP_TRN_CALCULATE_PRICE_SALEs.Where(w => w.PlanType == planType && w.InputM1 == inputM1 && w.TransactionSalesPlan == APPCONSTANT.TRANSACTION_SALESPLAN.CONSTRAINT);
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            var listDB = query.ToList();

            result = listDB.GroupBy(g => new
            {
                g.VersionName,
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
                g.SceneDesc,
                g.SalesDistrict,
                g.Plant,
                g.Bom,
                g.PrdLine,
                g.Unit,
                g.ReqProductionSite,
                g.MonthNo,
                g.MonthIndex
            }).OrderBy(o => o.Key.MonthNo).Select(s => new MonthModel
            {
                Scenario = s.Key.SceneDesc,
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
                CycleName = s.Key.VersionName,
                RequestProdSite = s.Key.ReqProductionSite,
                Plant = s.Key.Plant,
                Bom = s.Key.Bom,
                Line = s.Key.PrdLine,
                Unit = s.Key.Unit,
                Name = "PriceTH-" + s.Key.MonthIndex,
                Value = s.Sum(s => s.SellingPriceSiloTH ?? 0),
                Year = s.Key.MonthNo.Substring(0, 4),
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(s.Key.MonthNo.Substring(5, 2)))
            }).ToList();

            return result;
        }

        public List<MonthModel> GetConstraintsSellingPriceSiloVN(string planType, string inputM1, List<string> planningGroups)
        {
            List<MonthModel> result = new List<MonthModel>();

            var query = _context.SSP_TRN_CALCULATE_PRICE_SALEs.Where(w => w.PlanType == planType && w.InputM1 == inputM1 && w.TransactionSalesPlan == APPCONSTANT.TRANSACTION_SALESPLAN.CONSTRAINT);
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            var listDB = query.ToList();

            result = listDB.GroupBy(g => new
            {
                g.VersionName,
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
                g.SceneDesc,
                g.SalesDistrict,
                g.Plant,
                g.Bom,
                g.PrdLine,
                g.Unit,
                g.ReqProductionSite,
                g.MonthNo,
                g.MonthIndex
            }).OrderBy(o => o.Key.MonthNo).Select(s => new MonthModel
            {
                Scenario = s.Key.SceneDesc,
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
                CycleName = s.Key.VersionName,
                RequestProdSite = s.Key.ReqProductionSite,
                Plant = s.Key.Plant,
                Bom = s.Key.Bom,
                Line = s.Key.PrdLine,
                Unit = s.Key.Unit,
                Name = "PriceVN-" + s.Key.MonthIndex,
                Value = s.Sum(s => s.SellingPriceSiloVN ?? 0),
                Year = s.Key.MonthNo.Substring(0, 4),
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(s.Key.MonthNo.Substring(5, 2)))
            }).ToList();
            return result;
        }

        public List<MonthGroupModel> GetConstraintsSellingPriceSilo(string planType, string inputM1, List<string> planningGroups)
        {
            List<MonthGroupModel> result = new List<MonthGroupModel>();

            var query = _context.SSP_TRN_CALCULATE_PRICE_SALEs.Where(w => w.PlanType == planType && w.InputM1 == inputM1 && w.TransactionSalesPlan == APPCONSTANT.TRANSACTION_SALESPLAN.CONSTRAINT);
            if (planningGroups.Count() > 0)
                query = query.Where(w => planningGroups.Contains(w.PlanningGroup));

            var listDB = query.ToList();

            result = listDB.GroupBy(g => new
            {
                g.VersionName,
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
                g.SceneDesc,
                g.SalesDistrict,
                g.Plant,
                g.Bom,
                g.PrdLine,
                g.Unit,
                g.ReqProductionSite,
                g.MonthNo,
                g.MonthIndex
            }).OrderBy(o => o.Key.MonthNo).Select(s => new MonthGroupModel
            {
                Scenario = s.Key.SceneDesc,
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
                CycleName = s.Key.VersionName,
                RequestProdSite = s.Key.ReqProductionSite,
                Plant = s.Key.Plant,
                Bom = s.Key.Bom,
                Line = s.Key.PrdLine,
                Unit = s.Key.Unit,
                Name = s.Key.MonthIndex,
                PriceSiloTH = s.Average(s => s.SellingPriceSiloTH ?? 0),
                PriceSiloVN = s.Average(s => s.SellingPriceSiloVN ?? 0),
                Year = s.Key.MonthNo.Substring(0, 4),
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(s.Key.MonthNo.Substring(5, 2)))
            }).ToList();

            return result;
        }
    }
}