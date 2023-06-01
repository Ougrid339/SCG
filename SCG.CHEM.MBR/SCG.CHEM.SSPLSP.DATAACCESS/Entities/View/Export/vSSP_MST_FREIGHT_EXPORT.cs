using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export
{
    [Keyless]
    public class vSSP_MST_FREIGHT_EXPORT
    {
        public DateTime? FirstDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PlanType { get; set; }
        public string? ProductionSite { get; set; }
        public string? StartMonth { get; set; }
        public string EndMonth { get; set; }
        public string? RegionCode { get; set; }
        public int? FreightUnitID { get; set; }
        public string? FreightUnit { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? FreightSTDSEA { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? FreightSTDASIA { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal STDFreight { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal FreightAmtAdjTPE { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal FreightAmtAdjLSP { get; set; }
    }
}