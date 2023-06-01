using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export
{
    [Keyless]
    public class vSSP_MST_MOVE_MAPPING_BY_GRADE_EXPORT
    {
        public string ProductionSite { get; set; }
        public string Grade { get; set; }
        public string StockType { get; set; }
        public string ProductSub { get; set; }
    }
}