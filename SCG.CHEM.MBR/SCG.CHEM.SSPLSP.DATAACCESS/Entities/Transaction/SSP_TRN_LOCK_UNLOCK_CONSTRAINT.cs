using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction
{
    [Table("SSP_TRN_LockUnlockConstraint")]
    public class SSP_TRN_LOCK_UNLOCK_CONSTRAINT : BaseContext
    {
        [Key]
        [StringLength(50)]
        public string PlanCategory { get; set; }

        [Key]
        [StringLength(50)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(50)]
        public string Cycle { get; set; }

        [Key]
        [StringLength(50)]
        public string PlanningGroup { get; set; }

        public bool IsLockedBySupplier { get; set; }

        [StringLength(1)]
        public string DeletedFlag { get; set; }

        [StringLength(50)]
        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public SSP_TRN_LOCK_UNLOCK_CONSTRAINT(string planCategory, string planType, string cycle, string planningGroup)
        {
            PlanCategory = planCategory;
            PlanType = planType;
            Cycle = cycle;
            PlanningGroup = planningGroup;

            IsLockedBySupplier = false;

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

        public void SetLockBySupplier(bool isLock)
        {
            if (this.IsLockedBySupplier != isLock)
            {
                this.IsLockedBySupplier = isLock;
                this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
                this.UpdatedDate = DateTime.Now;
            }
        }
    }
}