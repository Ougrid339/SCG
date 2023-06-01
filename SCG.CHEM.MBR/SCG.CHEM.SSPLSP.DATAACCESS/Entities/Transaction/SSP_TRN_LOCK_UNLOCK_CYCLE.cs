using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction
{
    [Table("SSP_TRN_LockUnlockCycle")]
    public class SSP_TRN_LOCK_UNLOCK_CYCLE : BaseContext
    {
        [Key]
        [StringLength(50)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(50)]
        public string Cycle { get; set; }

        public bool IsLockedByDMO { get; set; }

        [StringLength(1)]
        public string DeletedFlag { get; set; }

        [StringLength(50)]
        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public SSP_TRN_LOCK_UNLOCK_CYCLE(string planType, string cycle)
        {
            PlanType = planType;
            Cycle = cycle;

            IsLockedByDMO = false;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
            this.DeletedFlag = APPCONSTANT.DELETE_FLAG.NO;
        }

        public void MarkDelete()
        {
            if (this.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES)
            {
                this.DeletedFlag = APPCONSTANT.DELETE_FLAG.YES;
                this.DeletedBy = UserUtilities.GetADAccount()?.UserId ?? "";
                this.DeletedDate = DateTime.Now;
            }
        }

        public void UnMarkDelete()
        {
            if (this.DeletedFlag == APPCONSTANT.DELETE_FLAG.YES)
            {
                this.DeletedFlag = APPCONSTANT.DELETE_FLAG.NO;
                this.DeletedBy = UserUtilities.GetADAccount()?.UserId ?? "";
                this.DeletedDate = DateTime.Now;
            }
        }

        public void SetLockByDMO(bool isLock)
        {
            if (this.IsLockedByDMO != isLock)
            {
                this.IsLockedByDMO = isLock;
                this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
                this.UpdatedDate = DateTime.Now;
            }
        }
    }
}