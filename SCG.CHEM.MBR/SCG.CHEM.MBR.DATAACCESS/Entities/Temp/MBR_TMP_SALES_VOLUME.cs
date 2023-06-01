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
    [Table("MBR_TMP_SalesVolume")]
    public class MBR_TMP_SALES_VOLUME
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

        [Key]
        [StringLength(10)]
        [Column("Case")]
        [Required]
        public string Case { get; set; }

        [StringLength(20)]
        [Column("CyclePoly")]
        [Required]
        public string CyclePoly { get; set; }

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

        [StringLength(10)]
        [Column("MonthIndex")]
        [Required]
        public string MonthIndex { get; set; }

        [Key]
        [StringLength(50)]
        [Column("Product")]
        [Required]
        public string Product { get; set; }

        [StringLength(30)]
        [Column("ProductGroup")]
        [Required]
        public string ProductGroup { get; set; }

        [Key]
        [StringLength(3)]
        [Column("Channel")]
        [Required]
        public string Channel { get; set; }

        [StringLength(50)]
        [Column("ReEXP")]
        public string? ReEXP { get; set; }

        [Key]
        [StringLength(50)]
        [Column("FormulaName")]
        [Required]
        public string FormulaName { get; set; }

        [Key]
        [StringLength(10)]
        [Column("Customers")]
        [Required]
        public string Customers { get; set; }

        [Column("Margin")]
        public int? Margin { get; set; }

        [StringLength(50)]
        [Column("TransportationMode")]
        public string? TransportationMode { get; set; }

        [StringLength(30)]
        [Column("CountryPort")]
        public string? CountryPort { get; set; }

        [StringLength(5)]
        [Column("Countries")]
        public string? Countries { get; set; }

        [Key]
        [StringLength(10)]
        [Column("ContractSpot")]
        [Required]
        public string TermSpot { get; set; }

        [Key]
        [StringLength(5)]
        [Column("PriceSet")]
        [Required]
        public string PriceSet { get; set; }

        [StringLength(60)]
        [Column("PaymentCondition")]
        public string? PaymentCondition { get; set; }

        [StringLength(60)]
        [Column("ContractNo")]
        public string? ContractNo { get; set; }

        [StringLength(60)]
        [Column("VesselOrderNo")]
        public string? VesselOrderNo { get; set; }

        [StringLength(1024)]
        [Column("Formula")]
        public string? Formula { get; set; }

        [StringLength(255)]
        [Column("Remark")]
        public string? Remark { get; set; }

        [Required]
        [Column(TypeName = "decimal(15, 5)")]
        public decimal VolTons { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? HedgingGainLoss { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal Alpha1 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal Alpha2 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal Premium { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal BD { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal IB { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal Adj1 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal Adj2 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal Adj3 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal Adj4 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal Adj5 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal Den { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? FinalPrice { get; set; }

        [Key]
        [StringLength(10)]
        [Column("MonthNo")]
        [Required]
        public string MonthNo { get; set; }

        [StringLength(20)]
        [Column("CopiedFromCycle")]
        public string? CopiedFromCycle { get; set; }

        [StringLength(20)]
        [Column("MergedWithCycle")]
        public string? MergedWithCycle { get; set; }

        [StringLength(20)]
        [Column("CopiedFromPlanType")]
        public string? CopiedFromPlanType { get; set; }

        [StringLength(20)]
        [Column("MergedWithPlanType")]
        public string? MergedWithPlanType { get; set; }

        [StringLength(20)]
        [Column("CopiedFromCase")]
        public string? CopiedFromCase { get; set; }

        [StringLength(20)]
        [Column("MergedWithCase")]
        public string? MergedWithCase { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Key]
        public string? RunId { get; set; }

        public string? ErrorMessage { get; set; }

        public MBR_TMP_SALES_VOLUME()
        {

        }

        public MBR_TMP_SALES_VOLUME(MBR_TRN_SALES_VOLUME data)
        {
            ObjectUtil.CopyProperties(data, this);
        }

        public MBR_TMP_SALES_VOLUME(MBR_TMP_SALES_VOLUME data)
        {
            ObjectUtil.CopyProperties(data, this);
        }
    }
}
