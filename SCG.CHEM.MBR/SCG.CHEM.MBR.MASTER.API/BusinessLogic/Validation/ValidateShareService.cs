using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.MASTER.API.AppModels.Master;
using SCG.CHEM.MBR.MASTER.API.AppModels.Validation;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services.Validation.Interface;
using SCG.CHEM.MBR.DATAACCESS;
using System.Globalization;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services.Validation
{
    public sealed class ValidateShareService : IValidateShareService
    {
        private readonly UnitOfWork _unit;
        private readonly SCG.CHEM.SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork _unitLSP;

        public ValidateShareService(UnitOfWork unitOfWork, SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork unitLSP)
        {
            this._unit = unitOfWork;
            this._unitLSP = unitLSP;
        }

        public List<DataValidationModel> ValidateYearMonth(List<DataValidationModel> data)
        {
            // set Error Msg format
            string ErrMsg1 = "Incorrect Year-Month format (" + APPCONSTANT.FORMAT.YEAR_MONTH + ")";

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                DateTime dt;
                var isValid = DateTime.TryParseExact(i.Data, APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);

                if (!isValid)
                {
                    string msg = String.Format(ErrMsg1, i.Id);
                    i.Message.Add(msg);
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        public List<DecimalValidationModel> ValidateDecimal(List<DecimalValidationModel> data)
        {
            // set Error Msg format
            string ErrMsg1 = "Incorrect number format.";
            string ErrMsg2 = "decimal not more than 5 places.";

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                try
                {
                    decimal chkDecimal = Convert.ToDecimal(i.Data);
                    var numDigit = i.Data.ToString().Split('.').ToList();
                    if (numDigit.Count > 1)
                    {
                        bool isValid = numDigit[1].Length <= 5;
                        if (!isValid)
                        {
                            string msg = String.Format(ErrMsg2, i.Id);
                            i.Message.Add(msg);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string msg = String.Format(ErrMsg1, i.Id);
                    i.Message.Add(msg);
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        public List<DecimalValidationModel> ValidateDecimalQty(List<DecimalValidationModel> data)
        {
            // set Error Msg format
            string ErrMsg1 = "VOL INVALID: Qty must equal or more than 0";

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                if (i.Data < 0)
                {
                    string msg = String.Format(ErrMsg1, i.Id);
                    i.Message.Add(msg);
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        public List<DataValidationModel> ValidateStringLength(List<DataValidationModel> data, int stringLegth)
        {
            // set Error Msg format
            string ErrMsg1 = "invalid because StringLength not match " + stringLegth;

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                var isValid = i.Data.Length <= stringLegth;

                if (!isValid)
                {
                    string msg = String.Format(ErrMsg1, i.Id);
                    i.Message.Add(msg);
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        public List<MaterialCodeValidationModel> ValidateMaterialCode(List<MaterialCodeValidationModel> data, string errorMessage)
        {
            // set Error Msg format
            string ErrMsg1 = errorMessage;

            // distinct key for search DB
            var codeList = data.Select(s => s.MaterialCode).Distinct().ToList();

            // pull DB only need
            var dataDB = _unitLSP.FCTMaterialRepo.GetMaterialCodeForMBR();
            var dataDB2 = _unitLSP.FCTMaterialRepo.GetMaterialCodeForLSP();
            //var dataDB = _unitLSP.FCTMaterialRepo.GetMaterialCodeForMBR(codeList);

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                bool isValid = i.SourceSystem.ToUpper() == APPCONSTANT.SOURCE_SYSTEM.LSP ? dataDB2.Any(a => String.Equals(a, i.MaterialCode, StringComparison.OrdinalIgnoreCase)) : dataDB.Any(a => String.Equals(a, i.MaterialCode, StringComparison.OrdinalIgnoreCase));

                if (!isValid)
                {
                    string msg = String.Format(ErrMsg1, i.Id);
                    i.Message.Add(msg);
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        public List<MaterialCodeValidationModel> ValidateMaterialCodeForLSP(List<MaterialCodeValidationModel> data, string errorMessage)
        {
            // set Error Msg format
            string ErrMsg1 = errorMessage;

            // distinct key for search DB
            var codeList = data.Select(s => s.MaterialCode).Distinct().ToList();

            // pull DB only need
            var dataDB = _unitLSP.FCTMaterialRepo.GetMaterialCodeForLSP();
            //var dataDB = _unitLSP.FCTMaterialRepo.GetMaterialCodeForMBR(codeList);

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                bool isValid = dataDB.Any(a => String.Equals(a, i.MaterialCode, StringComparison.OrdinalIgnoreCase));

                if (!isValid)
                {
                    string msg = String.Format(ErrMsg1, i.Id);
                    i.Message.Add(msg);
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        public List<CustomerCodeValidationModel> ValidateCustomer(List<CustomerCodeValidationModel> data)
        {
            // set Error Msg format
            string ErrMsg1 = "Customer wasn't found.";

            // distinct key for search DB
            var customerName = data.Select(s => s.CustomerCode).Distinct().ToList();

            // pull DB only need
            var customerList = _unitLSP.MasterCustomerRepo.GetCustomer(customerName);

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                bool isValid = customerList.Any(a => String.Equals(a.BusinessPartner, i.CustomerCode, StringComparison.OrdinalIgnoreCase));

                if (!isValid)
                {
                    string msg = String.Format(ErrMsg1, i.Id);
                    i.Message.Add(msg);
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        public List<ProductMappingValidationModel> ValidateProductShortName(List<ProductMappingValidationModel> data)
        {
            // set Error Msg format
            string ErrMsg1 = "Product Short Name wasn't found.";

            // distinct key for search DB
            var product = data.Select(s => s.ProductShortName).Distinct().ToList();

            // pull DB only need
            var productList = _unit.MasterProductMappingRepo.GetProductMapping(product);

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                bool isValid = productList.Any(a => String.Equals(a.ProductShortName, i.ProductShortName, StringComparison.OrdinalIgnoreCase));

                if (!isValid)
                {
                    string msg = String.Format(ErrMsg1, i.Id);
                    i.Message.Add(msg);
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        public List<DataValidationModel> ValidateType(List<DataValidationModel> data)
        {
            // set Error Msg format
            string ErrMsg1 = $"Invalid Type. Type can only be \"{APPCONSTANT.TYPE.CUSTOMER}\" or \"{APPCONSTANT.TYPE.SUPPLIER}\".";

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                bool isValid = (String.Equals(i.Data, APPCONSTANT.TYPE.CUSTOMER, StringComparison.OrdinalIgnoreCase)
                        || String.Equals(i.Data, APPCONSTANT.TYPE.SUPPLIER, StringComparison.OrdinalIgnoreCase));

                if (!isValid)
                {
                    string msg = String.Format(ErrMsg1, i.Id);
                    i.Message.Add(msg);
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        #region Check Duplicate

        public List<CustomerCodeValidationModel> CheckDuplicateCustomer(List<CustomerCodeValidationModel> data, string errorMessage)
        {
            // set Error Msg format
            string ErrMsg1 = errorMessage;

            // distinct key for search DB
            var customer = data.Select(s => s.CustomerCode).Distinct().ToList();

            // pull DB only need
            var customerList = _unit.MasterCustomerVendorMappingRepo.GetAll();

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                bool isDup = customerList.Any(a => String.Equals(a.CustomerCode, i.CustomerCode, StringComparison.OrdinalIgnoreCase)
                                && String.Equals(a.DeletedFlag, APPCONSTANT.DELETE_FLAG.NO, StringComparison.OrdinalIgnoreCase));

                if (isDup)
                {
                    string msg = String.Format(ErrMsg1, i.Id);
                    i.Message.Add(msg);
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        public List<ProductShortNameValidationModel> CheckDuplicateProductShortName(List<ProductShortNameValidationModel> data)
        {
            // set Error Msg format
            string ErrMsg1 = "Product Short Name was duplicate.";

            // distinct key for search DB
            //var product = data.Select(s => s.ProductShortName).Distinct().ToList();

            // pull DB only need
            var productList = _unit.MasterProductMappingRepo.GetAll();

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                bool isDup = productList.Any(a => String.Equals(a.ProductShortName, i.ProductShortName, StringComparison.OrdinalIgnoreCase)
                                && String.Equals(a.DeletedFlag, APPCONSTANT.DELETE_FLAG.NO, StringComparison.OrdinalIgnoreCase));

                if (isDup)
                {
                    var checkData = productList.Where(a => String.Equals(a.ProductShortName, i.ProductShortName, StringComparison.OrdinalIgnoreCase)
                                && String.Equals(a.DeletedFlag, APPCONSTANT.DELETE_FLAG.NO, StringComparison.OrdinalIgnoreCase)
                                && String.Equals(a.MaterialCode, i.MaterialCode, StringComparison.OrdinalIgnoreCase)
                                && String.Equals(a.SourceSystem, i.SourceSystem, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    if (checkData != null)
                    {
                        string msg = String.Format(ErrMsg1, i.Id);
                        i.Message.Add(msg);
                    }
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        public List<MarketPriceMappingValidationModel> CheckDuplicateEBACode(List<MarketPriceMappingValidationModel> data)
        {
            // set Error Msg format
            string ErrMsg1 = "EBACode was duplicate.";

            // distinct key for search DB
            var EBACode = data.Select(s => s.EBACode).Distinct().ToList();

            // pull DB only need
            var marketPriceList = _unit.MasterMarketPriceMappingRepo.GetAllByEBACode(EBACode);

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                var marketPrice = marketPriceList.Where(w => w.EBACode == i.EBACode && w.DeletedFlag == APPCONSTANT.DELETE_FLAG.NO).Distinct().ToList();
                if (marketPrice.Any(w => w.MarketPriceMI == i.MarketPriceMI))
                {
                    var isDup = marketPrice.Any(w => w.MarketPriceMI == i.MarketPriceMI && w.MarketPriceWebPricing == i.MarketPriceWebPricing);

                    if (!isDup && marketPrice?.Count >= 1)
                    {
                        string msg = String.Format(ErrMsg1, i.Id);
                        i.Message.Add(msg);
                    }
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        #endregion Check Duplicate
    }
}