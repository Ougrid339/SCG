using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Transaction
{
    [Table("MBR_TRN_MergeHistory")]
    public class MBR_TRN_MERGE_HISTORY
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(20)]
        public string Cycle { get; set; }

        [StringLength(10)]
        public string Case { get; set; }

        [StringLength(20)]
        public string MergedWithCycle { get; set; }

        [StringLength(10)]
        public string MergedWithCase { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [Key]
        [Required]
        public int ExcelId { get; set; }

    }
}