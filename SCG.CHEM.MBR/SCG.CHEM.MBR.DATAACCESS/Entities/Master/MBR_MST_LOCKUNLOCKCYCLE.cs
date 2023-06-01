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
    [Table("MBR_MST_LockUnlockCycle")]
    public class MBR_MST_LOCKUNLOCKCYCLE
    {
        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(20)]
        public string Cycle { get; set; }

        [Key]
        [StringLength(10)]
        public string Case { get; set; }

        public bool IsLocked { get; set; }

        [StringLength(1)]
        public string DeletedFlag { get; set; }

        [StringLength(50)]
        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public MBR_MST_LOCKUNLOCKCYCLE()
        { }

        public MBR_MST_LOCKUNLOCKCYCLE(string scenario, string cycle, string caseName, bool isLock)
        {
            this.PlanType = scenario;
            this.Cycle = cycle;
            this.Case = caseName;
            this.IsLocked = isLock;

            this.DeletedFlag = APPCONSTANT.DELETE_FLAG.NO;
            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public void UpdateLockUnlock(bool isLock)
        {
            this.IsLocked = isLock;
            this.UpdatedDate = DateTime.Now;
            this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
        }
    }
}