using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_ValTypeToProductionLine")]
    public class SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE
    {
        [Key]
        [StringLength(20)]
        public string ValuationTypeCode { get; set; }

        [StringLength(20)]
        public string? ProductionLineCode { get; set; }

        [StringLength(8)]
        public string SDPlantCode { get; set; }

        [StringLength(8)]
        public string? CompanyCode { get; set; }
    }
}