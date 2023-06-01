using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using System.Linq;
using System.Security.Cryptography;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo
{
    public class FeedInfoModel
    {
        public string RefNo { get; set; }
        public string Company { get; set; }
        public string MCSC { get; set; }
        public string MonthStatus { get; set; }
        public string FeedNameKey { get; set; }
        public string MaterialCode { get; set; }
        public string FeedGeoCategoryKey { get; set; }
        public string SupplierKey { get; set; }
        public string? SupplierCode { get; set; }
        public string PricingIndexKey { get; set; }
        public string PricingRefKey { get; set; }
        public string? OriginKey { get; set; }
        public string ContractSpot { get; set; }
        public string TransportationKey { get; set; }
        public string BuyerRightKey { get; set; }
        public string? PurchasingVolume { get; set; }
        public string? PurchasingPremium { get; set; }
        public string? HedgingGainLoss { get; set; }
        public string? GITStatus { get; set; }
        public string? Surveyor { get; set; }
        public string? Insurance { get; set; }
        public string? Margin { get; set; }
        public string? TR { get; set; }

        public void SetModel(FeedInfoModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }

        public FeedInfoModel TryConvertToModel(out List<string> errList)
        {
            var model = new FeedInfoModel();
            errList = new List<string>();

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.RefNo)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Ref No")); }
            else { model.RefNo = this.RefNo; }
            if (String.IsNullOrEmpty(this.Company)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Company")); } else { model.Company = this.Company; }
            if (String.IsNullOrEmpty(this.MCSC)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MCSC")); } else { model.MCSC = this.MCSC; }
            if (String.IsNullOrEmpty(this.MonthStatus)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MonthStatus")); } else { model.MonthStatus = this.MonthStatus; }
            //if (String.IsNullOrEmpty(this.FeedNameKey)){ errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "FeedNameKey")); } else { model.FeedNameKey = this.FeedNameKey; }
            //if (String.IsNullOrEmpty(this.FeedGeoCategoryKey)){ errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "FeedGeoCategoryKey")); } else { model.FeedGeoCategoryKey = this.FeedGeoCategoryKey; }
            //if (String.IsNullOrEmpty(this.SupplierKey)){ errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "SupplierKey")); } else { model.SupplierKey = this.SupplierKey; }
            if (String.IsNullOrEmpty(this.PricingIndexKey)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "PricingIndexKey")); } else { model.PricingIndexKey = this.PricingIndexKey; }
            if (String.IsNullOrEmpty(this.PricingRefKey)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "PricingRefKey")); } else { model.PricingRefKey = this.PricingRefKey; }
            //if (String.IsNullOrEmpty(this.ContractCategoryKey)){ errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "ContractCategoryKey")); } else { model.ContractCategoryKey = this.ContractCategoryKey; }
            if (String.IsNullOrEmpty(this.TransportationKey)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "TransportationKey")); } else { model.TransportationKey = this.TransportationKey; }
            if (String.IsNullOrEmpty(this.BuyerRightKey)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "BuyerRightKey")); } else { model.BuyerRightKey = this.BuyerRightKey; }

            if (String.IsNullOrEmpty(this.FeedNameKey))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "FeedNameKey"));
            }
            else
            {
                model.FeedNameKey = this.FeedNameKey;
            }
            if (String.IsNullOrEmpty(this.MaterialCode))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MaterialCode"));
            }
            else
            {
                model.MaterialCode = this.MaterialCode;
            }
            if (String.IsNullOrEmpty(this.FeedGeoCategoryKey))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "FeedGeoCategoryKey"));
            }
            else
            {
                model.FeedGeoCategoryKey = this.FeedGeoCategoryKey;
            }

            model.SupplierKey = this.SupplierKey;
            model.SupplierCode = this.SupplierCode;
            model.PricingIndexKey = this.PricingIndexKey;
            if (String.IsNullOrEmpty(this.ContractSpot))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "ContractSpot"));
            }
            else
            {
                model.ContractSpot = this.ContractSpot;
            }
            model.OriginKey = this.OriginKey;

            var PurchasingVolume = isDecimal(this.PurchasingVolume, "PurchasingVolume", errList);
            var PurchasingPremium = isDecimal(this.PurchasingPremium, "PurchasingPremium", errList);
            var HedgingGainLoss = isDecimal(this.HedgingGainLoss, "HedgingGainLoss", errList);
            var Surveyor = isDecimal(this.Surveyor, "Surveyor", errList);
            var Insurance = isDecimal(this.Insurance, "Insurance", errList);
            var Margin = isDecimal(this.Margin, "Margin", errList);
            var TR = isDecimal(this.TR, "TR", errList);

            model.OriginKey = this.OriginKey;
            model.PurchasingVolume = PurchasingVolume?.ToString() ?? "";
            model.PurchasingPremium = PurchasingPremium?.ToString() ?? "";
            model.HedgingGainLoss = HedgingGainLoss?.ToString() ?? "";
            model.GITStatus = this.GITStatus;
            model.Surveyor = Surveyor?.ToString() ?? "";
            model.Insurance = Insurance?.ToString() ?? "";
            model.Margin = Margin?.ToString() ?? "";
            model.TR = TR?.ToString() ?? "";

            return model;
        }

        public FeedInfoModel TryConvertToModel(List<MRB_TRN_FEED_INFO>? existingData, List<MBR_MST_PRODUCT_MAPPING> containProductMapping, List<MBR_MST_CUSTOMER_VENDOR_MAPPING> contaiCustomerVendorMapping, List<SSPLSP.DATAACCESS.Entities.Master.SSP_MST_COMPANY_CODE> containCompany, List<string> marketPriceMIs, List<string>? productGroup, bool isMerge, out List<string> errList, out List<string> warningList)
        {
            var model = new FeedInfoModel();
            errList = new List<string>();
            warningList = new List<string>();

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.RefNo)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Ref No")); } else { model.RefNo = this.RefNo; }
            if (String.IsNullOrEmpty(this.Company)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Company")); } else { model.Company = this.Company; }
            if (String.IsNullOrEmpty(this.MCSC)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MCSC")); } else { model.MCSC = this.MCSC; }
            if (String.IsNullOrEmpty(this.MonthStatus)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MonthStatus")); } else { model.MonthStatus = this.MonthStatus; }
            //if (String.IsNullOrEmpty(this.FeedNameKey)){ errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "FeedNameKey")); } else { model.FeedNameKey = this.FeedNameKey; }
            //if (String.IsNullOrEmpty(this.FeedGeoCategoryKey)){ errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "FeedGeoCategoryKey")); } else { model.FeedGeoCategoryKey = this.FeedGeoCategoryKey; }
            //if (String.IsNullOrEmpty(this.SupplierKey)){ errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "SupplierKey")); } else { model.SupplierKey = this.SupplierKey; }
            if (String.IsNullOrEmpty(this.PricingIndexKey)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "PricingIndexKey")); } else { model.PricingIndexKey = this.PricingIndexKey; }
            if (String.IsNullOrEmpty(this.PricingRefKey)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "PricingRefKey")); } else { model.PricingRefKey = this.PricingRefKey; }
            //if (String.IsNullOrEmpty(this.ContractCategoryKey)){ errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "ContractCategoryKey")); } else { model.ContractCategoryKey = this.ContractCategoryKey; }
            if (String.IsNullOrEmpty(this.TransportationKey)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "TransportationKey")); } else { model.TransportationKey = this.TransportationKey; }
            if (String.IsNullOrEmpty(this.BuyerRightKey)) { errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "BuyerRightKey")); } else { model.BuyerRightKey = this.BuyerRightKey; }

            //Validate Company
            SSPLSP.DATAACCESS.Entities.Master.SSP_MST_COMPANY_CODE isContainCompany = containCompany.FirstOrDefault(f => f.CompanyShortName.ToUpper() == this.Company.ToUpper());
            if (isContainCompany != null)
            {
                model.Company = isContainCompany.CompanyShortName;
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "Company"));
            }
            //Validate MCSC
            if (this.Company.ToUpper() == APPCONSTANT.COMPANY.MOC && this.MCSC.ToUpper() != APPCONSTANT.MC_SC.MC && this.MCSC.ToUpper() != APPCONSTANT.MC_SC.SC)
            {
                errList.Add(APPCONSTANT.ERROR_MSG.ERROR_MC_SC_FOUND);
            }
            else if (this.Company.ToUpper() == APPCONSTANT.COMPANY.ROC && this.MCSC.ToUpper() != APPCONSTANT.MC_SC.MC)
            {
                errList.Add(APPCONSTANT.ERROR_MSG.ERROR_MC_SC_FOUND);
            }
            else if (this.Company.ToUpper() == APPCONSTANT.COMPANY.LSP && this.MCSC.ToUpper() != APPCONSTANT.MC_SC.MC)
            {
                errList.Add(APPCONSTANT.ERROR_MSG.ERROR_MC_SC_FOUND);
            }
            // validate materialCode
            MBR_MST_PRODUCT_MAPPING isContainProductShortName = null;
            if (COMPANY.MOC == this.Company.ToUpper() || COMPANY.ROC == this.Company.ToUpper())
            {
                isContainProductShortName = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.CHEM && f.MaterialCode.ToLower() == this.MaterialCode.ToLower());
            }
            else if (COMPANY.LSP == this.Company.ToUpper())
            {
                isContainProductShortName = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.LSP && f.MaterialCode.ToLower() == this.MaterialCode.ToLower());
            }
            if (String.IsNullOrEmpty(this.MaterialCode))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MaterialCode"));
            }
            else if (isContainProductShortName != null)
            {
                //Validate ProductGroup
                if (productGroup != null && productGroup.Count > 0) // If user does not select 'ALL'
                {
                    var chk = containProductMapping.Where(w => productGroup.Select(s => s.ToLower()).Contains(w.ProductGroup.ToLower()) && w.MaterialCode.ToLower() == this.MaterialCode.ToLower()).ToList();
                    if (chk.Count == 0)
                    {
                        errList.Add($"Your input MaterialCode does not match the ProductGroup maintained in MST_ProductMapping. Please select the correct ProductGroup.");
                    }
                }
                model.MaterialCode = isContainProductShortName.MaterialCode;
                model.FeedNameKey = isContainProductShortName.ProductShortName;
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "MaterialCode"));
            }
            //Validate FeedNameKey
            //if (COMPANY.MOC == this.Company.ToUpper() || COMPANY.ROC == this.Company.ToUpper())
            //{
            //    isContainProductShortName = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.CHEM && f.ProductShortName.ToLower() == this.FeedNameKey.ToLower());
            //}
            //else if (COMPANY.LSP == this.Company.ToUpper())
            //{
            //    isContainProductShortName = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.LSP && f.ProductShortName.ToLower() == this.FeedNameKey.ToLower());
            //}
            if (String.IsNullOrEmpty(this.FeedNameKey))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "FeedNameKey"));
            }
            //else if (isContainProductShortName != null)
            //{
            //    //Validate ProductGroup
            //    if (productGroup != null && productGroup.Count > 0)
            //    {
            //        var chk = containProductMapping.Where(w => productGroup.Select(s => s.ToLower()).Contains(w.ProductGroup.ToLower()) && w.ProductShortName.ToLower() == this.FeedNameKey.ToLower()).ToList();
            //        if (chk.Count == 0)
            //        {
            //            errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_IN_FOUND, "FeedNameKey", "ProductGroup"));
            //        }
            //    }
            //    model.FeedNameKey = isContainProductShortName.ProductShortName;
            //}
            //else
            //{
            //    errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "FeedNameKey"));
            //}
            //Validate FeedGeoCategoryKey
            if (String.IsNullOrEmpty(this.FeedGeoCategoryKey))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "FeedGeoCategoryKey"));
            }
            else if (this.FeedGeoCategoryKey.ToUpper() == "DOM" || this.FeedGeoCategoryKey.ToUpper() == "IMP")
            {
                model.FeedGeoCategoryKey = this.FeedGeoCategoryKey;
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "DOM/IMP"));
            }
            //Validate SupplierKey
            MBR_MST_CUSTOMER_VENDOR_MAPPING isContainSupplierKey = null;
            if (COMPANY.MOC == this.Company.ToUpper() || COMPANY.ROC == this.Company.ToUpper())
            {
                isContainSupplierKey = contaiCustomerVendorMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.CHEM && f.CustomerShortName.ToLower() == this.SupplierKey.ToLower());
            }
            else if (COMPANY.LSP == this.Company.ToUpper())
            {
                isContainSupplierKey = contaiCustomerVendorMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.LSP && f.CustomerShortName.ToLower() == this.SupplierKey.ToLower());
            }

            if (String.IsNullOrEmpty(this.SupplierKey) || this.SupplierKey.ToLower() == "none")
            {
                model.SupplierKey = this.SupplierKey.ToLower();
                model.SupplierCode = this.SupplierKey.ToLower();
            }
            else if (isContainSupplierKey != null)
            {
                model.SupplierKey = isContainSupplierKey.CustomerShortName;
                model.SupplierCode = isContainSupplierKey.CustomerCode;
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "Supplier Key"));
            }
            ////Validate SupplierCode
            //MBR_MST_CUSTOMER_VENDOR_MAPPING isContainSupplierKey = null;
            //if (COMPANY.MOC == this.Company.ToUpper() || COMPANY.ROC == this.Company.ToUpper())
            //{
            //    isContainSupplierKey = contaiCustomerVendorMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.CHEM && f.CustomerCode.ToLower() == this.SupplierCode.ToLower());
            //}
            //else if (COMPANY.LSP == this.Company.ToUpper())
            //{
            //    isContainSupplierKey = contaiCustomerVendorMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.LSP && f.CustomerCode.ToLower() == this.SupplierCode.ToLower());
            //}

            //if (String.IsNullOrEmpty(this.SupplierCode) || this.SupplierCode.ToLower() == "none")
            //{
            //    model.SupplierKey = this.SupplierKey.ToLower();
            //    model.SupplierCode = this.SupplierCode.ToLower();
            //}
            //else if (isContainSupplierKey != null)
            //{
            //    model.SupplierKey = isContainSupplierKey.CustomerShortName;
            //    model.SupplierCode = isContainSupplierKey.CustomerCode;
            //}
            //else
            //{
            //    errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "Supplier Code"));
            //}
            //Validate PricingIndexKey
            var isContainMarketPriceMI = marketPriceMIs.FirstOrDefault(f => f.ToLower() == this.PricingIndexKey.ToLower());
            if (isContainMarketPriceMI != null)
            {
                model.PricingIndexKey = isContainMarketPriceMI;
            }
            else
            {
                errList.Add(APPCONSTANT.ERROR_MSG.ERROR_MARKET_SOURCE_FOUND);
            }
            //Validate ContractCategoryKey
            if (String.IsNullOrEmpty(this.ContractSpot))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "ContractSpot"));
            }
            else if (this.ContractSpot.ToUpper() == "CONTRACT" || this.ContractSpot.ToUpper() == "SPOT")
            {
                model.ContractSpot = this.ContractSpot;
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "Contract/Spot"));
            }

            model.OriginKey = this.OriginKey;

            var PurchasingVolume = isDecimal(this.PurchasingVolume, "PurchasingVolume", errList);
            var PurchasingPremium = isDecimal(this.PurchasingPremium, "PurchasingPremium", errList);
            var HedgingGainLoss = isDecimal(this.HedgingGainLoss, "HedgingGainLoss", errList);
            var Surveyor = isDecimal(this.Surveyor, "Surveyor", errList);
            var Insurance = isDecimal(this.Insurance, "Insurance", errList);
            var Margin = isDecimal(this.Margin, "Margin", errList);
            var TR = isDecimal(this.TR, "TR", errList);

            //merge
            if (existingData != null && existingData.Count > 0 && isMerge)
            {
                List<string> statusSame = new List<string>();
                //model.OriginKey = MergeDataString(this.OriginKey, existingData?.FirstOrDefault()?.OriginKey, "OriginKey", warningList, statusSame);
                model.PurchasingVolume = MergeData(PurchasingVolume, existingData?.FirstOrDefault()?.PurchasingVolume, "PurchasingPremium", warningList, statusSame);
                model.PurchasingPremium = MergeData(PurchasingPremium, existingData?.FirstOrDefault()?.PurchasingPremium, "PurchasingPremium", warningList, statusSame);
                model.HedgingGainLoss = MergeData(HedgingGainLoss, existingData?.FirstOrDefault()?.HedgingGainLoss, "HedgingGainLoss", warningList, statusSame);
                model.GITStatus = MergeDataString(GITStatus, existingData?.FirstOrDefault()?.GITStatus, "GITStatus", warningList, statusSame);
                model.Surveyor = MergeData(Surveyor, existingData?.FirstOrDefault()?.Surveyor, "Surveyor", warningList, statusSame);
                model.Insurance = MergeData(Insurance, existingData?.FirstOrDefault()?.Insurance, "Insurance", warningList, statusSame);
                model.Margin = MergeData(Margin, existingData?.FirstOrDefault()?.Margin, "Margin", warningList, statusSame);
                model.TR = MergeData(TR, existingData?.FirstOrDefault()?.TR, "TR", warningList, statusSame);

                //if (statusSame.Count >= Enum.GetNames(typeof(MONTH_INDEX)).Length)
                //{
                //    warningList.Add(APPCONSTANT.ERROR_MSG.ERROR_MERGE_SAME_FIELD);
                //}
            }
            else
            {
                //model.OriginKey = this.OriginKey;
                model.PurchasingVolume = this.PurchasingVolume ?? "0";
                model.PurchasingPremium = this.PurchasingPremium ?? "0";
                model.HedgingGainLoss = this.HedgingGainLoss ?? "0";
                model.GITStatus = this.GITStatus ?? "";
                model.Surveyor = this.Surveyor ?? "0";
                model.Insurance = this.Insurance ?? "0";
                model.Margin = this.Margin ?? "0";
                model.TR = this.TR ?? "0";
            }

            return model;
        }

        private string? MergeDataString(string? dataFileUpload, string? existingData, string text, List<string> errList, List<string> statusSame)
        {
            if ((dataFileUpload == "" && existingData == "") || (dataFileUpload == null && existingData == null))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_MERGE_ZERO_OR_NULL_FIELD, text, dataFileUpload.ToString() ?? "null"));
                statusSame.Add(text);
            }
            else
            {
                var mergeData = MergeString(dataFileUpload, existingData);
                string? mergeDataString = !string.IsNullOrWhiteSpace(mergeData) ? mergeData : null;
                if (!String.IsNullOrEmpty(dataFileUpload) && (dataFileUpload == mergeDataString))
                {
                    statusSame.Add(text);
                }
                if (mergeDataString == null || mergeDataString == "")
                {
                    errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_MERGE_ZERO_OR_NULL_FIELD, text, mergeData ?? "null"));
                }
                else
                {
                    return mergeData;
                }
            }
            return null;
        }

        private string? MergeString(string? dataFileUpload, string? dataExisting)
        {
            if (!String.IsNullOrEmpty(dataExisting) && (dataFileUpload == "" || dataFileUpload == null))
            {
                return dataExisting.ToString();
            }
            else if (!String.IsNullOrEmpty(dataFileUpload) && (dataExisting == "" || dataExisting == null))
            {
                return dataFileUpload.ToString();
            }
            else
            {
                return dataFileUpload?.ToString();
            }
        }

        private decimal? isDecimal(string? value, string text, List<string> errList)
        {
            decimal number;
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            else if (!decimal.TryParse(value, out number))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_CONVERT_STR_TO_DECIMAL, text));
                return null;
            }
            return number;
        }

        private string? MergeData(decimal? dataFileUpload, decimal? existingData, string text, List<string> errList, List<string> statusSame)
        {
            if ((dataFileUpload == 0 && existingData == 0) || (dataFileUpload == null && existingData == null))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_MERGE_ZERO_OR_NULL_FIELD, text, dataFileUpload.HasValue ? dataFileUpload.ToString() : "null"));
                statusSame.Add(text);
            }
            else
            {
                var mergeData = Merge(dataFileUpload, existingData);
                decimal? mergeDataDecimal = !string.IsNullOrWhiteSpace(mergeData) ? decimal.Parse(mergeData) : null;
                if (dataFileUpload.HasValue && Math.Round(dataFileUpload.Value, 5) == mergeDataDecimal || (dataFileUpload == mergeDataDecimal))
                {
                    statusSame.Add(text);
                }
                if (mergeDataDecimal == null /*|| mergeDataDecimal == 0*/)
                {
                    errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_MERGE_ZERO_OR_NULL_FIELD, text, mergeData ?? "null"));
                }
                else
                {
                    return mergeData;
                }
            }
            return null;
        }

        private string? Merge(decimal? dataFileUpload, decimal? dataExisting)
        {
            if (dataExisting.HasValue && (/*dataFileUpload == 0 || */dataFileUpload == null))
            {
                return dataExisting.ToString();
            }
            else if (dataFileUpload.HasValue && (dataExisting == 0 || dataExisting == null))
            {
                return dataFileUpload.ToString();
            }
            else
            {
                return dataFileUpload?.ToString();
            }
        }
    }

    public class FeedInfoCriteriaModel
    {
        public string PlaneType { get; set; }
        public string Case { get; set; }
        public string Cycle { get; set; }
        public List<string> Company { get; set; }
        public List<string>? FeedGeoCategoryKey { get; set; }
        public List<string>? FeedNameKey { get; set; }
        public List<string>? ProductGroup { get; set; }
        public string? MergePlaneType { get; set; }
        public string? MergeCase { get; set; }
        public string? MergeCycle { get; set; }
        public bool isMerge { get; set; }

        public void SetModel(FeedInfoCriteriaModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }
    }

    public class ValidateFeedInfoModel : FeedInfoModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();

        public ValidateFeedInfoModel()
        { }

        public ValidateFeedInfoModel(ValidateFeedInfoModel from)
        {
            this.Id = from.Id;
            this.RefNo = from.RefNo;
            this.Company = from.Company;
            this.MCSC = from.MCSC;
            this.MonthStatus = from.MonthStatus;
            this.FeedNameKey = from.FeedNameKey;
            this.MaterialCode = from.MaterialCode;
            this.FeedGeoCategoryKey = from.FeedGeoCategoryKey;
            this.SupplierKey = from.SupplierKey;
            this.SupplierCode = from.SupplierCode;
            this.PricingIndexKey = from.PricingIndexKey;
            this.PricingRefKey = from.PricingRefKey;
            this.OriginKey = from.OriginKey;
            this.ContractSpot = from.ContractSpot;
            this.TransportationKey = from.TransportationKey;
            this.BuyerRightKey = from.BuyerRightKey;
            this.PurchasingVolume = from.PurchasingVolume;
            this.PurchasingPremium = from.PurchasingPremium;
            this.HedgingGainLoss = from.HedgingGainLoss;
            this.GITStatus = from.GITStatus;
            this.Surveyor = from.Surveyor;
            this.Insurance = from.Insurance;
            this.Margin = from.Margin;
            this.TR = from.TR;
        }
    }
}