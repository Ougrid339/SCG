using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template
{
    [Table("SSP_TMP_StandardLine")]
    public class SSP_TMP_STANDARD_LINE
    {
        [Key]
        [StringLength(2)]
        public string ProductionSite { get; set; }

        [Key]
        [StringLength(50)]
        public string MatPrefix { get; set; }

        [Key]
        [StringLength(50)]
        public string Grade { get; set; }

        [Key]
        [StringLength(10)]
        public string Plant { get; set; }

        [Key]
        [StringLength(10)]
        public string ProductionLine { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? Ratio { get; set; }

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

        public SSP_TMP_STANDARD_LINE()
        { }

        public SSP_TMP_STANDARD_LINE(SSP_MST_STANDARD_LINE data)
        {
            ObjectUtil.CopyProperties(data, this);

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_TMP_STANDARD_LINE(string productionSite, string matPrefix, string grade, string plant, string productionLine, decimal? ratio, int versionNo)
        {
            ProductionSite = productionSite;
            MatPrefix = matPrefix;
            Grade = grade;
            Plant = plant;
            ProductionLine = productionLine;
            Ratio = ratio;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
            this.VersionNo = versionNo;
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
    }
}