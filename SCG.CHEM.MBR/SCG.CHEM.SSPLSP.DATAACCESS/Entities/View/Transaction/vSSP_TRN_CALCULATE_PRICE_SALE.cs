using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Transaction
{
    public class vSSP_TRN_CALCULATE_PRICE_SALE
    {
        public string TransactionSalesPlan { get; set; }
        public string? VersionName { get; set; }
        public string PlanningGroup { get; set; }
        public string MonthNo { get; set; }
        public string? SalesGroupCode { get; set; }
        public int NewProductId { get; set; }
        public string Channel { get; set; }
        public string Region { get; set; }
        public string? SubRegion { get; set; }
        public int ScenarioId { get; set; }
        public string HVASegmentCode { get; set; }
        public string? SalesDistrict { get; set; }
        public string? ReqProductionSite { get; set; }
        public string MonthIndex { get; set; }
        public string? Grade { get; set; }
        public string? Package { get; set; }
        public string? Plant { get; set; }
        public string? Bom { get; set; }
        public string? PrdLine { get; set; }
        public string Unit { get; set; }
        public string InputM1 { get; set; }
        public string CustomerCode { get; set; }

        public string PlanType { get; set; }
        public string? ProductSub { get; set; }
        public string? SceneDesc { get; set; }
        public string ProjectID { get; set; }
        public string MatCodeMst { get; set; }
        public decimal? UnconQty { get; set; }
        public decimal? ConQty { get; set; }
        public decimal? SellingPriceSiloTH { get; set; }
        public decimal? SellingPriceSiloVN { get; set; }
    }
}