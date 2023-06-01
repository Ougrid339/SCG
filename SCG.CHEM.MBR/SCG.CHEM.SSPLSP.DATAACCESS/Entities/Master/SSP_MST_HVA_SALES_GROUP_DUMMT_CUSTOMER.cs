using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_HVASalesGroupDummyCustomer")]
    public class SSP_MST_HVA_SALES_GROUP_DUMMT_CUSTOMER
    {
        [Key]
        [StringLength(60)]
        public string SalesGroup { get; set; }

        [StringLength(50)]
        public string SalesGroupName { get; set; }

        [Key]
        [StringLength(10)]
        public string Customer { get; set; }

        [StringLength(500)]
        public string CustomerName { get; set; }

        [StringLength(4)]
        public string HVASegment { get; set; }

        [StringLength(200)]
        public string HVASegmentName { get; set; }

        [Key]
        [StringLength(10)]
        public string StartYearMonth { get; set; }

        [Required]
        [StringLength(10)]
        public string EndYearMonth { get; set; }
    }
}