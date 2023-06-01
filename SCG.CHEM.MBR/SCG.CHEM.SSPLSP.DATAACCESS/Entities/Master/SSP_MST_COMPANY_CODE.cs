using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_CompanyCode")]
    public class SSP_MST_COMPANY_CODE
    {
        [Key]
        [StringLength(4)]
        public string CompanyCode { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string CompanyShortName { get; set; }
    }
}