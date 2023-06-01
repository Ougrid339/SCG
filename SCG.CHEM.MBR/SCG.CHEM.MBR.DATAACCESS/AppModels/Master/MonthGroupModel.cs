using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Master
{
    public class MonthGroupModel
    {
        [JsonIgnore]
        public string CycleName { get; set; }

        [JsonIgnore]
        public string PlanningGroup { get; set; }

        [JsonIgnore]
        public string SalesGroupCode { get; set; }

        [JsonIgnore]
        public string Channel { get; set; }

        [JsonIgnore]
        public string Region { get; set; }

        [JsonIgnore]
        public string SubRegion { get; set; }

        [JsonIgnore]
        public string HVASegmentCode { get; set; }

        [JsonIgnore]
        public string CustomerCode { get; set; }

        [JsonIgnore]
        public string ProductSub { get; set; }

        [JsonIgnore]
        public string Grade { get; set; }

        [JsonIgnore]
        public string Package { get; set; }

        [JsonIgnore]
        public int NewProductId { get; set; }

        [JsonIgnore]
        public string NewProductDesc { get; set; }

        [JsonIgnore]
        public int PriceUnitId { get; set; }

        [JsonIgnore]
        public string Unit { get; set; }

        [JsonIgnore]
        public string Scenario { get; set; }

        [JsonIgnore]
        public string RequestProdSite { get; set; }

        [JsonIgnore]
        public string SalesDistrict { get; set; }

        [JsonIgnore]
        public string ProjectId { get; set; }

        [JsonIgnore]
        public string Plan { get; set; }

        [JsonIgnore]
        public string MatCodeMst { get; set; }

        [JsonIgnore]
        public int RevId { get; set; }

        [JsonIgnore]
        public string Plant { get; set; }

        [JsonIgnore]
        public string Bom { get; set; }

        [JsonIgnore]
        public string Line { get; set; }

        public string Name { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public decimal Qty { get; set; }
        public decimal InputPrice { get; set; }
        public decimal PriceSiloTH { get; set; }
        public decimal PriceSiloVN { get; set; }
    }
}