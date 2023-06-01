using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_MoveMappingByGrade")]
    public class SSP_MST_MOVE_MAPPING_BY_GRADE
    {
        [Key]
        [StringLength(2)]
        public string ProductionSite { get; set; }

        [StringLength(10)]
        public string StockType { get; set; }

        [Key]
        [StringLength(10)]
        public string Grade { get; set; }

        [StringLength(10)]
        public string ProductSub { get; set; }

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

        public SSP_MST_MOVE_MAPPING_BY_GRADE()
        { }

        public SSP_MST_MOVE_MAPPING_BY_GRADE(SSP_TMP_MOVE_MAPPING_BY_GRADE data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_MOVE_MAPPING_BY_GRADE(string productionSite, string stockType, string grade, string productSub, int versionNo)
        {
            ProductionSite = productionSite;
            StockType = stockType;
            Grade = grade;
            ProductSub = productSub;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
            this.VersionNo = versionNo;
            this.DeletedFlag = APPCONSTANT.DELETE_FLAG.NO;
        }

        public void MarkDelete(string userName)
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