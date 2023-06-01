using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_DeliveryMethod")]
    public class SSP_MST_DELIVERY_METHOD
    {
        [Key]
        [StringLength(2)]
        public string DeliveryMethod { get; set; }

        [StringLength(50)]
        public string DeliveryMethodDesc { get; set; }
    }
}