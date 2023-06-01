using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_SalesDistrict")]
    public class SSP_MST_SALES_DISTRICT
    {
        [Key]
        [StringLength(50)]
        public string SalesDistrict { get; set; }
    }
}