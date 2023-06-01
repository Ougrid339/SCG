using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_SubRegion")]
    public class SSP_MST_SUB_REGION
    {
        [Key]
        [StringLength(10)]
        public string SubRegion { get; set; }

        [Key]
        [StringLength(2)]
        public string Region { get; set; }
    }
}