using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_StockType")]
    public class SSP_MST_STOCK_TYPE
    {
        [Key]
        public int StockId { get; set; }

        [StringLength(50)]
        public string StockDesc { get; set; }
    }
}