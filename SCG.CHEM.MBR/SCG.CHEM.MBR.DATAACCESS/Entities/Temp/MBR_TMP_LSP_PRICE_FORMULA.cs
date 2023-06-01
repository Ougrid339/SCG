using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Temp
{
    [Table("MBR_TMP_LSPPriceFormula")]
    public class MBR_TMP_LSP_PRICE_FORMULA : BaseMasterContext
    {
        [StringLength(40)]
        public string ProductCode { get; set; }

        [StringLength(50)]
        public string ProductShortName { get; set; }

        [StringLength(50)]
        public string? ProductDescription { get; set; }

        [Key]
        [StringLength(50)]
        public string FormulaName { get; set; }

        [StringLength(250)]
        public string? FormulaDescription { get; set; }

        [StringLength(1024)]
        public string FormulaEquation { get; set; }

        public MBR_TMP_LSP_PRICE_FORMULA()
        { }

        public MBR_TMP_LSP_PRICE_FORMULA(MBR_MST_LSP_PRICE_FORMULA data)
        {
            ObjectUtil.CopyProperties(data, this);

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public MBR_TMP_LSP_PRICE_FORMULA(string productCode, string productShortName, string productDescription
            , string formulaName, string formulaDescription, string formulaEquation, int versionNo)
        {
            this.ProductCode = productCode;
            this.ProductShortName = productShortName;
            this.ProductDescription = productDescription;
            this.FormulaName = formulaName;
            this.FormulaDescription = formulaDescription;
            this.FormulaEquation = formulaEquation;
            this.VersionNo = versionNo;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
            this.DeletedFlag = APPCONSTANT.DELETE_FLAG.NO;
        }

        public void MarkDelete(string? userName)
        {
            if (this.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES)
            {
                this.DeletedFlag = APPCONSTANT.DELETE_FLAG.YES;
                this.DeletedBy = !String.IsNullOrEmpty(userName) ? userName : (UserUtilities.GetADAccount()?.UserId ?? "");
                this.DeletedDate = DateTime.Now;
            }
        }
    }
}