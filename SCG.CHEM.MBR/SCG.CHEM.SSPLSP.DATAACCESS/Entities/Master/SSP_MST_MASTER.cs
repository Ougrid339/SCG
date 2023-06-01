using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_Master")]
    public class SSP_MST_MASTER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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