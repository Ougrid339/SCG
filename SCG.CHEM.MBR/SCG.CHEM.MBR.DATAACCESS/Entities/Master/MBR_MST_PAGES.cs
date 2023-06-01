using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_Pages")]
    public class MBR_MST_PAGES
    {
        [Key]
        public int Id { get; set; }

        [Key]
        [StringLength(255)]
        public string Pages { get; set; }
    }
}