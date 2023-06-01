using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_MasterExcel")]
    public class MBR_MST_MASTER_EXCEL
    {
        [Key]
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