using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_SandOP_ProductionVersion")]
    public class SSP_MST_SANDOP_PRODUCTION_VERSION
    {
        [Key]
        [StringLength(20)]
        public string VersionId { get; set; }

        [StringLength(4)]
        public string? VersionNumber { get; set; }

        [StringLength(8)]
        public string? RoutingGroupNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string RoutingId { get; set; }

        [Required]
        [StringLength(18)]
        public string MaterialCode { get; set; }

        [Required]
        [StringLength(4)]
        public string Plant { get; set; }

        [Required]
        [StringLength(3)]
        public string ProductionLine { get; set; }

        [Required]
        [StringLength(2)]
        public string AltBOM { get; set; }

        [Required]
        [StringLength(1)]
        public string BOMUsage { get; set; }

        public int? Preference { get; set; }

        [StringLength(4)]
        public string? IssuingStorageLocation { get; set; }

        [StringLength(4)]
        public string? ReceivingStorageLocation { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        [StringLength(2)]
        public string? LastInterfaceStatus { get; set; }

        public DateTime? LastInterfaceDate { get; set; }

        [StringLength(2)]
        public string? TollingTypeCode { get; set; }

        public DateTime ProcessDate { get; set; }

        [StringLength(3)]
        public string? CustomizationProductionLine { get; set; }

        [StringLength(4)]
        public string? CustomizationValType { get; set; }

        public bool ActiveFlag { get; set; }

        [Required]
        [StringLength(30)]
        public string CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(30)]
        public string? UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}