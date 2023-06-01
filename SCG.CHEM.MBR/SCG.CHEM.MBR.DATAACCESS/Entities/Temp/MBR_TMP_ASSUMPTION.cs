using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Temp
{
    [Table("MBR_TMP_Assumption")]
    public class MBR_TMP_ASSUMPTION : BaseMasterContext
    {
        [Key]
        [StringLength(100)]
        public string Type { get; set; }

        [Key]
        [StringLength(10)]
        [Column("PlanType")]
        public string PlanType { get; set; }

        [Key]
        [StringLength(20)]
        [Column("Cycle")]
        public string Cycle { get; set; }

        [Key]
        [StringLength(10)]
        [Column("Case")]
        public string Case { get; set; }

        [StringLength(1024)]
        public string? Assumption { get; set; }

        [Key]
        public string? RunId { get; set; }

        public MBR_TMP_ASSUMPTION()
        { }

        public MBR_TMP_ASSUMPTION(MBR_MST_ASSUMPTION data)
        {
            ObjectUtil.CopyProperties(data, this);

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public void MarkDelete(string? userName)
        {
            if (this.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES)
            {
                this.DeletedFlag = APPCONSTANT.DELETE_FLAG.YES;
                this.DeletedBy = !String.IsNullOrEmpty(userName) ? userName : (UserUtilities.GetADAccount()?.UserId ?? "");
                this.DeletedDate = DateTime.Now;
            }
        }
    }
}
