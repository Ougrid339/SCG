using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_AvailableProductionLineByPlanningGroupAndPlanType")]
    public class SSP_MST_AVAILABLE_PRODUCTION_LINE_BY_PLANNING_GROUP_AND_PLAN_TYPE
    {
        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Key]
        public int AvailableId { get; set; }

        [StringLength(50)]
        public string PlanningGroup { get; set; }

        [StringLength(50)]
        public string ProductionLine { get; set; }

        public int SeqNo { get; set; }

        [StringLength(1)]
        public string? StockFlag { get; set; }

        public int StockTypeId { get; set; }

        //[StringLength(20)]
        //public string? ProductionSite { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(1)]
        public string? DeletedFlag { get; set; }

        [StringLength(50)]
        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}