﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master
{
    public class FreightSubRegionMasterSheet
    {
        public string PlanType { get; set; }

        public string ProductionSite { get; set; }

        public string StartMonth { get; set; }

        public string RegionCode { get; set; }

        public string SubRegion { get; set; }

        public decimal FreightGap { get; set; }
    }
}