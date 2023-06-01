using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_Master")]
    public class MBR_MST_MASTER
    {
        [Key]
        public int MasterId { get; set; }

        [StringLength(50)]
        public string MasterName { get; set; }

        [StringLength(50)]
        public string MasterTable { get; set; }

        [StringLength(50)]
        public string MasterTemp { get; set; }

        [StringLength(50)]
        public string Sheet { get; set; }

        public int Mode { get; set; }

        [StringLength(50)]
        public string ViewExport { get; set; }

        [StringLength(50)]
        public string ViewTemplate { get; set; }

        [StringLength(50)]
        public string PlanType { get; set; }

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