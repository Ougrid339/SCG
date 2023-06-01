using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Temp
{
    [Table("MBR_TMP_SalesPreviewSubmit")]
    public class MBR_TMP_SALES_PREVIEW_SUBMIT
    {
        [Key]
        [Column("WebUUID")]
        [Required]
        public Guid WebUUID { get; set; }

        [Column("PriviewRunId")]
        public string? PriviewRunId { get; set; }
        [Column("SubmitRunId")]
        public string? SubmitRunId { get; set; }
        [Column("Mode")]
        [StringLength(50)]
        public string? Mode { get; set; }
        [Column("UpdateFinalPriceRunId")]
        [StringLength(50)]
        public string? UpdateFinalPriceRunId { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
