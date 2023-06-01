using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.MASTER.API.AppModels.Master;
using SCG.CHEM.MBR.MASTER.API.AppModels.Validation;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services.Validation.Interface;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services.Validation
{
    public sealed class ValidateMasterService : IValidateMasterService
    {
        private readonly UnitOfWork _unit;
        private readonly SCG.CHEM.SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork _unitLSP;

        private readonly IValidateShareService _validateShareService;

        public ValidateMasterService(UnitOfWork unitOfWork, IValidateShareService validateShareService, SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork unitLSP)
        {
            this._unit = unitOfWork;
            this._validateShareService = validateShareService;
            this._unitLSP = unitLSP;
        }

        public List<string> checkErrorList(int? Id, List<DataValidationModel> errorList, out bool isError)
        {
            List<string> result = new List<string>();
            isError = false;

            // Set Error Start Month
            var DataList = errorList.Where(w => w.Id == Id);
            if (DataList.Any())
            {
                isError = true;

                var checkData = DataList.FirstOrDefault();

                result = checkData.Message;
            }

            return result;
        }

        public List<string> checkErrorList(int? Id, List<DecimalValidationModel> errorList, out bool isError)
        {
            List<string> result = new List<string>();
            isError = false;

            // Set Error Start Month
            var DataList = errorList.Where(w => w.Id == Id);
            if (DataList.Any())
            {
                isError = true;

                var checkData = DataList.FirstOrDefault();

                result = checkData.Message;
            }

            return result;
        }

        public List<string> checkErrorList(int? Id, List<LockUnlockValidateModel> errorList, out bool isError)
        {
            List<string> result = new List<string>();
            isError = false;

            // Set Error Start Month
            var DataList = errorList.Where(w => w.Id == Id);
            if (DataList.Any())
            {
                isError = true;

                var checkData = DataList.FirstOrDefault();

                result = checkData.Message;
            }

            return result;
        }

        public List<string> checkErrorList(int? Id, List<MaterialCodeValidationModel> errorList, out bool isError)
        {
            List<string> result = new List<string>();
            isError = false;

            // Set Error Start Month
            var DataList = errorList.Where(w => w.Id == Id);
            if (DataList.Any())
            {
                isError = true;

                var checkData = DataList.FirstOrDefault();

                result = checkData.Message;
            }

            return result;
        }

        public List<string> checkErrorList(int? Id, List<ProductMappingValidationModel> errorList, out bool isError)
        {
            List<string> result = new List<string>();
            isError = false;

            // Set Error Start Month
            var DataList = errorList.Where(w => w.Id == Id);
            if (DataList.Any())
            {
                isError = true;

                var checkData = DataList.FirstOrDefault();

                result = checkData.Message;
            }

            return result;
        }

        public List<string> checkErrorList(int? Id, List<CustomerCodeValidationModel> errorList, out bool isError)
        {
            List<string> result = new List<string>();
            isError = false;

            // Set Error Start Month
            var DataList = errorList.Where(w => w.Id == Id);
            if (DataList.Any())
            {
                isError = true;

                var checkData = DataList.FirstOrDefault();

                result = checkData.Message;
            }

            return result;
        }

        public List<string> checkErrorList(int? Id, List<ProductShortNameValidationModel> errorList, out bool isError)
        {
            List<string> result = new List<string>();
            isError = false;

            // Set Error Start Month
            var DataList = errorList.Where(w => w.Id == Id);
            if (DataList.Any())
            {
                isError = true;

                var checkData = DataList.FirstOrDefault();

                result = checkData.Message;
            }

            return result;
        }

        public List<string> checkErrorList(int? Id, List<MarketPriceMappingValidationModel> errorList, out bool isError)
        {
            List<string> result = new List<string>();
            isError = false;

            // Set Error Start Month
            var DataList = errorList.Where(w => w.Id == Id);
            if (DataList.Any())
            {
                isError = true;

                var checkData = DataList.FirstOrDefault();

                result = checkData.Message;
            }

            return result;
        }

        public DataWIthInterface<ValidateProductMappingTempModel> ValidateMasterProductMapping(DataWIthInterface<ValidateProductMappingTempModel> data)
        {
            var result = new DataWIthInterface<ValidateProductMappingTempModel>();
            //result.PlanType = data.PlanType;
            //result.Cycle = data.Cycle;

            #region Set Id (RowNo) for dataValidates List

            // Set RowId (Row No)
            int row = 0;
            data.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
            });

            #endregion Set Id (RowNo) for dataValidates List

            #region Create Validate Model & Set Id (RowNo)

            var validateModels = new List<ValidateProductMappingModel>();
            data.Data.ForEach(i =>
            {
                row++;

                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateProductMappingModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);

                validateModels.Add(validateModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            #region Validate DB

            // Material Code
            var materialCodeList = validateModels.Select(s => s.MaterialCode).ToList();
            //var materialCodeListDB = _unitLSP.FCTMaterialRepo.GetByMaterialCode(materialCodeList);

            var meterialValidateList = validateModels.Select(s => new MaterialCodeValidationModel { Id = s.Id, MaterialCode = s.MaterialCode, SourceSystem = s.SourceSystem }).Distinct().ToList();
            var meterialValidate = _validateShareService.ValidateMaterialCode(meterialValidateList, "Material wasn't found in SAP. Please register this material in SAP before upload.");

            //// Product Short Name Check Dup
            //var producthortNameList = validateModels.Select(s => s.ProductShortName).ToList();
            //var productShortNameValidateList = validateModels.Select(s => new ProductShortNameValidationModel { Id = s.Id, ProductShortName = s.ProductShortName, MaterialCode = s.MaterialCode, SourceSystem = s.SourceSystem }).Distinct().ToList();
            //var productShortNameValidate = _validateShareService.CheckDuplicateProductShortName(productShortNameValidateList);

            #endregion Validate DB

            // set error msg
            data.Data.ForEach(i =>
            {
                bool isError = false;
                bool isOutError = false;
                List<string> errorMsg;
                var error = new ValidateProductMappingTempModel();

                ObjectUtil.CopyProperties(i, error);

                // Set Error Convert Data
                var checkConvertData = validateModels.Where(w => w.Id == i.Id && w.ErrorMsg.Count > 0);
                if (checkConvertData.Any())
                {
                    isError = true;

                    var checkData = checkConvertData.FirstOrDefault();
                    error.ErrorMsg.AddRange(checkData.ErrorMsg);
                }

                // Set Error Material
                errorMsg = checkErrorList(i.Id, meterialValidate, out isOutError);
                if (isOutError)
                {
                    isError = isError || isOutError;
                    error.ErrorMsg.AddRange(errorMsg);
                }

                //// Set Error Product Short Name
                //errorMsg = checkErrorList(i.Id, productShortNameValidate, out isOutError);
                //if (isOutError)
                //{
                //    isError = isError || isOutError;
                //    error.ErrorMsg.AddRange(errorMsg);
                //}

                if (isError)
                    result.Data.Add(error);
            });

            return result;
        }

        public DataWIthInterface<ValidateCustomerVendorMappingTempModel> ValidateMasterCustomerVendorMapping(DataWIthInterface<ValidateCustomerVendorMappingTempModel> data)
        {
            var result = new DataWIthInterface<ValidateCustomerVendorMappingTempModel>();

            #region Set Id (RowNo) for dataValidates List

            // Set RowId (Row No)
            int row = 0;
            data.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
            });

            #endregion Set Id (RowNo) for dataValidates List

            #region Create Validate Model & Set Id (RowNo)

            var validateModels = new List<ValidateCustomerVendorMappingModel>();
            data.Data.ForEach(i =>
            {
                row++;

                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateCustomerVendorMappingModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);

                validateModels.Add(validateModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            #region Validate DB

            // Customer Code
            var customerCodeList = validateModels.Select(s => s.CustomerCode).ToList();

            var customerValidateList = validateModels.Select(s => new CustomerCodeValidationModel { Id = s.Id, CustomerCode = s.CustomerCode }).Distinct().ToList();
            var customerValidate = _validateShareService.ValidateCustomer(customerValidateList);

            // Type
            var typeList = validateModels.Select(s => s.Type).ToList();
            var typeValidateList = validateModels.Select(s => new DataValidationModel { Id = s.Id, Data = s.Type }).Distinct().ToList();
            var typeValidate = _validateShareService.ValidateType(typeValidateList);

            // Check if customer code already exist
            var duplicatedCustomerCodeValidationResult = _validateShareService.CheckDuplicateCustomer(customerValidateList, "This customer code already exists in the database.");

            #endregion Validate DB

            // set error msg
            data.Data.ForEach(i =>
            {
                bool isError = false;
                bool isOutError = false;
                List<string> errorMsg;
                var error = new ValidateCustomerVendorMappingTempModel();

                ObjectUtil.CopyProperties(i, error);

                // Set Error Convert Data
                var checkConvertData = validateModels.Where(w => w.Id == i.Id && w.ErrorMsg.Count > 0);
                if (checkConvertData.Any())
                {
                    isError = true;

                    var checkData = checkConvertData.FirstOrDefault();
                    error.ErrorMsg.AddRange(checkData.ErrorMsg);
                }

                // Set Error Customer
                errorMsg = checkErrorList(i.Id, customerValidate, out isOutError);
                if (isOutError)
                {
                    isError = true;
                    error.ErrorMsg.AddRange(errorMsg);
                }

                // Set Error Type
                errorMsg = checkErrorList(i.Id, typeValidate, out isOutError);
                if (isOutError)
                {
                    isError = true;
                    error.ErrorMsg.AddRange(errorMsg);
                }

                // Set Error Duplicated CustomerCode
                errorMsg = checkErrorList(i.Id, duplicatedCustomerCodeValidationResult, out isOutError);
                if (isOutError)
                {
                    isError = true;
                    error.ErrorMsg.AddRange(errorMsg);
                }

                if (isError)
                    result.Data.Add(error);
            });

            return result;
        }

        public DataWIthInterface<ValidateLSPPriceFormulaTempModel> ValidateMasterLSPPriceFormula(DataWIthInterface<ValidateLSPPriceFormulaTempModel> data)
        {
            var result = new DataWIthInterface<ValidateLSPPriceFormulaTempModel>();

            #region Set Id (RowNo) for dataValidates List

            // Set RowId (Row No)
            int row = 0;
            data.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
            });

            #endregion Set Id (RowNo) for dataValidates List

            #region Create Validate Model & Set Id (RowNo)

            var validateModels = new List<ValidateLSPPriceFormulaModel>();
            data.Data.ForEach(i =>
            {
                row++;

                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateLSPPriceFormulaModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);

                validateModels.Add(validateModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            // Product Code
            var productCodesToBeValidated = validateModels
                                            .Select(s => new MaterialCodeValidationModel { Id = s.Id, MaterialCode = s.ProductCode })
                                            .Distinct()
                                            .ToList();

            var productCodesValidationResult = _validateShareService.ValidateMaterialCodeForLSP(productCodesToBeValidated, "ProductCode wasn't found.");

            // Product Short Name
            var productShortNamesToBeValidated = validateModels
                                            .Select(s => new ProductMappingValidationModel { Id = s.Id, ProductShortName = s.ProductShortName })
                                            .Distinct()
                                            .ToList();

            var productShortNamesValidationResult = _validateShareService.ValidateProductShortName(productShortNamesToBeValidated);

            // Set error msg
            data.Data.ForEach(i =>
            {
                bool isError = false;
                bool isOutError = false;
                List<string> errorMsg;
                var error = new ValidateLSPPriceFormulaTempModel();

                ObjectUtil.CopyProperties(i, error);

                // Set Error Convert Data
                var checkConvertData = validateModels.Where(w => w.Id == i.Id && w.ErrorMsg.Count > 0);
                if (checkConvertData.Any())
                {
                    isError = true;

                    var checkData = checkConvertData.FirstOrDefault();
                    error.ErrorMsg.AddRange(checkData.ErrorMsg);
                }

                // Set Error ProductCode
                errorMsg = checkErrorList(i.Id, productCodesValidationResult, out isOutError);
                if (isOutError)
                {
                    isError = isError || isOutError;
                    error.ErrorMsg.AddRange(errorMsg);
                }

                // Set Error ProductShortName
                errorMsg = checkErrorList(i.Id, productShortNamesValidationResult, out isOutError);
                if (isOutError)
                {
                    isError = isError || isOutError;
                    error.ErrorMsg.AddRange(errorMsg);
                }

                if (isError)
                    result.Data.Add(error);
            });

            return result;
        }

        public DataWIthInterface<ValidateMarketPriceMappingTempModel> ValidateMasterMarketPriceMapping(DataWIthInterface<ValidateMarketPriceMappingTempModel> data)
        {
            var result = new DataWIthInterface<ValidateMarketPriceMappingTempModel>();

            #region Set Id (RowNo) for dataValidates List

            // Set RowId (Row No)
            int row = 0;
            data.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
            });

            #endregion Set Id (RowNo) for dataValidates List

            #region Create Validate Model & Set Id (RowNo)

            var validateModels = new List<ValidateMarketPriceMappingModel>();
            var masterFormulaParameterMappingRepo = _unit.MasterFormulaParameterMappingRepo.GetMasterFormulaParameterByMarketPriceWebPricing(data.Data.Select(s => s.MarketPriceWebPricing).ToList());
            var fctMarketPriceOlefinsRepo = _unit.FctMarketPriceOlefinsRepo.GetFctMarketPriceOlefinsByMarketPriceName(data.Data.Select(s => s.MarketPriceName).ToList());
            data.Data.ForEach(i =>
            {
                row++;

                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(masterFormulaParameterMappingRepo, fctMarketPriceOlefinsRepo, out convertErrorList);

                // create model
                var validateModel = new ValidateMarketPriceMappingModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);

                validateModels.Add(validateModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            #region Validate

            // EBACode Check Dup
            var EBACodeList = validateModels.Select(s => new MarketPriceMappingValidationModel { Id = s.Id, EBACode = s.EBACode, MarketPriceMI = s.MarketPriceMI, MarketPriceWebPricing = s.MarketPriceWebPricing }).ToList();
            var EBACodeValidate = _validateShareService.CheckDuplicateEBACode(EBACodeList);

            #endregion Validate

            // set error msg
            data.Data.ForEach(i =>
            {
                bool isError = false;
                bool isOutError = false;
                List<string> errorMsg;
                var error = new ValidateMarketPriceMappingTempModel();

                ObjectUtil.CopyProperties(i, error);

                // Set Error Convert Data
                var checkConvertData = validateModels.Where(w => w.Id == i.Id && w.ErrorMsg.Count > 0);
                if (checkConvertData.Any())
                {
                    isError = true;

                    var checkData = checkConvertData.FirstOrDefault();
                    error.ErrorMsg.AddRange(checkData.ErrorMsg);
                }

                // Set Error EBACode
                errorMsg = checkErrorList(i.Id, EBACodeValidate, out isOutError);
                if (isOutError)
                {
                    isError = isError || isOutError;
                    error.ErrorMsg.AddRange(errorMsg);
                }

                if (isError)
                    result.Data.Add(error);
            });

            return result;
        }
    }
}