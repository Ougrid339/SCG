using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_ProductionSite")]
    public class SSP_MST_PRODUCTION_SITE
    {
        [Key]
        [StringLength(2)]
        public string ProductionSite { get; set; }
    }
}