using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Template
{
    [Keyless]
    public class vSSP_MST_RAW_MAT_GAP_TEMPLATE
    {
        public DateTime? FirstDate { get; set; }

        public string PlanType { get; set; }

        public string ProductionSite { get; set; }

        public string StartMonth { get; set; }

        public string Company { get; set; }

        [Column("MaterialCode")]
        public string MatCode { get; set; }

        public string Unit { get; set; }

        [Column("Price", TypeName = "decimal(15, 5)")]
        public decimal? GapPrice { get; set; }
    }
}