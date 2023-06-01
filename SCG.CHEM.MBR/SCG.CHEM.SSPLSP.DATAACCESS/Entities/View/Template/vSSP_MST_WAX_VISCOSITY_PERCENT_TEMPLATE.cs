using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Template
{
    public class vSSP_MST_WAX_VISCOSITY_PERCENT_TEMPLATE
    {
        public DateTime? FirstDate { get; set; }
        public string PlanType { get; set; }
        public string StartMonth { get; set; }
        public string MatPrefix { get; set; }
        public string Grade { get; set; }
        public string Plant { get; set; }
        public string ProductionLine { get; set; }
        public decimal LVPercent { get; set; }
        public decimal HVPercent { get; set; }
    }
}