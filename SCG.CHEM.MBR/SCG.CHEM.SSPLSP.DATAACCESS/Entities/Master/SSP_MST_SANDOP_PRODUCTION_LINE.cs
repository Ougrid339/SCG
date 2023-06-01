using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_SandOP_ProductionLine")]
    public class SSP_MST_SANDOP_PRODUCTION_LINE
    {
        [Key]
        [StringLength(20)]
        public string ProductionLineCode { get; set; }

        [StringLength(100)]
        public string? ProductionLineDescription { get; set; }

        [StringLength(40)]
        public string? ProductionTypeCode { get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal? PercentPrime { get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal? MaximumLotSize { get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal? ProductionRate { get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal? Yield { get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal? SpeedRatio { get; set; }

        [Key]
        [StringLength(8)]
        public string Plant { get; set; }

        [Required]
        [StringLength(16)]
        public string WorkCenter { get; set; }

        public bool? PSDefault { get; set; }

        [StringLength(20)]
        public string? FAM { get; set; }

        [StringLength(10)]
        public string? FAMCode { get; set; }

        [Required]
        [StringLength(8)]
        public string CompanyCode { get; set; }

        [StringLength(10)]
        public string? IssuingStorageLocation { get; set; }

        [StringLength(10)]
        public string? ReceivingStorageLocation { get; set; }

        public int? FACId { get; set; }

        [StringLength(4)]
        public string? DefaultAltBOM { get; set; }

        public bool? PSActive { get; set; }

        public bool? Owner { get; set; }

        [Required]
        public DateTime? ProcessDate { get; set; }

        public bool? Active { get; set; }
    }
}