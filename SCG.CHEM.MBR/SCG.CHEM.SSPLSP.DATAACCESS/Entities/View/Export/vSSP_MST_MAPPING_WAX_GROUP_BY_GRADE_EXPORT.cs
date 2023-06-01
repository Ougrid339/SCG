using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export
{
    [Keyless]
    public class vSSP_MST_MAPPING_WAX_GROUP_BY_GRADE_EXPORT
    {
        public string Grade { get; set; }
        public string WaxGroup { get; set; }
        public string PolymerMKT { get; set; }
        public string MonomerMKT { get; set; }
    }
}