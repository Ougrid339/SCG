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
    [Table("SSP_MST_DeliveryByZone")]
    public class SSP_MST_DELIVERY_BY_ZONE : BaseDatabaseContext
    {
        [Key]
        [StringLength(2)]
        public string ProductionSite { get; set; }

        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(10)]
        public string Zone { get; set; }

        [Key]
        [StringLength(10)]
        public string Product { get; set; }

        [Key]
        [StringLength(10)]
        public string ProductSub { get; set; }

        [Key]
        [StringLength(10)]
        public string ChannelGroup { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal AdjCost { get; set; }

        public int UnitId { get; set; }

        public SSP_MST_DELIVERY_BY_ZONE()
        { }

        public SSP_MST_DELIVERY_BY_ZONE(SSP_TMP_DELIVERY_BY_ZONE data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_DELIVERY_BY_ZONE(string productionSite, string planType, string zone, string product, string productSub, string channelGroup, decimal adjCost, int unitId, string startMonth, int versionNo)
        {
            ProductionSite = productionSite;
            PlanType = planType;
            Zone = zone;
            Product = product;
            ProductSub = productSub;
            ChannelGroup = channelGroup;
            AdjCost = adjCost;
            UnitId = unitId;
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