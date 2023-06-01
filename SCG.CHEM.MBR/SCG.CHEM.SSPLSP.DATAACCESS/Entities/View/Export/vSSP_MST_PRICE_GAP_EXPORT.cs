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
    public class vSSP_MST_PRICE_GAP_EXPORT
    {
        public DateTime? FirstDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string PlanType { get; set; }

        public string StartMonth { get; set; }

        public string EndMonth { get; set; }
        public string RawMatCode { get; set; }

        public string MarketGroup { get; set; }

        public int UnitId { get; set; }

        public string Unit { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? PriceGap { get; set; }
    }
}