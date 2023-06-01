using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_FCT_MarketPriceOlefins")]
    public class MBR_FCT_MARKETPRICEOLEFINS
    {
        [Column("SCENARIO")]
        public string Scenario { get; set; }

        [Column("PRICING_YEAR")]
        public string PricingYear { get; set; }

        [Column("PRICING_MONTH")]
        public string PricingMonth { get; set; }

        [Column("PRICING_WEEKNO")]
        public string PricingWeekNo { get; set; }

        [Column("PRICING_WEEK")]
        public string PricingWeek { get; set; }

        [Column("PRICING_DATE")]
        public string PricingDate { get; set; }

        [Column("PRODUCT")]
        public string Product { get; set; }

        [Column("PRODUCT_FORM")]
        public string ProductForm { get; set; }

        [Column("PRODUCT_COLOR")]
        public string ProductColor { get; set; }

        [Column("PRICE_SOURCE")]
        public string PriceSource { get; set; }

        [Column("REGION")]
        public string region { get; set; }

        [Column("INCOTERM")]
        public string Incoterm { get; set; }

        [Column("UNIT")]
        public string Unit { get; set; }

        [Column("MIN_PRICE", TypeName = "decimal(16, 2)")]
        public decimal MinPrice { get; set; }

        [Column("MAX_PRICE", TypeName = "decimal(16, 2)")]
        public decimal MaxPrice { get; set; }

        [Column("AVG_PRICE", TypeName = "decimal(16, 2)")]
        public decimal AvgPrice { get; set; }

        [Column("SUB_SCENARIO")]
        public string SubScenario { get; set; }

        [Column("PRODUCT_WEB")]
        public string? ProductWeb { get; set; }

        [Column("ACTIVE_WEB")]
        public char? ActiveWeb { get; set; }
    }
}