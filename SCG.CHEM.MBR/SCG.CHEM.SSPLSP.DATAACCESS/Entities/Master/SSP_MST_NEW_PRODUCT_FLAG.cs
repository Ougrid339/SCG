using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_NewProductFlag")]
    public class SSP_MST_NEW_PRODUCT_FLAG
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NewProductId { get; set; }

        [StringLength(50)]
        public string NewProductLDesc { get; set; }

        [StringLength(20)]
        public string NewProductSDesc { get; set; }
    }
}