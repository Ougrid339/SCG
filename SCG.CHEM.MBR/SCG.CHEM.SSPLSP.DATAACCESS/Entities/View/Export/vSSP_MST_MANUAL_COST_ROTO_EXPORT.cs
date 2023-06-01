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
    public class vSSP_MST_MANUAL_COST_ROTO_EXPORT
    {
        public DateTime? FirstDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string PlanType { get; set; }

        public string StartMonth { get; set; }
        public string EndMonth { get; set; }

        public string MatPrefix { get; set; }

        public string Product { get; set; }

        public string ProductSub { get; set; }

        //public string Application { get; set; }

        public string ProductForm { get; set; }

        public string ProductColor { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? STDYield { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? InventoryCost { get; set; }

        public int InventoryCostUnitId { get; set; }

        public string InventoryCostUnit { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? MaintenanceCost { get; set; }

        public int MaintenanceCostUnitId { get; set; }

        public string MaintenanceCostUnit { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? SemiVC { get; set; }

        public int SemiVCUnitId { get; set; }

        public string SemiVCUnit { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? FC { get; set; }

        public int FCUnitId { get; set; }

        public string FCUnit { get; set; }
    }
}