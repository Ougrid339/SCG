using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Temp
{
    [Table("MBR_TMP_ProductionVolume")]
    public class MBR_TMP_PRODUCTION_VOLUME
    {
        [Key]
        [StringLength(10)]
        [Column("PlanType")]
        [Required]
        public string PlanType { get; set; }

        [Key]
        [StringLength(20)]
        [Column("Cycle")]
        [Required]
        public string Cycle { get; set; }

        [StringLength(20)]
        [Column("CyclePoly")]
        public string CyclePoly { get; set; }

        [Key]
        [StringLength(10)]
        [Column("Case")]
        [Required]
        public string Case { get; set; }

        [Key]
        [StringLength(5)]
        [Column("Company")]
        [Required]
        public string Company { get; set; }

        [Key]
        [StringLength(2)]
        [Column("MCSC")]
        [Required]
        public string MCSC { get; set; }

        [Key]
        [StringLength(50)]
        [Column("ProductName")]
        [Required]
        public string ProductName { get; set; }

        [StringLength(50)]
        [Column("ProductShortName")]
        [Required]
        public string ProductShortName { get; set; }

        [StringLength(40)]
        [Column("MaterialCode")]
        public string MaterialCode { get; set; }

        [StringLength(15)]
        [Column("ElementCode")]
        public string? ElementCodeEBA { get; set; }

        [StringLength(10)]
        [Column("MonthIndex")]
        [Required]
        public string MonthIndex { get; set; }

        [Key]
        [StringLength(10)]
        [Column("MonthNo")]
        public string? MonthNo { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? Price { get; set; }

        [StringLength(20)]
        [Column("CopiedFromCycle")]
        public string? CopiedFromCycle { get; set; }

        [StringLength(20)]
        [Column("MergedWithCycle")]
        public string? MergedWithCycle { get; set; }

        [StringLength(10)]
        [Column("CopiedFromPlanType")]
        public string? CopiedFromPlanType { get; set; }

        [StringLength(10)]
        [Column("MergedWithPlanType")]
        public string? MergedWithPlanType { get; set; }

        [StringLength(10)]
        [Column("CopiedFromCase")]
        public string? CopiedFromCase { get; set; }

        [StringLength(10)]
        [Column("MergedWithCase")]
        public string? MergedWithCase { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Key]
        public string RunId { get; set; }

        public MBR_TMP_PRODUCTION_VOLUME()
        { }

        public MBR_TMP_PRODUCTION_VOLUME(MBR_TRN_PRODUCTION_VOLUME data)
        {
            ObjectUtil.CopyProperties(data, this);
        }
    }
}