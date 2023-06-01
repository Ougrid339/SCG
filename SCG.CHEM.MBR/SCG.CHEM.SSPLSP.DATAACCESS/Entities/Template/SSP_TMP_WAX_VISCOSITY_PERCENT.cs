using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template
{
    [Table("SSP_TMP_WaxViscosityPercent")]
    public class SSP_TMP_WAX_VISCOSITY_PERCENT : BaseDatabaseContext
    {
        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(10)]
        public string MatPrefix { get; set; }

        [Key]
        [StringLength(18)]
        public string Grade { get; set; }

        [Key]
        [StringLength(25)]
        public string GradeComp { get; set; }

        [Key]
        [StringLength(10)]
        public string Plant { get; set; }

        [Key]
        [StringLength(10)]
        public string ProductionLine { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal LVPercent { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal HVPercent { get; set; }

        public SSP_TMP_WAX_VISCOSITY_PERCENT()
        { }

        public SSP_TMP_WAX_VISCOSITY_PERCENT(SSP_MST_WAX_VISCOSITY_PERCENT data)
        {
            ObjectUtil.CopyProperties(data, this);

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_TMP_WAX_VISCOSITY_PERCENT(string planType, string matPrefix, string grade, string gradeComp, string plant, string productionLine, decimal lvPercent, decimal hvPercent, string startMonth, int versionNo)
        {
            PlanType = planType;
            MatPrefix = matPrefix;
            Grade = grade;
            GradeComp = gradeComp;
            Plant = plant;
            ProductionLine = productionLine;
            LVPercent = lvPercent;
            HVPercent = hvPercent;
            StartMonth = startMonth;

            DateTime dt;
            var isValid = DateTime.TryParseExact(startMonth, APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
            if (isValid)
                this.FirstDate = dt;

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