using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Transaction
{
    [Keyless]
    public class vSSP_TRN_UNCONSTRAINT_SELLING_PRICE_SILO_VN
    {
        public string PlanType { get; set; }
        public int ScenarioId { get; set; }
        public string CustomerCode { get; set; }
        public string Channel { get; set; }
        public string MatCodeMst { get; set; }
        public string MatCodeTrn { get; set; }
        public int NewProductId { get; set; }
        public string SalesGroupCode { get; set; }
        public string PlanningGroup { get; set; }
        public string Region { get; set; }
        public string HVASegmentCode { get; set; }
        public int PriceTypeId { get; set; }
        public int PriceUnitId { get; set; }
        public string InputM1 { get; set; }
        public string MonthNo { get; set; }
        public int VersionNo { get; set; }
        public string ScenarioDesc { get; set; }
        public string CustomerName { get; set; }
        public string? MatPrefix { get; set; }
        public string? Grade { get; set; }
        public string? Package { get; set; }
        public string? MatGroup { get; set; }
        public string? Product { get; set; }
        public string? ProductSub { get; set; }
        public int UnitId { get; set; }
        public string Unit { get; set; }
        public string? NewProductDesc { get; set; }
        public string? SalesGroupName { get; set; }
        public string? RefGrade { get; set; }
        public string? ProjectID { get; set; }
        public string? ReqProductSite { get; set; }
        public string? SubRegion { get; set; }
        public string? SalesDistrict { get; set; }
        public string MonthIndex { get; set; }
        public string UsedPrevFlag { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? Qty { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? Price { get; set; }

        public string? RefGradeMatPrefix { get; set; }
        public string? RefGradeGrade { get; set; }
        public string? RefGradePackage { get; set; }
        public string? RefGradePlant { get; set; }
        public string? RefGradeLine { get; set; }
        public string? RefGradeMarketGroup { get; set; }
        public string? RefGradeMarketSource { get; set; }
        public string? RefGradeMainMonomer { get; set; }
        public string? RefGradeMainRawMat { get; set; }
        public string? RefGradeGradeComp { get; set; }
        public string? RefGradeGradePackComp { get; set; }
        public bool? AutoGenFlag { get; set; }
        public DateTime? ProcessDate { get; set; }
        public string DeletedFlag { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? PriceTypeDesc { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? ExchangeRate { get; set; }

        public string? MarketGroup { get; set; }

        [Column(TypeName = "decimal(38, 6)")]
        public decimal? RefMarketPriceVN { get; set; }

        [Column(TypeName = "decimal(31, 21)")]
        public decimal? STDFreightCostTH { get; set; }

        [Column(TypeName = "decimal(31, 21)")]
        public decimal? STDFreightCostVN { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? STDDeliveryCostTH { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? DeliveryCostTH { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? AdditionalDeliveryCostByCustomerTH { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? AdditionalDeliveryCostByGradeTH { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? AdditionalDeliveryCostByPackTH { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? STDDeliveryCostVN { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? DeliveryCostVN { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? AdditionalDeliveryCostByCustomerVN { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? AdditionalDeliveryCostByGradeVN { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? AdditionalDeliveryCostByPackVN { get; set; }

        [Column(TypeName = "decimal(32, 5)")]
        public decimal PackageCostTH { get; set; }

        [Column(TypeName = "decimal(32, 5)")]
        public decimal PackageCostVN { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? AdditionalPackageCostByCustomerTH { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? AdditionalPackageCostByGradeTH { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? AdditionalPackageCostByPackTH { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? AdditionalPackageCostByCustomerVN { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? AdditionalPackageCostByGradeVN { get; set; }

        [Column(TypeName = "decimal(36, 21)")]
        public decimal? AdditionalPackageCostByPackVN { get; set; }

        public int? TaxRefundUnitIdVN { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? TaxRefundVN { get; set; }

        [Column(TypeName = "decimal(38, 6)")]
        public decimal? SellingPriceSiloVN { get; set; }
    }
}