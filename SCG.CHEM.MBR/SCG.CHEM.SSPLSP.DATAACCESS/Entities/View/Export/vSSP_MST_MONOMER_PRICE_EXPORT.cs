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
    public class vSSP_MST_MONOMER_PRICE_EXPORT
    {
        public DateTime? FirstDate { get; set; }

        public string PlanType { get; set; }

        public string VersionName { get; set; }

        public string MonthNo { get; set; }

        public string MonthIndex { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? C2 { get; set; }

        public int? C2UnitId { get; set; }
        public string C2Unit { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? C3 { get; set; }

        public int? C3UnitId { get; set; }
        public string C3Unit { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? C4 { get; set; }

        public int? C4UnitId { get; set; }
        public string C4Unit { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? C6 { get; set; }

        public int? C6UnitId { get; set; }
        public string C6Unit { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? C8 { get; set; }

        public int? C8UnitId { get; set; }
        public string C8Unit { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? WAX_HV { get; set; }

        public int? WaxHVUnitId { get; set; }
        public string WaxHVUnit { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? WAX_LV { get; set; }

        public int? WaxLVUnitId { get; set; }
        public string WaxLVUnit { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? VCM { get; set; }

        public int? VCMUnitId { get; set; }
        public string VCMUnit { get; set; }
    }
}