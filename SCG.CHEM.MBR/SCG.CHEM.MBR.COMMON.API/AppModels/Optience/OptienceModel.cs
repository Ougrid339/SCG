using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.COMMON.API.AppModels.Optience
{
    public class OptienceData
    {
        public List<MBR_TMP_PRODUCTION_VOLUME> productionVolumeData { get; set; }
        public List<MBR_TMP_BEGINING_INVENTORY> beginningInventoryData { get; set; }
        public List<MBR_TMP_FEED_CONSUMPTION> feedConsumptionData { get; set; }
        public List<MBR_TMP_FEED_PURCHASE> feedPurchaseData { get; set; }
    }

    public class FeedPurchaseModel
    {
        public string Company { get; set; }
        public string MCSC { get; set; }
        public string FeedName { get; set; }
        public string FeedShortName { get; set; }
        public string MaterialCode { get; set; }
        public string SupplierKey { get; set; }
        public string? SupplierCode { get; set; }
        public string? ElementCode { get; set; }
        public string? M0 { get; set; }
        public string? M1 { get; set; }
        public string? M2 { get; set; }
        public string? M3 { get; set; }
        public string? M4 { get; set; }
        public string? M5 { get; set; }
        public string? M6 { get; set; }
        public string? M7 { get; set; }
        public string? M8 { get; set; }
        public string? M9 { get; set; }
        public string? M10 { get; set; }
        public string? M11 { get; set; }
        public string? M12 { get; set; }
        public string? M13 { get; set; }
        public string? M14 { get; set; }
        public string? M15 { get; set; }
        public string? M16 { get; set; }
        public string? M17 { get; set; }
        public string? M18 { get; set; }
    }

    public class FeedConsumptionModel
    {
        public string Company { get; set; }
        public string MCSC { get; set; }
        public string FeedName { get; set; }
        public string FeedShortName { get; set; }
        public string MaterialCode { get; set; }
        public string SupplierKey { get; set; }
        public string? SupplierCode { get; set; }
        public string? ElementCode { get; set; }
        public string? M0 { get; set; }
        public string? M1 { get; set; }
        public string? M2 { get; set; }
        public string? M3 { get; set; }
        public string? M4 { get; set; }
        public string? M5 { get; set; }
        public string? M6 { get; set; }
        public string? M7 { get; set; }
        public string? M8 { get; set; }
        public string? M9 { get; set; }
        public string? M10 { get; set; }
        public string? M11 { get; set; }
        public string? M12 { get; set; }
        public string? M13 { get; set; }
        public string? M14 { get; set; }
        public string? M15 { get; set; }
        public string? M16 { get; set; }
        public string? M17 { get; set; }
        public string? M18 { get; set; }
    }

    public class ProductionVolumeModel
    {
        public string Company { get; set; }
        public string MCSC { get; set; }
        public string ProductName { get; set; }
        public string ProductShortName { get; set; }
        public string MaterialCode { get; set; }
        public string? ElementCode { get; set; }
        public string? M0 { get; set; }
        public string? M1 { get; set; }
        public string? M2 { get; set; }
        public string? M3 { get; set; }
        public string? M4 { get; set; }
        public string? M5 { get; set; }
        public string? M6 { get; set; }
        public string? M7 { get; set; }
        public string? M8 { get; set; }
        public string? M9 { get; set; }
        public string? M10 { get; set; }
        public string? M11 { get; set; }
        public string? M12 { get; set; }
        public string? M13 { get; set; }
        public string? M14 { get; set; }
        public string? M15 { get; set; }
        public string? M16 { get; set; }
        public string? M17 { get; set; }
        public string? M18 { get; set; }
    }

    public class BeginningInventoryModel
    {
        public string Company { get; set; }
        public string MCSC { get; set; }

        public string? InventoryName { get; set; }
        public string? TankNumber { get; set; }
        public string ProductShortName { get; set; }
        public string MaterialCode { get; set; }
        public string SupplierKey { get; set; }
        public string? SupplierCode { get; set; }
        public string? ElementCode { get; set; }
        public string? M0 { get; set; }
    }

    public class OptienceCriteriaModel
    {
        public string Type { get; set; }
        public string Scenario { get; set; }
        public string Case { get; set; }
        public string Cycle { get; set; }
        public List<string> Company { get; set; } = new List<string>();
        public string? MergeScenario { get; set; }
        public string? MergeCase { get; set; }
        public string? MergeCycle { get; set; }
        public bool isMerge { get; set; }
    }

    public class ValidateFeedPurchaseModel : FeedPurchaseModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();

        public ValidateFeedPurchaseModel()
        { }

        public ValidateFeedPurchaseModel(ValidateFeedPurchaseModel from)
        {
            this.ElementCode = from.ElementCode;
            this.Company = from.Company;
            this.FeedName = from.FeedName;
            this.FeedShortName = from.FeedShortName;
            this.MCSC = from.MCSC;
            this.SupplierKey = from.SupplierKey;
            this.SupplierCode = from.SupplierCode;
            this.Id = from.Id;
            this.M0 = from.M0;
            this.M1 = from.M1;
            this.M2 = from.M2;
            this.M3 = from.M3;
            this.M4 = from.M4;
            this.M5 = from.M5;
            this.M6 = from.M6;
            this.M7 = from.M7;
            this.M8 = from.M8;
            this.M9 = from.M9;
            this.M10 = from.M10;
            this.M11 = from.M11;
            this.M12 = from.M12;
            this.M13 = from.M13;
            this.M14 = from.M14;
            this.M15 = from.M15;
            this.M16 = from.M16;
            this.M17 = from.M17;
            this.M18 = from.M18;
        }

        internal FeedPurchaseModel TryConvertToModel(out List<string>? errList)
        {
            var model = new FeedPurchaseModel();
            errList = new List<string>();

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.Company))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Company"));
            }
            else
            {
                model.Company = this.Company;
            }

            if (String.IsNullOrEmpty(this.MCSC))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MC/SC"));
            }
            else
            {
                model.MCSC = this.MCSC;
            }
            if (String.IsNullOrEmpty(this.FeedName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Feed Name"));
            }
            else
            {
                model.FeedName = this.FeedName;
            }

            //FeedShortName

            if (String.IsNullOrEmpty(this.FeedShortName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Feed Short Name"));
            }
            else
            {
                model.FeedShortName = this.FeedShortName;
            }
            if (String.IsNullOrEmpty(this.MaterialCode))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MaterialCode"));
            }
            else
            {
                model.MaterialCode = this.MaterialCode;
            }

            //SupplierKey

            model.SupplierKey = this.SupplierKey.ToLower();
            //model.SupplierCode = this.SupplierCode.ToLower();

            model.ElementCode = this.ElementCode;

            var M0 = isDecimal(this.M0, "M0", errList);
            var M1 = isDecimal(this.M1, "M1", errList);
            var M2 = isDecimal(this.M2, "M2", errList);
            var M3 = isDecimal(this.M3, "M3", errList);
            var M4 = isDecimal(this.M4, "M4", errList);
            var M5 = isDecimal(this.M5, "M5", errList);
            var M6 = isDecimal(this.M6, "M6", errList);
            var M7 = isDecimal(this.M7, "M7", errList);
            var M8 = isDecimal(this.M8, "M8", errList);
            var M9 = isDecimal(this.M9, "M9", errList);
            var M10 = isDecimal(this.M10, "M10", errList);
            var M11 = isDecimal(this.M11, "M11", errList);
            var M12 = isDecimal(this.M12, "M12", errList);
            var M13 = isDecimal(this.M13, "M13", errList);
            var M14 = isDecimal(this.M14, "M14", errList);
            var M15 = isDecimal(this.M15, "M15", errList);
            var M16 = isDecimal(this.M16, "M16", errList);
            var M17 = isDecimal(this.M17, "M17", errList);
            var M18 = isDecimal(this.M18, "M18", errList);

            model.M0 = M0?.ToString() ?? "";
            model.M1 = M1?.ToString() ?? "";
            model.M2 = M2?.ToString() ?? "";
            model.M3 = M3?.ToString() ?? "";
            model.M4 = M4?.ToString() ?? "";
            model.M5 = M5?.ToString() ?? "";
            model.M6 = M6?.ToString() ?? "";
            model.M7 = M7?.ToString() ?? "";
            model.M8 = M8?.ToString() ?? "";
            model.M9 = M9?.ToString() ?? "";
            model.M10 = M10?.ToString() ?? "";
            model.M11 = M11?.ToString() ?? "";
            model.M12 = M12?.ToString() ?? "";
            model.M13 = M13?.ToString() ?? "";
            model.M14 = M14?.ToString() ?? "";
            model.M15 = M15?.ToString() ?? "";
            model.M16 = M16?.ToString() ?? "";
            model.M17 = M17?.ToString() ?? "";
            model.M18 = M18?.ToString() ?? "";

            return model;
        }

        internal FeedPurchaseModel TryConvertToFeedPurchaseModel(List<MBR_TRN_FEED_PURCHASE>? existingData, List<MBR_MST_PRODUCT_MAPPING> containProductMapping, List<MBR_MST_CUSTOMER_VENDOR_MAPPING> contaiCustomerVendorMapping, List<SSPLSP.DATAACCESS.Entities.Master.SSP_MST_COMPANY_CODE> containCompany, bool isMerge, bool isZero, out List<string>? errList, out List<string>? warningList)
        {
            var model = new FeedPurchaseModel();
            errList = new List<string>();
            warningList = new List<string>();

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.Company))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Company"));
            }

            if (String.IsNullOrEmpty(this.MCSC))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MC/SC"));
            }
            else
            {
                model.MCSC = this.MCSC;
            }
            if (String.IsNullOrEmpty(this.FeedName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Feed Name"));
            }
            else
            {
                model.FeedName = this.FeedName;
            }

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

            SSPLSP.DATAACCESS.Entities.Master.SSP_MST_COMPANY_CODE isContainCompany = containCompany.FirstOrDefault(f => f.CompanyShortName.ToUpper() == this.Company.ToUpper());
            if (isContainCompany != null)
            {
                model.Company = isContainCompany.CompanyShortName;
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "Company"));
            }
            // Material Code
            MBR_MST_PRODUCT_MAPPING isContainFeedShortName = null;
            if (COMPANY.MOC == this.Company.ToUpper() || COMPANY.ROC == this.Company.ToUpper())
            {
                isContainFeedShortName = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.CHEM && f.MaterialCode.ToLower() == this.MaterialCode.ToLower());
            }
            else if (COMPANY.LSP == this.Company.ToUpper())
            {
                isContainFeedShortName = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.LSP && f.MaterialCode.ToLower() == this.MaterialCode.ToLower());
            }
            if (String.IsNullOrEmpty(this.MaterialCode))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MaterialCode"));
            }
            else if (isContainFeedShortName != null)
            {
                model.MaterialCode = isContainFeedShortName.MaterialCode;
                model.FeedShortName = isContainFeedShortName.ProductShortName;
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "MaterialCode"));
            }
            ////FeedShortName
            //MBR_MST_PRODUCT_MAPPING isContainFeedShortName = null;
            //if (COMPANY.MOC == this.Company.ToUpper() || COMPANY.ROC == this.Company.ToUpper())
            //{
            //    isContainFeedShortName = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.CHEM && f.ProductShortName.ToLower() == this.FeedShortName.ToLower());
            //}
            //else if (COMPANY.LSP == this.Company.ToUpper())
            //{
            //    isContainFeedShortName = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.LSP && f.ProductShortName.ToLower() == this.FeedShortName.ToLower());
            //}
            //if (String.IsNullOrEmpty(this.FeedShortName))
            //{
            //    errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Feed Short Name"));
            //}
            //else if (isContainFeedShortName != null)
            //{
            //    model.FeedShortName = isContainFeedShortName.ProductShortName;
            //}
            //else
            //{
            //    errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "Feed Short Name"));
            //}
            //SupplierKey
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
                model.SupplierCode = "none";
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
            ////Supplier Code
            //MBR_MST_CUSTOMER_VENDOR_MAPPING isContainSupplierKey = null;
            //if (COMPANY.MOC == this.Company.ToUpper() || COMPANY.ROC == this.Company.ToUpper())
            //{
            //    isContainSupplierKey = contaiCustomerVendorMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.CHEM && f.CustomerShortName.ToLower() == this.SupplierCode.ToLower());
            //}
            //else if (COMPANY.LSP == this.Company.ToUpper())
            //{
            //    isContainSupplierKey = contaiCustomerVendorMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.LSP && f.CustomerShortName.ToLower() == this.SupplierCode.ToLower());
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
            model.ElementCode = this.ElementCode;

            var M0 = isDecimal(this.M0, "M0", errList);
            var M1 = isDecimal(this.M1, "M1", errList);
            var M2 = isDecimal(this.M2, "M2", errList);
            var M3 = isDecimal(this.M3, "M3", errList);
            var M4 = isDecimal(this.M4, "M4", errList);
            var M5 = isDecimal(this.M5, "M5", errList);
            var M6 = isDecimal(this.M6, "M6", errList);
            var M7 = isDecimal(this.M7, "M7", errList);
            var M8 = isDecimal(this.M8, "M8", errList);
            var M9 = isDecimal(this.M9, "M9", errList);
            var M10 = isDecimal(this.M10, "M10", errList);
            var M11 = isDecimal(this.M11, "M11", errList);
            var M12 = isDecimal(this.M12, "M12", errList);
            var M13 = isDecimal(this.M13, "M13", errList);
            var M14 = isDecimal(this.M14, "M14", errList);
            var M15 = isDecimal(this.M15, "M15", errList);
            var M16 = isDecimal(this.M16, "M16", errList);
            var M17 = isDecimal(this.M17, "M17", errList);
            var M18 = isDecimal(this.M18, "M18", errList);

            //merge
            if (existingData != null && isMerge)
            {
                List<string> statusSame = new List<string>();
                model.M0 = MergeData(M0, existingData?.FirstOrDefault(f => f.MonthIndex == "M0")?.Price, "M0", warningList, statusSame, isZero);
                model.M1 = MergeData(M1, existingData?.FirstOrDefault(f => f.MonthIndex == "M1")?.Price, "M1", warningList, statusSame, isZero);
                model.M2 = MergeData(M2, existingData?.FirstOrDefault(f => f.MonthIndex == "M2")?.Price, "M2", warningList, statusSame, isZero);
                model.M3 = MergeData(M3, existingData?.FirstOrDefault(f => f.MonthIndex == "M3")?.Price, "M3", warningList, statusSame, isZero);
                model.M4 = MergeData(M4, existingData?.FirstOrDefault(f => f.MonthIndex == "M4")?.Price, "M4", warningList, statusSame, isZero);
                model.M5 = MergeData(M5, existingData?.FirstOrDefault(f => f.MonthIndex == "M5")?.Price, "M5", warningList, statusSame, isZero);
                model.M6 = MergeData(M6, existingData?.FirstOrDefault(f => f.MonthIndex == "M6")?.Price, "M6", warningList, statusSame, isZero);
                model.M7 = MergeData(M7, existingData?.FirstOrDefault(f => f.MonthIndex == "M7")?.Price, "M7", warningList, statusSame, isZero);
                model.M8 = MergeData(M8, existingData?.FirstOrDefault(f => f.MonthIndex == "M8")?.Price, "M8", warningList, statusSame, isZero);
                model.M9 = MergeData(M9, existingData?.FirstOrDefault(f => f.MonthIndex == "M9")?.Price, "M9", warningList, statusSame, isZero);
                model.M10 = MergeData(M10, existingData?.FirstOrDefault(f => f.MonthIndex == "M10")?.Price, "M10", warningList, statusSame, isZero);
                model.M11 = MergeData(M11, existingData?.FirstOrDefault(f => f.MonthIndex == "M11")?.Price, "M11", warningList, statusSame, isZero);
                model.M12 = MergeData(M12, existingData?.FirstOrDefault(f => f.MonthIndex == "M12")?.Price, "M12", warningList, statusSame, isZero);
                model.M13 = MergeData(M13, existingData?.FirstOrDefault(f => f.MonthIndex == "M13")?.Price, "M13", warningList, statusSame, isZero);
                model.M14 = MergeData(M14, existingData?.FirstOrDefault(f => f.MonthIndex == "M14")?.Price, "M14", warningList, statusSame, isZero);
                model.M15 = MergeData(M15, existingData?.FirstOrDefault(f => f.MonthIndex == "M15")?.Price, "M15", warningList, statusSame, isZero);
                model.M16 = MergeData(M16, existingData?.FirstOrDefault(f => f.MonthIndex == "M16")?.Price, "M16", warningList, statusSame, isZero);
                model.M17 = MergeData(M17, existingData?.FirstOrDefault(f => f.MonthIndex == "M17")?.Price, "M17", warningList, statusSame, isZero);
                model.M18 = MergeData(M18, existingData?.FirstOrDefault(f => f.MonthIndex == "M18")?.Price, "M18", warningList, statusSame, isZero);
                if (statusSame.Count >= Enum.GetNames(typeof(MONTH_INDEX)).Length)
                {
                    warningList.Add(APPCONSTANT.ERROR_MSG.ERROR_MERGE_SAME_FIELD);
                }
            }
            else
            {
                model.M0 = this.M0;
                model.M1 = this.M1;
                model.M2 = this.M2;
                model.M3 = this.M3;
                model.M4 = this.M4;
                model.M5 = this.M5;
                model.M6 = this.M6;
                model.M7 = this.M7;
                model.M8 = this.M8;
                model.M9 = this.M9;
                model.M10 = this.M10;
                model.M11 = this.M11;
                model.M12 = this.M12;
                model.M13 = this.M13;
                model.M14 = this.M14;
                model.M15 = this.M15;
                model.M16 = this.M16;
                model.M17 = this.M17;
                model.M18 = this.M18;
            }

            return model;
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

        private string? MergeData(decimal? dataFileUpload, decimal? existingData, string text, List<string> errList, List<string> statusSame, bool isZero)
        {
            if (dataFileUpload == 0 && existingData == 0)
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_MERGE_ZERO_OR_NULL_FIELD, text, dataFileUpload.ToString()));
                statusSame.Add(text);
                return dataFileUpload.ToString();
            }
            else if (dataFileUpload == null && existingData == null)
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_MERGE_ZERO_OR_NULL_FIELD, text, "null"));
                statusSame.Add(text);
            }
            else
            {
                var mergeData = Merge(dataFileUpload, existingData, isZero);
                decimal? mergeDataDecimal = !string.IsNullOrWhiteSpace(mergeData) ? decimal.Parse(mergeData) : null;
                if (dataFileUpload.HasValue && Math.Round(dataFileUpload.Value, 5) == mergeDataDecimal || (dataFileUpload == mergeDataDecimal))
                {
                    statusSame.Add(text);
                }
                if (mergeDataDecimal == null || mergeDataDecimal == 0 && !isZero)
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

        private string? Merge(decimal? dataFileUpload, decimal? dataExisting, bool isZero)
        {
            if (dataExisting.HasValue && ((dataFileUpload == 0 && !isZero) || dataFileUpload == null))
            {
                return dataExisting.ToString();
            }
            else if (dataFileUpload.HasValue && ((dataExisting == 0 && !isZero) || dataExisting == null))
            {
                return dataFileUpload.ToString();
            }
            else
            {
                return dataFileUpload?.ToString();
            }
        }

        public void SetModel(FeedPurchaseModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }
    }

    public class ValidateFeedConsumptionModel : FeedConsumptionModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();

        public ValidateFeedConsumptionModel()
        { }

        public ValidateFeedConsumptionModel(ValidateFeedConsumptionModel from)
        {
            this.ElementCode = from.ElementCode;
            this.Company = from.Company;
            this.FeedName = from.FeedName;
            this.FeedShortName = from.FeedShortName;
            this.MCSC = from.MCSC;
            this.SupplierKey = from.SupplierKey;
            this.SupplierCode = from.SupplierCode;
            this.Id = from.Id;
            this.M0 = from.M0;
            this.M1 = from.M1;
            this.M2 = from.M2;
            this.M3 = from.M3;
            this.M4 = from.M4;
            this.M5 = from.M5;
            this.M6 = from.M6;
            this.M7 = from.M7;
            this.M8 = from.M8;
            this.M9 = from.M9;
            this.M10 = from.M10;
            this.M11 = from.M11;
            this.M12 = from.M12;
            this.M13 = from.M13;
            this.M14 = from.M14;
            this.M15 = from.M15;
            this.M16 = from.M16;
            this.M17 = from.M17;
            this.M18 = from.M18;
        }

        internal FeedConsumptionModel TryConvertToModel(out List<string>? errList)
        {
            var model = new FeedConsumptionModel();
            errList = new List<string>();

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.Company))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Company"));
            }
            else
            {
                model.Company = this.Company;
            }
            if (String.IsNullOrEmpty(this.MCSC))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MC/SC"));
            }
            else
            {
                model.MCSC = this.MCSC;
            }

            if (String.IsNullOrEmpty(this.FeedName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Feed Name"));
            }
            else
            {
                model.FeedName = this.FeedName;
            }
            if (String.IsNullOrEmpty(this.FeedShortName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Feed Short Name"));
            }
            else
            {
                model.FeedShortName = this.FeedShortName;
            }
            if (String.IsNullOrEmpty(this.MaterialCode))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MaterialCode"));
            }
            else
            {
                model.MaterialCode = this.MaterialCode;
            }

            model.SupplierKey = this.SupplierKey.ToLower();
            //model.SupplierCode = this.SupplierCode.ToLower();
            model.ElementCode = this.ElementCode;
            var M0 = isDecimal(this.M0, "M0", errList);
            var M1 = isDecimal(this.M1, "M1", errList);
            var M2 = isDecimal(this.M2, "M2", errList);
            var M3 = isDecimal(this.M3, "M3", errList);
            var M4 = isDecimal(this.M4, "M4", errList);
            var M5 = isDecimal(this.M5, "M5", errList);
            var M6 = isDecimal(this.M6, "M6", errList);
            var M7 = isDecimal(this.M7, "M7", errList);
            var M8 = isDecimal(this.M8, "M8", errList);
            var M9 = isDecimal(this.M9, "M9", errList);
            var M10 = isDecimal(this.M10, "M10", errList);
            var M11 = isDecimal(this.M11, "M11", errList);
            var M12 = isDecimal(this.M12, "M12", errList);
            var M13 = isDecimal(this.M13, "M13", errList);
            var M14 = isDecimal(this.M14, "M14", errList);
            var M15 = isDecimal(this.M15, "M15", errList);
            var M16 = isDecimal(this.M16, "M16", errList);
            var M17 = isDecimal(this.M17, "M17", errList);
            var M18 = isDecimal(this.M18, "M18", errList);

            model.M0 = M0?.ToString() ?? "";
            model.M1 = M1?.ToString() ?? "";
            model.M2 = M2?.ToString() ?? "";
            model.M3 = M3?.ToString() ?? "";
            model.M4 = M4?.ToString() ?? "";
            model.M5 = M5?.ToString() ?? "";
            model.M6 = M6?.ToString() ?? "";
            model.M7 = M7?.ToString() ?? "";
            model.M8 = M8?.ToString() ?? "";
            model.M9 = M9?.ToString() ?? "";
            model.M10 = M10?.ToString() ?? "";
            model.M11 = M11?.ToString() ?? "";
            model.M12 = M12?.ToString() ?? "";
            model.M13 = M13?.ToString() ?? "";
            model.M14 = M14?.ToString() ?? "";
            model.M15 = M15?.ToString() ?? "";
            model.M16 = M16?.ToString() ?? "";
            model.M17 = M17?.ToString() ?? "";
            model.M18 = M18?.ToString() ?? "";

            return model;
        }

        internal FeedConsumptionModel TryConvertToFeedConsumptionModel(List<MBR_TRN_FEED_CONSUMPTION>? existingData, List<MBR_MST_PRODUCT_MAPPING> containProductMapping, List<MBR_MST_CUSTOMER_VENDOR_MAPPING> contaiCustomerVendorMapping, List<SSPLSP.DATAACCESS.Entities.Master.SSP_MST_COMPANY_CODE> containCompany, bool isMerge, bool isZero, out List<string>? errList, out List<string>? warningList)
        {
            var model = new FeedConsumptionModel();
            errList = new List<string>();
            warningList = new List<string>();

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.Company))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Company"));
            }
            if (String.IsNullOrEmpty(this.MCSC))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MC/SC"));
            }
            else
            {
                model.MCSC = this.MCSC;
            }

            if (String.IsNullOrEmpty(this.FeedName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Feed Name"));
            }
            else
            {
                model.FeedName = this.FeedName;
            }

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

            SSPLSP.DATAACCESS.Entities.Master.SSP_MST_COMPANY_CODE isContainCompany = containCompany.FirstOrDefault(f => f.CompanyShortName.ToUpper() == this.Company.ToUpper());
            if (isContainCompany != null)
            {
                model.Company = isContainCompany.CompanyShortName;
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "Company"));
            }

            MBR_MST_PRODUCT_MAPPING isContainFeedShortName = null;
            if (COMPANY.MOC == this.Company.ToUpper() || COMPANY.ROC == this.Company.ToUpper())
            {
                isContainFeedShortName = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.CHEM && f.MaterialCode.ToLower() == this.MaterialCode.ToLower());
            }
            else if (COMPANY.LSP == this.Company.ToUpper())
            {
                isContainFeedShortName = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.LSP && f.MaterialCode.ToLower() == this.MaterialCode.ToLower());
            }
            if (String.IsNullOrEmpty(this.MaterialCode))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MaterialCode"));
            }
            else if (isContainFeedShortName != null)
            {
                model.FeedShortName = isContainFeedShortName.ProductShortName;
                model.MaterialCode = isContainFeedShortName.MaterialCode;
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "MaterialCode"));
            }
            //MBR_MST_PRODUCT_MAPPING isContainFeedShortName = null;
            //if (COMPANY.MOC == this.Company.ToUpper() || COMPANY.ROC == this.Company.ToUpper())
            //{
            //    isContainFeedShortName = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.CHEM && f.ProductShortName.ToLower() == this.FeedShortName.ToLower());
            //}
            //else if (COMPANY.LSP == this.Company.ToUpper())
            //{
            //    isContainFeedShortName = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.LSP && f.ProductShortName.ToLower() == this.FeedShortName.ToLower());
            //}
            //if (String.IsNullOrEmpty(this.FeedShortName))
            //{
            //    errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Feed Short Name"));
            //}
            //else if (isContainFeedShortName != null)
            //{
            //    model.FeedShortName = isContainFeedShortName.ProductShortName;
            //}
            //else
            //{
            //    errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "Feed Short Name"));
            //}
            ////Supplier Code
            //MBR_MST_CUSTOMER_VENDOR_MAPPING isContainSupplierKey = null;
            //if (COMPANY.MOC == this.Company.ToUpper() || COMPANY.ROC == this.Company.ToUpper())
            //{
            //    isContainSupplierKey = contaiCustomerVendorMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.CHEM && f.CustomerShortName.ToLower() == this.SupplierCode.ToLower());
            //}
            //else if (COMPANY.LSP == this.Company.ToUpper())
            //{
            //    isContainSupplierKey = contaiCustomerVendorMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.LSP && f.CustomerShortName.ToLower() == this.SupplierCode.ToLower());
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
            //SupplierKey
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
                model.SupplierCode = "none";
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
            model.ElementCode = this.ElementCode;
            var M0 = isDecimal(this.M0, "M0", errList);
            var M1 = isDecimal(this.M1, "M1", errList);
            var M2 = isDecimal(this.M2, "M2", errList);
            var M3 = isDecimal(this.M3, "M3", errList);
            var M4 = isDecimal(this.M4, "M4", errList);
            var M5 = isDecimal(this.M5, "M5", errList);
            var M6 = isDecimal(this.M6, "M6", errList);
            var M7 = isDecimal(this.M7, "M7", errList);
            var M8 = isDecimal(this.M8, "M8", errList);
            var M9 = isDecimal(this.M9, "M9", errList);
            var M10 = isDecimal(this.M10, "M10", errList);
            var M11 = isDecimal(this.M11, "M11", errList);
            var M12 = isDecimal(this.M12, "M12", errList);
            var M13 = isDecimal(this.M13, "M13", errList);
            var M14 = isDecimal(this.M14, "M14", errList);
            var M15 = isDecimal(this.M15, "M15", errList);
            var M16 = isDecimal(this.M16, "M16", errList);
            var M17 = isDecimal(this.M17, "M17", errList);
            var M18 = isDecimal(this.M18, "M18", errList);

            //merge
            if (existingData != null && isMerge)
            {
                List<string> statusSame = new List<string>();
                model.M0 = MergeData(M0, existingData?.FirstOrDefault(f => f.MonthIndex == "M0")?.Price, "M0", warningList, statusSame, isZero);
                model.M1 = MergeData(M1, existingData?.FirstOrDefault(f => f.MonthIndex == "M1")?.Price, "M1", warningList, statusSame, isZero);
                model.M2 = MergeData(M2, existingData?.FirstOrDefault(f => f.MonthIndex == "M2")?.Price, "M2", warningList, statusSame, isZero);
                model.M3 = MergeData(M3, existingData?.FirstOrDefault(f => f.MonthIndex == "M3")?.Price, "M3", warningList, statusSame, isZero);
                model.M4 = MergeData(M4, existingData?.FirstOrDefault(f => f.MonthIndex == "M4")?.Price, "M4", warningList, statusSame, isZero);
                model.M5 = MergeData(M5, existingData?.FirstOrDefault(f => f.MonthIndex == "M5")?.Price, "M5", warningList, statusSame, isZero);
                model.M6 = MergeData(M6, existingData?.FirstOrDefault(f => f.MonthIndex == "M6")?.Price, "M6", warningList, statusSame, isZero);
                model.M7 = MergeData(M7, existingData?.FirstOrDefault(f => f.MonthIndex == "M7")?.Price, "M7", warningList, statusSame, isZero);
                model.M8 = MergeData(M8, existingData?.FirstOrDefault(f => f.MonthIndex == "M8")?.Price, "M8", warningList, statusSame, isZero);
                model.M9 = MergeData(M9, existingData?.FirstOrDefault(f => f.MonthIndex == "M9")?.Price, "M9", warningList, statusSame, isZero);
                model.M10 = MergeData(M10, existingData?.FirstOrDefault(f => f.MonthIndex == "M10")?.Price, "M10", warningList, statusSame, isZero);
                model.M11 = MergeData(M11, existingData?.FirstOrDefault(f => f.MonthIndex == "M11")?.Price, "M11", warningList, statusSame, isZero);
                model.M12 = MergeData(M12, existingData?.FirstOrDefault(f => f.MonthIndex == "M12")?.Price, "M12", warningList, statusSame, isZero);
                model.M13 = MergeData(M13, existingData?.FirstOrDefault(f => f.MonthIndex == "M13")?.Price, "M13", warningList, statusSame, isZero);
                model.M14 = MergeData(M14, existingData?.FirstOrDefault(f => f.MonthIndex == "M14")?.Price, "M14", warningList, statusSame, isZero);
                model.M15 = MergeData(M15, existingData?.FirstOrDefault(f => f.MonthIndex == "M15")?.Price, "M15", warningList, statusSame, isZero);
                model.M16 = MergeData(M16, existingData?.FirstOrDefault(f => f.MonthIndex == "M16")?.Price, "M16", warningList, statusSame, isZero);
                model.M17 = MergeData(M17, existingData?.FirstOrDefault(f => f.MonthIndex == "M17")?.Price, "M17", warningList, statusSame, isZero);
                model.M18 = MergeData(M18, existingData?.FirstOrDefault(f => f.MonthIndex == "M18")?.Price, "M18", warningList, statusSame, isZero);
                if (statusSame.Count >= Enum.GetNames(typeof(MONTH_INDEX)).Length)
                {
                    warningList.Add(APPCONSTANT.ERROR_MSG.ERROR_MERGE_SAME_FIELD);
                }
            }
            else
            {
                model.M0 = this.M0;
                model.M1 = this.M1;
                model.M2 = this.M2;
                model.M3 = this.M3;
                model.M4 = this.M4;
                model.M5 = this.M5;
                model.M6 = this.M6;
                model.M7 = this.M7;
                model.M8 = this.M8;
                model.M9 = this.M9;
                model.M10 = this.M10;
                model.M11 = this.M11;
                model.M12 = this.M12;
                model.M13 = this.M13;
                model.M14 = this.M14;
                model.M15 = this.M15;
                model.M16 = this.M16;
                model.M17 = this.M17;
                model.M18 = this.M18;
            }

            return model;
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

        private string? MergeData(decimal? dataFileUpload, decimal? existingData, string text, List<string> errList, List<string> statusSame, bool isZero)
        {
            if (dataFileUpload == 0 && existingData == 0)
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_MERGE_ZERO_OR_NULL_FIELD, text, dataFileUpload.ToString()));
                statusSame.Add(text);
                return dataFileUpload.ToString();
            }
            else if (dataFileUpload == null && existingData == null)
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_MERGE_ZERO_OR_NULL_FIELD, text, "null"));
                statusSame.Add(text);
            }
            else
            {
                var mergeData = Merge(dataFileUpload, existingData, isZero);
                decimal? mergeDataDecimal = !string.IsNullOrWhiteSpace(mergeData) ? decimal.Parse(mergeData) : null;
                if (dataFileUpload.HasValue && Math.Round(dataFileUpload.Value, 5) == mergeDataDecimal || (dataFileUpload == mergeDataDecimal))
                {
                    statusSame.Add(text);
                }
                if (mergeDataDecimal == null || mergeDataDecimal == 0 && !isZero)
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

        private string? Merge(decimal? dataFileUpload, decimal? dataExisting, bool isZero)
        {
            if (dataExisting.HasValue && ((dataFileUpload == 0 && !isZero) || dataFileUpload == null))
            {
                return dataExisting.ToString();
            }
            else if (dataFileUpload.HasValue && ((dataExisting == 0 && !isZero) || dataExisting == null))
            {
                return dataFileUpload.ToString();
            }
            else
            {
                return dataFileUpload?.ToString();
            }
        }

        public void SetModel(FeedConsumptionModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }
    }

    public class ValidateProductionVolumeModel : ProductionVolumeModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();

        public ValidateProductionVolumeModel()
        { }

        public ValidateProductionVolumeModel(ValidateProductionVolumeModel from)
        {
            this.ElementCode = from.ElementCode;
            this.Company = from.Company;
            this.ProductName = from.ProductName;
            this.ProductShortName = from.ProductShortName;
            this.MCSC = from.MCSC;
            this.Id = from.Id;
            this.M0 = from.M0;
            this.M1 = from.M1;
            this.M2 = from.M2;
            this.M3 = from.M3;
            this.M4 = from.M4;
            this.M5 = from.M5;
            this.M6 = from.M6;
            this.M7 = from.M7;
            this.M8 = from.M8;
            this.M9 = from.M9;
            this.M10 = from.M10;
            this.M11 = from.M11;
            this.M12 = from.M12;
            this.M13 = from.M13;
            this.M14 = from.M14;
            this.M15 = from.M15;
            this.M16 = from.M16;
            this.M17 = from.M17;
            this.M18 = from.M18;
        }

        internal ProductionVolumeModel TryConvertToModel(out List<string>? errList)
        {
            var model = new ProductionVolumeModel();
            errList = new List<string>();

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.Company))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Company"));
            }
            else
            {
                model.Company = this.Company;
            }
            if (String.IsNullOrEmpty(this.MCSC))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MC/SC"));
            }
            else
            {
                model.MCSC = this.MCSC;
            }

            if (String.IsNullOrEmpty(this.ProductName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Product Name"));
            }
            else
            {
                model.ProductName = this.ProductName;
            }

            if (String.IsNullOrEmpty(this.ProductShortName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Product Short Name"));
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

            model.ElementCode = this.ElementCode;

            var M0 = isDecimal(this.M0, "M0", errList);
            var M1 = isDecimal(this.M1, "M1", errList);
            var M2 = isDecimal(this.M2, "M2", errList);
            var M3 = isDecimal(this.M3, "M3", errList);
            var M4 = isDecimal(this.M4, "M4", errList);
            var M5 = isDecimal(this.M5, "M5", errList);
            var M6 = isDecimal(this.M6, "M6", errList);
            var M7 = isDecimal(this.M7, "M7", errList);
            var M8 = isDecimal(this.M8, "M8", errList);
            var M9 = isDecimal(this.M9, "M9", errList);
            var M10 = isDecimal(this.M10, "M10", errList);
            var M11 = isDecimal(this.M11, "M11", errList);
            var M12 = isDecimal(this.M12, "M12", errList);
            var M13 = isDecimal(this.M13, "M13", errList);
            var M14 = isDecimal(this.M14, "M14", errList);
            var M15 = isDecimal(this.M15, "M15", errList);
            var M16 = isDecimal(this.M16, "M16", errList);
            var M17 = isDecimal(this.M17, "M17", errList);
            var M18 = isDecimal(this.M18, "M18", errList);
            model.M0 = M0?.ToString() ?? "";
            model.M1 = M1?.ToString() ?? "";
            model.M2 = M2?.ToString() ?? "";
            model.M3 = M3?.ToString() ?? "";
            model.M4 = M4?.ToString() ?? "";
            model.M5 = M5?.ToString() ?? "";
            model.M6 = M6?.ToString() ?? "";
            model.M7 = M7?.ToString() ?? "";
            model.M8 = M8?.ToString() ?? "";
            model.M9 = M9?.ToString() ?? "";
            model.M10 = M10?.ToString() ?? "";
            model.M11 = M11?.ToString() ?? "";
            model.M12 = M12?.ToString() ?? "";
            model.M13 = M13?.ToString() ?? "";
            model.M14 = M14?.ToString() ?? "";
            model.M15 = M15?.ToString() ?? "";
            model.M16 = M16?.ToString() ?? "";
            model.M17 = M17?.ToString() ?? "";
            model.M18 = M18?.ToString() ?? "";

            return model;
        }

        internal ProductionVolumeModel TryConvertToProductionVolumeModel(List<MBR_TRN_PRODUCTION_VOLUME>? existingData, List<MBR_MST_PRODUCT_MAPPING> containProductMapping, List<SSPLSP.DATAACCESS.Entities.Master.SSP_MST_COMPANY_CODE> containCompany, bool isMerge, bool isZero, out List<string>? errList, out List<string>? warningList)
        {
            var model = new ProductionVolumeModel();
            errList = new List<string>();
            warningList = new List<string>();

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.Company))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Company"));
            }

            if (String.IsNullOrEmpty(this.MCSC))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MC/SC"));
            }
            else
            {
                model.MCSC = this.MCSC;
            }

            if (String.IsNullOrEmpty(this.ProductName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Product Name"));
            }
            else
            {
                model.ProductName = this.ProductName;
            }

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

            //Validate Material Code
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
                model.MaterialCode = isContainProductShortName.MaterialCode;
                model.ProductShortName = isContainProductShortName.ProductShortName;
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "MaterialCode"));
            }
            ////Validate Product ShotName
            //MBR_MST_PRODUCT_MAPPING isContainProductShortName = null;
            //if (COMPANY.MOC == this.Company.ToUpper() || COMPANY.ROC == this.Company.ToUpper())
            //{
            //    isContainProductShortName = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.CHEM && f.ProductShortName.ToLower() == this.ProductShortName.ToLower());
            //}
            //else if (COMPANY.LSP == this.Company.ToUpper())
            //{
            //    isContainProductShortName = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.LSP && f.ProductShortName.ToLower() == this.ProductShortName.ToLower());
            //}
            //if (String.IsNullOrEmpty(this.ProductShortName))
            //{
            //    errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Product Short Name"));
            //}
            //else if (isContainProductShortName != null)
            //{
            //    model.ProductShortName = isContainProductShortName.ProductShortName;
            //}
            //else
            //{
            //    errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "Product Short Name"));
            //}

            model.ElementCode = this.ElementCode;

            var M0 = isDecimal(this.M0, "M0", errList);
            var M1 = isDecimal(this.M1, "M1", errList);
            var M2 = isDecimal(this.M2, "M2", errList);
            var M3 = isDecimal(this.M3, "M3", errList);
            var M4 = isDecimal(this.M4, "M4", errList);
            var M5 = isDecimal(this.M5, "M5", errList);
            var M6 = isDecimal(this.M6, "M6", errList);
            var M7 = isDecimal(this.M7, "M7", errList);
            var M8 = isDecimal(this.M8, "M8", errList);
            var M9 = isDecimal(this.M9, "M9", errList);
            var M10 = isDecimal(this.M10, "M10", errList);
            var M11 = isDecimal(this.M11, "M11", errList);
            var M12 = isDecimal(this.M12, "M12", errList);
            var M13 = isDecimal(this.M13, "M13", errList);
            var M14 = isDecimal(this.M14, "M14", errList);
            var M15 = isDecimal(this.M15, "M15", errList);
            var M16 = isDecimal(this.M16, "M16", errList);
            var M17 = isDecimal(this.M17, "M17", errList);
            var M18 = isDecimal(this.M18, "M18", errList);

            //merge
            if (existingData != null && isMerge)
            {
                List<string> statusSame = new List<string>();
                model.M0 = MergeData(M0, existingData?.FirstOrDefault(f => f.MonthIndex == "M0")?.Price, "M0", warningList, statusSame, isZero);
                model.M1 = MergeData(M1, existingData?.FirstOrDefault(f => f.MonthIndex == "M1")?.Price, "M1", warningList, statusSame, isZero);
                model.M2 = MergeData(M2, existingData?.FirstOrDefault(f => f.MonthIndex == "M2")?.Price, "M2", warningList, statusSame, isZero);
                model.M3 = MergeData(M3, existingData?.FirstOrDefault(f => f.MonthIndex == "M3")?.Price, "M3", warningList, statusSame, isZero);
                model.M4 = MergeData(M4, existingData?.FirstOrDefault(f => f.MonthIndex == "M4")?.Price, "M4", warningList, statusSame, isZero);
                model.M5 = MergeData(M5, existingData?.FirstOrDefault(f => f.MonthIndex == "M5")?.Price, "M5", warningList, statusSame, isZero);
                model.M6 = MergeData(M6, existingData?.FirstOrDefault(f => f.MonthIndex == "M6")?.Price, "M6", warningList, statusSame, isZero);
                model.M7 = MergeData(M7, existingData?.FirstOrDefault(f => f.MonthIndex == "M7")?.Price, "M7", warningList, statusSame, isZero);
                model.M8 = MergeData(M8, existingData?.FirstOrDefault(f => f.MonthIndex == "M8")?.Price, "M8", warningList, statusSame, isZero);
                model.M9 = MergeData(M9, existingData?.FirstOrDefault(f => f.MonthIndex == "M9")?.Price, "M9", warningList, statusSame, isZero);
                model.M10 = MergeData(M10, existingData?.FirstOrDefault(f => f.MonthIndex == "M10")?.Price, "M10", warningList, statusSame, isZero);
                model.M11 = MergeData(M11, existingData?.FirstOrDefault(f => f.MonthIndex == "M11")?.Price, "M11", warningList, statusSame, isZero);
                model.M12 = MergeData(M12, existingData?.FirstOrDefault(f => f.MonthIndex == "M12")?.Price, "M12", warningList, statusSame, isZero);
                model.M13 = MergeData(M13, existingData?.FirstOrDefault(f => f.MonthIndex == "M13")?.Price, "M13", warningList, statusSame, isZero);
                model.M14 = MergeData(M14, existingData?.FirstOrDefault(f => f.MonthIndex == "M14")?.Price, "M14", warningList, statusSame, isZero);
                model.M15 = MergeData(M15, existingData?.FirstOrDefault(f => f.MonthIndex == "M15")?.Price, "M15", warningList, statusSame, isZero);
                model.M16 = MergeData(M16, existingData?.FirstOrDefault(f => f.MonthIndex == "M16")?.Price, "M16", warningList, statusSame, isZero);
                model.M17 = MergeData(M17, existingData?.FirstOrDefault(f => f.MonthIndex == "M17")?.Price, "M17", warningList, statusSame, isZero);
                model.M18 = MergeData(M18, existingData?.FirstOrDefault(f => f.MonthIndex == "M18")?.Price, "M18", warningList, statusSame, isZero);
                if (statusSame.Count >= Enum.GetNames(typeof(MONTH_INDEX)).Length)
                {
                    warningList.Add(APPCONSTANT.ERROR_MSG.ERROR_MERGE_SAME_FIELD);
                }
            }
            else
            {
                model.M0 = this.M0;
                model.M1 = this.M1;
                model.M2 = this.M2;
                model.M3 = this.M3;
                model.M4 = this.M4;
                model.M5 = this.M5;
                model.M6 = this.M6;
                model.M7 = this.M7;
                model.M8 = this.M8;
                model.M9 = this.M9;
                model.M10 = this.M10;
                model.M11 = this.M11;
                model.M12 = this.M12;
                model.M13 = this.M13;
                model.M14 = this.M14;
                model.M15 = this.M15;
                model.M16 = this.M16;
                model.M17 = this.M17;
                model.M18 = this.M18;
            }

            return model;
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

        private string? MergeData(decimal? dataFileUpload, decimal? existingData, string text, List<string> errList, List<string> statusSame, bool isZero)
        {
            if (dataFileUpload == 0 && existingData == 0)
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_MERGE_ZERO_OR_NULL_FIELD, text, dataFileUpload.ToString()));
                statusSame.Add(text);
                return dataFileUpload.ToString();
            }
            else if (dataFileUpload == null && existingData == null)
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_MERGE_ZERO_OR_NULL_FIELD, text, "null"));
                statusSame.Add(text);
            }
            else
            {
                var mergeData = Merge(dataFileUpload, existingData, isZero);
                decimal? mergeDataDecimal = !string.IsNullOrWhiteSpace(mergeData) ? decimal.Parse(mergeData) : null;
                if (dataFileUpload.HasValue && Math.Round(dataFileUpload.Value, 5) == mergeDataDecimal || (dataFileUpload == mergeDataDecimal))
                {
                    statusSame.Add(text);
                }
                if (mergeDataDecimal == null || mergeDataDecimal == 0 && !isZero)
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

        private string? Merge(decimal? dataFileUpload, decimal? dataExisting, bool isZero)
        {
            if (dataExisting.HasValue && ((dataFileUpload == 0 && !isZero) || dataFileUpload == null))
            {
                return dataExisting.ToString();
            }
            else if (dataFileUpload.HasValue && ((dataExisting == 0 && !isZero) || dataExisting == null))
            {
                return dataFileUpload.ToString();
            }
            else
            {
                return dataFileUpload?.ToString();
            }
        }

        public void SetModel(ProductionVolumeModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }
    }

    public class ValidateBeginningInventoryModel : BeginningInventoryModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();

        public ValidateBeginningInventoryModel()
        { }

        public ValidateBeginningInventoryModel(ValidateBeginningInventoryModel from)
        {
            this.Company = from.Company;
            this.MCSC = from.MCSC;
            this.InventoryName = from.InventoryName;
            this.TankNumber = from.TankNumber;
            this.ProductShortName = from.ProductShortName;
            this.MaterialCode = from.MaterialCode;
            this.SupplierKey = from.SupplierKey;
            this.SupplierCode = from.SupplierCode;
            this.ElementCode = from.ElementCode;
            this.Id = from.Id;
            this.M0 = from.M0;
        }

        internal BeginningInventoryModel TryConvertToModel(out List<string>? errList)
        {
            var model = new BeginningInventoryModel();
            errList = new List<string>();

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.Company))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Company"));
            }
            else
            {
                model.Company = this.Company;
            }
            if (String.IsNullOrEmpty(this.MCSC))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MC/SC"));
            }
            else
            {
                model.MCSC = this.MCSC;
            }

            if (String.IsNullOrEmpty(this.ProductShortName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Product Short Name"));
            }
            else
            {
                model.ProductShortName = this.ProductShortName;
            }

            if (String.IsNullOrEmpty(this.MaterialCode))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Material Code"));
            }
            else
            {
                model.MaterialCode = this.MaterialCode;
            }

            if (String.IsNullOrEmpty(this.SupplierKey))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Supplier Key"));
            }
            else
            {
                model.SupplierKey = this.SupplierKey;
            }
            //model.SupplierCode = this.SupplierCode;
            var M0 = isDecimal(this.M0, "M0", errList);

            model.M0 = M0?.ToString() ?? "";

            return model;
        }

        internal BeginningInventoryModel TryConvertToBeginningInventoryModel(List<MBR_TRN_BEGINING_INVENTORY>? existingData, List<MBR_MST_PRODUCT_MAPPING> containProductMapping, List<SSPLSP.DATAACCESS.Entities.Master.SSP_MST_COMPANY_CODE> containCompany, List<MBR_MST_CUSTOMER_VENDOR_MAPPING> contaiCustomerVendorMapping, bool isMerge, bool isZero, out List<string>? errList, out List<string>? warningList)
        {
            var model = new BeginningInventoryModel();
            errList = new List<string>();
            warningList = new List<string>();

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.Company))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Company"));
            }

            if (String.IsNullOrEmpty(this.MCSC))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MC/SC"));
            }
            else
            {
                model.MCSC = this.MCSC;
            }

            if (String.IsNullOrEmpty(this.ProductShortName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Product Short Name"));
            }
            else
            {
                model.ProductShortName = this.ProductShortName;
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

            SSPLSP.DATAACCESS.Entities.Master.SSP_MST_COMPANY_CODE isContainCompany = containCompany.FirstOrDefault(f => f.CompanyShortName.ToUpper() == this.Company.ToUpper());
            if (isContainCompany != null)
            {
                model.Company = isContainCompany.CompanyShortName;
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "Company"));
            }
            //Validate materialCode
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
                model.MaterialCode = isContainProductShortName.MaterialCode;
                model.ProductShortName = isContainProductShortName.ProductShortName;
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "Material Code"));
            }

            ////Supplier Code
            //MBR_MST_CUSTOMER_VENDOR_MAPPING isContainSupplierKey = null;
            //if (COMPANY.MOC == this.Company.ToUpper() || COMPANY.ROC == this.Company.ToUpper())
            //{
            //    isContainSupplierKey = contaiCustomerVendorMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.CHEM && f.CustomerShortName.ToLower() == this.SupplierCode.ToLower());
            //}
            //else if (COMPANY.LSP == this.Company.ToUpper())
            //{
            //    isContainSupplierKey = contaiCustomerVendorMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.LSP && f.CustomerShortName.ToLower() == this.SupplierCode.ToLower());
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
            //SupplierKey
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
                model.SupplierCode = "none";
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
            model.InventoryName = this.Company;
            model.TankNumber = this.TankNumber;
            model.ElementCode = this.ElementCode;

            var M0 = isDecimal(this.M0, "M0", errList);

            //merge
            if (existingData != null && isMerge)
            {
                List<string> statusSame = new List<string>();
                model.M0 = MergeData(M0, existingData?.FirstOrDefault(f => f.MonthIndex == "M0")?.Price, "M0", warningList, statusSame, isZero);

                if (statusSame.Count >= Enum.GetNames(typeof(MONTH_INDEX)).Length)
                {
                    warningList.Add(APPCONSTANT.ERROR_MSG.ERROR_MERGE_SAME_FIELD);
                }
            }
            else
            {
                model.M0 = this.M0;
            }

            return model;
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

        private string? MergeData(decimal? dataFileUpload, decimal? existingData, string text, List<string> errList, List<string> statusSame, bool isZero)
        {
            if (dataFileUpload == 0 && existingData == 0)
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_MERGE_ZERO_OR_NULL_FIELD, text, dataFileUpload.ToString()));
                statusSame.Add(text);
                return dataFileUpload.ToString();
            }
            else if (dataFileUpload == null && existingData == null)
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_MERGE_ZERO_OR_NULL_FIELD, text, "null"));
                statusSame.Add(text);
            }
            else
            {
                var mergeData = Merge(dataFileUpload, existingData, isZero);
                decimal? mergeDataDecimal = !string.IsNullOrWhiteSpace(mergeData) ? decimal.Parse(mergeData) : null;
                if (dataFileUpload.HasValue && Math.Round(dataFileUpload.Value, 5) == mergeDataDecimal || (dataFileUpload == mergeDataDecimal))
                {
                    statusSame.Add(text);
                }
                if (mergeDataDecimal == null || mergeDataDecimal == 0 && !isZero)
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

        private string? Merge(decimal? dataFileUpload, decimal? dataExisting, bool isZero)
        {
            if (dataExisting.HasValue && ((dataFileUpload == 0 && !isZero) || dataFileUpload == null))
            {
                return dataExisting.ToString();
            }
            else if (dataFileUpload.HasValue && ((dataExisting == 0 && !isZero) || dataExisting == null))
            {
                return dataFileUpload.ToString();
            }
            else
            {
                return dataFileUpload?.ToString();
            }
        }

        public void SetModel(BeginningInventoryModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }
    }
}