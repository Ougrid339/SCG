using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;

namespace SCG.CHEM.MBR.MASTER.API.AppModels.Master
{
    public class MarketPriceMappingTempModel
    {
        public string? MarketPriceShortName { get; set; }
        public string? MarketPriceMI { get; set; }
        public string? MarketPriceWebPricing { get; set; }
        public string? MarketPriceName { get; set; }
        public string? EBACode { get; set; }

        public void SetModel(MarketPriceMappingTempModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }

        public MarketPriceMappingModel TryConvertToModel(out List<string> errList)
        {
            var model = new MarketPriceMappingModel();
            errList = new List<string>();

            #region Temp Variable

            bool isParsed = true;
            int tempInt;
            decimal tempDecimal;
            DateTime tempDateTime;

            #endregion Temp Variable

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.MarketPriceShortName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MarketPriceShortName"));
            }
            else
            {
                model.MarketPriceShortName = this.MarketPriceShortName;
            }

            if (String.IsNullOrEmpty(this.MarketPriceMI))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MarketPriceMI"));
            }
            else
            {
                model.MarketPriceMI = this.MarketPriceMI;
            }

            if (String.IsNullOrEmpty(this.MarketPriceWebPricing))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MarketPriceWebPricing"));
            }
            else
            {
                model.MarketPriceWebPricing = this.MarketPriceWebPricing;
            }

            if (String.IsNullOrEmpty(this.MarketPriceName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MarketPriceName"));
            }
            else
            {
                model.MarketPriceName = this.MarketPriceName;
            }

            if (String.IsNullOrEmpty(this.EBACode))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "EBACode"));
            }
            else
            {
                model.EBACode = this.EBACode;
            }

            return model;
        }

        public MarketPriceMappingModel TryConvertToModel(List<MBR_MST_FormulaParameterMapping> masterFormulaParameterMappingList, List<MBR_FCT_MARKETPRICEOLEFINS> fctMarketPriceOlefinsList, out List<string> errList)
        {
            var model = new MarketPriceMappingModel();
            errList = new List<string>();

            #region Temp Variable

            bool isParsed = true;
            int tempInt;
            decimal tempDecimal;
            DateTime tempDateTime;

            #endregion Temp Variable

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.MarketPriceShortName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MarketPriceShortName"));
            }
            else
            {
                model.MarketPriceShortName = this.MarketPriceShortName;
            }

            if (String.IsNullOrEmpty(this.MarketPriceMI))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MarketPriceMI"));
            }
            else
            {
                model.MarketPriceMI = this.MarketPriceMI;
            }

            if (String.IsNullOrEmpty(this.MarketPriceWebPricing))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MarketPriceWebPricing"));
            }
            else
            {
                model.MarketPriceWebPricing = this.MarketPriceWebPricing;
            }

            if (String.IsNullOrEmpty(this.MarketPriceName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MarketPriceName"));
            }
            else
            {
                model.MarketPriceName = this.MarketPriceName;
            }

            if (String.IsNullOrEmpty(this.EBACode))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "EBACode"));
            }
            else
            {
                model.EBACode = this.EBACode;
            }
            var containFormulaParameter = masterFormulaParameterMappingList.FirstOrDefault(s => !string.IsNullOrEmpty(this.MarketPriceWebPricing) && s.Parameter.ToLower() == this.MarketPriceWebPricing.ToLower());

            if (containFormulaParameter != null)
            {
                model.MarketPriceWebPricing = containFormulaParameter.Parameter;
            }
            else if (!string.IsNullOrEmpty(this.MarketPriceWebPricing) && this.MarketPriceWebPricing.ToLower() == "none")
            {
                model.MarketPriceWebPricing = this.MarketPriceWebPricing.ToLower();
            }
            else
            {
                errList.Add(APPCONSTANT.ERROR_MSG.ERROR_MARKET_PRICE_FOUND_DWH);
            }
            var containFctMarketPriceOlefins = fctMarketPriceOlefinsList.FirstOrDefault(s => !string.IsNullOrEmpty(this.MarketPriceName) && s.ProductWeb.ToLower() == this.MarketPriceName.ToLower());
            if (containFctMarketPriceOlefins != null)
            {
                model.MarketPriceName = containFctMarketPriceOlefins.ProductWeb;
            }
            else if (!string.IsNullOrEmpty(this.MarketPriceName) && this.MarketPriceName.ToLower() == "none")
            {
                model.MarketPriceName = this.MarketPriceName.ToLower();
            }
            else
            {
                errList.Add(APPCONSTANT.ERROR_MSG.ERROR_MARKET_PRICE_NAME_FOUND_DWH);
            }
            return model;
        }
    }

    public class MarketPriceMappingModel
    {
        public string MarketPriceShortName { get; set; }
        public string MarketPriceMI { get; set; }
        public string MarketPriceWebPricing { get; set; }
        public string MarketPriceName { get; set; }
        public string EBACode { get; set; }

        public void SetModel(MarketPriceMappingModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }
    }

    public class ValidateMarketPriceMappingTempModel : MarketPriceMappingTempModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();
    }

    public class ValidateMarketPriceMappingModel : MarketPriceMappingModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();
    }
}