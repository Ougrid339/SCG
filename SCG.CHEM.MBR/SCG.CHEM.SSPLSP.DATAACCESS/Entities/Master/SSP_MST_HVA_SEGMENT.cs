using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_HVASegment")]
    public class SSP_MST_HVA_SEGMENT
    {
        [Key]
        [StringLength(3)]
        public string HVACode { get; set; }

        [StringLength(100)]
        public string HVALDesc { get; set; }

        [StringLength(20)]
        public string HVASDesc { get; set; }
    }
}