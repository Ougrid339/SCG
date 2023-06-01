using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Transaction
{
    [Keyless]
    public class vSSP_MST_VAL_TYPE_TO_PRODUCTION_LINE
    {
        public string ValuationTypeCode { get; set; }
        public string? ProductionLineCode { get; set; }
        public string SDPlantCode { get; set; }
    }
}