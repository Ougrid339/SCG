using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Views.Master
{
    public class vMBR_MST_ProductMapping
    {
        public string ProductShortName { get; set; }

        public string MaterialCode { get; set; }

        public string ProductGroup { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string SourceSystem { get; set; }

        public string ProductName { get; set; }
    }
}
