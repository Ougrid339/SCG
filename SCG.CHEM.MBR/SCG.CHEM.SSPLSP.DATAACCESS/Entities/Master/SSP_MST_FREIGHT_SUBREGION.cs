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
    [Table("SSP_MST_FreightSubRegion")]
    public class SSP_MST_FREIGHT_SUBREGION : BaseDatabaseContext
    {
        [Key]
        [StringLength(2)]
        public string ProductionSite { get; set; }

        [Key]
        [StringLength(10)]
        public string RegionCode { get; set; }

        [Key]
        [StringLength(10)]
        public string SubRegion { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal FreightGap { get; set; }

        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        public SSP_MST_FREIGHT_SUBREGION()
        { }

        public SSP_MST_FREIGHT_SUBREGION(SSP_TMP_FREIGHT_SUBREGION data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_FREIGHT_SUBREGION(string productionSite, string regionCode, string subRegion, decimal freightGap, string planType, string startMonth, int versionNo)
        {
            ProductionSite = productionSite;
            RegionCode = regionCode;
            SubRegion = subRegion;
            FreightGap = freightGap;
            PlanType = planType;
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