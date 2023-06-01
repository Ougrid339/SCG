using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_SalesConfirm")]
    public class MBR_MST_SALECONFIRM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(10)]
        public string PlanType { get; set; }

        [StringLength(20)]
        public string Cycle { get; set; }

        [StringLength(10)]
        public string Case { get; set; }

        [StringLength(30)]
        public string ProductGroup { get; set; }

        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public MBR_MST_SALECONFIRM()
        { }

        public MBR_MST_SALECONFIRM(string plantype, string cycle, string caseName, string productGroup)
        {
            this.PlanType = plantype;
            this.Cycle = cycle;
            this.Case = caseName;
            this.ProductGroup = productGroup;
            this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? ""; ;
            this.UpdatedDate = DateTime.Now;
        }
    }
}