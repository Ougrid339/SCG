using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Transaction
{
    public class vSSP_TRN_CONSTRAINT_SELLING_PRICE_SILO_VN
    {
        public string VersionName { get; set; }
        public string PlanningGroup { get; set; }
        public string MonthNo { get; set; }
        public string SalesGroupCode { get; set; }
        public string Channel { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public string ScenarioId { get; set; }
        public string HVASegmentCode { get; set; }
        public string SalesDistrict { get; set; }
        public string ReqProductionSite { get; set; }
        public string MonthIndex { get; set; }
        public string Grade { get; set; }
        public string InputM1 { get; set; }
        public string CustomerCode { get; set; }
        public string DeletedFlag { get; set; }
        public string PlanType { get; set; }
        public decimal? SellingPriceSiloVN { get; set; }

        public string ProductSub { get; set; }
        public string Package { get; set; }
        public string SceneDesc { get; set; }
    }
}