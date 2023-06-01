using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Optience;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Validation.Interface;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Validation
{
    public class ValidateOptienceService : IValidateOptienceService
    {
        private readonly UnitOfWork _unit;
        private readonly SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork _unitSSP;

        public ValidateOptienceService(UnitOfWork unitOfWork, SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork unitSSP)
        {
            this._unit = unitOfWork;
            this._unitSSP = unitSSP;
        }

        public DataWitOptienceModel<OptienceCriteriaModel> ValidateOptience(DataWitOptienceModel<OptienceCriteriaModel> data)
        {
            var result = new DataWitOptienceModel<OptienceCriteriaModel>();

            ValidateFeedPurchaseModel(data, result);

            ValidateFeedConsumptionModel(data, result);

            ValidateProductionVolumeModel(data, result);

            ValidateBeginningInventoryModel(data, result);

            return result;
        }

        public void ValidateFeedConsumptionModel(DataWitOptienceModel<OptienceCriteriaModel> data, DataWitOptienceModel<OptienceCriteriaModel> result)
        {
            #region Set Id (RowNo) for dataValidates List

            // Set RowId (Row No)
            int row = 0;
            data.FeedConsumptionData.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
            });

            #endregion Set Id (RowNo) for dataValidates List

            #region Create Validate Model & Set Id (RowNo)

            var validateFeedConsumptionModels = new List<ValidateFeedConsumptionModel>();
            var dataWarnningFeedConsumptionModels = new List<ValidateFeedConsumptionModel>();

            var isZero = _unit.MasterMaintainPriceRepo.GetByMaintainId(MASTER_EXCEL_TYPE.FEED_CONSUMPTION)?.IsZero ?? false;
            var containCompany = _unitSSP.MasterCompanyRepo.GetByShortName(data.FeedConsumptionData.Select(s => s.Company).ToList());
            var containProductMapping = _unit.MasterProductMappingRepo.GetProductShortName(data.FeedConsumptionData.Select(s => s.FeedShortName).ToList());
            var contaiCustomerVendorMapping = _unit.MasterCustomerVendorMappingRepo.GetCustomerShortName(data.FeedPurchaseData.Select(s => s.SupplierKey).ToList());
            List<MBR_TRN_FEED_CONSUMPTION> feedConsumptionExistingData = new List<MBR_TRN_FEED_CONSUMPTION>();
            if (data.Criteria.isMerge && data.Criteria.MergeScenario != null && data.Criteria.MergeCase != null && data.Criteria.MergeCycle != null)
                feedConsumptionExistingData = _unit.FeedConsumptionRepo.FindByCriterias(data.Criteria.MergeScenario, data.Criteria.MergeCase, data.Criteria.MergeCycle);
            data.FeedConsumptionData.ForEach(i =>
            {
                row++;
                List<MBR_TRN_FEED_CONSUMPTION> existingDatas = null;
                if (feedConsumptionExistingData != null)
                    existingDatas = feedConsumptionExistingData.Where(f => f.Company.ToLower() == i.Company.ToLower() && f.MCSC.ToLower() == i.MCSC.ToLower() && f.FeedName.ToLower() == i.FeedName.ToLower()).ToList();
                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToFeedConsumptionModel(existingDatas, containProductMapping, contaiCustomerVendorMapping, containCompany, data.Criteria.isMerge, isZero, out convertErrorList, out convertDataWarningList);

                // create model
                var validateModel = new ValidateFeedConsumptionModel();
                var dataWarnningModel = new ValidateFeedConsumptionModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateFeedConsumptionModels.Add(validateModel);

                dataWarnningModel.Id = i.Id;
                dataWarnningModel.SetModel(convertModel);
                dataWarnningModel.ErrorMsg.AddRange(convertDataWarningList);
                dataWarnningFeedConsumptionModels.Add(dataWarnningModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            // set error msg
            data.FeedConsumptionData.ForEach(i =>
            {
                bool isError = false;
                bool isWarnning = false;
                bool isOutError = false;
                List<string> errorMsg;
                var error = new ValidateFeedConsumptionModel(i);
                var errorDataWarnning = new ValidateFeedConsumptionModel(i);

                // Set Error Convert Data
                var checkConvertData = validateFeedConsumptionModels.Where(w => w.Id == i.Id && w.ErrorMsg.Count > 0);
                var checkDataWarnning = dataWarnningFeedConsumptionModels.Where(w => w.Id == i.Id && w.ErrorMsg.Count > 0);
                if (checkConvertData.Any())
                {
                    isError = true;

                    var checkData = checkConvertData.FirstOrDefault();
                    error.ErrorMsg.AddRange(checkData.ErrorMsg);
                }
                if (checkDataWarnning.Any())
                {
                    isWarnning = true;
                    var checkData = checkDataWarnning.FirstOrDefault();
                    errorDataWarnning.ErrorMsg.AddRange(checkData.ErrorMsg);
                }

                if (isError)
                    result.FeedConsumptionData.Add(error);
                if (isWarnning)
                    result.FeedConsumptionDataWarnning.Add(errorDataWarnning);
            });
        }

        public void ValidateFeedPurchaseModel(DataWitOptienceModel<OptienceCriteriaModel> data, DataWitOptienceModel<OptienceCriteriaModel> result)
        {
            #region Set Id (RowNo) for dataValidates List

            // Set RowId (Row No)
            int row = 0;
            data.FeedPurchaseData.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
            });

            #endregion Set Id (RowNo) for dataValidates List

            #region Create Validate Model & Set Id (RowNo)

            var validateFeedPurchaseModels = new List<ValidateFeedPurchaseModel>();
            var dataWarnningFeedPurchaseModels = new List<ValidateFeedPurchaseModel>();
            var isZero = _unit.MasterMaintainPriceRepo.GetByMaintainId(MASTER_EXCEL_TYPE.FEED_PURCHASE)?.IsZero ?? false;
            var containCompany = _unitSSP.MasterCompanyRepo.GetByShortName(data.FeedPurchaseData.Select(s => s.Company).ToList());
            var containProductMapping = _unit.MasterProductMappingRepo.GetProductShortName(data.FeedPurchaseData.Select(s => s.FeedShortName).ToList());
            var contaiCustomerVendorMapping = _unit.MasterCustomerVendorMappingRepo.GetCustomerShortName(data.FeedPurchaseData.Select(s => s.SupplierKey).ToList());
            List<MBR_TRN_FEED_PURCHASE> feedPurchaseExistingData = new List<MBR_TRN_FEED_PURCHASE>();
            if (data.Criteria.isMerge && data.Criteria.MergeScenario != null && data.Criteria.MergeCase != null && data.Criteria.MergeCycle != null)
                feedPurchaseExistingData = _unit.FeedPurchaseRepo.FindByCriteria(data.Criteria.MergeScenario, data.Criteria.MergeCase, data.Criteria.MergeCycle);
            data.FeedPurchaseData.ForEach(i =>
            {
                row++;
                List<MBR_TRN_FEED_PURCHASE> existingDatas = null;
                if (feedPurchaseExistingData != null)
                    existingDatas = feedPurchaseExistingData.Where(f => f.Company.ToLower() == i.Company.ToLower() && f.MCSC.ToLower() == i.MCSC.ToLower() && f.FeedName.ToLower() == i.FeedName.ToLower()).ToList();
                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToFeedPurchaseModel(existingDatas, containProductMapping, contaiCustomerVendorMapping, containCompany, data.Criteria.isMerge, isZero, out convertErrorList, out convertDataWarningList);

                // create model
                var validateModel = new ValidateFeedPurchaseModel();
                var dataWarnningModel = new ValidateFeedPurchaseModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateFeedPurchaseModels.Add(validateModel);

                dataWarnningModel.Id = i.Id;
                dataWarnningModel.SetModel(convertModel);
                dataWarnningModel.ErrorMsg.AddRange(convertDataWarningList);
                dataWarnningFeedPurchaseModels.Add(dataWarnningModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            // set error msg
            data.FeedPurchaseData.ForEach(i =>
            {
                bool isError = false;
                bool isWarnning = false;
                bool isOutError = false;
                List<string> errorMsg;
                var error = new ValidateFeedPurchaseModel(i);
                var errorDataWarnning = new ValidateFeedPurchaseModel(i);

                // Set Error Convert Data
                var checkConvertData = validateFeedPurchaseModels.Where(w => w.Id == i.Id && w.ErrorMsg.Count > 0);
                var checkDataWarnning = dataWarnningFeedPurchaseModels.Where(w => w.Id == i.Id && w.ErrorMsg.Count > 0);
                if (checkConvertData.Any())
                {
                    isError = true;

                    var checkData = checkConvertData.FirstOrDefault();
                    error.ErrorMsg.AddRange(checkData.ErrorMsg);
                }
                if (checkDataWarnning.Any())
                {
                    isWarnning = true;
                    var checkData = checkDataWarnning.FirstOrDefault();
                    errorDataWarnning.ErrorMsg.AddRange(checkData.ErrorMsg);
                }

                if (isError)
                    result.FeedPurchaseData.Add(error);
                if (isWarnning)
                    result.FeedPurchaseDataWarnning.Add(errorDataWarnning);
            });
        }

        public void ValidateProductionVolumeModel(DataWitOptienceModel<OptienceCriteriaModel> data, DataWitOptienceModel<OptienceCriteriaModel> result)
        {
            #region Set Id (RowNo) for dataValidates List

            // Set RowId (Row No)
            int row = 0;
            data.ProductionVolumeData.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
            });

            #endregion Set Id (RowNo) for dataValidates List

            #region Create Validate Model & Set Id (RowNo)

            var validateProductionVolumeModels = new List<ValidateProductionVolumeModel>();
            var dataWarnningProductionVolumeModels = new List<ValidateProductionVolumeModel>();
            var isZero = _unit.MasterMaintainPriceRepo.GetByMaintainId(MASTER_EXCEL_TYPE.PRODUCTION_VOLUME)?.IsZero ?? false;
            var containProductMapping = _unit.MasterProductMappingRepo.GetProductShortName(data.ProductionVolumeData.Select(s => s.ProductShortName).ToList());
            var containCompany = _unitSSP.MasterCompanyRepo.GetByShortName(data.ProductionVolumeData.Select(s => s.Company).ToList());

            List<MBR_TRN_PRODUCTION_VOLUME> productionVolumeModelExistingData = new List<MBR_TRN_PRODUCTION_VOLUME>();

            if (data.Criteria.isMerge && data.Criteria.MergeScenario != null && data.Criteria.MergeCase != null && data.Criteria.MergeCycle != null)
                productionVolumeModelExistingData = _unit.ProductionVolumeRepo.FindByCriterias(data.Criteria.MergeScenario, data.Criteria.MergeCase, data.Criteria.MergeCycle);
            data.ProductionVolumeData.ForEach(i =>
            {
                row++;
                List<MBR_TRN_PRODUCTION_VOLUME> existingDatas = null;
                if (productionVolumeModelExistingData != null)
                    existingDatas = productionVolumeModelExistingData.Where(f => f.ProductName.ToLower() == i.ProductName.ToLower() && f.MCSC.ToLower() == i.MCSC.ToLower()).ToList();
                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToProductionVolumeModel(existingDatas, containProductMapping, containCompany, data.Criteria.isMerge, isZero, out convertErrorList, out convertDataWarningList);

                // create model
                var validateModel = new ValidateProductionVolumeModel();
                var dataWarnningModel = new ValidateProductionVolumeModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateProductionVolumeModels.Add(validateModel);

                dataWarnningModel.Id = i.Id;
                dataWarnningModel.SetModel(convertModel);
                dataWarnningModel.ErrorMsg.AddRange(convertDataWarningList);
                dataWarnningProductionVolumeModels.Add(dataWarnningModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            // set error msg
            data.ProductionVolumeData.ForEach(i =>
            {
                bool isError = false;
                bool isWarnning = false;
                bool isOutError = false;
                List<string> errorMsg;
                var error = new ValidateProductionVolumeModel(i);
                var errorDataWarnning = new ValidateProductionVolumeModel(i);

                // Set Error Convert Data
                var checkConvertData = validateProductionVolumeModels.Where(w => w.Id == i.Id && w.ErrorMsg.Count > 0);
                var checkDataWarnning = dataWarnningProductionVolumeModels.Where(w => w.Id == i.Id && w.ErrorMsg.Count > 0);
                if (checkConvertData.Any())
                {
                    isError = true;

                    var checkData = checkConvertData.FirstOrDefault();
                    error.ErrorMsg.AddRange(checkData.ErrorMsg);
                }
                if (checkDataWarnning.Any())
                {
                    isWarnning = true;
                    var checkData = checkDataWarnning.FirstOrDefault();
                    errorDataWarnning.ErrorMsg.AddRange(checkData.ErrorMsg);
                }

                if (isError)
                    result.ProductionVolumeData.Add(error);
                if (isWarnning)
                    result.ProductionVolumeDataWarnning.Add(errorDataWarnning);
            });
        }

        public void ValidateBeginningInventoryModel(DataWitOptienceModel<OptienceCriteriaModel> data, DataWitOptienceModel<OptienceCriteriaModel> result)
        {
            #region Set Id (RowNo) for dataValidates List

            // Set RowId (Row No)
            int row = 0;
            data.BeginningInventoryData.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
            });

            #endregion Set Id (RowNo) for dataValidates List

            #region Create Validate Model & Set Id (RowNo)

            var validateBeginningInventoryModels = new List<ValidateBeginningInventoryModel>();
            var dataWarnningBeginningInventoryModels = new List<ValidateBeginningInventoryModel>();
            var isZero = _unit.MasterMaintainPriceRepo.GetByMaintainId(MASTER_EXCEL_TYPE.BEGINNING_INVENTORY)?.IsZero ?? false;
            var containCompany = _unitSSP.MasterCompanyRepo.GetByShortName(data.BeginningInventoryData.Select(s => s.Company).ToList());
            //var containProductMapping = _unit.MasterProductMappingRepo.GetProductShortName(data.BeginningInventoryData.Select(s => s.ProductShortName).ToList());
            var containProductMapping = _unit.MasterProductMappingRepo.GetMaterialCode(data.BeginningInventoryData.Select(s => s.MaterialCode).ToList());
            var contaiCustomerVendorMapping = _unit.MasterCustomerVendorMappingRepo.GetCustomerShortName(data.FeedPurchaseData.Select(s => s.SupplierKey).ToList());
            List<MBR_TRN_BEGINING_INVENTORY> beginningInventoryExistingData = new List<MBR_TRN_BEGINING_INVENTORY>();
            if (data.Criteria.isMerge && data.Criteria.MergeScenario != null && data.Criteria.MergeCase != null && data.Criteria.MergeCycle != null)
                beginningInventoryExistingData = _unit.BeginningInventoryRepo.FindByCriterias(data.Criteria.MergeScenario, data.Criteria.MergeCase, data.Criteria.MergeCycle);
            data.BeginningInventoryData.ForEach(i =>
            {
                row++;
                List<MBR_TRN_BEGINING_INVENTORY> existingDatas = null;
                if (beginningInventoryExistingData != null)
                    existingDatas = beginningInventoryExistingData.Where(f => f.ProductShortName.ToLower() == i.ProductShortName.ToLower() && f.MCSC.ToLower() == i.MCSC.ToLower() && f.MaterialCode.ToLower() == i.MaterialCode.ToLower() && f.SupplierKey.ToLower() == i.SupplierKey.ToLower()).ToList();
                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToBeginningInventoryModel(existingDatas, containProductMapping, containCompany, contaiCustomerVendorMapping, data.Criteria.isMerge, isZero, out convertErrorList, out convertDataWarningList);

                // create model
                var validateModel = new ValidateBeginningInventoryModel();
                var dataWarnningModel = new ValidateBeginningInventoryModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateBeginningInventoryModels.Add(validateModel);

                dataWarnningModel.Id = i.Id;
                dataWarnningModel.SetModel(convertModel);
                dataWarnningModel.ErrorMsg.AddRange(convertDataWarningList);
                dataWarnningBeginningInventoryModels.Add(dataWarnningModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            // set error msg
            data.BeginningInventoryData.ForEach(i =>
            {
                bool isError = false;
                bool isWarnning = false;
                bool isOutError = false;
                List<string> errorMsg;
                var error = new ValidateBeginningInventoryModel(i);
                var errorDataWarnning = new ValidateBeginningInventoryModel(i);

                // Set Error Convert Data
                var checkConvertData = validateBeginningInventoryModels.Where(w => w.Id == i.Id && w.ErrorMsg.Count > 0);
                var checkDataWarnning = dataWarnningBeginningInventoryModels.Where(w => w.Id == i.Id && w.ErrorMsg.Count > 0);
                if (checkConvertData.Any())
                {
                    isError = true;

                    var checkData = checkConvertData.FirstOrDefault();
                    error.ErrorMsg.AddRange(checkData.ErrorMsg);
                }
                if (checkDataWarnning.Any())
                {
                    isWarnning = true;
                    var checkData = checkDataWarnning.FirstOrDefault();
                    errorDataWarnning.ErrorMsg.AddRange(checkData.ErrorMsg);
                }

                if (isError)
                    result.BeginningInventoryData.Add(error);
                if (isWarnning)
                    result.BeginningInventoryDataWarnning.Add(errorDataWarnning);
            });
        }
    }
}