using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_PriceType")]
    public class SSP_MST_PRICE_TYPE
    {
        [Key]
        public int PriceTypeId { get; set; }

        [StringLength(50)]
        public string PriceTypeDesc { get; set; }

        [StringLength(3)]
        public string Country { get; set; }
    }
}