using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_CountryMaster")]
    public class SSP_MST_COUNTRYMASTER
    {
        [Key]
        [StringLength(2)]
        public string CountryCode { get; set; }

        [StringLength(50)]
        public string CountryName { get; set; }

        [StringLength(2)]
        public string RegionCode { get; set; }

        [StringLength(50)]
        public string RegionDescription { get; set; }
    }
}