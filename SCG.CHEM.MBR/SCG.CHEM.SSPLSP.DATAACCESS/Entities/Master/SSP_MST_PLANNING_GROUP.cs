using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_PlanningGroup")]
    public class SSP_MST_PLANNING_GROUP
    {
        [Key]
        [StringLength(3)]
        public string PlanningGroupCode { get; set; }

        [StringLength(50)]
        public string PlanningGroupName { get; set; }
    }
}