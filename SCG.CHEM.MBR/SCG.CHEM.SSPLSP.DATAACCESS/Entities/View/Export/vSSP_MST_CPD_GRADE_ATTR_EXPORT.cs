using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export
{
    [Keyless]
    public class vSSP_MST_CPD_GRADE_ATTR_EXPORT
    {
        public DateTime FirstDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string ProductionSite { get; set; }

        public string StartMonth { get; set; }

        public string EndMonth { get; set; }
        public string MatPrefix { get; set; }

        public string Grade { get; set; }

        public string MainGrade { get; set; }

        public string MTSFlag { get; set; }

        public string Formula { get; set; }

        public string CPDApplication { get; set; }

        public string CPDGroup { get; set; }

        public string STDPlant { get; set; }

        public string STDProductionLine { get; set; }

        public string STDPackage { get; set; }

        public string STDValType { get; set; }
    }
}