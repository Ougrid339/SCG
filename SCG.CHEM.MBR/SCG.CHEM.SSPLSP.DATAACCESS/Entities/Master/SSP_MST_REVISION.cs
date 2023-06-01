using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_Revision")]
    public class SSP_MST_REVISION
    {
        [Key]
        public int RevisionId { get; set; }

        [StringLength(50)]
        public string RevisionDesc { get; set; }

        [StringLength(50)]
        public string OleRevisionDesc { get; set; }
    }
}