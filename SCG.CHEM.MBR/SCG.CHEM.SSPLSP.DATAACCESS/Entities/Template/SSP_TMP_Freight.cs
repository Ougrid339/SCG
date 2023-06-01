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
    [Table("SSP_TMP_Freight")]
    public class SSP_TMP_FREIGHT : BaseDatabaseContext
    {
        [Key]
        [StringLength(2)]
        public string ProductionSite { get; set; }

        [Key]
        [StringLength(2)]
        public string RegionCode { get; set; }

        public int UnitId { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal STDFreight { get; set; }

        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal FreightAmtAdjTPE { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal FreightAmtAdjLSP { get; set; }

        public SSP_TMP_FREIGHT()
        { }

        public SSP_TMP_FREIGHT(SSP_MST_FREIGHT data)
        {
            ObjectUtil.CopyProperties(data, this);

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_TMP_FREIGHT(string productionSite, string regionCode, int unitId, decimal stdFreight, string planType, decimal freightAmtAdjTPE, decimal freightAmtAdjLSP, string startMonth, int versionNo)
        {
            this.ProductionSite = productionSite;
            this.RegionCode = regionCode;
            this.UnitId = unitId;
            this.STDFreight = stdFreight;
            this.PlanType = planType;
            this.FreightAmtAdjTPE = freightAmtAdjTPE;
            this.FreightAmtAdjLSP = freightAmtAdjLSP;
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