using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export
{
    public class vSSP_MST_AFP_STANDARD_EARN_EXPORT
    {
        public DateTime? FirstDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PlanType { get; set; }
        public string StartMonth { get; set; }
        public string EndMonth { get; set; }
        public string MatPrefix { get; set; }
        public string Grade { get; set; }
        public string StandardEarn { get; set; }
        public string ProductionLine { get; set; }
    }
}