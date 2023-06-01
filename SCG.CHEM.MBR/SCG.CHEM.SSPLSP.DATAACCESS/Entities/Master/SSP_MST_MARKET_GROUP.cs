using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_MarketGroup")]
    public class SSP_MST_MARKET_GROUP
    {
        [Key]
        [StringLength(20)]
        public string MarketGroup { get; set; }

        [StringLength(50)]
        public string MarketGroupDesc { get; set; }
    }
}