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
    public class vSSP_MST_STANDARD_LINE_EXPORT
    {
        public string ProductionSite { get; set; }
        public string MatPrefix { get; set; }
        public string Grade { get; set; }
        public string Plant { get; set; }
        public string ProductionLine { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal? Ratio { get; set; }
    }
}