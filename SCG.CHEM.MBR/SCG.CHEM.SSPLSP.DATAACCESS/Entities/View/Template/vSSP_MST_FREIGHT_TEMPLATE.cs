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
    public class vSSP_MST_FREIGHT_TEMPLATE
    {
        public string PlanType { get; set; }
        public DateTime? FirstDate { get; set; }
        public string? ProductionSite { get; set; }
        public string? RegionCode { get; set; }
        public string? Unit { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? STDFreight { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? FreightAmtAdjTPE { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? FreightAmtAdjLSP { get; set; }

        public string? StartMonth { get; set; }
    }
}