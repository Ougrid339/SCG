using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_Plant")]
    public class SSP_MST_PLANT
    {
        [Key]
        [StringLength(10)]
        public string Plant { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}