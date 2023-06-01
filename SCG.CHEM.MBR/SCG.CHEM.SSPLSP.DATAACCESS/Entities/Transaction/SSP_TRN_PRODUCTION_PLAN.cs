using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction
{
    [Table("SSP_TRN_ProductionPlan")]
    public class SSP_TRN_PRODUCTION_PLAN : BaseContext
    {
        [Key]
        [StringLength(50)]
        public string VersionName { get; set; }

        [Key]
        [StringLength(20)]
        public string PlanningGroup { get; set; }

        [Key]
        public int RevId { get; set; }

        [Key]
        [StringLength(10)]
        public string Plant { get; set; }

        [Key]
        [StringLength(20)]
        public string Bom { get; set; }

        [Key]
        [StringLength(10)]
        public string Line { get; set; }

        [StringLength(20)]
        public string ValuationTypeCode { get; set; }

        [Key]
        [StringLength(20)]
        public string MatCodeMst { get; set; }

        [Key]
        [StringLength(20)]
        public string MatCodeTrn { get; set; }

        [Key]
        [StringLength(10)]
        public string Unit { get; set; }

        [Required]
        [StringLength(10)]
        public string MonthIndex { get; set; }

        [Key]
        [StringLength(10)]
        public string MonthNo { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? PrdQty { get; set; }

        [Key]
        public int NewProductId { get; set; }

        [StringLength(255)]
        public string? Remark { get; set; }

        [Key]
        public int VersionNo { get; set; }

        [StringLength(1)]
        public string DeletedFlag { get; set; }

        [StringLength(50)]
        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public SSP_TRN_PRODUCTION_PLAN()
        { }

        public SSP_TRN_PRODUCTION_PLAN(string versionName, string planningGroup, int revId, string plant, string bom, string line, string valuationTypeCode, string matCodeMst, string matCodeTrn, string unit, string monthIndex, string monthNo, decimal? prdQty, int newProductId, string? remark, int versionNo)
        {
            VersionName = versionName;
            PlanningGroup = planningGroup;
            RevId = revId;
            Plant = plant;
            Bom = bom;
            Line = line;
            ValuationTypeCode = valuationTypeCode;
            MatCodeMst = matCodeMst;
            MatCodeTrn = matCodeTrn;
            Unit = unit;
            MonthIndex = monthIndex;
            MonthNo = monthNo;
            PrdQty = prdQty;
            NewProductId = newProductId;
            Remark = remark;
            VersionNo = versionNo;

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

        public void SetVersionNo(int versionNo)
        {
            this.VersionNo = versionNo;
            //this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            //this.UpdatedDate = DateTime.Now;
        }
    }
}