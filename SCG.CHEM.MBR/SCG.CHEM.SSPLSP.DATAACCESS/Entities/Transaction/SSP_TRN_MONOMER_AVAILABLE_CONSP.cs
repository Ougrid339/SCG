using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction
{
    [Table("SSP_TRN_MonomerAvailableConsp")]
    public class SSP_TRN_MONOMER_AVAILABLE_CONSP : BaseContext
    {
        [Key]
        [StringLength(50)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(50)]
        public string VersionName { get; set; }

        [Key]
        public int MonomerType { get; set; }

        [StringLength(4)]
        public string CompanyCode { get; set; }

        [Key]
        [StringLength(20)]
        public string MatCodeMst { get; set; }

        [Key]
        [StringLength(50)]
        public string DataPart { get; set; }

        [Key]
        [StringLength(50)]
        public string Tier { get; set; }

        [Key]
        public int PriceUnitId { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? Qty { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? Price { get; set; }

        [Key]
        [StringLength(10)]
        public string InputM1 { get; set; }

        [StringLength(10)]
        public string MonthIndex { get; set; }

        [Key]
        [StringLength(10)]
        public string MonthNo { get; set; }

        [Key]
        public int VersionNo { get; set; }

        [StringLength(1)]
        public string DeletedFlag { get; set; }

        [StringLength(50)]
        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public SSP_TRN_MONOMER_AVAILABLE_CONSP()
        { }

        public SSP_TRN_MONOMER_AVAILABLE_CONSP(string planType, string versionName, int monomerType, string companyCode, string matCodeMst, string dataPart, string tier, int priceUnitId, decimal? qty, decimal? price, string inputM1, string monthIndex, string monthNo, int versionNo)
        {
            PlanType = planType;
            VersionName = versionName;
            MonomerType = monomerType;
            CompanyCode = companyCode;
            MatCodeMst = matCodeMst;
            DataPart = dataPart;
            Tier = tier;
            PriceUnitId = priceUnitId;
            Qty = qty;
            Price = price;
            InputM1 = inputM1;
            MonthIndex = monthIndex;
            MonthNo = monthNo;
            VersionNo = versionNo;

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

        public void SetVersionNo(int versionNo)
        {
            this.VersionNo = versionNo;
            //this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            //this.UpdatedDate = DateTime.Now;
        }
    }
}