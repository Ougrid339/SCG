using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Transaction
{
    public class ViewTransactionUnconstraintSellingPriceSiloTHRepo : RepositoryBase<vSSP_TRN_UNCONSTRAINT_SELLING_PRICE_SILO_TH>, IViewTransactionUnconstraintSellingPriceSiloTHRepo
    {
        #region Inject

        public ViewTransactionUnconstraintSellingPriceSiloTHRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        //public List<MonthModel> GetUnconstraintsSellingPriceSiloTH(string planType, string inputM1,string name)
        //{
        //    List<MonthModel> result = new List<MonthModel>();

        //    result = _context.vSSP_TRN_UNCONSTRAINT_SELLING_PRICE_SILO_THs.Where(w => w.PlanType == planType && w.InputM1 == inputM1
        //   && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).GroupBy(g => new
        //   {
        //       g.ScenarioDesc,
        //       g.CustomerCode,
        //       g.Channel,
        //       g.Grade,
        //       g.Package,
        //       g.SalesGroupCode,
        //       g.PlanningGroup,
        //       g.Region,
        //       g.SubRegion,
        //       g.SalesDistrict,
        //       g.HVASegmentCode,
        //       g.ProductSub,
        //       g.ReqProductSite,
        //       g.PlanType,
        //       g.InputM1,
        //       g.MonthIndex,
        //       g.MonthNo,
        //       g.MatCodeMst,
        //       g.ProjectID
        //   }).OrderBy(o => o.Key.MonthNo).Select(s => new MonthModel()
        //   {
        //       Scenario = s.Key.ScenarioDesc,
        //       CustomerCode = s.Key.CustomerCode,
        //       Channel = s.Key.Channel,
        //       Grade = s.Key.Grade,
        //       Package = s.Key.Package,
        //       SalesGroupCode = s.Key.SalesGroupCode,
        //       PlanningGroup = s.Key.PlanningGroup,
        //       Region = s.Key.Region,
        //       SubRegion = s.Key.SubRegion,
        //       SalesDistrict = s.Key.SalesDistrict,
        //       HVASegmentCode = s.Key.HVASegmentCode,
        //       ProductSub = s.Key.ProductSub,
        //       CycleName = s.Key.PlanType + "_" + s.Key.InputM1,
        //       RequestProdSite = s.Key.ReqProductSite,
        //       Name = name + s.Key.MonthIndex,
        //       MatCodeMst = s.Key.MatCodeMst,
        //       ProjectId = s.Key.ProjectID,
        //       //Value = s.FirstOrDefault().SellingPriceSiloTH ?? 0,
        //       Value =  s.Sum(q => q.Qty ?? 0) == 0 ? 0 :  s.Sum(q => (q.SellingPriceSiloTH ?? 0) * (q.Qty ?? 0)) /  s.Sum(q => q.Qty ?? 0),
        //       Year = s.Key.MonthNo.Substring(0, 4),
        //       Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(s.Key.MonthNo.Substring(5, 2)))
        //   }).ToList();

        //    return result;
        //}
    }
}