using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_Unit")]
    public class SSP_MST_UNIT
    {
        [Key]
        [StringLength(10)]
        public string Unit { get; set; }
    }
}