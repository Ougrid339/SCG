using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_PPRCostValidation")]
    public class SSP_MST_PPR_COST_VALIDATION
    {
        [Key]
        [StringLength(40)]
        public string Material { get; set; }

        [Key]
        [StringLength(8)]
        public string Plant { get; set; }

        [Key]
        [StringLength(20)]
        public string CusValuationType1 { get; set; }

        [Key]
        [StringLength(12)]
        public string StartYearMonth { get; set; }
    }
}