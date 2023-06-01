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
    public class vSSP_MST_MARKETPRICEATSILO
    {
        //public string Material {  get; set; }
        public string MarketGroup { get; set; }

        public string PlanType { get; set; }
        public string MonthNo { get; set; }
        public string MonthIndex { get; set; }
        public string VersionName { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? RefMarketGroupPriceTH { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? RefMarketGroupPriceVN { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? STDFreightCostTH { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? STDFreightCostVN { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? STDPackageCostTH { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? STDPackageCostVN { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? STDDeliveryCostTH { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? STDDeliveryCostVN { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? MarketPriceAtSiloTH { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? MarketPriceAtSiloVN { get; set; }
    }
}