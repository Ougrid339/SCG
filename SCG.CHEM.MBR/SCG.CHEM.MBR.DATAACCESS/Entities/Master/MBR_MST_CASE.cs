using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_Case")]
    public class MBR_MST_CASE
    {
        [Key]
        public int CaseId { get; set; }

        [StringLength(50)]
        public string CaseDesc { get; set; }
    }
}