using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Template
{
    [Keyless]
    public class vSSP_MST_FREIGHT_SUBREGION_TEMPLATE
    {
        public DateTime? FirstDate { get; set; }

        public string PlanType { get; set; }

        public string ProductionSite { get; set; }

        public string RegionCode { get; set; }

        public string SubRegion { get; set; }

        public string StartMonth { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal FreightGap { get; set; }
    }
}