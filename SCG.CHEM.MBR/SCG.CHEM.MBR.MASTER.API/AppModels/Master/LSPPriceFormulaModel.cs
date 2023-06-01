using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;

namespace SCG.CHEM.MBR.MASTER.API.AppModels.Master
{
    public class LSPPriceFormulaTempModel
    {
        public string? ProductCode { get; set; }
        public string? ProductShortName { get; set; }
        public string? ProductDescription { get; set; }
        public string? FormulaName { get; set; }
        public string? FormulaDescription { get; set; }
        public string? FormulaEquation { get; set; }

        public void SetModel(LSPPriceFormulaTempModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }

        public LSPPriceFormulaModel TryConvertToModel(out List<string> errList)
        {
            var model = new LSPPriceFormulaModel();
            errList = new List<string>();

            #region Temp Variable

            bool isParsed = true;
            int tempInt;
            decimal tempDecimal;
            DateTime tempDateTime;

            #endregion Temp Variable

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.ProductCode))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "ProductCode"));
            }
            else
            {
                model.ProductCode = this.ProductCode;
            }
            if (String.IsNullOrEmpty(this.ProductShortName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "ProductShortName"));
            }
            else
            {
                model.ProductShortName = this.ProductShortName;
            }

            if (String.IsNullOrEmpty(this.FormulaName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "FormulaName"));
            }
            else
            {
                model.FormulaName = this.FormulaName;
            }

            if (String.IsNullOrEmpty(this.FormulaEquation))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "FormulaEquation"));
            }
            else
            {
                model.FormulaEquation = this.FormulaEquation;
            }
            model.ProductDescription = this.ProductDescription;
            model.FormulaDescription = this.FormulaDescription;

            return model;
        }
    }

    public class LSPPriceFormulaModel
    {
        public string ProductCode { get; set; }
        public string ProductShortName { get; set; }
        public string? ProductDescription { get; set; }
        public string FormulaName { get; set; }
        public string? FormulaDescription { get; set; }
        public string FormulaEquation { get; set; }

        public void SetModel(LSPPriceFormulaModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }
    }

    public class ValidateLSPPriceFormulaTempModel : LSPPriceFormulaTempModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();
    }

    public class ValidateLSPPriceFormulaModel : LSPPriceFormulaModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();
    }
}