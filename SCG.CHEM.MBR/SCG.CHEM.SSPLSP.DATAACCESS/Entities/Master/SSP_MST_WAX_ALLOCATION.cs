using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_WaxAllocation")]
    public class SSP_MST_WAX_ALLOCATION : BaseDatabaseContext
    {
        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(4)]
        public string WaxGroupId { get; set; }

        [Key]
        [StringLength(10)]
        public string FromProductionLine { get; set; }

        [Key]
        [StringLength(10)]
        public string ToProductionLine { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal PercentAllocation { get; set; }

        public SSP_MST_WAX_ALLOCATION()
        { }

        public SSP_MST_WAX_ALLOCATION(SSP_TMP_WAX_ALLOCATION data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_WAX_ALLOCATION(string planType, string waxGroupId, string fromProductionLine, string toProductionLine, decimal percentAllocation, string startMonth, int versionNo)
        {
            PlanType = planType;
            WaxGroupId = waxGroupId;
            FromProductionLine = fromProductionLine;
            ToProductionLine = toProductionLine;
            PercentAllocation = percentAllocation;
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