using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Views.Master
{
    public class vMBR_MST_CustomerVendorMapping
    {
        public string CustomerShortName { get; set; }

        public string Type { get; set; }

        public string CustomerCode { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string SourceSystem { get; set; }
    }
}
