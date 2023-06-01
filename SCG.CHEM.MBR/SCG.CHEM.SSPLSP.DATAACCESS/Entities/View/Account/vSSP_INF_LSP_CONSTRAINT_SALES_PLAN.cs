using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Account
{
    [Keyless]
    public class vSSP_INF_LSP_CONSTRAINT_SALES_PLAN
    {
        [Column("CYCLE_NAME")]
        public string? CycleName { get; set; }

        [Column("CAL_YEAR_MONTH")]
        public string? CalYearMonth { get; set; }

        [Column("COMPANY_CODE")]
        public string? CompanyCode { get; set; }

        [Column("MANUFAC_COMP")]
        public string? ManuFacComp { get; set; }

        [Column("SCENARIO_NAME")]
        public string? ScenarioName { get; set; }

        [Column("CUSTOMER")]
        public string? Customer { get; set; }

        [Column("CUSTOMER_NAME")]
        public string? CustomerName { get; set; }

        [Column("CHANNEL")]
        public string? Channel { get; set; }

        [Column("REGION")]
        public string? Region { get; set; }

        [Column("SALES_GROUP_CODE")]
        public string? SalesGroupCode { get; set; }

        [Column("SALES_GROUP_DESC")]
        public string? SalesGroupDesc { get; set; }

        [Column("HVA_SEGMENT_CODE")]
        public string? hvaSegmentCode { get; set; }

        [Column("HVAName")]
        public string? hvaName { get; set; }

        [Column("NEW_PROD_DESCR")]
        public string? NewProdDescr { get; set; }

        [Column("MAT_INPUT")]
        public string? MatInput { get; set; }

        [Column("GRADE_INPUT")]
        public string? GradeInput { get; set; }

        [Column("PACKAGE")]
        public string? Package { get; set; }

        [Column("MatGroup")]
        public string? MatGroup { get; set; }

        [Column("Class")]
        public string? Class { get; set; }

        [Column("Product")]
        public string? Product { get; set; }

        [Column("PRODUCT_SUB")]
        public string? ProductSub { get; set; }

        [Column("App")]
        public string? App { get; set; }

        [Column("APP_NAME")]
        public string? AppName { get; set; }

        [Column("APP_SNAME")]
        public string? AppSName { get; set; }

        [Column("PRODUCT_COLOR")]
        public string? ProductColor { get; set; }

        [Column("PRODUCT_COLOR_NAME")]
        public string? ProductColorName { get; set; }

        [Column("PLANT")]
        public string? Plant { get; set; }

        [Column("PRODUCTION_LINE")]
        public string? ProductionLine { get; set; }

        [Column("STOCK_DESC")]
        public string? StockDesc { get; set; }

        [Column("PLANNING_GROUP")]
        public string? PlanningGroup { get; set; }

        [Column("REF_MARKETGROUP")]
        public string? RefMarketGroup { get; set; }

        [Column("SALES_UNIT")]
        public string? SalesUnit { get; set; }

        [Column("CON_QTY")]
        public decimal? ConQty { get; set; }

        [Column("EXCHANGE_RATE")]
        public decimal? ExchangeRate { get; set; }

        [Column("USD_SELLING_PRICE_END_CUST")]
        public decimal? usd_SellingPriceEndCust { get; set; }

        [Column("USD_PAYMENT")]
        public decimal? usd_Payment { get; set; }

        [Column("USD_FREIGHT")]
        public decimal? usd_Freight { get; set; }

        [Column("USD_INSURANCE")]
        public decimal? usd_Insurance { get; set; }

        [Column("USD_UPFRONT")]
        public decimal? usd_Upfront { get; set; }

        [Column("USD_KICKBACK")]
        public decimal? usd_Kickback { get; set; }

        [Column("USD_DELIVERY_PRICE")]
        public decimal? usd_DeliveryPrice { get; set; }

        [Column("USD_SELLING_PRICE_CFR")]
        public decimal? usd_SellingPriceCFR { get; set; }

        //[Column("USD_MKT_PRICE_CFR")]
        //public decimal? usd_MKTPriceCFR { get; set; }

        [Column("USD_FREIGHT_STD_SEA")]
        public decimal? usd_FreightSTDSEA { get; set; }

        [Column("USD_PRICE_FOB")]
        public decimal? usd_PriceFOB { get; set; }

        [Column("USD_TAX_REFUND")]
        public decimal? usd_TaxRefund { get; set; }

        [Column("USD_DELIVERY")]
        public decimal? usd_Delivery { get; set; }

        [Column("USD_PACKAGE")]
        public decimal? usd_Package { get; set; }

        [Column("USD_PACKAGE_ADD")]
        public decimal? usd_PackageAdd { get; set; }

        [Column("USD_PRICE_AT_SILO")]
        public decimal? usd_PriceAtSilo { get; set; }

        [Column("USD_PREMIUM_AT_SILO")]
        public decimal? usd_PremiumAtSilo { get; set; }

        [Column("USD_MKT_BASE_PRICE_CFR")]
        public decimal? usd_MKTBasePriceCFR { get; set; }

        [Column("USD_PACKAGE_BASE")]
        public decimal? usd_PackageBase { get; set; }

        [Column("USD_DELIVERY_BASE")]
        public decimal? usd_DeliveryBase { get; set; }

        [Column("USD_MKT_BASE_PRICE_AT_SILO")]
        public decimal? usd_MKTBasePriceAtSilo { get; set; }

        [Column("USD_C2_MKT")]
        public decimal? usd_C2MKT { get; set; }

        [Column("USD_C3_MKT")]
        public decimal? usd_C3MKT { get; set; }

        [Column("USD_MONOMER_MKT")]
        public int? usd_MonomerMKT { get; set; }

        [Column("USD_COST_ADJ")]
        public int? usd_CostADJ { get; set; }

        [Column("USD_TRANSITION")]
        public int? usd_Transition { get; set; }

        [Column("SALES_DISTRICT")]
        public string? SalesDisTrict { get; set; }

        [Column("USD_PRICE_AT_TPC")]
        public decimal? usd_priceattpc { get; set; }

        [Column("USD_TPC_DISCOUNT")]
        public decimal? usd_tpcdiscount { get; set; }

        //[Column("CHANNEL_NAME")]
        //public string? ChannelName { get; set;  }

        //[Column("SOLDTO")]
        //public string? SoldTo { get; set;  }
        //[Column("SOLDTO_NAME")]
        //public string? SoldToName { get; set;  }

        //[Column("MAT_LOOKUP")]
        //public string? MatLookup { get; set;  }

        //[Column("MAT_MST")]
        //public string? MatMST { get; set;  }

        //[Column("GRADE_MST")]
        //public string? GradeMst { get; set;  }

        //[Column("MarketPriceGroup")]
        //public string? MarketPriceGroup { get; set;  }

        //[Column("SCENARIO_ID")]
        //public int? ScenarioId { get; set;  }

        //[Column("CLASS_GROUP")]
        //public string? ClassGroup { get; set;  }
        //[Column("BOM")]
        //public string? Bom { get; set;  }

        //[Column("REF_PRDLINE")]
        //public string? RefPrdLine { get; set;  }
        //[Column("REF_PLANT")]
        //public string? RefPlant { get; set;  }
        //[Column("REF_GRADE_BASE")]
        //public string? RefGradeBase { get; set;  }

        //[Column("THB_FREIGHT")]
        //public decimal? thb_Freight { get; set;  }

        //[Column("THB_UPFRONT")]
        //public decimal? thb_Upfront { get; set;  }

        //[Column("THB_PAYMENT")]
        //public decimal? thb_Payment { get; set;  }

        //[Column("THB_PREMIUM_CFR")]
        //public decimal? thb_PremiumCFR { get; set;  }
        //[Column("USD_PREMIUM_CFR")]
        //public decimal? usd_PremiumCFR { get; set;  }
        //[Column("THB_DELIVERY_PRICE")]
        //public decimal? thb_DeliveryPrice { get; set;  }

        //[Column("THB_KICKBACK")]
        //public decimal? thb_Kickback { get; set;  }

        //[Column("THB_MKT_PRICE_CFR")]
        //public decimal? thb_MKTPriceCFR { get; set;  }

        //[Column("THB_MONOMER_MKT")]
        //public int? thb_MonomerMKT { get; set;  }

        //[Column("THB_FREIGHT_STD_SEA")]
        //public decimal? thb_FreightSTDSEA { get; set;  }

        //[Column("THB_C2_MKT")]
        //public decimal? thb_C2MKT { get; set;  }

        //[Column("THB_C3_MKT")]
        //public decimal? thb_C3MKT { get; set;  }

        //[Column("THB_COST_ADJ")]
        //public int? thb_CostADJ { get; set;  }

        //[Column("THB_DELIVERY")]
        //public decimal? thb_Delivery { get; set;  }

        //[Column("THB_DELIVERY_BASE")]
        //public decimal? thb_DeliveryBase { get; set;  }

        //[Column("THB_INSURANCE")]
        //public decimal? thb_Insurance { get; set;  }

        //[Column("THB_MKT_BASE_PRICE_AT_SILO")]
        //public decimal? thb_MKTBasePriceAtSilo { get; set;  }

        //[Column("THB_MKT_BASE_PRICE_CFR")]
        //public decimal? thb_MKTBasePriceCFR { get; set;  }

        //[Column("THB_PACKAGE")]
        //public decimal? thb_Package { get; set;  }

        //[Column("THB_PACKAGE_ADD")]
        //public decimal? thb_PackageAdd { get; set;  }

        //[Column("THB_PACKAGE_BASE")]
        //public decimal? thb_PackageBase { get; set;  }

        //[Column("THB_PREMIUM_AT_SILO")]
        //public decimal? thb_PremiumAtSilo { get; set;  }

        //[Column("THB_PRICE_AT_SILO")]
        //public decimal? thb_PriceAtSilo { get; set;  }

        //[Column("THB_PRICE_AT_TPC")]
        //public decimal? thb_PriceAtTPC { get; set;  }
        //[Column("USD_PRICE_AT_TPC")]
        //public decimal? usd_PriceAtTPC { get; set;  }
        //[Column("THB_TPC_DISCOUNT")]
        //public decimal? thb_TPCDiscount { get; set;  }
        //[Column("USD_TPC_DISCOUNT")]
        //public decimal? usd_TPCDiscount { get; set;  }
        //[Column("THB_PRICE_FOB")]
        //public decimal? thb_PriceFOB { get; set;  }

        //[Column("THB_SELLING_PRICE_CFR")]
        //public decimal? thb_SellingPriceCFR { get; set;  }

        //[Column("THB_SELLING_PRICE_END_CUST")]
        //public decimal? thb_SellingPriceEndCust { get; set;  }

        //[Column("THB_TAX_REFUND")]
        //public decimal? thb_TaxRefund { get; set;  }

        //[Column("THB_TRANSITION")]
        //public int? thb_Transition { get; set;  }

        //[Column("PRD_KEY")]
        //public string? PrdKey { get; set;  }
    }
}