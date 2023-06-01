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
    [Table("SSP_MST_ManualCostRoto")]
    public class SSP_MST_MANUAL_COST_ROTO : BaseDatabaseContext
    {
        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(3)]
        public string MatPrefix { get; set; }

        [Key]
        [StringLength(50)]
        public string Product { get; set; }

        [Key]
        [StringLength(50)]
        public string ProductSub { get; set; }

        //[Key]
        //[StringLength(50)]
        //public string Application { get; set; }

        [Key]
        [StringLength(50)]
        public string ProductForm { get; set; }

        [Key]
        [StringLength(50)]
        public string ProductColor { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? STDYield { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? InventoryCost { get; set; }

        public int InventoryCostUnitId { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? MaintenanceCost { get; set; }

        public int MaintenanceCostUnitId { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? SemiVC { get; set; }

        public int SemiVCUnitId { get; set; }

        [Column(TypeName = "decimal(15,5)")]
        public decimal? FC { get; set; }

        public int FCUnitId { get; set; }

        public SSP_MST_MANUAL_COST_ROTO()
        { }

        public SSP_MST_MANUAL_COST_ROTO(SSP_TMP_MANUAL_COST_ROTO data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_MANUAL_COST_ROTO(string planType, string matPrefix, string product, string productSub, string productForm, string productColor, decimal? sTDYield, decimal? inventoryCost, int inventoryCostUnitId, decimal? maintenanceCost, int maintenanceCostUnitId, decimal? semiVC, int semiVCUnitId, decimal? fC, int fCUnitId, string startMonth, int versionNo)
        {
            PlanType = planType;
            MatPrefix = matPrefix;
            Product = product;
            ProductSub = productSub;
            //Application = application;
            ProductForm = productForm;
            ProductColor = productColor;
            STDYield = sTDYield;
            InventoryCost = inventoryCost;
            InventoryCostUnitId = inventoryCostUnitId;
            MaintenanceCost = maintenanceCost;
            MaintenanceCostUnitId = maintenanceCostUnitId;
            SemiVC = semiVC;
            SemiVCUnitId = semiVCUnitId;
            FC = fC;
            FCUnitId = fCUnitId;
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

        public void MarkDelete(string userName = null)
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