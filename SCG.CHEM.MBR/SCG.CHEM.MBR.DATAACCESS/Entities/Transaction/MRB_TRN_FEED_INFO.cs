using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Transaction
{
    [Table("MBR_TRN_FeedInfo")]
    public class MRB_TRN_FEED_INFO
    {
        [Key]
        [Column("ID")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(10)]
        [Column("PlanType")]
        [Required]
        public string PlanType { get; set; }

        [StringLength(20)]
        [Column("Cycle")]
        [Required]
        public string Cycle { get; set; }

        [StringLength(20)]
        [Column("CyclePoly")]
        public string CyclePoly { get; set; }

        [StringLength(10)]
        [Column("Case")]
        [Required]
        public string Case { get; set; }

        [StringLength(5)]
        [Column("RefNo")]
        [Required]
        public string RefNo { get; set; }

        [StringLength(3)]
        [Column("Company")]
        [Required]
        public string Company { get; set; }

        [StringLength(2)]
        [Column("MCSC")]
        [Required]
        public string MCSC { get; set; }

        [StringLength(50)]
        [Column("FeedNameKey")]
        [Required]
        public string FeedNameKey { get; set; }

        [StringLength(40)]
        [Column("MaterialCode")]
        public string MaterialCode { get; set; }

        [StringLength(10)]
        [Column("FeedGeoCategoryKey")]
        [Required]
        public string FeedGeoCategoryKey { get; set; }

        [StringLength(50)]
        [Column("SupplierKey")]
        [Required]
        public string SupplierKey { get; set; }

        [StringLength(50)]
        [Column("SupplierCode")]
        [Required]
        public string SupplierCode { get; set; }

        [StringLength(20)]
        [Column("PricingIndexKey")]
        [Required]
        public string PricingIndexKey { get; set; }

        [StringLength(5)]
        [Column("PricingRefKey")]
        [Required]
        public string PricingRefKey { get; set; }

        [StringLength(30)]
        [Column("OriginKey")]
        public string? OriginKey { get; set; }

        [StringLength(10)]
        [Column("ContractSpot")]
        [Required]
        public string ContractSpot { get; set; }

        [StringLength(20)]
        [Column("TransportationKey")]
        [Required]
        public string TransportationKey { get; set; }

        [StringLength(10)]
        [Column("BuyerRightKey")]
        [Required]
        public string BuyerRightKey { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? PurchasingVolume { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? PurchasingPremium { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? HedgingGainLoss { get; set; }

        [Column(TypeName = "char")]
        public string GITStatus { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? Surveyor { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? Insurance { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? Margin { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? TR { get; set; }

        public decimal? MarketPrice { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? SurveyorUSDPerTon { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? InsuranceUSDPerTon { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? PriceUSDPerTon { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? MOPJM0 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? ExchangeRate { get; set; }

        [StringLength(10)]
        [Column("MonthIndex")]
        [Required]
        public string MonthIndex { get; set; }

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

        [StringLength(10)]
        [Column("MonthNo")]
        [Required]
        public string MonthNo { get; set; }

        [StringLength(30)]
        [Column("ProductGroup")]
        public string? ProductGroup { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? Price { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}