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
    [Table("MBR_TMP_BeginningInventory")]
    public class MBR_TMP_BEGINING_INVENTORY
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

        [StringLength(5)]
        [Column("Company")]
        [Required]
        public string Company { get; set; }

        [Key]
        [StringLength(2)]
        [Column("MCSC")]
        [Required]
        public string MCSC { get; set; }

        [StringLength(50)]
        [Column("InventoryName")]
        public string? InventoryName { get; set; }

        [StringLength(30)]
        [Column("TankNumber")]
        public string? TankNumber { get; set; }

        [Key]
        [StringLength(50)]
        [Column("ProductShortName")]
        [Required]
        public string ProductShortName { get; set; }

        [Key]
        [StringLength(40)]
        [Column("MaterialCode")]
        [Required]
        public string MaterialCode { get; set; }

        [Key]
        [StringLength(50)]
        [Column("SupplierKey")]
        [Required]
        public string SupplierKey { get; set; }

        [StringLength(50)]
        [Column("SupplierCode")]
        [Required]
        public string SupplierCode { get; set; }

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

        [StringLength(10)]
        [Column("CopiedFromPlanType")]
        public string? CopiedFromPlanType { get; set; }

        [StringLength(10)]
        [Column("CopiedFromCase")]
        public string? CopiedFromCase { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Key]
        public string RunId { get; set; }

        public MBR_TMP_BEGINING_INVENTORY()
        { }

        public MBR_TMP_BEGINING_INVENTORY(MBR_TRN_BEGINING_INVENTORY data)
        {
            ObjectUtil.CopyProperties(data, this);
        }
    }
}