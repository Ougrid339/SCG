using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master
{
    public class PackagingCostMasterSheet
    {
        public string StartYearMonth { get; set; }

        public string ProductionSite { get; set; }

        public string Product { get; set; }

        public string ProductSub { get; set; }

        public string RefGrade { get; set; }

        public string Package { get; set; }

        public decimal? USDPackagingCost { get; set; }
    }
}