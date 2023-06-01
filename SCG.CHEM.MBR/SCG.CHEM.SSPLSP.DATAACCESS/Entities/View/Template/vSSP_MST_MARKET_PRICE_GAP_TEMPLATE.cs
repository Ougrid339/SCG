﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Template
{
    [Keyless]
    public class vSSP_MST_MARKET_PRICE_GAP_TEMPLATE
    {
        public DateTime? FirstDate { get; set; }

        public string PlanType { get; set; }

        public string ProductionSite { get; set; }

        public string StartMonth { get; set; }

        public string MarketGroup { get; set; }

        public string BaseMarketGroup { get; set; }

        public string Unit { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal MarketGap { get; set; }
    }
}