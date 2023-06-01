using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_RefGrade")]
    public class SSP_MST_REF_GRADE
    {
        [Key]
        [StringLength(20)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(6)]
        public string MatPrefix { get; set; }

        [Key]
        [StringLength(20)]
        public string Product { get; set; }

        [Key]
        [StringLength(20)]
        public string PrdSub { get; set; }

        [StringLength(6)]
        public string RefMatPrefix { get; set; }

        [StringLength(40)]
        public string RefGrade { get; set; }

        [StringLength(20)]
        public string? RefPackage { get; set; }

        [StringLength(40)]
        public string? GradePackComp { get; set; }

        [StringLength(50)]
        public string RefGradeComp { get; set; }

        [StringLength(15)]
        public string? RefMarketGroup { get; set; }

        [StringLength(20)]
        public string? RefMarketSource { get; set; }

        [StringLength(20)]
        public string RefPlant { get; set; }

        [StringLength(20)]
        public string RefLine { get; set; }

        [StringLength(40)]
        public string? MainMonomer { get; set; }

        [Key]
        [StringLength(2)]
        public string ProductionSite { get; set; }
    }
}