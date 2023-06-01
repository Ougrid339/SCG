using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_FCT_Material")]
    public class SSP_FCT_MATERIAL
    {
        [Key]
        [StringLength(40)]
        public string Material { get; set; }

        [StringLength(255)]
        public string? MaterialName { get; set; }

        [StringLength(4)]
        public string? MaterialGroup { get; set; }

        [StringLength(20)]
        public string? MaterialGroupDesc { get; set; }

        [StringLength(6)]
        public string? MaterialGroup00 { get; set; }

        [StringLength(20)]
        public string? CategoryID { get; set; }

        [StringLength(4)]
        public string? ProductLevel { get; set; }

        [StringLength(40)]
        public string? ProductLevelDesc { get; set; }

        [StringLength(18)]
        public string? ProductHierarchy { get; set; }

        [StringLength(20)]
        public string? GradeCustomization { get; set; }

        [StringLength(5)]
        public string? Product { get; set; }

        [StringLength(18)]
        public string? Hierarchy4 { get; set; }

        [StringLength(18)]
        public string? Grade { get; set; }

        [StringLength(20)]
        public string? GradePackage { get; set; }

        [StringLength(18)]
        public string? GradeCRM { get; set; }

        [StringLength(60)]
        public string? GradeColor { get; set; }

        [StringLength(1)]
        public string? PackagingGroup { get; set; }

        [StringLength(40)]
        public string? PackagingGroupDesc { get; set; }

        [StringLength(1)]
        public string? PackagingType { get; set; }

        [StringLength(40)]
        public string? PackagingTypeDesc { get; set; }

        [StringLength(18)]
        public string? PackageQuantity { get; set; }

        [StringLength(15)]
        public string? ProductForm { get; set; }

        [StringLength(60)]
        public string? ProductFormDesc { get; set; }

        [StringLength(3)]
        public string? ProductColorGroup { get; set; }

        [StringLength(60)]
        public string? ProductColorGroupDesc { get; set; }

        [StringLength(20)]
        public string? ProductColor { get; set; }

        [StringLength(60)]
        public string? ProductColorDesc { get; set; }

        [StringLength(15)]
        public string? MarketPriceGroup { get; set; }

        [StringLength(60)]
        public string? MarketPriceGroupDesc { get; set; }

        [StringLength(20)]
        public string? MarketPriceSource { get; set; }

        [StringLength(15)]
        public string? MarketPriceBase { get; set; }

        [StringLength(60)]
        public string? MarketPriceBaseDesc { get; set; }

        [StringLength(2)]
        public string? ProductGroup { get; set; }

        [StringLength(60)]
        public string? ProductGroupDesc { get; set; }

        [StringLength(20)]
        public string? HarmonizeCode { get; set; }

        [StringLength(60)]
        public string? HarmonizeCodeDesc { get; set; }

        [StringLength(10)]
        public string? MainOEM { get; set; }

        [StringLength(200)]
        public string? MainOEMDesc { get; set; }

        [StringLength(10)]
        public string? Manufacturer { get; set; }

        [StringLength(200)]
        public string? ManufacturerDesc { get; set; }

        [StringLength(2)]
        public string? MaterialPricingGroup { get; set; }

        [StringLength(20)]
        public string? MaterialPricingGroupDesc { get; set; }

        [StringLength(2)]
        public string? AcctAssgGrpMat { get; set; }

        [StringLength(20)]
        public string? AcctAssgGrpMatDesc { get; set; }

        [StringLength(5)]
        public string? ProductSub { get; set; }

        [StringLength(40)]
        public string? ProductSubDesc { get; set; }

        [StringLength(15)]
        public string? ProductApplication { get; set; }

        [StringLength(40)]
        public string? ProductApplicationDesc { get; set; }

        [StringLength(40)]
        public string? ProductApplicationDescL { get; set; }

        [StringLength(3)]
        public string? HighValueSegment { get; set; }

        [StringLength(40)]
        public string? HighValueSegmentDesc { get; set; }

        [StringLength(15)]
        public string? Class { get; set; }

        [StringLength(15)]
        public string? ClassGroup { get; set; }

        [StringLength(20)]
        public string? Package { get; set; }

        [StringLength(40)]
        public string? PackageDesc { get; set; }

        [StringLength(100)]
        public string? BasicMaterial { get; set; }

        [StringLength(10)]
        public string? Competitor { get; set; }

        [StringLength(18)]
        public string? CrossPlantCM { get; set; }

        [StringLength(2)]
        public string? Division { get; set; }

        [StringLength(40)]
        public string? EanUpc { get; set; }

        [StringLength(40)]
        public string? OldMatlNumber { get; set; }

        [StringLength(40)]
        public string? ExtMatlGroup { get; set; }

        [StringLength(18)]
        public string? IndStdDesc { get; set; }

        [StringLength(1)]
        public string? IndustrySector { get; set; }

        [StringLength(40)]
        public string? MfrPartNumber { get; set; }

        [StringLength(2)]
        public string? MatlCategory { get; set; }

        [StringLength(60)]
        public string? MatlCategoryDesc { get; set; }

        [StringLength(4)]
        public string? MaterialType { get; set; }

        [StringLength(40)]
        public string? MaterialTypeDesc { get; set; }

        [StringLength(10)]
        public string? ManufacturerECC { get; set; }

        [StringLength(200)]
        public string? ManufacturerECCDesc { get; set; }

        [StringLength(10)]
        public string? ProfitCenter { get; set; }

        [StringLength(2)]
        public string? PriceBandCat { get; set; }

        [StringLength(1)]
        public string? ProcureRule { get; set; }

        [StringLength(4)]
        public string? SeasonCategory { get; set; }

        [StringLength(4)]
        public string? SeasonYear { get; set; }

        [StringLength(32)]
        public string? SizeDimensions { get; set; }

        [StringLength(1)]
        public string? SupplySource { get; set; }

        [Column(TypeName = "decimal(17,3)")]
        public decimal? GrossContents { get; set; }

        [Column(TypeName = "decimal(17,3)")]
        public decimal? NetContents { get; set; }

        [StringLength(3)]
        public string? ContentUnit { get; set; }

        [StringLength(10)]
        public string? ContentUnitDesc { get; set; }

        [Column(TypeName = "decimal(17,3)")]
        public decimal? GrossWeight { get; set; }

        [Column(TypeName = "decimal(17,3)")]
        public decimal? GrossWeightPerBag { get; set; }

        [Column(TypeName = "decimal(17,3)")]
        public decimal? NetWeightPerBag { get; set; }

        [StringLength(3)]
        public string? WeightUnit { get; set; }

        [StringLength(10)]
        public string? WeightUnitDesc { get; set; }

        [Column(TypeName = "decimal(17,3)")]
        public decimal? Height { get; set; }

        [Column(TypeName = "decimal(17,3)")]
        public decimal? Length { get; set; }

        [Column(TypeName = "decimal(17,3)")]
        public decimal? Width { get; set; }

        [StringLength(3)]
        public string? DimensionUnit { get; set; }

        [Column(TypeName = "decimal(17,3)")]
        public decimal? Volume { get; set; }

        [StringLength(3)]
        public string? VolumeUnit { get; set; }

        [StringLength(10)]
        public string? VolumeUnitDesc { get; set; }

        [Column(TypeName = "decimal(17,3)")]
        public decimal? NetWeight { get; set; }

        [StringLength(3)]
        public string? Unit { get; set; }

        [Column(TypeName = "decimal(17,3)")]
        public decimal? VolumePerBag { get; set; }

        [StringLength(3)]
        public string? VolumeBagUnit { get; set; }

        [StringLength(3)]
        public string? BaseUnit { get; set; }

        [StringLength(10)]
        public string? BaseUnitDesc { get; set; }

        public int? Denominator { get; set; }

        [StringLength(3)]
        public string? OrderUnit { get; set; }

        [StringLength(10)]
        public string? OrderUnitDesc { get; set; }

        [StringLength(60)]
        public string? SalesTextENLine1 { get; set; }

        [StringLength(60)]
        public string? SalesTextENLine2 { get; set; }

        [StringLength(60)]
        public string? SalesTextENLine3 { get; set; }

        [StringLength(60)]
        public string? SalesTextENLine4 { get; set; }

        [StringLength(60)]
        public string? SalesTextTHLine1 { get; set; }

        [StringLength(60)]
        public string? SalesTextTHLine2 { get; set; }

        [StringLength(60)]
        public string? SalesTextTHLine3 { get; set; }

        [StringLength(60)]
        public string? SalesTextTHLine4 { get; set; }

        [StringLength(5)]
        public string? MaterialMappingCompany { get; set; }

        [StringLength(6)]
        public string? MappingCompany { get; set; }

        [StringLength(18)]
        public string? BOI { get; set; }

        public DateTime? BOIBeginDate { get; set; }

        public DateTime? BOIHalfDate { get; set; }

        public DateTime? BOIExpireDate { get; set; }

        [StringLength(1)]
        public string? ECC6Flag { get; set; }

        [StringLength(1)]
        public string? FlagDelete { get; set; }

        [StringLength(40)]
        public string? Description { get; set; }

        [StringLength(1)]
        public string? Replatform { get; set; }

        public DateTime? ProcessDate { get; set; }

        [StringLength(1)]
        public string? GradeCustomizeFlag { get; set; }

        [StringLength(18)]
        public string? EuroProductCode { get; set; }

        [StringLength(3)]
        public string? GrossWeightPerBagUnit { get; set; }

        [StringLength(6)]
        public string? NetWeightPerBagUnit { get; set; }

        [StringLength(50)]
        public string? NewMaterial { get; set; }

        [StringLength(20)]
        public string? POType { get; set; }

        [StringLength(20)]
        public string? ProductHierarchyLevel1 { get; set; }

        [StringLength(25)]
        public string? ValidTo { get; set; }

        [StringLength(9)]
        public string SourceSystem { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastChange { get; set; }

        [StringLength(50)]
        public string? ShortNamePriceWeb { get; set; }
    }
}