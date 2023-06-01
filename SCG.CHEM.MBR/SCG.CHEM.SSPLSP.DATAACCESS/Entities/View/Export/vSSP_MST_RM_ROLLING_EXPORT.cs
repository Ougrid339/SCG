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
    public class vSSP_MST_RM_ROLLING_EXPORT
    {
        public DateTime? FirstDate { get; set; }
        public string PlanType { get; set; }
        public string VersionName { get; set; }
        public string MonthNo { get; set; }
        public string MonthIndex { get; set; }
        public string InputM1 { get; set; }
        public string CompanyCode { get; set; }
        public string MatCode { get; set; }
        public string MatName { get; set; }
        public string DataPart { get; set; }
        public string UnitId { get; set; }
        public string? Unit { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal Price { get; set; }
    }
}