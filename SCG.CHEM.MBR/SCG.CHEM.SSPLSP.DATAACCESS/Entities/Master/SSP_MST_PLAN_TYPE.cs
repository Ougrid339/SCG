using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_PlanType")]
    public class SSP_MST_PLAN_TYPE
    {
        [Key]
        [StringLength(3)]
        public string PlanTypeId { get; set; }

        [StringLength(10)]
        public string PlanTypeName { get; set; }
    }
}