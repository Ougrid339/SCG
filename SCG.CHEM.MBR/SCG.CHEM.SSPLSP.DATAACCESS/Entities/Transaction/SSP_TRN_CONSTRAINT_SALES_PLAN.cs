using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction
{
    [Table("SSP_TRN_ConstraintSalesPlan")]
    public class SSP_TRN_CONSTRAINT_SALES_PLAN : BaseContext
    {
        [StringLength(50)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(50)]
        public string VersionName { get; set; }

        [Key]
        [StringLength(20)]
        public string PlanningGroup { get; set; }

        [Required]
        [StringLength(10)]
        public string MonthIndex { get; set; }

        [Key]
        [StringLength(10)]
        public string MonthNo { get; set; }

        [Key]
        [StringLength(3)]
        public string SalesGroupCode​ { get; set; }

        [Key]
        [StringLength(2)]
        public string Channel { get; set; }

        [Key]
        [StringLength(10)]
        public string Region { get; set; }

        [Key]
        [StringLength(10)]
        public string SubRegion​ { get; set; }

        [Key]
        public int ScenarioId { get; set; }

        [StringLength(50)]
        public string Grade { get; set; }

        [Key]
        public int NewProductId { get; set; }

        [Key]
        public int RevId { get; set; }

        [Required]
        [StringLength(10)]
        public string Plant { get; set; }

        [Required]
        [StringLength(20)]
        public string Bom { get; set; }

        [Required]
        [StringLength(10)]
        public string PrdLine { get; set; }

        [StringLength(20)]
        public string ValuationTypeCode { get; set; }

        [Key]
        [StringLength(100)]
        public string PrdKey { get; set; }

        [Key]
        public int StockId { get; set; }

        [Key]
        [StringLength(20)]
        public string CustomerCode { get; set; }

        [Required]
        [StringLength(4)]
        public string CompanyCode { get; set; }

        [Required]
        [StringLength(4)]
        public string SalesOrg { get; set; }

        [Required]
        [StringLength(10)]
        public string InputM1 { get; set; }

        [Required]
        public int PriceTypeId { get; set; }

        [Key]
        [StringLength(20)]
        public string MatCodeMst { get; set; }

        [Key]
        [StringLength(20)]
        public string MatcodeTrn { get; set; }

        [Key]
        [StringLength(3)]
        public string HVASegmentCode { get; set; }

        [Key]
        [StringLength(10)]
        public string SalesDistrict​ { get; set; }

        [Key]
        [StringLength(50)]
        public string? ProjectID { get; set; }

        [Key]
        [StringLength(2)]
        public string ReqProductionSite { get; set; }

        [StringLength(2)]
        public string ProductionSite { get; set; }

        [Key]
        [StringLength(10)]
        public string Unit { get; set; }

        [Key]
        public int VersionNo { get; set; }

        [StringLength(1)]
        public string DeletedFlag { get; set; }

        [StringLength(50)]
        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        [Key]
        public int PriceUnitId { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? UnconQty { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? ConQty { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? InputPrice { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? UsdInputPrice { get; set; }

        [StringLength(255)]
        public string? Remark { get; set; }

        [StringLength(4)]
        public string? RefLine { get; set; }

        public bool IsAutoConvertCompany { get; set; }

        public SSP_TRN_CONSTRAINT_SALES_PLAN()
        { }

        public SSP_TRN_CONSTRAINT_SALES_PLAN(string planType, string versionName, string planningGroup, string monthIndex, string monthNo, string salesGroupCode, string channel, string region, string subRegion, int scenarioId, string grade, int newProductId, int revId, string plant, string bom, string prdLine, string valuationTypeCode, string prdKey, int stockId, string customerCode, string companyCode, string salesOrg, string inputM1, int priceTypeId, string matCodeMst, string matcodeTrn, string hvaSegmentCode, string salesDistrict, string projectID, string reqProductionSite, string productionSite, string unit, int priceUnitId, decimal? unconQty, decimal? conQty, decimal? inputPrice, decimal? usdInputPrice, int versionNo)
        {
            PlanType = planType;
            VersionName = versionName;
            PlanningGroup = planningGroup;
            MonthIndex = monthIndex;
            MonthNo = monthNo;
            SalesGroupCode = salesGroupCode;
            Channel = channel;
            Region = region;
            SubRegion = subRegion;
            ScenarioId = scenarioId;
            Grade = grade;
            NewProductId = newProductId;
            RevId = revId;
            Plant = plant;
            Bom = bom;
            PrdLine = prdLine;
            ValuationTypeCode = valuationTypeCode;
            PrdKey = prdKey;
            StockId = stockId;
            CustomerCode = customerCode;
            CompanyCode = companyCode;
            SalesOrg = salesOrg;
            InputM1 = inputM1;
            PriceTypeId = priceTypeId;
            MatCodeMst = matCodeMst;
            MatcodeTrn = matcodeTrn;
            HVASegmentCode = hvaSegmentCode;
            SalesDistrict = salesDistrict;
            ProjectID = projectID;
            ReqProductionSite = reqProductionSite;
            ProductionSite = productionSite;
            Unit = unit;
            PriceUnitId = priceUnitId;
            UnconQty = unconQty;
            ConQty = conQty;
            InputPrice = inputPrice;
            UsdInputPrice = usdInputPrice;
            VersionNo = versionNo;

            IsAutoConvertCompany = false;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
            this.DeletedFlag = APPCONSTANT.DELETE_FLAG.NO;
        }

        public void SetIsAutoConvertCompany(bool isAutoConvertCompany)
        {
            this.IsAutoConvertCompany = isAutoConvertCompany;
        }

        public void MarkDelete()
        {
            if (this.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES)
            {
                this.DeletedFlag = APPCONSTANT.DELETE_FLAG.YES;
                this.DeletedBy = UserUtilities.GetADAccount()?.UserId ?? "";
                this.DeletedDate = DateTime.Now;
            }
        }

        public void SetVersionNo(int versionNo)
        {
            this.VersionNo = versionNo;
            //this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            //this.UpdatedDate = DateTime.Now;
        }

        public void SetUnconQty(decimal? unconQty)
        {
            this.UnconQty = unconQty;
        }

        public void SetConQty(decimal? conQty)
        {
            this.ConQty = conQty;
        }

        public void SetInputPrice(decimal? inputPrice)
        {
            this.InputPrice = inputPrice;
        }

        public void SetUsdInputPrice(decimal? usdInputPrice)
        {
            this.UsdInputPrice = usdInputPrice;
        }
    }
}