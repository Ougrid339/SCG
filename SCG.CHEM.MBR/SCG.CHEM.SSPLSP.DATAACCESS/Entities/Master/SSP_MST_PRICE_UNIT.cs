using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_PriceUnit")]
    public class SSP_MST_PRICE_UNIT
    {
        [Key]
        public int PriceUnitId { get; set; }

        [StringLength(10)]
        public string PriceUnitDesc { get; set; }
    }
}