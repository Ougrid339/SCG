using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_FCT_BusinessPartner")]
    public class SSP_FCT_BUSINESS_PARTNER
    {
        [Key]
        [StringLength(10)]
        public string BusinessPartner { get; set; }

        [StringLength(10)]
        public string? BusinessPartnerDisplay { get; set; }

        [StringLength(4)]
        public string? IndustrySector { get; set; }

        [StringLength(20)]
        public string? IndustryDesc { get; set; }

        [StringLength(20)]
        public string? ShortName { get; set; }

        [StringLength(10)]
        public string? IDNumber { get; set; }

        [StringLength(4)]
        public string? Role { get; set; }

        [StringLength(4)]
        public string? PartnerType { get; set; }

        [StringLength(6)]
        public string? Gender { get; set; }

        [StringLength(1)]
        public string? MaritalStatus { get; set; }

        [StringLength(20)]
        public string? MaritalStatusDesc { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(40)]
        public string? NickName { get; set; }

        [StringLength(2)]
        public string? SCGRegion { get; set; }

        [StringLength(20)]
        public string? SCGRegionDesc { get; set; }

        [StringLength(2)]
        public string? SalesRegion { get; set; }

        [StringLength(20)]
        public string? SalesRegionDesc { get; set; }

        [StringLength(6)]
        public string? SalesDistrict { get; set; }

        [StringLength(4)]
        public string? MainBPtypeCode { get; set; }

        [StringLength(30)]
        public string? MainBPtype { get; set; }

        [StringLength(1)]
        public string ActiveStatus { get; set; }

        [StringLength(10)]
        public string? MainBusinessPartner { get; set; }

        [StringLength(500)]
        public string? MainBusinessPartnerDesc { get; set; }

        [StringLength(3)]
        public string? MainBusinessPartnerCountry { get; set; }

        [StringLength(30)]
        public string? MainBusinessPartnerBPType { get; set; }

        [StringLength(4)]
        public string? MainBusinessPartnerIndustry { get; set; }

        [StringLength(10)]
        public string? MainBusinessPartnerFG { get; set; }

        [StringLength(10)]
        public string? ExportSaleCoordinate { get; set; }

        [StringLength(10)]
        public string? ExportSaleAdmin { get; set; }

        [StringLength(10)]
        public string? SalesRepresentative { get; set; }

        [StringLength(241)]
        public string? EMailAddress { get; set; }

        [StringLength(40)]
        public string? FirstName { get; set; }

        [StringLength(4)]
        public string? ContactPersonFn { get; set; }

        [StringLength(4)]
        public string? ContactDepartment { get; set; }

        [StringLength(15)]
        public string? Title { get; set; }

        [StringLength(10)]
        public string? Customer { get; set; }

        [StringLength(4)]
        public string? PaymentTerm { get; set; }

        [StringLength(60)]
        public string? PaymentTermDesc { get; set; }

        [StringLength(2)]
        public string? PriceGroupItem { get; set; }

        [StringLength(2)]
        public string? COARequested { get; set; }

        [StringLength(40)]
        public string? COARequestedDesc { get; set; }

        [StringLength(2)]
        public string? COARequestedCopy { get; set; }

        [StringLength(40)]
        public string? COARequestedCopyDesc { get; set; }

        [StringLength(2)]
        public string? ReqColorPlate1StLot { get; set; }

        [StringLength(40)]
        public string? ReqColorPlate1StLotDesc { get; set; }

        [StringLength(2)]
        public string? NoOfColorPlate1StLot { get; set; }

        [StringLength(40)]
        public string? NoOfColorPlate1StLotDesc { get; set; }

        [StringLength(18)]
        public string? TaxNumber3 { get; set; }

        [StringLength(12)]
        public string? StreetCode { get; set; }

        [StringLength(60)]
        public string? Street { get; set; }

        [StringLength(40)]
        public string? Street2 { get; set; }

        [StringLength(40)]
        public string? Street3 { get; set; }

        [StringLength(40)]
        public string? Street4 { get; set; }

        [StringLength(40)]
        public string? Street5 { get; set; }

        [StringLength(40)]
        public string? District { get; set; }

        [StringLength(40)]
        public string? City { get; set; }

        [StringLength(3)]
        public string? Province { get; set; }

        [StringLength(20)]
        public string? ProvinceDesc { get; set; }

        [StringLength(10)]
        public string? PostalCode { get; set; }

        [StringLength(10)]
        public string? POBox { get; set; }

        [StringLength(40)]
        public string? POBoxLocation { get; set; }

        [StringLength(10)]
        public string? POBoxPostCode { get; set; }

        [StringLength(10)]
        public string? TransportZone { get; set; }

        [StringLength(20)]
        public string? TransportZoneDesc { get; set; }

        [StringLength(3)]
        public string? Country { get; set; }

        [StringLength(70)]
        public string? CountryDesc { get; set; }

        [StringLength(30)]
        public string? TelephoneNo { get; set; }

        [StringLength(16)]
        public string? Telephone2 { get; set; }

        [StringLength(30)]
        public string? FaxNumber { get; set; }

        [StringLength(30)]
        public string? Telex { get; set; }

        [StringLength(30)]
        public string? TeletexNo { get; set; }

        [StringLength(15)]
        public string? TeleBox { get; set; }

        [StringLength(14)]
        public string? DataLine { get; set; }

        [StringLength(2)]
        public string? Language { get; set; }

        [StringLength(3)]
        public string? InvoiceSplit { get; set; }

        [StringLength(20)]
        public string? InvoiceSplitDesc { get; set; }

        [StringLength(3)]
        public string? UnloadingMethod { get; set; }

        [StringLength(20)]
        public string? UnloadingMethodDesc { get; set; }

        [StringLength(3)]
        public string? TruckType { get; set; }

        [StringLength(20)]
        public string? TruckTypeDesc { get; set; }

        [StringLength(3)]
        public string? ContractType { get; set; }

        [StringLength(20)]
        public string? ContractTypeDesc { get; set; }

        [StringLength(3)]
        public string? ApplicationCustomer { get; set; }

        [StringLength(20)]
        public string? ApplicationCustomerDesc { get; set; }

        [StringLength(4)]
        public string? AccountGroup { get; set; }

        [StringLength(40)]
        public string? AccountGroupDesc { get; set; }

        [StringLength(8)]
        public string? Employee { get; set; }

        [StringLength(32)]
        public string? BPGuid { get; set; }

        [StringLength(10)]
        public string? Vendor { get; set; }

        [StringLength(2)]
        public string? OrgLegalForm { get; set; }

        [StringLength(3)]
        public string? Incoterm1 { get; set; }

        [StringLength(28)]
        public string? Incoterm2 { get; set; }

        [StringLength(2)]
        public string? CustomerGroup1 { get; set; }

        [StringLength(2)]
        public string? DeliveryPriority { get; set; }

        [StringLength(2)]
        public string? PriceList { get; set; }

        [StringLength(10)]
        public string? PalletContract { get; set; }

        [StringLength(30)]
        public string? PalletContractDesc { get; set; }

        [StringLength(10)]
        public string? ProdQualitySens { get; set; }

        [StringLength(30)]
        public string? ProdQualitySensDesc { get; set; }

        [StringLength(10)]
        public string? MainChannel { get; set; }

        [StringLength(30)]
        public string? MainChannelDesc { get; set; }

        [StringLength(10)]
        public string? MainProduct { get; set; }

        [StringLength(30)]
        public string? MainProductDesc { get; set; }

        [StringLength(10)]
        public string? MainApplication { get; set; }

        [StringLength(30)]
        public string? MainApplicationDesc { get; set; }

        [StringLength(10)]
        public string? MainFinishedgoods { get; set; }

        [StringLength(30)]
        public string? MainFinishedgoodsDesc { get; set; }

        [StringLength(10)]
        public string? PricingPattern { get; set; }

        [StringLength(30)]
        public string? PricingPatternDesc { get; set; }

        [StringLength(10)]
        public string? EPZCustomer { get; set; }

        [StringLength(30)]
        public string? EPZCustomerDesc { get; set; }

        [StringLength(10)]
        public string? DeliveryPattern { get; set; }

        [StringLength(30)]
        public string? DeliveryPatternDesc { get; set; }

        [StringLength(10)]
        public string? PricingPeriod { get; set; }

        [StringLength(30)]
        public string? PricingPeriodDesc { get; set; }

        [StringLength(10)]
        public string? GSCPaymentMethod { get; set; }

        [StringLength(30)]
        public string? GSCPaymentMethodDesc { get; set; }

        [StringLength(10)]
        public string? GSCSection { get; set; }

        [StringLength(30)]
        public string? GSCSectionDesc { get; set; }

        [StringLength(10)]
        public string? GSCClassCurrent { get; set; }

        [StringLength(30)]
        public string? GSCClassCurrentDesc { get; set; }

        [StringLength(10)]
        public string? GSCClassHistorical { get; set; }

        [StringLength(30)]
        public string? GSCClassHistoricalDesc { get; set; }

        [StringLength(10)]
        public string? PerfBSSCurrent { get; set; }

        [StringLength(30)]
        public string? PerfBSSCurrentDesc { get; set; }

        [StringLength(10)]
        public string? PerfBSSHistorical { get; set; }

        [StringLength(30)]
        public string? PerfBSSHistoricalDesc { get; set; }

        [StringLength(10)]
        public string? PerfClassCurrent { get; set; }

        [StringLength(30)]
        public string? PerfClassCurrentDesc { get; set; }

        [StringLength(10)]
        public string? PerfClassHistorical { get; set; }

        [StringLength(30)]
        public string? PerfClassHistoricalDesc { get; set; }

        [StringLength(10)]
        public string? PlastBSSCurrent { get; set; }

        [StringLength(30)]
        public string? PlastBSSCurrentDesc { get; set; }

        [StringLength(10)]
        public string? PlastBSSHistorical { get; set; }

        [StringLength(30)]
        public string? PlastBSSHistoricalDesc { get; set; }

        [StringLength(10)]
        public string? PlastClassCurrent { get; set; }

        [StringLength(30)]
        public string? PlastClassCurrentDesc { get; set; }

        [StringLength(10)]
        public string? PlastClassHistorical { get; set; }

        [StringLength(30)]
        public string? PlastClassHistoricalDesc { get; set; }

        [StringLength(10)]
        public string? ICOBSSCurrent { get; set; }

        [StringLength(30)]
        public string? ICOBSSCurrentDesc { get; set; }

        [StringLength(10)]
        public string? ICOBSSHistorical { get; set; }

        [StringLength(30)]
        public string? ICOBSSHistoricalDesc { get; set; }

        [StringLength(10)]
        public string? ICOClassCurrent { get; set; }

        [StringLength(30)]
        public string? ICOClassCurrentDesc { get; set; }

        [StringLength(10)]
        public string? ICOClassHistorical { get; set; }

        [StringLength(30)]
        public string? ICOClassHistoricalDesc { get; set; }

        [StringLength(40)]
        public string? OrgName1 { get; set; }

        [StringLength(40)]
        public string? OrgName2 { get; set; }

        [StringLength(40)]
        public string? OrgName3 { get; set; }

        [StringLength(40)]
        public string? OrgName4 { get; set; }

        [StringLength(40)]
        public string? OrgName1C { get; set; }

        [StringLength(40)]
        public string? OrgName2C { get; set; }

        [StringLength(40)]
        public string? OrgName3C { get; set; }

        [StringLength(40)]
        public string? OrgName4C { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ProcessDate { get; set; }

        [StringLength(60)]
        public string? AllProductQuality { get; set; }

        [StringLength(60)]
        public string? AllDeliveryCondition { get; set; }

        [StringLength(60)]
        public string? DomesticGuarantee { get; set; }

        [StringLength(60)]
        public string? ZonetoDomesticZone { get; set; }

        [StringLength(60)]
        public string? AllDeliveryText { get; set; }

        [StringLength(60)]
        public string? TruckCondition { get; set; }

        [StringLength(60)]
        public string? AllRemarkforUSD { get; set; }

        [StringLength(60)]
        public string? DeliveryNoteWithInvioce { get; set; }

        [StringLength(60)]
        public string? ShippingInstruction { get; set; }

        [StringLength(8)]
        public string TypeOfBP { get; set; }

        [StringLength(20)]
        public string? GeographicRegion { get; set; }

        [StringLength(20)]
        public string? GeoRegion { get; set; }

        [StringLength(3)]
        public string? SalesRegionGroup { get; set; }

        [StringLength(9)]
        public string SourceSystem { get; set; }

        [StringLength(50)]
        public string? ShortNamePriceWeb { get; set; }
    }
}