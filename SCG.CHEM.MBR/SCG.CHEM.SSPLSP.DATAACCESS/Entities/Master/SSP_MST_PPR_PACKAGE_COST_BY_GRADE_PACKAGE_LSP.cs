using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_PPRPackageCostByGradePakcageLSP")]
    public class SSP_MST_PPR_PACKAGE_COST_BY_GRADE_PACKAGE_LSP
    {
        [Key]
        [StringLength(8)]
        public string FiscalYear { get; set; }

        [Key]
        [StringLength(12)]
        public string StartYearMonth { get; set; }

        [Key]
        [StringLength(12)]
        public string EndYearMonth { get; set; }

        [Key]
        [StringLength(6)]
        public string MatPrefix { get; set; }

        [Key]
        [StringLength(40)]
        public string Grade { get; set; }

        [Key]
        [StringLength(12)]
        public string Package { get; set; }

        [Column(TypeName = "decimal(32,5)")]
        public decimal? THBPackagingCost { get; set; }

        [Column(TypeName = "decimal(32,5)")]
        public decimal? USDPackagingCost { get; set; }

        [Required]
        [StringLength(40)]
        public string CostSource { get; set; }

        public DateTime ProcessDate { get; set; }
    }
}