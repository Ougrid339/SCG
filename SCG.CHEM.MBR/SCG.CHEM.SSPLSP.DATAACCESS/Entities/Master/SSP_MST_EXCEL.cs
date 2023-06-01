using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_MasterExcel")]
    public class SSP_MST_EXCEL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExcelId { get; set; }

        [StringLength(50)]
        public string MasterName { get; set; }

        [StringLength(50)]
        public string MasterTable { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(50)]
        public string? UpdatedBy { get; set; }
    }
}