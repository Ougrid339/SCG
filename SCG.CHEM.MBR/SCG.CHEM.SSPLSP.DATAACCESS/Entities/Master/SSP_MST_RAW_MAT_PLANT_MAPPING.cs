using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_RawMatPlantMapping")]
    public class SSP_MST_RAW_MAT_PLANT_MAPPING
    {
        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [StringLength(4)]
        public string Company { get; set; }

        [Key]
        [StringLength(20)]
        public string MaterialCode { get; set; }

        [Key]
        [StringLength(10)]
        public string Plant { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }
    }
}