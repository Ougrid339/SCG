using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master
{
    public class PackagingCostModel
    {
        public string StartYearMonth { get; set; }
        public string EndYearMonth { get; set; }
        public string RefGrade { get; set; }
        public string Package { get; set; }
        public decimal? USDPackagingCost { get; set; }
    }
}