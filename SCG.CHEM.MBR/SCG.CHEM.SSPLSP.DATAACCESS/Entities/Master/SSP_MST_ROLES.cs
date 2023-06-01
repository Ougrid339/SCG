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
    [Table("SSP_MST_Roles")]
    public class SSP_MST_ROLES : BaseContext
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(50)]
        public string RoleName { get; set; }

        public string AvailablePages { get; set; }

        public string AvailableMasters { get; set; }

        public string AvailableUploadPlanningGroups { get; set; }

        public string AvailableDWHPlanningGroups { get; set; }

        public string AvailableSalesGroup { get; set; }

        public string AvailableNewProductFlag { get; set; }

        [StringLength(1)]
        public string DeletedFlag { get; set; }

        [StringLength(50)]
        public string? DeletedBy { get; set; }

        public SSP_MST_ROLES()
        { }

        public SSP_MST_ROLES(string roleName, string availablePages, string availableMasters, string availableUploadPlanningGroups, string availableDWHPlanningGroups, string availableSalesGroup, string availableNewProductFlag)
        {
            RoleName = roleName;
            AvailablePages = availablePages;
            AvailableMasters = availableMasters;
            AvailableUploadPlanningGroups = availableUploadPlanningGroups;
            AvailableDWHPlanningGroups = availableDWHPlanningGroups;
            AvailableSalesGroup = availableSalesGroup;
            AvailableNewProductFlag = availableNewProductFlag;

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