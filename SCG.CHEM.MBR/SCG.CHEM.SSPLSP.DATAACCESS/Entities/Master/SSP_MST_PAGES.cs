using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_Pages")]
    public class SSP_MST_PAGES
    {
        [Key]
        public int Id { get; set; }

        [Key]
        [StringLength(255)]
        public string Pages { get; set; }
    }
}