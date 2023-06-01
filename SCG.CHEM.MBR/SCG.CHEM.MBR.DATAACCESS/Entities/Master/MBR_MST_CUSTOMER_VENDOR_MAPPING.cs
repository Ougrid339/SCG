using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_CustomerVendorMapping")]
    public class MBR_MST_CUSTOMER_VENDOR_MAPPING : BaseMasterContext
    {
        [Key]
        [StringLength(50)]
        public string CustomerShortName { get; set; }

        [Key]
        [StringLength(15)]
        public string Type { get; set; }

        //[Key]
        [StringLength(10)]
        public string CustomerCode { get; set; }

        [Key]
        [StringLength(9)]
        public string SourceSystem { get; set; }

        public MBR_MST_CUSTOMER_VENDOR_MAPPING()
        { }

        public MBR_MST_CUSTOMER_VENDOR_MAPPING(MBR_TMP_CUSTOMER_VENDOR_MAPPING data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            //this.CreatedDate = DateTime.Now;
        }

        public MBR_MST_CUSTOMER_VENDOR_MAPPING(string customerShortName, string type, string customerCode, string sourceSystem, int versionNo)
        {
            this.CustomerShortName = customerShortName;
            this.Type = type;
            this.CustomerCode = customerCode;
            this.SourceSystem = sourceSystem;
            this.VersionNo = versionNo;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
            this.DeletedFlag = APPCONSTANT.DELETE_FLAG.NO;
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