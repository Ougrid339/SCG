using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_MaintainPrice")]
    public class MBR_MST_MAINTAIN_PRICE
    {
        [Key]
        public int MaintainId { get; set; }

        [StringLength(50)]
        public string MaintainName { get; set; }

        public bool IsZero { get; set; }
    }
}
