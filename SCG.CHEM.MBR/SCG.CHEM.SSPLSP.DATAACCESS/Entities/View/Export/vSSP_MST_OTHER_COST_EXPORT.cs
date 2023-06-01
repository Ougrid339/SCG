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
    public class vSSP_MST_OTHER_COST_EXPORT
    {
        public DateTime? FirstDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string PlanType { get; set; }

        public string StartMonth { get; set; }

        public string EndMonth { get; set; }
        public string SalesOrg { get; set; }

        public string Channel { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal Payment { get; set; }

        public int PaymentUnitId { get; set; }

        public string PaymentUnit { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal Upfront { get; set; }

        public int UpfrontUnitId { get; set; }

        public string UpfrontUnit { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal Kickback { get; set; }

        public int KickbackUnitId { get; set; }

        public string KickbackUnit { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal Insurance { get; set; }

        public int InsuranceUnitId { get; set; }

        public string InsuranceUnit { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal TaxRefund { get; set; }

        public int TaxRefundUnitId { get; set; }

        public string TaxRefundUnit { get; set; }
    }
}