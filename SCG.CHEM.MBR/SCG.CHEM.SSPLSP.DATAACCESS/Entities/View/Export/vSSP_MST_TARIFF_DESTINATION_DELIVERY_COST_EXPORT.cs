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
    public class vSSP_MST_TARIFF_DESTINATION_DELIVERY_COST_EXPORT
    {
        public DateTime? FirstDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PlanType { get; set; }
        public string ProductionSite { get; set; }
        public string StartMonth { get; set; }
        public string EndMonth { get; set; }
        public string Product { get; set; }
        public string ProductSub { get; set; }
        public string Region { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal TariffCost { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal ADTCost { get; set; }
    }
}