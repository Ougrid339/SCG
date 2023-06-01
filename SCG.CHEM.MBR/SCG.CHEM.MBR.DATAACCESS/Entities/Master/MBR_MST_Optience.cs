using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_Optience")]
    public class MBR_MST_OPTIENCE
    {
        [Key]
        public int OptienceId { get; set; }

        [StringLength(50)]
        public string OptienceName { get; set; }

        [StringLength(50)]
        public string OptienceTable { get; set; }

        [StringLength(50)]
        public string OptienceTemp { get; set; }

        public int ExcelId { get; set; }
        [StringLength(50)]
        public string? Sheet { get; set; }

        public int? Mode { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public void SetSheet(string sheetName)
        {
            this.Sheet = sheetName;
        }

        public void UpdateStatus(string updateBy)
        {
            this.UpdatedDate = DateTime.Now;
            this.UpdatedBy = updateBy;
        }
    }
}