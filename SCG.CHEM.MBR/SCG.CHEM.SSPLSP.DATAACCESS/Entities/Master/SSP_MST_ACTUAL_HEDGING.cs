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
    [Table("SSP_MST_ActualHedging")]
    public class SSP_MST_ACTUAL_HEDGING : BaseDatabaseContext
    {
        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(2)]
        public string ProductionSite { get; set; }

        [Key]
        [StringLength(10)]
        public string Customer { get; set; }

        [Key]
        [StringLength(3)]
        public string SalesGroup { get; set; }

        [Key]
        [StringLength(20)]
        public string MatCode { get; set; }

        public int UnitId { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal HedgeSalesPrice { get; set; }

        public SSP_MST_ACTUAL_HEDGING()
        { }

        public SSP_MST_ACTUAL_HEDGING(SSP_TMP_ACTUAL_HEDGING data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_ACTUAL_HEDGING(string planType, string productionSite, string customer, string salesGroup, string matCode, int unitId, decimal hedgeSalesPrice, string startMonth, int versionNo)
        {
            PlanType = planType;
            ProductionSite = productionSite;
            Customer = customer;
            SalesGroup = salesGroup;
            MatCode = matCode;
            UnitId = unitId;
            HedgeSalesPrice = hedgeSalesPrice;
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