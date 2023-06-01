using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master
{
    public class ProductionPlanCycleModel
    {
        public string VersionName { get; set; }
        public string PlanningGroup { get; set; }
        public int RevId { get; set; }
        public string Plant { get; set; }
        public string Bom { get; set; }
        public string Line { get; set; }
        public string MatCode { get; set; }
        public string Grade { get; set; }
        public string Package { get; set; }
        public string Unit { get; set; }
        public string NewProductLDesc { get; set; }
        public string Remark { get; set; }
    }
}