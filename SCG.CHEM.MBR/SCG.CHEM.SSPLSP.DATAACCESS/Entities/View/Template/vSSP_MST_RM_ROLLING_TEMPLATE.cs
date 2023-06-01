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
    public class vSSP_MST_RM_ROLLING_TEMPLATE
    {
        public DateTime? FirstDate { get; set; }
        public string VersionName { get; set; }
        public string CompanyCode { get; set; }
        public string MatCode { get; set; }

        [Column("MaterialName")]
        public string? MatName { get; set; }

        public string DataPart { get; set; }
        public string? Unit { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M0 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M1 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M2 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M3 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M4 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M5 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M6 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M7 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M8 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M9 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M10 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M11 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M12 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M13 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M14 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M15 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M16 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M17 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal M18 { get; set; }
    }
}