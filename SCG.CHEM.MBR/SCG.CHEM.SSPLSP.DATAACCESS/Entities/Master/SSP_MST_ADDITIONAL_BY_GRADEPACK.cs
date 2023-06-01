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
    [Table("SSP_MST_AdditionalByGradePack")]
    public class SSP_MST_ADDITIONAL_BY_GRADEPACK : BaseDatabaseContext
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
        [StringLength(50)]
        public string Grade { get; set; }

        [Key]
        [StringLength(20)]
        public string Package { get; set; }

        [Key]
        [StringLength(20)]
        public string ChannelGroup { get; set; }

        public int UnitId { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal DeliveryCostByGrade { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal PackageCostByGrade { get; set; }

        public SSP_MST_ADDITIONAL_BY_GRADEPACK()
        { }

        public SSP_MST_ADDITIONAL_BY_GRADEPACK(SSP_TMP_ADDITIONAL_BY_GRADEPACK data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_ADDITIONAL_BY_GRADEPACK(string productionSite, string planType, string matPrefix, string grade, string package, string channelGroup, int unitId, decimal deliveryCostByGrade, decimal packageCostByGrade, string startMonth, int versionNo)
        {
            ProductionSite = productionSite;
            PlanType = planType;
            MatPrefix = matPrefix;
            Grade = grade;
            Package = package;
            ChannelGroup = channelGroup;
            UnitId = unitId;
            DeliveryCostByGrade = deliveryCostByGrade;
            PackageCostByGrade = packageCostByGrade;
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