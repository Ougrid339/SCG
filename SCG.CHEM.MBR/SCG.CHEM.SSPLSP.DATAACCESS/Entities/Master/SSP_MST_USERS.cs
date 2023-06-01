using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_Users")]
    public class SSP_MST_USERS : BaseContext
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(255)]
        public string Username { get; set; }

        public string Roles { get; set; }

        public bool IsActive { get; set; }

        [StringLength(1)]
        public string DeletedFlag { get; set; }

        [StringLength(50)]
        public string? DeletedBy { get; set; }

        public SSP_MST_USERS()
        { }

        public SSP_MST_USERS(string username, string roles, bool isActive)
        {
            Username = username;
            Roles = roles;
            IsActive = isActive;

            this.DeletedFlag = APPCONSTANT.DELETE_FLAG.NO;
            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public void UpdateChange()
        {
            this.UpdatedDate = DateTime.Now;
            this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
        }

        public void DeleteBy()
        {
            this.DeletedFlag = APPCONSTANT.DELETE_FLAG.YES;
            this.DeletedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.UpdatedDate = DateTime.Now;
        }
    }
}