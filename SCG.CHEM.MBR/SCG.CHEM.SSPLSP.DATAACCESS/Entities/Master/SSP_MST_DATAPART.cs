using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_DataPart")]
    public class SSP_MST_DATAPART
    {
        [Key]
        [StringLength(50)]
        public string Code { get; set; }
    }
}