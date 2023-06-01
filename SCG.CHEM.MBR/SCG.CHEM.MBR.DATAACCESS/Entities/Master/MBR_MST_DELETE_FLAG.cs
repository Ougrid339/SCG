using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_DeleteFlag")]
    public class MBR_MST_DELETE_FLAG
    {
        [Key]
        [StringLength(2)]
        public string Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public MBR_MST_DELETE_FLAG()
        { }
    }
}