using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_Region")]
    public class SSP_MST_REGION
    {
        [Key]
        [StringLength(2)]
        public string Region { get; set; }

        [StringLength(100)]
        public string RegionDesc { get; set; }

        [Key]
        [StringLength(3)]
        public string Country { get; set; }

        [StringLength(50)]
        public string CountryDesc { get; set; }

        [Key]
        [StringLength(4)]
        public string SalesOrg { get; set; }

        [StringLength(4)]
        public string CompanyCode { get; set; }
    }
}