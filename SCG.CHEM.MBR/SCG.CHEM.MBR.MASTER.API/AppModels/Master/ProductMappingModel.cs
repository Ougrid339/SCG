using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;

namespace SCG.CHEM.MBR.MASTER.API.AppModels.Master
{
    public class ProductMappingTempModel
    {
        public string? ProductShortName { get; set; }
        public string? MaterialCode { get; set; }
        public string? ProductGroup { get; set; }
        public string? SourceSystem { get; set; }
        public string? ProductName { get; set; }

        public void SetModel(ProductMappingTempModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }

        public ProductMappingModel TryConvertToModel(out List<string> errList)
        {
            var model = new ProductMappingModel();
            errList = new List<string>();

            #region Temp Variable

            bool isParsed = true;
            int tempInt;
            decimal tempDecimal;
            DateTime tempDateTime;

            #endregion Temp Variable

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.ProductShortName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "ProductShortName"));
            }
            else
            {
                model.ProductShortName = this.ProductShortName;
            }

            if (String.IsNullOrEmpty(this.MaterialCode))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MaterialCode"));
            }
            else
            {
                model.MaterialCode = this.MaterialCode;
            }

            model.ProductGroup = this.ProductGroup;
            if (String.IsNullOrEmpty(this.SourceSystem))
            {
                model.SourceSystem = this.SourceSystem;
            }
            else
            {
                model.SourceSystem = this.SourceSystem.ToUpper();
            }

            if (String.IsNullOrEmpty(this.ProductName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "ProductName"));
            }
            else
            {
                model.ProductName = this.ProductName;
            }

            return model;
        }
    }

    public class ProductMappingModel
    {
        public string ProductShortName { get; set; }
        public string MaterialCode { get; set; }
        public string? ProductGroup { get; set; }
        public string SourceSystem { get; set; }
        public string ProductName { get; set; }

        public void SetModel(ProductMappingModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }
    }

    public class ValidateProductMappingTempModel : ProductMappingTempModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();
    }

    public class ValidateProductMappingModel : ProductMappingModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();
    }
}