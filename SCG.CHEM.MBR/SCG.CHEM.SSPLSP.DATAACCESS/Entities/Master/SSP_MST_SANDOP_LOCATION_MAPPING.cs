using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_SandOP_LocationMapping")]
    public class SSP_MST_SANDOP_LOCATION_MAPPING
    {
        [StringLength(12)]
        public string LocationCode { get; set; }

        [Key]
        [StringLength(20)]
        public string ProductionLineCode { get; set; }

        [Key]
        [StringLength(8)]
        public string SDPlantCode { get; set; }

        [StringLength(20)]
        public string ValuationTypeCode { get; set; }

        [StringLength(2)]
        public string? SiteNumber { get; set; }

        [StringLength(60)]
        public string ValuationTypeDesc { get; set; }

        public DateTime ProcessDate { get; set; }
    }
}