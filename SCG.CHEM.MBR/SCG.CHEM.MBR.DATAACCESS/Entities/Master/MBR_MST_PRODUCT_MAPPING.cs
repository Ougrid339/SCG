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
    [Table("MBR_MST_ProductMapping")]
    public class MBR_MST_PRODUCT_MAPPING : BaseMasterContext
    {
        //[Key]
        [StringLength(50)]
        public string ProductShortName { get; set; }

        [Key]
        [StringLength(40)]
        public string MaterialCode { get; set; }

        [StringLength(30)]
        public string ProductGroup { get; set; }

        [Key]
        [StringLength(9)]
        public string SourceSystem { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public MBR_MST_PRODUCT_MAPPING()
        { }

        public MBR_MST_PRODUCT_MAPPING(MBR_TMP_PRODUCT_MAPPING data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            //this.CreatedDate = DateTime.Now;
        }

        public MBR_MST_PRODUCT_MAPPING(string productShortName, string materialCode, string productGroup, string sourceSystem, int versionNo, string productName)
        {
            this.ProductShortName = productShortName;
            this.MaterialCode = materialCode;
            this.ProductGroup = productGroup;
            this.SourceSystem = sourceSystem;
            this.VersionNo = versionNo;
            this.ProductName = productName;

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