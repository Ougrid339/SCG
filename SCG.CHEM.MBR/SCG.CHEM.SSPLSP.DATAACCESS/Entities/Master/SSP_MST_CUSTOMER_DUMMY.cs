using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_CustomerDummy")]
    public class SSP_MST_CUSTOMER_DUMMY
    {
        [Key]
        [StringLength(10)]
        public string CustomerCode { get; set; }
    }
}