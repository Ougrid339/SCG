using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.MASTER.API.AppModels.Master;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master.Interface;
using System.Globalization;
using SCG.CHEM.MBR.MASTER.API.AppModels.Maintain;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;
using System.Transactions;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using Microsoft.Data.SqlClient;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master
{
    public sealed class MasterService : IMasterService
    {
        private readonly UnitOfWork _unit;
        private readonly IDataFactoryService _dataFactoryService;

        public MasterService(UnitOfWork unitOfWork, IDataFactoryService dataFactoryService)
        {
            this._unit = unitOfWork;
            this._dataFactoryService = dataFactoryService;
        }

        public UserAuthorizeModel GetUserAccount(string username)
        {
            UserAuthorizeModel result = new UserAuthorizeModel();

            #region get user in role

            var userDB = _unit.MasterUsersRepo.Query().Where(o => o.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && o.Username == username).FirstOrDefault();

            if (userDB == null)
                return result;

            var masterRole = _unit.MasterRoleRepo.GetAll();
            var masterPage = _unit.MasterPageRepo.GetAll();
            var masterMaster = _unit.MasterRepo.GetAll();
            //var masterPlanningGroup = _unit.MasterPlanningGroupRepo.GetAll();
            //var masterSalesGroup = _unit.MasterSalesGroupRepo.GetAll();
            //var masterNewProductFlag = _unit.MasterNewProductFlagRepo.GetAll();

            var comma = ", ";

            var roleLs = masterRole.Where(w => userDB.Roles.Split(",").ToList().Contains(w.Id.ToString())).ToList();

            List<string> pageLs = new List<string>();
            List<string> masterLs = new List<string>();

            foreach (var role in roleLs)
            {
                // add page
                var pages = role.AvailablePages.Split(",").Where(w => w != "");
                pageLs = pageLs.Union(pages).ToList();

                // add master
                var masters = role.AvailableMasters.Split(",").Where(w => w != "");
                masterLs = masterLs.Union(masters).ToList();
            }

            result = new UserAuthorizeModel()
            {
                UserId = userDB.Id,
                Username = userDB.Username,
                IsActive = userDB.IsActive,
                Role = masterRole.Where(w => userDB.Roles.Split(",").ToList().Contains(w.Id.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.Id, Text = s.RoleName }).ToList(),
                Pages = masterPage.Where(w => pageLs.Contains(w.Id.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.Id, Text = s.Pages }).ToList(),
                Masters = masterMaster.Where(w => masterLs.Contains(w.MasterId.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.MasterId, Text = s.MasterName }).ToList(),
            };

            #endregion get user in role

            return result;
        }

        public string CallDataFactory(string masterName)
        {
            string userName = UserUtilities.GetADAccount()?.UserId ?? "";
            string res = _dataFactoryService.RunPipeline(masterName, userName);

            return res;
        }

        public string CallDataFactoryImportFormula(string masterName)
        {
            string userName = UserUtilities.GetADAccount()?.UserId ?? "";
            string res = _dataFactoryService.RunPipelineImportFormula(masterName, userName);

            return res;
        }

        public List<MBR_MST_MASTER> GetMasters(string username)
        {
            var userDetail = GetUserAccount(username);
            var item_list = userDetail.Masters?.Select(s => int.Parse(s.Value?.ToString() ?? "-1")).ToList() ?? new List<int>();
            var query = _unit.MasterRepo.Query();
            query = query.Where(w => item_list.Contains(w.MasterId));

            var result = query.ToList();

            return result;
        }

        public MBR_MST_MASTER GetMastersByName(string masterName)
        {
            var result = _unit.MasterRepo.Query().Where(w => w.MasterName == masterName).FirstOrDefault();
            return result;
        }

        //public List<vSSP_MST_FREIGHT_EXPORT> Test()
        //{
        //    //var startdate = DateTime.ParseExact("2022-03-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);
        //    //List<string> plantype = new List<string>();
        //    //plantype.Add("18M");
        //    //var result = _unit.ViewFreightExportRepo.GetByPlanTypeAndDate(plantype, startdate);
        //    //return result;
        //    return new List<vSSP_MST_FREIGHT_EXPORT>();
        //}

        public List<MBR_MST_MASTER_MAPPING> GetMasterMapping(int masterId)
        {
            var result = _unit.MasterMappingRepo.GetMapping(masterId).OrderBy(o => o.Sequence).ToList();
            return result;
        }

        public List<MBR_MST_EXPORT_MAPPING> GetExportMapping(int masterId)
        {
            var result = _unit.MasterExportMappingRepo.GetMapping(masterId).OrderBy(o => o.Sequence).ToList();
            return result;
        }

        public bool MasterMapping(RequestMaintainModel data)
        {
            var master = _unit.MasterRepo.GetMaster(data.masterId).FirstOrDefault();
            if (master != null)
            {
                master.SetSheet(data.sheetName);
            }
            var newMapping = new List<MBR_MST_MASTER_MAPPING>();
            var newExportMapping = new List<MBR_MST_EXPORT_MAPPING>();
            var listMapping = _unit.MasterMappingRepo.GetAll();
            var listExportMapping = _unit.MasterExportMappingRepo.GetAll();

            data.mapping?.ForEach(i =>
            {
                var mapping = listMapping.Where(s => i.variable.Equals(s.Variable)).FirstOrDefault();
                var mappingDB = _unit.MasterMappingRepo.GetMappingByVariable(data.masterId, mapping?.Variable).FirstOrDefault();
                if (mappingDB == null)
                {
                    // create
                    // mappingDB = new SSP_MST_MASTER_MAPPING(data.masterId, i.variable,i.excelheader,i.required);
                    // newMapping.Add(mappingDB);
                }
                else
                {
                    // update
                    mappingDB.MapVariableAndExcelHeader(i.excelheader, i.required);
                }
            });

            data.exportmapping.ForEach(i =>
            {
                var exportmapping = listExportMapping.Where(s => i.variable.Equals(s.Variable)).FirstOrDefault();
                var exportDB = _unit.MasterExportMappingRepo.GetMappingByVariable(data.masterId, exportmapping?.Variable).FirstOrDefault();
                if (exportDB == null)
                {
                    // create
                    // exportDB = new SSP_MST_EXPORT_MAPPING(data.masterId, i.variable, i.excelheader);
                    // newExportMapping.Add(exportDB);
                }
                else
                {
                    // update
                    exportDB.MapVariableAndExcelHeader(i.excelheader);
                }
            });

            _unit.MasterExportMappingRepo.Add(newExportMapping);
            _unit.MasterMappingRepo.Add(newMapping);
            _unit.SaveTransaction();

            return true;
        }

        public IEnumerable<MBR_MST_MASTER> GetAllMasters()
        {
            return _unit.MasterRepo.Query().ToList();
        }

        public int MoveMasterProductMapping()
        {
            var newMasterDB = new List<MBR_MST_PRODUCT_MAPPING>();
            var listTempDB = _unit.MasterTempProductMappingRepo.GetAll();
            listTempDB.ForEach(i =>
            {
                var masterDB = _unit.MasterProductMappingRepo.GetAllByKeyAndVersion(i.MaterialCode, i.SourceSystem, i.VersionNo).FirstOrDefault();
                if (masterDB == null)
                {
                    // create
                    masterDB = new MBR_MST_PRODUCT_MAPPING(i);
                    newMasterDB.Add(masterDB);
                }
                else
                {
                    // update
                    if (i.DeletedFlag == APPCONSTANT.DELETE_FLAG.YES)
                        masterDB.MarkDelete(i.DeletedBy);
                }
            });

            // insert data
            if (newMasterDB.Count > 0)
                _unit.MasterProductMappingRepo.Add(newMasterDB);

            _unit.SaveTransaction();

            int total = listTempDB.Count();

            return total;
        }

        public int MoveMasterLSPPriceFormula()
        {
            var newMasterDB = new List<MBR_MST_LSP_PRICE_FORMULA>();
            var listTempDB = _unit.MasterTempLSPPriceFormulaRepo.GetAll();

            listTempDB.ForEach(i =>
            {
                var masterDB = _unit.MasterLSPPriceFormulaRepo.GetAllByKeyAndVersion(i.FormulaName, i.VersionNo).FirstOrDefault();
                if (masterDB == null)
                {
                    // create
                    masterDB = new MBR_MST_LSP_PRICE_FORMULA(i);
                    newMasterDB.Add(masterDB);
                }
                else
                {
                    // update
                    if (i.DeletedFlag == APPCONSTANT.DELETE_FLAG.YES)
                        masterDB.MarkDelete(i.DeletedBy);
                }
            });

            // insert data
            if (newMasterDB.Count > 0)
                _unit.MasterLSPPriceFormulaRepo.Add(newMasterDB);

            _unit.SaveTransaction();

            int total = listTempDB.Count();

            #region Call pipeline import formula

            CallDataFactoryImportFormula("FormulaParameterMapping");

            #endregion Call pipeline import formula

            return total;
        }

        public int MoveMasterCustomerVendorMapping()
        {
            var newMasterDB = new List<MBR_MST_CUSTOMER_VENDOR_MAPPING>();
            var listTempDB = _unit.MasterTempCustomerVendorMappingRepo.GetAll();
            listTempDB.ForEach(i =>
            {
                var masterDB = _unit.MasterCustomerVendorMappingRepo.GetAllByKeyAndVersion(i.CustomerShortName, i.Type, i.SourceSystem, i.VersionNo).FirstOrDefault();
                if (masterDB == null)
                {
                    // create
                    masterDB = new MBR_MST_CUSTOMER_VENDOR_MAPPING(i);
                    newMasterDB.Add(masterDB);
                }
                else
                {
                    // update
                    if (i.DeletedFlag == APPCONSTANT.DELETE_FLAG.YES)
                        masterDB.MarkDelete(i.DeletedBy);
                }
            });

            // insert data
            if (newMasterDB.Count > 0)
                _unit.MasterCustomerVendorMappingRepo.Add(newMasterDB);

            _unit.SaveTransaction();

            int total = listTempDB.Count();

            return total;
        }

        public int MoveMasterMarketPriceMapping()
        {
            var newMasterDB = new List<MBR_MST_MARKET_PRICE_MAPPING>();
            var listTempDB = _unit.MasterTempMarketPriceMappingRepo.GetAll();
            listTempDB.ForEach(i =>
            {
                var masterDB = _unit.MasterMarketPriceMappingRepo.GetAllByKeyAndVersion(i.MarketPriceMI, i.MarketPriceWebPricing, i.VersionNo, i.MarketPriceName).FirstOrDefault();
                if (masterDB == null)
                {
                    // create
                    masterDB = new MBR_MST_MARKET_PRICE_MAPPING(i);
                    newMasterDB.Add(masterDB);
                }
                else
                {
                    // update
                    if (i.DeletedFlag == APPCONSTANT.DELETE_FLAG.YES)
                        masterDB.MarkDelete(i.DeletedBy);
                }
            });

            // insert data
            if (newMasterDB.Count > 0)
                _unit.MasterMarketPriceMappingRepo.Add(newMasterDB);

            _unit.SaveTransaction();

            int total = listTempDB.Count();

            return total;
        }

        public string UploadMasterProductMapping(DataWIthInterface<ValidateProductMappingTempModel> data, out int total)
        {
            total = 0;

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

            // Create Validate Model & Set Id (RowNo)
            var userInputData = new List<ProductMappingModel>();
            data.Data.ForEach(i =>
            {
                row++;

                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                userInputData.Add(convertModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            #region Save Data

            // Get data with DeleteFlag = 'N' from master table
            List<MBR_TMP_PRODUCT_MAPPING> newTempData = _unit.MasterProductMappingRepo
                                .Read()
                                .Where(w => w.DeletedFlag == APPCONSTANT.DELETE_FLAG.NO)
                                .OrderBy(o => o.CreatedDate)
                                .Select(s => new MBR_TMP_PRODUCT_MAPPING(s))
                                .ToList();

            // Loop through user input data, if primary key matches, then mark delete and insert new data (version + 1)
            // otherwise just insert new data (version 1)
            userInputData.ForEach(userInputData =>
            {
                // this can be only one record!
                var matchedExistingRecord = newTempData
                            .Where(w => w.MaterialCode == userInputData.MaterialCode)
                            .OrderBy(o => o.CreatedDate)
                            .FirstOrDefault();

                // Existing data
                if (matchedExistingRecord != null)
                {
                    matchedExistingRecord.MarkDelete(null);
                    var newData = new MBR_TMP_PRODUCT_MAPPING(userInputData.ProductShortName, userInputData.MaterialCode, userInputData.ProductGroup, userInputData.SourceSystem, (matchedExistingRecord.VersionNo + 1), userInputData.ProductName);
                    newTempData.Add(newData);
                }

                // New data or initial data
                else
                {
                    var newData = new MBR_TMP_PRODUCT_MAPPING(userInputData.ProductShortName, userInputData.MaterialCode, userInputData.ProductGroup, userInputData.SourceSystem, 1, userInputData.ProductName);
                    newTempData.Add(newData);
                }
            });

            // Truncate temp table and insert
            _unit.MasterProductMappingRepo.ExecuteCommand($"TRUNCATE TABLE [mbr].[MBR_TMP_ProductMapping]", new List<SqlParameter>());

            _unit.MasterTempProductMappingRepo.BulkInsert(newTempData);
            _unit.SaveTransaction();

            // set Total record
            total = newTempData.Count();

            #endregion Save Data

            #region Call API

            // Call DWH pipeline and return runnigid

            bool isCallApiSuccess = true;
            string runId = CallDataFactory("ProductMapping");
            if (isCallApiSuccess)
            {
                // insert runId to Database
            }
            else
            {
                throw new Exception("Error after call api.");
            }
            //MoveMasterProductMapping(); // Use Instead

            #endregion Call API

            //MoveMasterProductMapping();
            return runId;
        }

        public string UploadMasterProductMappingOriginal(DataWIthInterface<ValidateProductMappingTempModel> data, out int total)
        {
            total = 0;

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

            var validateModels = new List<ProductMappingModel>();
            data.Data.ForEach(i =>
            {
                row++;

                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                validateModels.Add(convertModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            #region Mapping value with DB

            //// Product Site
            //var productionSite = validateModels.Select(s => s.ProductionSite).Distinct().ToList();
            //var productionSiteDB = _unit.MasterProductionSiteRepo.GetProductionSite(productionSite);

            //// Region
            //var region = validateModels.Select(s => s.RegionCode).Distinct().ToList();
            //var regionDB = _unit.MasterRegionRepo.GetRegionByCodes(region);

            //// Unit
            //var unit = validateModels.Select(s => s.Unit).Distinct().ToList();
            //var unitDB = _unit.MasterPriceUnitRepo.GetByPriceUnitDesc(unit);

            //// Set Data as DB format
            //validateModels.ForEach(i =>
            //{
            //    i.ProductionSite = productionSiteDB.Where(w => String.Equals(w.ProductionSite, i.ProductionSite, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()?.ProductionSite ?? i.ProductionSite;
            //    i.RegionCode = regionDB.Where(w => String.Equals(w.Region, i.RegionCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()?.Region ?? i.RegionCode;
            //    i.Unit = unitDB.Where(w => String.Equals(w.PriceUnitDesc, i.Unit, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()?.PriceUnitDesc ?? i.Unit;
            //});

            #endregion Mapping value with DB

            #region Save Data

            // Step 1 Truncate Temp Data
            //_unit.MasterTempFreightRepo.Truncate();

            // prepare data
            //var unitList = validateModels.Select(s => s.Unit).Distinct().ToList();
            //var unitListDB = _unit.MasterPriceUnitRepo.GetByPriceUnitDesc(unitList);

            // Step 2 Create Temp Data & Mark Delete Temp
            var newTmpData = new List<MBR_TMP_PRODUCT_MAPPING>();

            // clone all active data in main master DB
            var mainMasterDB = _unit.MasterProductMappingRepo.Query().Where(w => w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).OrderBy(o => o.CreatedDate).ToList();
            mainMasterDB.ForEach(mainDB =>
            {
                var tmp = new MBR_TMP_PRODUCT_MAPPING(mainDB);
                newTmpData.Add(tmp);
            });

            //data.PlanType.ForEach(planType =>
            //{
            //});
            validateModels.ForEach(i =>
            {
                //var dataDB = _unit.MasterFreightRepo.GetByKey(i.ProductionSite, i.RegionCode, planType, i.StartMonth).OrderBy(o=> o.CreatedDate).ToList();
                var dataDB = newTmpData.Where(w => w.ProductShortName == i.ProductShortName && w.MaterialCode == i.MaterialCode).OrderBy(o => o.CreatedDate).ToList();
                int lastVersion = dataDB.OrderByDescending(o => o.CreatedDate).Select(s => s.VersionNo).FirstOrDefault();
                //var unitId = unitListDB.Where(w => w.PriceUnitDesc == i.Unit).Select(s => s.PriceUnitId).FirstOrDefault();

                // insert & mark delete old data
                dataDB.ForEach(db =>
                {
                    //var tmp = new SSP_TMP_FREIGHT(tmp);
                    //tmp.MarkDelete();
                    db.MarkDelete(null);

                    // insert to temp DB
                    //_unit.MasterTempFreightRepo.Add(tmp);

                    //newTmpData.Add(tmp);
                });

                // create new data
                var newData = new MBR_TMP_PRODUCT_MAPPING(i.ProductShortName, i.MaterialCode, i.ProductGroup, i.SourceSystem, (lastVersion + 1), i.ProductName);
                newTmpData.Add(newData);
            });
            // Truncate before insert
            var deleteDataDB = _unit.MasterTempProductMappingRepo.GetAll();
            _unit.MasterTempProductMappingRepo.BulkDelete(deleteDataDB);

            _unit.MasterTempProductMappingRepo.BulkInsert(newTmpData);

            _unit.SaveTransaction();

            // set Total record
            total = newTmpData.Count();

            #endregion Save Data

            #region Call API

            bool isCallApiSuccess = true;
            string runId = CallDataFactory("ProductMapping");
            if (isCallApiSuccess)
            {
                // insert runId to Database
            }
            else
            {
                throw new Exception("Error after call api.");
            }
            //MoveMasterProductMapping(); // Use Instead

            #endregion Call API

            return runId;
        }

        public string UploadMasterCustomerVendorMapping(DataWIthInterface<ValidateCustomerVendorMappingTempModel> data, out int total)
        {
            total = 0;

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

            var validateModels = new List<CustomerVendorMappingModel>();
            data.Data.ForEach(i =>
            {
                row++;

                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                validateModels.Add(convertModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            #region Save Data

            // Step 1 Truncate Temp Data
            //_unit.MasterTempFreightRepo.Truncate();

            // prepare data
            //var unitList = validateModels.Select(s => s.Unit).Distinct().ToList();
            //var unitListDB = _unit.MasterPriceUnitRepo.GetByPriceUnitDesc(unitList);

            // Step 2 Create Temp Data & Mark Delete Temp
            var newTmpData = new List<MBR_TMP_CUSTOMER_VENDOR_MAPPING>();

            // clone all active data in main master DB
            var mainMasterDB = _unit.MasterCustomerVendorMappingRepo.Read().Where(w => w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).OrderBy(o => o.CreatedDate).ToList();
            mainMasterDB.ForEach(mainDB =>
            {
                var tmp = new MBR_TMP_CUSTOMER_VENDOR_MAPPING(mainDB);
                newTmpData.Add(tmp);
            });

            validateModels.ForEach(i =>
            {
                var dataDB = newTmpData.Where(w => w.CustomerShortName == i.CustomerShortName && w.Type == i.Type).OrderBy(o => o.CreatedDate).ToList();
                int lastVersion = dataDB.OrderByDescending(o => o.CreatedDate).Select(s => s.VersionNo).FirstOrDefault();

                // insert & mark delete old data
                dataDB.ForEach(db =>
                {
                    //var tmp = new SSP_TMP_FREIGHT(tmp);
                    //tmp.MarkDelete();
                    db.MarkDelete(null);

                    // insert to temp DB
                    //_unit.MasterTempFreightRepo.Add(tmp);

                    //newTmpData.Add(tmp);
                });

                // create new data
                var newData = new MBR_TMP_CUSTOMER_VENDOR_MAPPING(i.CustomerShortName, i.Type, i.CustomerCode, i.SourceSystem, (lastVersion + 1));
                newTmpData.Add(newData);
            });
            // Truncate before insert
            _unit.MasterTempCustomerVendorMappingRepo.ExecuteCommand("TRUNCATE TABLE [mbr].[MBR_TMP_CustomerVendorMapping]", new List<SqlParameter>());

            _unit.MasterTempCustomerVendorMappingRepo.BulkInsert(newTmpData);

            _unit.SaveTransaction();

            // set Total record
            total = newTmpData.Count();

            #endregion Save Data

            #region Call API

            bool isCallApiSuccess = true;
            string runId = CallDataFactory("CustomerVendorMapping");
            if (isCallApiSuccess)
            {
                // insert runId to Database
            }
            else
            {
                throw new Exception("Error after call api.");
            }
            //MoveMasterCustomerVendorMapping();

            #endregion Call API

            return runId;
        }

        public string UploadMasterLSPPriceFormula(DataWIthInterface<ValidateLSPPriceFormulaTempModel> data, out int total)
        {
            total = 0;

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

            var validateModels = new List<LSPPriceFormulaModel>();
            data.Data.ForEach(i =>
            {
                row++;

                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                validateModels.Add(convertModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            #region Mapping value with DB

            //// Product Site
            //var productionSite = validateModels.Select(s => s.ProductionSite).Distinct().ToList();
            //var productionSiteDB = _unit.MasterProductionSiteRepo.GetProductionSite(productionSite);

            //// Region
            //var region = validateModels.Select(s => s.RegionCode).Distinct().ToList();
            //var regionDB = _unit.MasterRegionRepo.GetRegionByCodes(region);

            //// Unit
            //var unit = validateModels.Select(s => s.Unit).Distinct().ToList();
            //var unitDB = _unit.MasterPriceUnitRepo.GetByPriceUnitDesc(unit);

            //// Set Data as DB format
            //validateModels.ForEach(i =>
            //{
            //    i.ProductionSite = productionSiteDB.Where(w => String.Equals(w.ProductionSite, i.ProductionSite, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()?.ProductionSite ?? i.ProductionSite;
            //    i.RegionCode = regionDB.Where(w => String.Equals(w.Region, i.RegionCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()?.Region ?? i.RegionCode;
            //    i.Unit = unitDB.Where(w => String.Equals(w.PriceUnitDesc, i.Unit, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()?.PriceUnitDesc ?? i.Unit;
            //});

            #endregion Mapping value with DB

            #region Save Data

            // Step 1 Truncate Temp Data
            //_unit.MasterTempFreightRepo.Truncate();

            // prepare data
            //var unitList = validateModels.Select(s => s.Unit).Distinct().ToList();
            //var unitListDB = _unit.MasterPriceUnitRepo.GetByPriceUnitDesc(unitList);

            // Step 2 Create Temp Data & Mark Delete Temp
            var newTmpData = new List<MBR_TMP_LSP_PRICE_FORMULA>();

            // clone all active data in main master DB
            var mainMasterDB = _unit.MasterLSPPriceFormulaRepo.Read().Where(w => w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).OrderBy(o => o.CreatedDate).ToList();
            mainMasterDB.ForEach(mainDB =>
            {
                var tmp = new MBR_TMP_LSP_PRICE_FORMULA(mainDB);
                newTmpData.Add(tmp);
            });

            //data.PlanType.ForEach(planType =>
            //{
            //});
            validateModels.ForEach(i =>
            {
                //var dataDB = _unit.MasterFreightRepo.GetByKey(i.ProductionSite, i.RegionCode, planType, i.StartMonth).OrderBy(o=> o.CreatedDate).ToList();
                var dataDB = newTmpData.Where(w => w.FormulaName == i.FormulaName).OrderBy(o => o.CreatedDate).ToList();
                int lastVersion = dataDB.OrderByDescending(o => o.CreatedDate).Select(s => s.VersionNo).FirstOrDefault();
                //var unitId = unitListDB.Where(w => w.PriceUnitDesc == i.Unit).Select(s => s.PriceUnitId).FirstOrDefault();

                // insert & mark delete old data
                dataDB.ForEach(db =>
                {
                    //var tmp = new SSP_TMP_FREIGHT(tmp);
                    //tmp.MarkDelete();
                    db.MarkDelete(null);

                    // insert to temp DB
                    //_unit.MasterTempFreightRepo.Add(tmp);

                    //newTmpData.Add(tmp);
                });

                // create new data
                var newData = new MBR_TMP_LSP_PRICE_FORMULA(i.ProductCode, i.ProductShortName, i.ProductDescription
                                , i.FormulaName, i.FormulaDescription, i.FormulaEquation, (lastVersion + 1));
                newTmpData.Add(newData);
            });
            // Truncate before insert
            _unit.MasterTempLSPPriceFormulaRepo.ExecuteCommand($"TRUNCATE TABLE [mbr].[MBR_TMP_LSPPriceFormula]", new List<SqlParameter>());

            _unit.MasterTempLSPPriceFormulaRepo.BulkInsert(newTmpData);

            _unit.SaveTransaction();

            // set Total record
            total = newTmpData.Count();

            #endregion Save Data

            #region Call API

            bool isCallApiSuccess = true;
            string runId = CallDataFactory("LSPPriceFormula");
            if (isCallApiSuccess)
            {
                // insert runId to Database
            }
            else
            {
                throw new Exception("Error after call api.");
            }

            #endregion Call API

            //MoveMasterLSPPriceFormula();
            return runId;
        }

        public string UploadMasterMarketPriceMapping(DataWIthInterface<ValidateMarketPriceMappingTempModel> data, out int total)
        {
            total = 0;

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

            var masterFormulaParameterMappingRepo = _unit.MasterFormulaParameterMappingRepo.GetMasterFormulaParameterByMarketPriceWebPricing(data.Data.Select(s => s.MarketPriceWebPricing).ToList());
            var fctMarketPriceOlefinsRepo = _unit.FctMarketPriceOlefinsRepo.GetFctMarketPriceOlefinsByMarketPriceName(data.Data.Select(s => s.MarketPriceName).ToList());
            var validateModels = new List<MarketPriceMappingModel>();
            data.Data.ForEach(i =>
            {
                row++;

                var convertErrorList = new List<string>();
                var convertModel = i.TryConvertToModel(masterFormulaParameterMappingRepo, fctMarketPriceOlefinsRepo, out convertErrorList);

                validateModels.Add(convertModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            #region Mapping value with DB

            //// Product Site
            //var productionSite = validateModels.Select(s => s.ProductionSite).Distinct().ToList();
            //var productionSiteDB = _unit.MasterProductionSiteRepo.GetProductionSite(productionSite);

            //// Region
            //var region = validateModels.Select(s => s.RegionCode).Distinct().ToList();
            //var regionDB = _unit.MasterRegionRepo.GetRegionByCodes(region);

            //// Unit
            //var unit = validateModels.Select(s => s.Unit).Distinct().ToList();
            //var unitDB = _unit.MasterPriceUnitRepo.GetByPriceUnitDesc(unit);

            //// Set Data as DB format
            //validateModels.ForEach(i =>
            //{
            //    i.ProductionSite = productionSiteDB.Where(w => String.Equals(w.ProductionSite, i.ProductionSite, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()?.ProductionSite ?? i.ProductionSite;
            //    i.RegionCode = regionDB.Where(w => String.Equals(w.Region, i.RegionCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()?.Region ?? i.RegionCode;
            //    i.Unit = unitDB.Where(w => String.Equals(w.PriceUnitDesc, i.Unit, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()?.PriceUnitDesc ?? i.Unit;
            //});

            #endregion Mapping value with DB

            #region Save Data

            // Step 1 Truncate Temp Data
            //_unit.MasterTempFreightRepo.Truncate();

            // prepare data
            //var unitList = validateModels.Select(s => s.Unit).Distinct().ToList();
            //var unitListDB = _unit.MasterPriceUnitRepo.GetByPriceUnitDesc(unitList);

            // Step 2 Create Temp Data & Mark Delete Temp
            var newTmpData = new List<MBR_TMP_MARKET_PRICE_MAPPING>();

            // clone all active data in main master DB
            var mainMasterDB = _unit.MasterMarketPriceMappingRepo.Read().Where(w => w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).OrderBy(o => o.CreatedDate).ToList();
            mainMasterDB.ForEach(mainDB =>
            {
                var tmp = new MBR_TMP_MARKET_PRICE_MAPPING(mainDB);
                newTmpData.Add(tmp);
            });

            // Grab distinct MarketPriceMI from uploaded data
            // then mark delete
            List<string> distinctMarketPriceMI = validateModels.Select(s => s.MarketPriceMI).Distinct().ToList();
            distinctMarketPriceMI.ForEach(i =>
            {
                var marketPriceMIs = newTmpData.Where(w => w.MarketPriceMI == i).ToList();
                marketPriceMIs.ForEach(j => j.MarkDelete(null));
            });

            validateModels.ForEach(i =>
            {
                var dataDB = newTmpData.Where(w => w.MarketPriceMI == i.MarketPriceMI &&
                                                   w.MarketPriceWebPricing == i.MarketPriceWebPricing &&
                                                   w.MarketPriceName == i.MarketPriceName)
                                       .OrderBy(o => o.CreatedDate)
                                       .ToList();
                int lastVersion = dataDB.OrderByDescending(o => o.CreatedDate).Select(s => s.VersionNo).FirstOrDefault();

                dataDB.ForEach(db =>
                {
                    db.MarkDelete(null);
                });

                // create new data
                var newData = new MBR_TMP_MARKET_PRICE_MAPPING(i.MarketPriceShortName, i.MarketPriceMI, i.MarketPriceWebPricing
                                , i.MarketPriceName, i.EBACode, (lastVersion + 1));

                newTmpData.Add(newData);
            });
            // Truncate temp table and insert
            _unit.MarketPriceForecastRepo.ExecuteCommand($"TRUNCATE TABLE [mbr].[MBR_TMP_MarketPriceMapping]", new List<SqlParameter>());

            _unit.MasterTempMarketPriceMappingRepo.BulkInsert(newTmpData);

            _unit.SaveTransaction();

            // set Total record
            total = newTmpData.Count();

            #endregion Save Data

            #region Call API

            bool isCallApiSuccess = true;
            string runId = CallDataFactory("MarketPriceMapping");
            if (isCallApiSuccess)
            {
                // insert runId to Database
            }
            else
            {
                throw new Exception("Error after call api.");
            }

            #endregion Call API

            //MoveMasterMarketPriceMapping();
            return runId;
        }
    }
}