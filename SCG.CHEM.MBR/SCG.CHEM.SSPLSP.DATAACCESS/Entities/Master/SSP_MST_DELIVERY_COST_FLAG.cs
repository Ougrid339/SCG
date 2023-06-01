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
    [Table("SSP_MST_DeliveryCostFlag")]
    public class SSP_MST_DELIVERY_COST_FLAG : BaseDatabaseContext
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
        public string ChannelGroup { get; set; }

        [Key]
        [StringLength(10)]
        public string DeliveryMethod { get; set; }

        [StringLength(1)]
        public string DeliveryFlag { get; set; }

        public SSP_MST_DELIVERY_COST_FLAG()
        { }

        public SSP_MST_DELIVERY_COST_FLAG(SSP_TMP_DELIVERY_COST_FLAG data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_DELIVERY_COST_FLAG(string productionSite, string planType, string matPrefix, string product, string productSub, string channelGroup, string deliveryMethod, string deliveryFlag, string startMonth, int versionNo)
        {
            ProductionSite = productionSite;
            PlanType = planType;
            MatPrefix = matPrefix;
            Product = product;
            ProductSub = productSub;
            ChannelGroup = channelGroup;
            DeliveryMethod = deliveryMethod;
            DeliveryFlag = deliveryFlag;
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