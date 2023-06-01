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
    public class vSSP_MST_WAX_ALLOCATION_EXPORT
    {
        public DateTime? FirstDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string PlanType { get; set; }

        public string StartMonth { get; set; }
        public string EndMonth { get; set; }

        public string WaxGroupId { get; set; }

        public string FromProductionLine { get; set; }

        public string ToProductionLine { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PercentAllocation { get; set; }
    }
}