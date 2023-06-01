using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_PlanType")]
    public class MBR_MST_PLANTYPE
    {
        [Key]
        [StringLength(3)]
        public string PlanTypeId { get; set; }

        [StringLength(10)]
        public string PlanTypeName { get; set; }
    }
}
