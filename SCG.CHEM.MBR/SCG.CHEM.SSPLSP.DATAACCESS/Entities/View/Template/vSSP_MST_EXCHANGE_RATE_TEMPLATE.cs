using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Template
{
    public class vSSP_MST_EXCHANGE_RATE_TEMPLATE
    {
        public string StartMonth { get; set; }

        public string PlanType { get; set; }
        public DateTime FirstDate { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal ExchangeRate { get; set; }
    }
}