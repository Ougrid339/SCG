using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;

namespace SCG.CHEM.MBR.MASTER.API.AppModels.Master
{
    public class CustomerVendorMappingTempModel
    {
        public string? CustomerShortName { get; set; }
        public string? Type { get; set; }
        public string? CustomerCode { get; set; }
        public string? SourceSystem { get; set; }

        public void SetModel(CustomerVendorMappingTempModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }

        public CustomerVendorMappingModel TryConvertToModel(out List<string> errList)
        {
            var model = new CustomerVendorMappingModel();
            errList = new List<string>();

            #region Temp Variable

            bool isParsed = true;
            int tempInt;
            decimal tempDecimal;
            DateTime tempDateTime;

            #endregion Temp Variable

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.CustomerShortName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "CustomerShortName"));
            }
            else
            {
                model.CustomerShortName = this.CustomerShortName;
            }

            if (String.IsNullOrEmpty(this.Type))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Type"));
            }
            else
            {
                model.Type = this.Type.ToUpper();
            }
            if (String.IsNullOrEmpty(this.CustomerCode))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "CustomerCode"));
            }
            else
            {
                model.CustomerCode = this.CustomerCode.PadLeft(10, '0');
            }

            if (String.IsNullOrEmpty(this.SourceSystem))
            {
                model.SourceSystem = this.SourceSystem;
            }
            else
            {
                model.SourceSystem = this.SourceSystem.ToUpper();
            }

            return model;
        }
    }

    public class CustomerVendorMappingModel
    {
        public string CustomerShortName { get; set; }
        public string Type { get; set; }
        public string CustomerCode { get; set; }
        public string SourceSystem { get; set; }

        public void SetModel(CustomerVendorMappingModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }
    }

    public class ValidateCustomerVendorMappingTempModel : CustomerVendorMappingTempModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();
    }

    public class ValidateCustomerVendorMappingModel : CustomerVendorMappingModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();
    }
}