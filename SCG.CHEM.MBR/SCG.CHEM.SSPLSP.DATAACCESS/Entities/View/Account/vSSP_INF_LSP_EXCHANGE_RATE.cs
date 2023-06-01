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
    public class vSSP_INF_LSP_EXCHANGE_RATE
    {
        [Column("PLAN_TYPE")]
        public string? PlanType { get; set; }

        [Column("START_MONTH")]
        public string? StartMonth { get; set; }

        [Column("END_MONTH")]
        public string? EndMonth { get; set; }

        [Column("EXCHANGE_RATE")]
        public decimal? ExchangeRate { get; set; }

        [Column("FirstDate")]
        public DateTime FirstDate { get; set; }

        [Column("EndDate")]
        public DateTime EndDate { get; set; }
    }
}