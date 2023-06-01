using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.COMMON.API.AppModels.Sales
{
    public class SalesDataModel
    {
        public string Company { get; set; }

        public string MCSC { get; set; }

        public string MonthIndex { get; set; }

        public string Product { get; set; }
        //public string ProductGroup { get; set; }

        public string Channel { get; set; }

        public string? ReEXP { get; set; }

        public string FormulaName { get; set; }

        public string Customers { get; set; }
        public int? Margin { get; set; }
        public string? Countries { get; set; }
        public string? TransportationMode { get; set; }

        public string? CountryPort { get; set; }

        public string TermSpot { get; set; }

        public string PriceSet { get; set; }

        public string? PaymentCondition { get; set; }

        public string? ContractNo { get; set; }

        public string? Formula { get; set; }
        public string? VesselOrderNo { get; set; }
        public string? Remark { get; set; }

        public string VolTons { get; set; }

        public string? HedgingGainLoss { get; set; }

        public string? Alpha1 { get; set; }

        public string? Alpha2 { get; set; }

        public string? Premium { get; set; }

        public string? BD { get; set; }
        public string? IB { get; set; }
        public string? Adj1 { get; set; }
        public string? Adj2 { get; set; }
        public string? Adj3 { get; set; }
        public string? Adj4 { get; set; }
        public string? Adj5 { get; set; }
        public string? Den { get; set; }
        public string? FinalPrice { get; set; }

        public SalesDataModel()
        { }

        public SalesDataModel(DATAACCESS.Entities.Temp.MBR_TMP_SALES_VOLUME from)
        {
            this.Company = from.Company;

            this.MCSC = from.MCSC;

            this.MonthIndex = from.MonthIndex;

            this.Product = from.Product;

            this.Channel = from.Channel;

            this.ReEXP = from.ReEXP;

            this.FormulaName = from.FormulaName;

            this.Customers = from.Customers;
            this.Margin = from.Margin;
            this.Countries = from.Countries;
            this.TransportationMode = from.TransportationMode;

            this.CountryPort = from.CountryPort;

            this.TermSpot = from.TermSpot;

            this.PriceSet = from.PriceSet;

            this.PaymentCondition = from.PaymentCondition;

            this.ContractNo = from.ContractNo;

            this.Formula = from.Formula;
            this.VesselOrderNo = from.VesselOrderNo;
            this.Remark = from.Remark;

            this.VolTons = from.VolTons.ToString();

            this.HedgingGainLoss = from.HedgingGainLoss?.ToString();

            this.Alpha1 = from.Alpha1.ToString();

            this.Alpha2 = from.Alpha2.ToString();

            this.Premium = from.Premium.ToString();

            this.BD = from.BD.ToString();
            this.IB = from.IB.ToString();
            this.Adj1 = from.Adj1.ToString();
            this.Adj2 = from.Adj2.ToString();
            this.Adj3 = from.Adj3.ToString();
            this.Adj4 = from.Adj4.ToString();
            this.Adj5 = from.Adj5.ToString();
            this.Den = from.Den.ToString();
            this.FinalPrice = from.FinalPrice?.ToString();
        }

        public SalesDataModel(ValidateSalesModel data)
        {
            ObjectUtil.CopyProperties(data, this);
        }
    }

    public class SalesCriteriaModel
    {
        public Guid WebUUID { get; set; }
        public string PlaneType { get; set; }
        public string Case { get; set; }
        public string Cycle { get; set; }
        public List<string> Company { get; set; }
        public List<string> Product { get; set; }
        public List<string> ProductGroup { get; set; }
        public List<string> Channel { get; set; }
        public string? MergePlaneType { get; set; }
        public string? MergeCase { get; set; }
        public string? MergeCycle { get; set; }
        public bool isMerge { get; set; }

        public void SetModel(SalesCriteriaModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }
    }

    public class ValidateSalesModel : SalesDataModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();

        public ValidateSalesModel()
        { }

        public ValidateSalesModel(ValidateSalesModel from)
        {
            this.Company = from.Company;

            this.MCSC = from.MCSC;

            this.MonthIndex = from.MonthIndex;

            this.Product = from.Product;

            this.Channel = from.Channel;

            this.ReEXP = from.ReEXP;

            this.FormulaName = from.FormulaName;

            this.Customers = from.Customers;
            this.Margin = from.Margin;
            this.Countries = from.Countries;
            this.TransportationMode = from.TransportationMode;

            this.CountryPort = from.CountryPort;

            this.TermSpot = from.TermSpot;

            this.PriceSet = from.PriceSet;

            this.PaymentCondition = from.PaymentCondition;

            this.ContractNo = from.ContractNo;

            this.Formula = from.Formula;
            this.VesselOrderNo = from.VesselOrderNo;
            this.Remark = from.Remark;

            this.VolTons = from.VolTons;

            this.HedgingGainLoss = from.HedgingGainLoss;

            this.Alpha1 = from.Alpha1;

            this.Alpha2 = from.Alpha2;

            this.Premium = from.Premium;

            this.BD = from.BD;
            this.IB = from.IB;
            this.Adj1 = from.Adj1;
            this.Adj2 = from.Adj2;
            this.Adj3 = from.Adj3;
            this.Adj4 = from.Adj4;
            this.Adj5 = from.Adj5;
            this.FinalPrice = from.FinalPrice;
        }

        public void SetModel(SalesDataModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }

        internal SalesDataModel TryConvertToModel(out List<string>? errList)
        {
            var model = new SalesDataModel(this);
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

            if (String.IsNullOrEmpty(this.MonthIndex))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Month"));
            }
            else
            {
                model.MonthIndex = this.MonthIndex;
            }
            if (String.IsNullOrEmpty(this.Product))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Product"));
            }
            else
            {
                model.Product = this.Product;
            }
            if (String.IsNullOrEmpty(this.Channel))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Channel"));
            }
            else
            {
                model.Channel = this.Channel;
            }
            if (String.IsNullOrEmpty(this.FormulaName))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Formula Name"));
            }
            else
            {
                model.FormulaName = this.FormulaName;
            }
            if (String.IsNullOrEmpty(this.Customers))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Customers"));
            }
            else
            {
                model.Customers = this.Customers;
            }
            if (String.IsNullOrEmpty(this.TermSpot))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Contract/Spot"));
            }
            else
            {
                model.TermSpot = this.TermSpot;
            }
            if (String.IsNullOrEmpty(this.PriceSet))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Price Set"));
            }
            else
            {
                model.PriceSet = this.PriceSet;
            }

            var volTons = isDecimal(this.VolTons, "VolTons", errList);

            model.VolTons = volTons?.ToString() ?? "";

            return model;
        }

        internal SalesDataModel TryConvertToSalesModel(List<MBR_TRN_SALES_VOLUME>? existingData, List<MBR_MST_PRODUCT_MAPPING> containProductMapping, List<SSPLSP.DATAACCESS.Entities.Master.SSP_MST_COMPANY_CODE> containCompany, List<MBR_MST_FormulaParameterMapping> containFormulaName, List<SSP_FCT_BUSINESS_PARTNER> containBusinessPartner, List<SSP_MST_COUNTRYMASTER> containCountries, bool isMerge, out List<string>? errList, out List<string>? warningList)
        {
            var model = new SalesDataModel(this);
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

            if (String.IsNullOrEmpty(this.MonthIndex))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Month"));
            }
            //if (String.IsNullOrEmpty(this.Product))
            //{
            //    errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Product"));
            //}
            //if (String.IsNullOrEmpty(this.ProductGroup))
            //{
            //    errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Product Group"));
            //}
            if (String.IsNullOrEmpty(this.Channel))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Channel"));
            }
            //if (String.IsNullOrEmpty(this.FormulaName))
            //{
            //    errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Formula Name"));
            //}
            //if (String.IsNullOrEmpty(this.Customers))
            //{
            //    errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Customers"));
            //}
            if (String.IsNullOrEmpty(this.TermSpot))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Contract/Spot"));
            }
            if (String.IsNullOrEmpty(this.PriceSet))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Price Set"));
            }
            if (String.IsNullOrEmpty(this.VolTons))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Vol (Tons)"));
            }
            if (String.IsNullOrEmpty(this.FinalPrice) && this.FormulaName.ToLower() == "manual")
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Final Price"));
            }

            //mc sc
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

            //company

            SSP_MST_COMPANY_CODE isContainCompany = containCompany.FirstOrDefault(f => f.CompanyShortName.ToUpper() == this.Company.ToUpper());
            if (isContainCompany == null)
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "Company"));
            }
            else
            {
                model.Company = isContainCompany.CompanyShortName;
            }
            //MC/SC

            //Product
            MBR_MST_PRODUCT_MAPPING isContainProduct = null;
            if (COMPANY.MOC == this.Company.ToUpper() || COMPANY.ROC == this.Company.ToUpper())
            {
                isContainProduct = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.CHEM && f.ProductShortName.ToLower() == this.Product.ToLower());
            }
            else if (COMPANY.LSP == this.Company.ToUpper())
            {
                isContainProduct = containProductMapping.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.LSP && f.ProductShortName.ToLower() == this.Product.ToLower());
            }
            if (String.IsNullOrEmpty(this.Product))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Product"));
            }
            else if (isContainProduct != null)
            {
                model.Product = isContainProduct.ProductShortName;
            }
            else if (isContainProduct == null)
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "Product"));
            }
            //Channel
            if (!string.IsNullOrEmpty(this.Channel) && this.Channel.ToUpper() != "DOM" && this.Channel.ToUpper() != "EXP")
            {
                errList.Add(APPCONSTANT.ERROR_MSG.ERROR_MC_SC_FOUND);
            }
            //formular
            MBR_MST_FormulaParameterMapping isFormular = containFormulaName.FirstOrDefault(f => f.FormulaName.ToUpper() == this.FormulaName.ToUpper());
            if (!string.IsNullOrEmpty(this.FormulaName) && this.FormulaName.ToUpper() == "Manual".ToUpper())
            {
                model.FormulaName = this.FormulaName;
            }
            else if (isContainCompany == null)
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "FormulaName"));
            }
            else
            {
                model.FormulaName = isFormular.FormulaName;
            }
            //Customers
            SSP_FCT_BUSINESS_PARTNER isCustomers = null;
            if (COMPANY.MOC == this.Company.ToUpper() || COMPANY.ROC == this.Company.ToUpper())
            {
                isCustomers = containBusinessPartner.FirstOrDefault(f => f.SourceSystem.ToUpper() == SOURCE_SYSTEM.CHEM && f.ShortNamePriceWeb.ToLower() == this.Customers.ToLower());
            }
            else if (COMPANY.LSP == this.Company.ToUpper())
            {
                isCustomers = containBusinessPartner.FirstOrDefault(f => (f.SourceSystem.ToUpper() == SOURCE_SYSTEM.LSP || (f.SourceSystem == SOURCE_SYSTEM.CHEM && f.AccountGroup == "DREP")) && f.ShortNamePriceWeb.ToLower() == this.Customers.ToLower());
            }
            if (String.IsNullOrEmpty(this.Customers))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Customers"));
            }
            else if (isCustomers != null)
            {
                model.Customers = isCustomers.ShortNamePriceWeb;
            }
            else if (isCustomers == null)
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "Customers"));
            }
            //Countries
            SSP_MST_COUNTRYMASTER isContaineCountries = containCountries.FirstOrDefault(f => f.CountryCode.ToUpper() == this.Countries.ToUpper());

            if (String.IsNullOrEmpty(this.Countries) || this.Countries.ToLower() == "none")
            {
                model.Countries = this.Countries.ToLower();
            }
            else if (isContaineCountries != null)
            {
                model.Countries = isContaineCountries.CountryCode;
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "Countries"));
            }
            //TermSpot
            if (!string.IsNullOrEmpty(this.TermSpot) && this.TermSpot.ToLower() != "contract" && this.TermSpot.ToLower() != "spot")
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "TermSpot"));
            }
            if (!string.IsNullOrEmpty(this.PriceSet) && this.PriceSet.ToLower() != "fixed" && this.PriceSet.ToLower() != "float")
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_FOUND, "TermSpot"));
            }

            //merge
            if (existingData != null && isMerge)
            {
                List<string> statusSame = new List<string>();
                model.VolTons = MergeData(isDecimal(this.VolTons, "VolTons", errList), existingData?.FirstOrDefault(f => f.MonthIndex == this.MonthIndex)?.VolTons, "VolTons", warningList, statusSame);
                model.HedgingGainLoss = MergeData(isDecimal(this.HedgingGainLoss, "HedgingGainLoss", errList), existingData?.FirstOrDefault(f => f.MonthIndex == this.MonthIndex)?.HedgingGainLoss, "HedgingGainLoss", warningList, statusSame);
                model.Alpha1 = MergeData(isDecimal(this.Alpha1, "Alpha1", errList), existingData?.FirstOrDefault(f => f.MonthIndex == this.MonthIndex)?.Alpha1, "Alpha1", warningList, statusSame);
                model.Alpha2 = MergeData(isDecimal(this.Alpha2, "Alpha2", errList), existingData?.FirstOrDefault(f => f.MonthIndex == this.MonthIndex)?.Alpha2, "Alpha2", warningList, statusSame);
                model.Premium = MergeData(isDecimal(this.Premium, "Premium", errList), existingData?.FirstOrDefault(f => f.MonthIndex == this.MonthIndex)?.Premium, "Premium", warningList, statusSame);
                model.BD = MergeData(isDecimal(this.BD, "BD", errList), existingData?.FirstOrDefault(f => f.MonthIndex == this.MonthIndex)?.BD, "BD", warningList, statusSame);
                model.IB = MergeData(isDecimal(this.IB, "IB", errList), existingData?.FirstOrDefault(f => f.MonthIndex == this.MonthIndex)?.IB, "IB", warningList, statusSame);
                model.Adj1 = MergeData(isDecimal(this.Adj1, "Adj1", errList), existingData?.FirstOrDefault(f => f.MonthIndex == this.MonthIndex)?.Adj1, "Adj1", warningList, statusSame);
                model.Adj2 = MergeData(isDecimal(this.Adj2, "Adj2", errList), existingData?.FirstOrDefault(f => f.MonthIndex == this.MonthIndex)?.Adj2, "Adj2", warningList, statusSame);
                model.Adj3 = MergeData(isDecimal(this.Adj3, "Adj3", errList), existingData?.FirstOrDefault(f => f.MonthIndex == this.MonthIndex)?.Adj3, "Adj3", warningList, statusSame);
                model.Adj4 = MergeData(isDecimal(this.Adj4, "Adj4", errList), existingData?.FirstOrDefault(f => f.MonthIndex == this.MonthIndex)?.Adj4, "Adj4", warningList, statusSame);
                model.Adj5 = MergeData(isDecimal(this.Adj5, "Adj5", errList), existingData?.FirstOrDefault(f => f.MonthIndex == this.MonthIndex)?.Adj5, "Adj5", warningList, statusSame);
                model.Den = MergeData(isDecimal(this.Den, "Den", errList), existingData?.FirstOrDefault(f => f.MonthIndex == this.MonthIndex)?.Den, "Den", warningList, statusSame);
                model.FinalPrice = MergeData(isDecimal(this.FinalPrice, "FinalPrice", errList), existingData?.FirstOrDefault(f => f.MonthIndex == this.MonthIndex)?.FinalPrice, "FinalPrice", warningList, statusSame);

                if (statusSame.Count >= Enum.GetNames(typeof(MONTH_INDEX)).Length)
                {
                    warningList.Add(APPCONSTANT.ERROR_MSG.ERROR_MERGE_SAME_FIELD);
                }
            }
            //else
            //{
            //    model.VolTons = this.VolTons;

            //}

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
                if (mergeDataDecimal == null || mergeDataDecimal == 0)
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
            if (dataExisting.HasValue && (dataFileUpload == 0 || dataFileUpload == null))
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
}