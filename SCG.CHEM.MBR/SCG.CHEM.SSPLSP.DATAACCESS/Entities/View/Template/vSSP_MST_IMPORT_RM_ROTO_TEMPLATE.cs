using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Template
{
    [Keyless]
    public class vSSP_MST_IMPORT_RM_ROTO_TEMPLATE
    {
        public string RawMatCode { get; set; }

        public string RawMatDesc { get; set; }

        public string RefRawMatCode { get; set; }
    }
}