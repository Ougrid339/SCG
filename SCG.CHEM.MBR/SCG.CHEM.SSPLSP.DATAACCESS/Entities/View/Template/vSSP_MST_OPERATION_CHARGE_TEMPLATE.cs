using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Template
{
    [Keyless]
    public class vSSP_MST_OPERATION_CHARGE_TEMPLATE
    {
        public DateTime FirstDate { get; set; }

        public string PlanType { get; set; }

        public string StartMonth { get; set; }

        public string? SourceCompany { get; set; }

        public string? SalesOrg { get; set; }

        public string Product { get; set; }

        public string ProductSub { get; set; }

        public string ChannelCode { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal Discount { get; set; }

        public string? DiscountUnit { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal TaxRefund { get; set; }

        public string? TaxRefundUnit { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal OC { get; set; }

        public string? OCUnit { get; set; }
    }
}