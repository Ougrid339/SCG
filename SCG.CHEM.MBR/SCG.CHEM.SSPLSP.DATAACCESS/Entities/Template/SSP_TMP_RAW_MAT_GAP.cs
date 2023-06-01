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
    [Table("SSP_TMP_RawMatGap")]
    public class SSP_TMP_RAW_MAT_GAP : BaseDatabaseContext
    {
        [Key]
        [StringLength(2)]
        public string ProductionSite { get; set; }

        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(10)]
        public string Company { get; set; }

        [Key]
        [StringLength(20)]
        public string MatCode { get; set; }

        public int UnitId { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? GapPrice { get; set; }

        public SSP_TMP_RAW_MAT_GAP()
        { }

        public SSP_TMP_RAW_MAT_GAP(SSP_MST_RAW_MAT_GAP data)
        {
            ObjectUtil.CopyProperties(data, this);

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_TMP_RAW_MAT_GAP(string productionSite, string planType, string company, string matCode, int unitId, decimal? gapPrice, string startMonth, int versionNo)
        {
            ProductionSite = productionSite;
            PlanType = planType;
            Company = company;
            MatCode = matCode;
            UnitId = unitId;
            GapPrice = gapPrice;
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