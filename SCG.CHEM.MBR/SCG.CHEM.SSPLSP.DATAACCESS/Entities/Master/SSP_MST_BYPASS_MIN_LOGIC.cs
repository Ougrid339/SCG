using SCG.CHEM.MBR.COMMON.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_ByPassMinLogic")]
    public class SSP_MST_BYPASS_MIN_LOGIC : BaseContext
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Sequence { get; set; }

        public bool IsByPass { get; set; }

        [StringLength(200)]
        public string PlanType { get; set; }

        [StringLength(200)]
        public string PlanningGroup { get; set; }

        [StringLength(200)]
        public string SalesGroup { get; set; }

        [StringLength(200)]
        public string CustomerCode { get; set; }

        public bool IsActive { get; set; }

        public SSP_MST_BYPASS_MIN_LOGIC(int sequence, bool isByPass, string planType, string planningGroup, string salesGroup, string customerCode, bool isActive)
        {
            Sequence = sequence;
            IsByPass = isByPass;
            PlanType = planType;
            PlanningGroup = planningGroup;
            SalesGroup = salesGroup;
            CustomerCode = customerCode;
            IsActive = isActive;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public void Update(int sequence, bool isByPass, string planType, string planningGroup, string salesGroup, string customerCode, bool isActive)
        {
            Sequence = sequence;
            IsByPass = isByPass;
            PlanType = planType;
            PlanningGroup = planningGroup;
            SalesGroup = salesGroup;
            CustomerCode = customerCode;
            IsActive = isActive;

            this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.UpdatedDate = DateTime.Now;
        }
    }
}