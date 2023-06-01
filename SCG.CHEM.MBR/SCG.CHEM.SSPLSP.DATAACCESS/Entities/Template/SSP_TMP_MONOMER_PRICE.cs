using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template
{
    [Table("SSP_TMP_MonomerPrice")]
    public class SSP_TMP_MONOMER_PRICE
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
        public string Monomer { get; set; }

        [Key]
        public int PriceUnitId { get; set; }

        [Key]
        [StringLength(10)]
        public string MonthNo { get; set; }

        [StringLength(10)]
        public string MonthIndex { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal Price { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [Key]
        public int VersionNo { get; set; }

        [Key]
        [StringLength(1)]
        public string DeletedFlag { get; set; }

        [StringLength(50)]
        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public SSP_TMP_MONOMER_PRICE()
        { }

        public SSP_TMP_MONOMER_PRICE(SSP_MST_MONOMER_PRICE data)
        {
            ObjectUtil.CopyProperties(data, this);

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_TMP_MONOMER_PRICE(string planType, string inputM1, string versionName, string monomer, int priceUnitId, string monthNo, string monthIndex, decimal price, int versionNo)
        {
            this.PlanType = planType;
            this.InputM1 = inputM1;
            this.VersionName = versionName;
            this.Monomer = monomer;
            this.PriceUnitId = priceUnitId;
            this.MonthNo = monthNo;
            this.MonthIndex = monthIndex;
            this.Price = price;

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