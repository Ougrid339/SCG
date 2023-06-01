using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_TariffDestinationDeliveryCost")]
    public class SSP_MST_TARIFF_DESTINATION_DELIVERY_COST : BaseDatabaseContext
    {
        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(2)]
        public string ProductionSite { get; set; }

        [Key]
        [StringLength(10)]
        public string Region { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal TariffCost { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal ADTCost { get; set; }

        [Key]
        [StringLength(50)]
        public string Product { get; set; }

        [Key]
        [StringLength(50)]
        public string ProductSub { get; set; }

        public SSP_MST_TARIFF_DESTINATION_DELIVERY_COST()
        { }

        public SSP_MST_TARIFF_DESTINATION_DELIVERY_COST(SSP_TMP_TARIFF_DESTINATION_DELIVERY_COST data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_TARIFF_DESTINATION_DELIVERY_COST(string planType, string productionSite, string region, decimal tariffCost, decimal aDTCost, string product, string productSub, string startMonth, int versionNo)
        {
            PlanType = planType;
            ProductionSite = productionSite;
            Region = region;
            TariffCost = tariffCost;
            ADTCost = aDTCost;
            Product = product;
            ProductSub = productSub;
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