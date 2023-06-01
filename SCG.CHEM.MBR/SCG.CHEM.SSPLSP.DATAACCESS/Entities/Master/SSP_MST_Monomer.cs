using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_Monomer")]
    public class SSP_MST_MONOMER
    {
        [Key]
        [StringLength(20)]
        public string Monomer { get; set; }
    }
}