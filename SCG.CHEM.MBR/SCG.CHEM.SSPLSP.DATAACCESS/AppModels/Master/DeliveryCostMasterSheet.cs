﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master
{
    public class DeliveryCostMasterSheet
    {
        public string PlanType { get; set; }

        public string ProductionSite { get; set; }

        public string StartMonth { get; set; }

        public string MatPrefix { get; set; }

        public string Product { get; set; }

        public string ProductSub { get; set; }

        public string ChannelGroup { get; set; }

        public string Unit { get; set; }

        public decimal Delivery { get; set; }
    }
}