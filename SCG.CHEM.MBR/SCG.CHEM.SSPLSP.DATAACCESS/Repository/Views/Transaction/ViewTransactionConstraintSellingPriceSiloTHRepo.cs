using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Transaction
{
    public class ViewTransactionConstraintSellingPriceSiloTHRepo : RepositoryBase<vSSP_TRN_CONSTRAINT_SELLING_PRICE_SILO_TH>, IViewTransactionConstraintSellingPriceSiloTHRepo
    {
        #region Inject

        public ViewTransactionConstraintSellingPriceSiloTHRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        //public List<MonthModel> GetConstraintsSellingPriceSiloTH(string planType, string inputM1)
        //{
        //    List<MonthModel> result = new List<MonthModel>();
        //    result = _context.vSSP_TRN_CONSTRAINT_SELLING_PRICE_SILO_THs.Where(w => w.PlanType == planType && w.InputM1 == inputM1
        //   && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).OrderBy(o => o.MonthNo).Select(s => new MonthModel()
        //   {
        //       Scenario = s.SceneDesc,
        //       CustomerCode = s.CustomerCode,
        //       Channel = s.Channel,
        //       Grade = s.Grade,
        //       Package = s.Package,
        //       SalesGroupCode = s.SalesGroupCode,
        //       PlanningGroup = s.PlanningGroup,
        //       Region = s.Region,
        //       SubRegion = s.SubRegion,
        //       SalesDistrict = s.SalesDistrict,
        //       HVASegmentCode = s.HVASegmentCode,
        //       ProductSub = s.ProductSub,
        //       CycleName = s.PlanType + "_" + s.InputM1,
        //       RequestProdSite = s.ReqProductionSite,
        //       Name = "PriceTH-" + s.MonthIndex,
        //       Value = s.SellingPriceSiloTH ?? 0,
        //       Year = s.MonthNo.Substring(0, 4),
        //       Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(s.MonthNo.Substring(5, 2)))
        //   }).ToList();
        //    return result;
        //}
    }
}