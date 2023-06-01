﻿using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_PolymerPrice")]
    public class SSP_MST_POLYMER_PRICE
    {
        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(10)]
        public string InputM1 { get; set; }

        [Key]
        [StringLength(50)]
        public string VersionName { get; set; }

        [Key]
        [StringLength(50)]
        public string MarketGroup { get; set; }

        [Key]
        [StringLength(10)]
        public string MonthNo { get; set; }

        [StringLength(10)]
        public string MonthIndex { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal Price { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [Key]
        public int VersionNo { get; set; }

        //[Key]
        [StringLength(1)]
        public string DeletedFlag { get; set; }

        [StringLength(50)]
        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public SSP_MST_POLYMER_PRICE()
        { }

        public SSP_MST_POLYMER_PRICE(SSP_TMP_POLYMER_PRICE data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_POLYMER_PRICE(string planType, string inputM1, string versionName, string marketGroup, string monthNo, string monthIndex,
            decimal price, string createdBy, DateTime createdDate, int versionNo, string deletedFlag, string? deletedBy, DateTime? deletedDate)
        {
            PlanType = planType;
            InputM1 = inputM1;
            VersionName = versionName;
            MarketGroup = marketGroup;
            MonthNo = monthNo;
            MonthIndex = monthIndex;
            Price = price;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            VersionNo = versionNo;
            DeletedFlag = deletedFlag;
            DeletedBy = deletedBy;
            DeletedDate = deletedDate;

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