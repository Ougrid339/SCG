using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Views.Master
{
    public class vMBR_MST_LSPPriceFormula
    {
        public string ProductCode { get; set; }

        public string ProductShortName { get; set; }

        public string ProductDescription { get; set; }

        public string FormulaName { get; set; }

        public string FormulaDescription { get; set; }

        public string FormulaEquation { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
    }
}
