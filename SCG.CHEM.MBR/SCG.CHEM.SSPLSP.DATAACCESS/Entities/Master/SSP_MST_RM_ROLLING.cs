using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_RMRolling")]
    public class SSP_MST_RM_ROLLING
    {
        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(10)]
        public string InputM1 { get; set; }

        [Key]
        [StringLength(50)]
        public string VersionName { get; set; }

        [Key]
        [StringLength(50)]
        public string CompanyCode { get; set; }

        [Key]
        [StringLength(50)]
        public string MatCode { get; set; }

        [StringLength(50)]
        public string MatName { get; set; }

        [Key]
        [StringLength(50)]
        public string DataPart { get; set; }

        [Key]
        public string UnitId { get; set; }

        [Key]
        [StringLength(10)]
        public string MonthNo { get; set; }

        [StringLength(10)]
        public string MonthIndex { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal Qty { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [Key]
        public int VersionNo { get; set; }

        //[Key]
        [StringLength(1)]
        public string DeletedFlag { get; set; }

        [StringLength(50)]
        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public SSP_MST_RM_ROLLING()
        { }

        public SSP_MST_RM_ROLLING(SSP_TMP_RM_ROLLING data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_RM_ROLLING(string planType, string inputM1, string versionName, string companyCode, string matCode, string matName, string dataPart, string unitId, string monthNo, string monthIndex, decimal price, decimal qty, int versionNo)
        {
            PlanType = planType;
            InputM1 = inputM1;
            VersionName = versionName;
            CompanyCode = companyCode;
            MatCode = matCode;
            MatName = matName;
            DataPart = dataPart;
            UnitId = unitId;
            MonthNo = monthNo;
            MonthIndex = monthIndex;
            Price = price;
            Qty = qty;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
            this.VersionNo = versionNo;
            this.DeletedFlag = APPCONSTANT.DELETE_FLAG.NO;
        }

        public void MarkDelete(string userName = null)
        {
            if (this.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES)
            {
                this.DeletedFlag = APPCONSTANT.DELETE_FLAG.YES;
                this.DeletedBy = userName ?? UserUtilities.GetADAccount()?.UserId ?? "";
                this.DeletedDate = DateTime.Now;
            }
        }
    }
}