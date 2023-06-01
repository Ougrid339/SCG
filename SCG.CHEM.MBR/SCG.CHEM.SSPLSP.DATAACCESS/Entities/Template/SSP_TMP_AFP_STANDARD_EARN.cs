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
    [Table("SSP_TMP_AFPStandardEarn")]
    public class SSP_TMP_AFP_STANDARD_EARN : BaseDatabaseContext
    {
        [Key]
        [StringLength(50)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(4)]
        public string MatPrefix { get; set; }

        [Key]
        [StringLength(10)]
        public string Grade { get; set; }

        [StringLength(50)]
        public string StandardEarn { get; set; }

        [Key]
        [StringLength(50)]
        public string ProductionLine { get; set; }

        public SSP_TMP_AFP_STANDARD_EARN()
        { }

        public SSP_TMP_AFP_STANDARD_EARN(SSP_MST_AFP_STANDARD_EARN data)
        {
            ObjectUtil.CopyProperties(data, this);

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_TMP_AFP_STANDARD_EARN(string planType, string matPrefix, string grade, string standardEarn, string productionLine, string startMonth, int versionNo)
        {
            PlanType = planType;
            MatPrefix = matPrefix;
            Grade = grade;
            StandardEarn = standardEarn;
            ProductionLine = productionLine;

            this.StartMonth = startMonth;

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