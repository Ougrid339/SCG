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
    [Table("SSP_MST_AdditionalByPack")]
    public class SSP_MST_ADDITIONAL_BY_PACK : BaseDatabaseContext
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
        [StringLength(20)]
        public string Package { get; set; }

        [Key]
        [StringLength(20)]
        public string ChannelGroup { get; set; }

        public int UnitId { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedPackageCost { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? DeliveryCostByPack { get; set; }

        public SSP_MST_ADDITIONAL_BY_PACK()
        { }

        public SSP_MST_ADDITIONAL_BY_PACK(SSP_TMP_ADDITIONAL_BY_PACK data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_ADDITIONAL_BY_PACK(string productionSite, string planType, string matPrefix, string product, string productSub, string package, string channelGroup, int unitId, decimal adjustedPackageCost, decimal? deliveryCostByPack, string startMonth, int versionNo)
        {
            this.ProductionSite = productionSite;
            this.PlanType = planType;
            this.MatPrefix = matPrefix;
            this.Product = product;
            this.ProductSub = productSub;
            this.Package = package;
            this.ChannelGroup = channelGroup;
            this.UnitId = unitId;
            this.AdjustedPackageCost = adjustedPackageCost;
            this.DeliveryCostByPack = deliveryCostByPack;

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