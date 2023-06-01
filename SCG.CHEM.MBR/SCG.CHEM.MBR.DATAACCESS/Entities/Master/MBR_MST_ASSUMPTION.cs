using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_Assumption")]
    public class MBR_MST_ASSUMPTION : BaseMasterContext
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

        public MBR_MST_ASSUMPTION() { }

        public MBR_MST_ASSUMPTION(MBR_TMP_ASSUMPTION data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            //this.CreatedDate = DateTime.Now;
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
