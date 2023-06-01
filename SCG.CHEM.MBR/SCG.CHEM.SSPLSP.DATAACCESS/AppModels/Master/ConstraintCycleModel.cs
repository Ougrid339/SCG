using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master
{
    public class ConstraintCycleModel
    {
        public string StockMapping { get; set; }
        public string ProductionLine { get; set; }
        public string CycleName { get; set; }
        public string PlanningGroup { get; set; }
        public string SalesGroupCode { get; set; }
        public string SalesGroupName { get; set; }
        public string Channel { get; set; }
        public string MatCodeMst { get; set; }
        public string MatPrefix { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public string HVASegmentCode { get; set; }
        public string HVASegmentName { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string ProductSub { get; set; }
        public string AppName { get; set; }
        public string Grade { get; set; }
        public string Unit { get; set; }
        public string Package { get; set; }
        public int NewProductId { get; set; }
        public string NewProdFlag { get; set; }
        public string Scenario { get; set; }
        public string RequestProdSite { get; set; }
        public string SalesDistrict { get; set; }
        public int PriceUnitId { get; set; }
        public string PriceType { get; set; }
        public string MonthNo { get; set; }
        public int RevId { get; set; }
        public string Remark { get; set; }
        public string RefLine { get; set; }
        public string Plant { get; set; }
        public string Bom { get; set; }
        public string Line { get; set; }
    }
}