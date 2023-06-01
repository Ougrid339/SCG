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
    [Table("SSP_MST_OperationCharge")]
    public class SSP_MST_OPERATION_CHARGE : BaseDatabaseContext
    {
        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(10)]
        public string Product { get; set; }

        [Key]
        [StringLength(10)]
        public string ProductSub { get; set; }

        [Key]
        [StringLength(2)]
        public string ChannelCode { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal Discount { get; set; }

        public int DiscountUnitId { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal Tax { get; set; }

        public int TaxUnitId { get; set; }

        [Key]
        [StringLength(4)]
        public string SourceCompany { get; set; }

        [Key]
        [StringLength(4)]
        public string SalesOrg { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal OC { get; set; }

        public int OCUnit { get; set; }

        public SSP_MST_OPERATION_CHARGE()
        { }

        public SSP_MST_OPERATION_CHARGE(SSP_TMP_OPERATION_CHARGE data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_OPERATION_CHARGE(string planType, string product, string productSub, string channelCode, decimal discount, int discountUnitId,
            decimal tax, int taxUnitId, string sourceCompany, string salesOrg, decimal oC, int oCUnit, string startMonth, int versionNo)
        {
            PlanType = planType;
            Product = product;
            ProductSub = productSub;
            ChannelCode = channelCode;
            Discount = discount;
            DiscountUnitId = discountUnitId;
            Tax = tax;
            TaxUnitId = taxUnitId;
            SourceCompany = sourceCompany;
            SalesOrg = salesOrg;
            OC = oC;
            OCUnit = oCUnit;
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