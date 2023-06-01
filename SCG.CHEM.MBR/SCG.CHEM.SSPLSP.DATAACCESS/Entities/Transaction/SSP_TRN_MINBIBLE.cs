using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction
{
    [Table("SSP_TRN_Minbible")]
    public class SSP_TRN_MINBIBLE : BaseContext
    {
        [Key]
        [StringLength(50)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(50)]
        public string StartMonth { get; set; }

        [StringLength(50)]
        public string EndMonth { get; set; }

        [Key]
        public int ScenarioId { get; set; }

        [StringLength(50)]
        public string ScenarioDesc { get; set; }

        [Key]
        [StringLength(50)]
        public string CustomerCode { get; set; }

        [StringLength(500)]
        public string CustomerName { get; set; }

        [Key]
        [StringLength(2)]
        public string Channel { get; set; }

        [StringLength(4)]
        public string? MatPrefix { get; set; }

        [StringLength(50)]
        public string? Grade { get; set; }

        [StringLength(50)]
        public string? Package { get; set; }

        [Key]
        [StringLength(50)]
        public string MatCodeMst { get; set; }

        [Key]
        [StringLength(50)]
        public string MatCodeTrn { get; set; }

        [StringLength(50)]
        public string? MatGroup { get; set; }

        [StringLength(50)]
        public string? Product { get; set; }

        [StringLength(50)]
        public string? ProductSub { get; set; }

        public int UnitId { get; set; }

        [Key]
        [StringLength(50)]
        public string Unit { get; set; }

        [Key]
        public int NewProductId { get; set; }

        [StringLength(50)]
        public string? NewProductDesc { get; set; }

        [Key]
        [StringLength(50)]
        public string SalesGroupCode { get; set; }

        [StringLength(255)]
        public string? SalesGroupName { get; set; }

        [Key]
        [StringLength(50)]
        public string PlanningGroup { get; set; }

        [Key]
        [StringLength(50)]
        public string Region { get; set; }

        [Key]
        [StringLength(50)]
        public string ReqProductSite { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? Qty { get; set; }

        [StringLength(20)]
        public string? HVACode { get; set; }

        [StringLength(100)]
        public string? HVAName { get; set; }

        [Key]
        public int VersionNo { get; set; }

        public DateTime? ProcessDate { get; set; }

        [StringLength(1)]
        public string? DeletedFlag { get; set; }

        [StringLength(50)]
        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public SSP_TRN_MINBIBLE(string planType, string startMonth, string endMonth, int scenarioId, string scenarioDesc, string customerCode, string customerName, string channel, string matPrefix, string grade, string package, string matCodeMst, string matCodeTrn, string matGroup, string product, string productSub, int unitId, string unit, int newProductId, string newProductDesc, string salesGroupCode, string salesGroupName, string planningGroup, string region, string reqProductSite, decimal? qty, string hVACode, string hVAName, int versionNo)
        {
            PlanType = planType;
            StartMonth = startMonth;
            EndMonth = endMonth;
            ScenarioId = scenarioId;
            ScenarioDesc = scenarioDesc;
            CustomerCode = customerCode;
            CustomerName = customerName;
            Channel = channel;
            MatPrefix = matPrefix;
            Grade = grade;
            Package = package;
            MatCodeMst = matCodeMst;
            MatCodeTrn = matCodeTrn;
            MatGroup = matGroup;
            Product = product;
            ProductSub = productSub;
            UnitId = unitId;
            Unit = unit;
            NewProductId = newProductId;
            NewProductDesc = newProductDesc;
            SalesGroupCode = salesGroupCode;
            SalesGroupName = salesGroupName;
            PlanningGroup = planningGroup;
            Region = region;
            ReqProductSite = reqProductSite;
            Qty = qty;
            HVACode = hVACode;
            HVAName = hVAName;
            VersionNo = versionNo;

            ProcessDate = DateTime.Now;

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