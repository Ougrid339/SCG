using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_MonomerType")]
    public class SSP_MST_MONOMER_TYPE
    {
        [Key]
        public int MonomerTypeId { get; set; }

        [StringLength(50)]
        public string MonomerTypeDesc { get; set; }
    }
}