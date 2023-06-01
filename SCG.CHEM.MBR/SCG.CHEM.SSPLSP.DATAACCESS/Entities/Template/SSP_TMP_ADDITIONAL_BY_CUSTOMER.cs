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
    [Table("SSP_TMP_AdditionalByCustomer")]
    public class SSP_TMP_ADDITIONAL_BY_CUSTOMER : BaseDatabaseContext
    {
        [Key]
        [StringLength(2)]
        public string ProductionSite { get; set; }

        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(3)]
        public string MatPrefix { get; set; }

        [Key]
        [StringLength(10)]
        public string Product { get; set; }

        [Key]
        [StringLength(10)]
        public string ProductSub { get; set; }

        [Key]
        [StringLength(10)]
        public string Customer { get; set; }

        public int UnitId { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal DeliveryByCustomer { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal PackageByCustomer { get; set; }

        public SSP_TMP_ADDITIONAL_BY_CUSTOMER()
        { }

        public SSP_TMP_ADDITIONAL_BY_CUSTOMER(SSP_MST_ADDITIONAL_BY_CUSTOMER data)
        {
            ObjectUtil.CopyProperties(data, this);

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_TMP_ADDITIONAL_BY_CUSTOMER(string productionSite, string planType, string matPrefix, string product, string productSub, string customer, int unitId, decimal deliveryByCustomer, decimal packageByCustomer, string startMonth, int versionNo)
        {
            ProductionSite = productionSite;
            PlanType = planType;
            MatPrefix = matPrefix;
            Product = product;
            ProductSub = productSub;
            Customer = customer;
            UnitId = unitId;
            DeliveryByCustomer = deliveryByCustomer;
            PackageByCustomer = packageByCustomer;
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