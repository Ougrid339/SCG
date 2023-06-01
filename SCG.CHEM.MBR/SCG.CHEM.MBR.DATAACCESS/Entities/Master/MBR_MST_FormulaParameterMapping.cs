using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    public class MBR_MST_FormulaParameterMapping
    {
        [StringLength(10)]
        public string FormulaID { get; set; }

        [StringLength(50)]
        public string FormulaName { get; set; }

        [StringLength(20)]
        public string Parameter { get; set; }

        [StringLength(20)]
        public string? ConditionVariable { get; set; }

        public DateTime? ProcessDate { get; set; }

        [StringLength(1024)]
        public string FormulaEquation { get; set; }
    }
}