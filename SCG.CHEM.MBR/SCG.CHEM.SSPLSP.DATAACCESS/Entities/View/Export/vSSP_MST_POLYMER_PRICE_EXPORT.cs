using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export
{
    [Keyless]
    public class vSSP_MST_POLYMER_PRICE_EXPORT
    {
        public DateTime? FirstDate { get; set; }
        public string PlanType { get; set; }
        public string VersionName { get; set; }
        public string MonthNo { get; set; }
        public string MonthIndex { get; set; }
        public string MarketGroup { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? Price { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal SEA_ASIA_DIFF { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? PriceVN { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal SEA_ASIA_DIFF_VN { get; set; }
    }
}