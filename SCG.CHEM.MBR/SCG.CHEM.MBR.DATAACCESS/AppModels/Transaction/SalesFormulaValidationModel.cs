using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction
{
    public class SalesFormulaValidationModel
    {
        public bool IsValid { get; set; } = false;
        public List<string> Errors { get; set; }
    }
}
