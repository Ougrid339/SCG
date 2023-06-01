using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_RefGradeByProductGroup")]
    public class SSP_MST_REF_GRADE_BY_PRODUCT_GROUP
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

        [Key]
        [StringLength(4)]
        public string ProductGroupId { get; set; }

        [Required]
        [StringLength(120)]
        public string ProductGroupName { get; set; }

        [Key]
        [StringLength(20)]
        public string ProductGroupSDesc { get; set; }

        [Required]
        [StringLength(120)]
        public string ProductGroupDesc { get; set; }

        [Required]
        [StringLength(30)]
        public string MarketPriceGroup { get; set; }

        [Required]
        [StringLength(6)]
        public string RefMatPrefix { get; set; }

        [Required]
        [StringLength(40)]
        public string RefGrade { get; set; }

        [StringLength(20)]
        public string RefPackage { get; set; }

        [Required]
        [StringLength(20)]
        public string RefPlant { get; set; }

        [Required]
        [StringLength(20)]
        public string RefLine { get; set; }

        [Required]
        [StringLength(40)]
        public string MainMonomer { get; set; }

        [Required]
        [StringLength(40)]
        public string MainRawMat { get; set; }

        [StringLength(50)]
        public string RefGradeComp { get; set; }

        [Required]
        [StringLength(50)]
        public string GradePackComp { get; set; }

        [Key]
        [StringLength(2)]
        public string ProductionSite { get; set; }
    }
}