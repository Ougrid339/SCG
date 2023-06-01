using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master
{
    public class PackagingRefGradeMasterSheet
    {
        public string PlanType { get; set; }

        public string ProductionSite { get; set; }

        public string MatPrefix { get; set; }

        public string Product { get; set; }

        public string PrdSub { get; set; }

        public string RefMatPrefix { get; set; }

        public string RefGrade { get; set; }

        public string? RefPackage { get; set; }

        public string? RefMarketGroup { get; set; }

        public string? RefMarketSource { get; set; }

        public string RefPlant { get; set; }

        public string RefLine { get; set; }

        public string? MainMonomer { get; set; }
    }
}