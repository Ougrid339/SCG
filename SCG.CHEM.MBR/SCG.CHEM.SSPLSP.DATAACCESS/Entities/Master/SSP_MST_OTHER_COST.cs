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
    [Table("SSP_MST_OtherCost")]
    public class SSP_MST_OTHER_COST : BaseDatabaseContext
    {
        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal Payment { get; set; }

        public int PaymentUnit { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal Upfront { get; set; }

        public int UpfrontUnit { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal Kickback { get; set; }

        public int KickbackUnit { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal Insurance { get; set; }

        public int InsuranceUnit { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal TaxRefund { get; set; }

        public int TaxRefundUnit { get; set; }

        [Key]
        [StringLength(2)]
        public string Channel { get; set; }

        [Key]
        [StringLength(4)]
        public string SalesOrg { get; set; }

        public SSP_MST_OTHER_COST()
        { }

        public SSP_MST_OTHER_COST(SSP_TMP_OTHER_COST data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_OTHER_COST(string planType, decimal payment, int paymentUnit, decimal upfront, int upfrontUnit, decimal kickback, int kickbackUnit, decimal insurance, int insuranceUnit, decimal taxRefund, int taxRefundUnit, string channel, string salesOrg, string startMonth, int versionNo)
        {
            PlanType = planType;
            Payment = payment;
            PaymentUnit = paymentUnit;
            Upfront = upfront;
            UpfrontUnit = upfrontUnit;
            Kickback = kickback;
            KickbackUnit = kickbackUnit;
            Insurance = insurance;
            InsuranceUnit = insuranceUnit;
            TaxRefund = taxRefund;
            TaxRefundUnit = taxRefundUnit;
            Channel = channel;
            SalesOrg = salesOrg;
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