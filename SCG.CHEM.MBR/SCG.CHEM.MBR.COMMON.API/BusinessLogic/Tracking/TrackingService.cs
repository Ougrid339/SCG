using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.COMMON.API.AppModels.Tracking;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.Tracking.Interface;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS;

//using SCG.CHEM.MBR.COMMON.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using System.Globalization;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.Services.Validation.Interface;
using SCG.CHEM.MBR.COMMON.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.Logging.Interface;
using Newtonsoft.Json;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.Datafacetory.Interface;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.COMMON.API.AppModels.Optience;
using SCG.CHEM.MBR.COMMON.API.AppModels.Sales;
using SCG.CHEM.MBR.COMMON.API.AppModels.FeedInfo;
using SCG.CHEM.MBR.COMMON.API.AppModels.DataFactory;

namespace SCG.CHEM.MBR.COMMON.API.BusinessLogic.Tracking
{
    public class TrackingService : ITrackingService
    {
        private readonly UnitOfWork _unit;
        private readonly ILogService _logService;
        private readonly IDataFactoryService _dataFactoryService;

        public TrackingService(UnitOfWork unitOfWork, ILogService logService, IDataFactoryService dataFactoryService)
        {
            this._unit = unitOfWork;
            this._logService = logService;
            this._dataFactoryService = dataFactoryService;
        }

        #region Call Data Fact

        public string CallDataFactoryMarketPrice(string tableName, string transactionName, string cycleName, string caseName, string planType)
        {
            string userName = UserUtilities.GetADAccount()?.UserId ?? "";
            string res = _dataFactoryService.RunPipeline(tableName, transactionName, cycleName, caseName, planType, userName);

            return res;
        }

        public string CallDataFactoryOptience(string tableName, string transactionName, string cycleName, string caseName, string planType, List<string> company)
        {
            string userName = UserUtilities.GetADAccount()?.UserId ?? "";
            string res = _dataFactoryService.RunPipelineOptience(tableName, transactionName, cycleName, caseName, planType, company, userName);

            return res;
        }

        public string CallDataFactoryFeedInfo(string tableName, string transactionName, RequestCriteriaTransaction criteria, string submitStatus)
        {
            string userName = UserUtilities.GetADAccount()?.UserId ?? "";
            string res = _dataFactoryService.RunPipelineMultiCriteria(tableName, transactionName, criteria, userName, submitStatus);

            return res;
        }

        public string CallDataFactorySale(string tableName, string transactionName, RequestCriteriaSales criteria, string submitStatus, bool isPreview, Guid webUUID, bool isMerge = false)
        {
            string userName = UserUtilities.GetADAccount()?.UserId ?? "";
            string res = _dataFactoryService.RunPipelineSalesCriteria(tableName, transactionName, criteria, submitStatus, userName, isPreview, webUUID);

            return res;
        }

        #endregion Call Data Fact

        public List<SearchTrackingResModel> SearchTracking(SearchTrackingReqModel data, out int total)
        {
            var res = new List<SearchTrackingResModel>();
            var lstData = new List<TrackingModel>();
            total = 0;

            //var datafactory = _unit.DataFactoryRunRepo.GetTransactionByCriteria(data.PlanType, data.Cycle);
            var lstName = new List<TransactionNameModel> {
                new TransactionNameModel { name = TRANSACTIONMAINNAME.MI,trnName = TRANSACTIONNAME.MARKETPRICEFORECAST,officialName = TRANSACTIONNAMESHOW.MARKETPRICEFORECAST,type = HISTORY_MBR_TYPE.MARKET_PRICE_FORECAST, ExcelId = 1}, // fix hardcoded value later
                new TransactionNameModel { name = TRANSACTIONMAINNAME.Optimize,trnName = TRANSACTIONNAME.PRODUCTIONVOLUME,officialName = TRANSACTIONNAMESHOW.PRODUCTIONVOLUME,type = HISTORY_MBR_TYPE.PRODUCTION_VOLUME, ExcelId = 2},
                new TransactionNameModel { name = TRANSACTIONMAINNAME.Optimize,trnName = TRANSACTIONNAME.FEEDCONSUMPTION, officialName = TRANSACTIONNAMESHOW.FEEDCONSUMPTION,type = HISTORY_MBR_TYPE.FEED_CONSUMPTION, ExcelId = 3},
                new TransactionNameModel { name = TRANSACTIONMAINNAME.Optimize,trnName = TRANSACTIONNAME.BEGINNINGINVENTORY, officialName = TRANSACTIONNAMESHOW.BEGINNINGINVENTORY,type = HISTORY_MBR_TYPE.BEGINNING_INVENTORY, ExcelId = 4},
                new TransactionNameModel { name = TRANSACTIONMAINNAME.Optimize,trnName = TRANSACTIONNAME.FEEDPURCHASE, officialName = TRANSACTIONNAMESHOW.FEEDPURCHASE,type = HISTORY_MBR_TYPE.FEED_PURCHASE, ExcelId = 5},
                new TransactionNameModel { name = TRANSACTIONMAINNAME.Sales,trnName = TRANSACTIONNAME.SALEVOLUME, officialName = TRANSACTIONNAMESHOW.SALEVOLUME,type = HISTORY_MBR_TYPE.SALE_VOLUME, ExcelId = 7},
                new TransactionNameModel { name = TRANSACTIONMAINNAME.Feed,trnName = TRANSACTIONNAME.FEEDINFO, officialName = TRANSACTIONNAMESHOW.FEEDINFO,type = HISTORY_MBR_TYPE.FEED_DATA,  ExcelId = 6 },
            }.GroupBy(g => g.name);
            foreach (var item in lstName)
            {
                var model = new SearchTrackingResModel
                {
                    Name = item.Key
                };
                var lstTransaction = new List<TrackingModel>();
                foreach (var trn in item)
                {
                    #region MI

                    if (item.Key == TRANSACTIONMAINNAME.MI)
                    {
                        var dataDB = _unit.MarketPriceForecastRepo.FindByCriteria(data.PlanType, data.Case, data.Cycle).OrderByDescending(o => o.UpdatedDate ?? o.CreatedDate).FirstOrDefault();
                        if (dataDB != null)
                        {
                            lstTransaction.Add(new TrackingModel
                            {
                                Detail = trn.officialName,
                                UploadStatus = "Success",
                                ValidateStatus = "Success",
                                UpdatedBy = dataDB.UpdatedBy ?? dataDB.CreatedBy,
                                Updateddate = dataDB.UpdatedDate ?? dataDB.CreatedDate,
                                Type = trn.type,
                                ExcelId = trn.ExcelId
                            });
                        }
                        else
                        {
                            lstTransaction.Add(new TrackingModel
                            {
                                Detail = trn.officialName,
                                UploadStatus = "Fail",
                                ValidateStatus = "Fail",
                                UpdatedBy = null,
                                Updateddate = null,
                                Type = trn.type,
                                ExcelId = trn.ExcelId
                            });
                        }
                    }

                    #endregion MI

                    #region Optience

                    if (item.Key == TRANSACTIONMAINNAME.Optimize)

                    {
                        // Production Volume
                        if (trn.type == HISTORY_MBR_TYPE.PRODUCTION_VOLUME)
                        {
                            var dataDB = _unit.ProductionVolumeRepo.FindByCriterias(data.PlanType, data.Case, data.Cycle).OrderByDescending(o => o.UpdatedDate ?? o.CreatedDate).FirstOrDefault();
                            if (dataDB != null)
                            {
                                lstTransaction.Add(new TrackingModel
                                {
                                    Detail = trn.officialName,
                                    UploadStatus = "Success",
                                    ValidateStatus = "Success",
                                    UpdatedBy = dataDB.UpdatedBy ?? dataDB.CreatedBy,
                                    Updateddate = dataDB.UpdatedDate ?? dataDB.CreatedDate,
                                    Type = trn.type,
                                    ExcelId = trn.ExcelId
                                });
                            }
                            else
                            {
                                lstTransaction.Add(new TrackingModel
                                {
                                    Detail = trn.officialName,
                                    UploadStatus = "Fail",
                                    ValidateStatus = "Fail",
                                    UpdatedBy = null,
                                    Updateddate = null,
                                    Type = trn.type,
                                    ExcelId = trn.ExcelId
                                });
                            }
                        }
                        //Feed Consumption
                        if (trn.type == HISTORY_MBR_TYPE.FEED_CONSUMPTION)
                        {
                            var dataDB = _unit.FeedConsumptionRepo.FindByCriterias(data.PlanType, data.Case, data.Cycle).OrderByDescending(o => o.UpdatedDate ?? o.CreatedDate).FirstOrDefault();
                            if (dataDB != null)
                            {
                                lstTransaction.Add(new TrackingModel
                                {
                                    Detail = trn.officialName,
                                    UploadStatus = "Success",
                                    ValidateStatus = "Success",
                                    UpdatedBy = dataDB.UpdatedBy ?? dataDB.CreatedBy,
                                    Updateddate = dataDB.UpdatedDate ?? dataDB.CreatedDate,
                                    Type = trn.type,
                                    ExcelId = trn.ExcelId
                                });
                            }
                            else
                            {
                                lstTransaction.Add(new TrackingModel
                                {
                                    Detail = trn.officialName,
                                    UploadStatus = "Fail",
                                    ValidateStatus = "Fail",
                                    UpdatedBy = null,
                                    Updateddate = null,
                                    Type = trn.type,
                                    ExcelId = trn.ExcelId
                                });
                            }
                        }

                        // Brginning Inventory
                        if (trn.type == HISTORY_MBR_TYPE.BEGINNING_INVENTORY)
                        {
                            var dataDB = _unit.BeginningInventoryRepo.FindByCriterias(data.PlanType, data.Case, data.Cycle).OrderByDescending(o => o.UpdatedDate ?? o.CreatedDate).FirstOrDefault();
                            if (dataDB != null)
                            {
                                lstTransaction.Add(new TrackingModel
                                {
                                    Detail = trn.officialName,
                                    UploadStatus = "Success",
                                    ValidateStatus = "Success",
                                    UpdatedBy = dataDB.UpdatedBy ?? dataDB.CreatedBy,
                                    Updateddate = dataDB.UpdatedDate ?? dataDB.CreatedDate,
                                    Type = trn.type,
                                    ExcelId = trn.ExcelId
                                });
                            }
                            else
                            {
                                lstTransaction.Add(new TrackingModel
                                {
                                    Detail = trn.officialName,
                                    UploadStatus = "Fail",
                                    ValidateStatus = "Fail",
                                    UpdatedBy = null,
                                    Updateddate = null,
                                    Type = trn.type,
                                    ExcelId = trn.ExcelId
                                });
                            }
                        }

                        // Feed Purchase
                        if (trn.type == HISTORY_MBR_TYPE.FEED_PURCHASE)
                        {
                            var dataDB = _unit.FeedPurchaseRepo.FindByCriteria(data.PlanType, data.Case, data.Cycle).OrderByDescending(o => o.UpdatedDate ?? o.CreatedDate).FirstOrDefault();
                            if (dataDB != null)
                            {
                                lstTransaction.Add(new TrackingModel
                                {
                                    Detail = trn.officialName,
                                    UploadStatus = "Success",
                                    ValidateStatus = "Success",
                                    UpdatedBy = dataDB.UpdatedBy ?? dataDB.CreatedBy,
                                    Updateddate = dataDB.UpdatedDate ?? dataDB.CreatedDate,
                                    Type = trn.type,
                                    ExcelId = trn.ExcelId
                                });
                            }
                            else
                            {
                                lstTransaction.Add(new TrackingModel
                                {
                                    Detail = trn.officialName,
                                    UploadStatus = "Fail",
                                    ValidateStatus = "Fail",
                                    UpdatedBy = null,
                                    Updateddate = null,
                                    Type = trn.type,
                                    ExcelId = trn.ExcelId
                                });
                            }
                        }
                    }

                    #endregion Optience

                    #region Sale

                    if (item.Key == TRANSACTIONMAINNAME.Sales)
                    {
                        lstTransaction.Add(new TrackingModel
                        {
                            Detail = trn.officialName,
                            ExcelId = trn.ExcelId
                        });
                        var dataDB = _unit.SalesVoiumeRepo.FindByCriteria(data.PlanType, data.Case, data.Cycle).OrderByDescending(o => o.UpdatedDate ?? o.CreatedDate).ToList();
                        var productGroup = dataDB.Select(s => s.ProductGroup).Distinct().ToList();
                        var saleConfirm = _unit.SaleConfirmRepo.FindByCriteria(data.PlanType, data.Cycle, data.Case);

                        foreach (var product in productGroup)
                        {
                            var saleVolumeData = dataDB.Where(w => w.ProductGroup == product).OrderByDescending(o => o.UpdatedDate ?? o.CreatedDate).FirstOrDefault();
                            var updateDate = saleVolumeData.UpdatedDate ?? saleVolumeData.CreatedDate;
                            // Check Sale Confirmed
                            var saleConfirmPass = saleConfirm?.FirstOrDefault(w => w.ProductGroup == product) ?? null;
                            if (saleConfirmPass != null)
                            {
                                var dt1 = new DateTime(saleConfirmPass.UpdatedDate.Value.Year, saleConfirmPass.UpdatedDate.Value.Month, saleConfirmPass.UpdatedDate.Value.Day, saleConfirmPass.UpdatedDate.Value.Hour, saleConfirmPass.UpdatedDate.Value.Minute, saleConfirmPass.UpdatedDate.Value.Second);
                                var dt2 = new DateTime(updateDate.Year, updateDate.Month, updateDate.Day, updateDate.Hour, updateDate.Minute, updateDate.Second);
                                saleConfirmPass = dt1 < dt2 ? null : saleConfirmPass;
                            }

                            // set datetime no sec
                            DateTime? dateProductionVOlume = lstData.FirstOrDefault(f => f.Detail == TRANSACTIONNAMESHOW.PRODUCTIONVOLUME).Updateddate.HasValue ?
                                lstData.FirstOrDefault(f => f.Detail == TRANSACTIONNAMESHOW.PRODUCTIONVOLUME).Updateddate.Value : null;
                            var dtVolume = dateProductionVOlume != null ?
                                (DateTime?)new DateTime(dateProductionVOlume.Value.Year, dateProductionVOlume.Value.Month, dateProductionVOlume.Value.Day,
                                        dateProductionVOlume.Value.Hour, dateProductionVOlume.Value.Minute, 0) : null;

                            DateTime? dateMarketPriceForecast = lstData.FirstOrDefault(f => f.Detail == TRANSACTIONNAMESHOW.MARKETPRICEFORECAST).Updateddate.HasValue ?
                                lstData.FirstOrDefault(f => f.Detail == TRANSACTIONNAMESHOW.MARKETPRICEFORECAST).Updateddate.Value : null;
                            var dtMkPrice = dateMarketPriceForecast != null ?
                                (DateTime?)new DateTime(dateMarketPriceForecast.Value.Year, dateMarketPriceForecast.Value.Month, dateMarketPriceForecast.Value.Day,
                                        dateMarketPriceForecast.Value.Hour, dateMarketPriceForecast.Value.Minute, 0) : null;
                            var dtForCheckEq = new DateTime(updateDate.Year, updateDate.Month, updateDate.Day, updateDate.Hour, updateDate.Minute, 0);

                            var checkWarning = dtMkPrice > dtForCheckEq
                                         ? true : dtVolume > dtForCheckEq ? true : false;
                            var checkEq = CheckSaleAndProduction(data, saleVolumeData.Product);
                            lstTransaction.Add(new TrackingModel
                            {
                                Detail = "- " + saleVolumeData.ProductGroup,
                                UploadStatus = "Success",
                                ValidateStatus = checkWarning || (checkEq != null && checkEq.Count >= 1 && saleConfirmPass == null) ? "Warning" : "Success",
                                UpdatedBy = saleVolumeData.UpdatedBy ?? saleVolumeData.CreatedBy,
                                Updateddate = saleVolumeData.UpdatedDate ?? saleVolumeData.CreatedDate,
                                Type = trn.type,
                                ExcelId = trn.ExcelId,
                                ProductGroup = product,
                                NotEq = checkEq != null && checkEq.Count >= 1 && saleConfirmPass == null ? checkEq : null
                            });
                        }
                        var saleVolumeMain = lstTransaction.FirstOrDefault(f => f.Detail == trn.officialName);
                        if (lstTransaction.Where(w => w.Type == trn.type).Select(s => s.UploadStatus != "Success" && s.ValidateStatus != "Success")?.Count() >= 1)
                        {
                            lstTransaction.Where(f => f.Detail == trn.officialName).ToList().ForEach(f => { f.UploadStatus = "Fail"; f.ValidateStatus = "Fail"; });
                        }
                        else
                        {
                            lstTransaction.Where(f => f.Detail == trn.officialName).ToList().ForEach(f => { f.UploadStatus = "Success"; f.ValidateStatus = "Success"; });
                        }
                    }

                    #endregion Sale

                    #region Feed

                    if (item.Key == TRANSACTIONMAINNAME.Feed)
                    {
                        var dataDB = _unit.FeedInfoRepo.FindByCriterias(data.PlanType, data.Case, data.Cycle).OrderByDescending(o => o.UpdatedDate ?? o.CreatedDate).FirstOrDefault();
                        if (dataDB != null)
                        {
                            var updateDate = dataDB.UpdatedDate ?? dataDB.CreatedDate;
                            // set datetime no sec
                            DateTime? dateFeedConsumption = lstData.FirstOrDefault(f => f.Detail == TRANSACTIONNAMESHOW.FEEDCONSUMPTION).Updateddate.HasValue ?
                                lstData.FirstOrDefault(f => f.Detail == TRANSACTIONNAMESHOW.FEEDCONSUMPTION).Updateddate.Value : null;
                            var dtFeedCon = dateFeedConsumption != null ?
                                (DateTime?)new DateTime(dateFeedConsumption.Value.Year, dateFeedConsumption.Value.Month, dateFeedConsumption.Value.Day,
                                        dateFeedConsumption.Value.Hour, dateFeedConsumption.Value.Minute, 0) : null;

                            DateTime? dateMarketPriceForecast = lstData.FirstOrDefault(f => f.Detail == TRANSACTIONNAMESHOW.MARKETPRICEFORECAST).Updateddate.HasValue ?
                                lstData.FirstOrDefault(f => f.Detail == TRANSACTIONNAMESHOW.MARKETPRICEFORECAST).Updateddate.Value : null;
                            var dtMkPrice = dateMarketPriceForecast != null ?
                                (DateTime?)new DateTime(dateMarketPriceForecast.Value.Year, dateMarketPriceForecast.Value.Month, dateMarketPriceForecast.Value.Day,
                                        dateMarketPriceForecast.Value.Hour, dateMarketPriceForecast.Value.Minute, 0) : null;
                            var dtForCheckEq = new DateTime(updateDate.Year, updateDate.Month, updateDate.Day, updateDate.Hour, updateDate.Minute, 0);

                            var checkWarning = dtMkPrice > dtForCheckEq
                                ? true : dtFeedCon > dtForCheckEq
                                        ? true : false;

                            lstTransaction.Add(new TrackingModel
                            {
                                Detail = trn.officialName,
                                UploadStatus = "Success",
                                ValidateStatus = checkWarning ? "Warning" : "Success",
                                UpdatedBy = dataDB.UpdatedBy ?? dataDB.CreatedBy,
                                Updateddate = dataDB.UpdatedDate ?? dataDB.CreatedDate,
                                Type = trn.type,
                                ExcelId = trn.ExcelId
                            });
                        }
                        else
                        {
                            lstTransaction.Add(new TrackingModel
                            {
                                Detail = trn.officialName,
                                UploadStatus = "Fail",
                                ValidateStatus = "Fail",
                                UpdatedBy = null,
                                Updateddate = null,
                                Type = trn.type,
                                ExcelId = trn.ExcelId
                            });
                        }
                    }

                    #endregion Feed
                }
                model.Data = lstTransaction;
                lstData.AddRange(lstTransaction);
                res.Add(model);
            }
            total = res.Count;
            return res;
        }

        public string Confirm(ConfirmTrackingModel param)
        {
            ResponseModel res = new ResponseModel();

            int total = 0;
            string runId = "";
            long interfaceId = 0;
            var success = false;
            // MI
            if (param.Type == HISTORY_MBR_TYPE.MARKET_PRICE_FORECAST)
            {
                var newData = new DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel>();
                var dataDB = _unit.MarketPriceForecastRepo.FindByCriteria(param.PlanType, param.Case, param.Cycle).ToList();
                var result = UploadMarketPriceForecast(dataDB, param, out total, out runId, out interfaceId, out newData);
                res.Data = result;
                res.Total = total;
                res.IsSuccess = true;
                var logId = _logService.UpdateLog(interfaceId, "/api/UploadMarketPriceForecast/UploadMarketPriceForecast", JsonConvert.SerializeObject(result), APPCONSTANT.HISTORY_MBR_TYPE.MARKET_PRICE_FORECAST, param.PlanType, param.Cycle, param.Case);

                // Log Success
                _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(newData));
                success = true;
            }

            #region Optience

            // Production Volume
            if (param.Type == HISTORY_MBR_TYPE.PRODUCTION_VOLUME)
            {
                var newData = new DataWitOptienceModel<OptienceCriteriaModel, ValidateProductionVolumeModel>();
                var dataDB = _unit.ProductionVolumeRepo.FindByCriterias(param.PlanType, param.Case, param.Cycle).ToList();
                var result = UploadProductionVolume(dataDB, param, out total, out runId, out interfaceId, out newData);

                res.Data = result;
                res.Total = total;
                res.IsSuccess = true;
                var logId = _logService.UpdateLog(interfaceId, "/api/UploadOptience/UploadOptienceProductionVolume", JsonConvert.SerializeObject(result), APPCONSTANT.HISTORY_MBR_TYPE.PRODUCTION_VOLUME, param.PlanType, param.Cycle, param.Case);

                // Log Success
                _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(newData));
                success = true;
            }
            // Feed Consumption
            if (param.Type == HISTORY_MBR_TYPE.FEED_CONSUMPTION)
            {
                var newData = new DataWitOptienceModel<OptienceCriteriaModel, ValidateFeedConsumptionModel>();
                var dataDB = _unit.FeedConsumptionRepo.FindByCriterias(param.PlanType, param.Case, param.Cycle).ToList();
                var result = UploadFeedConsumptionData(dataDB, param, out total, out runId, out interfaceId, out newData);

                res.Data = result;
                res.Total = total;
                res.IsSuccess = true;
                var logId = _logService.UpdateLog(interfaceId, "/api/UploadOptience/UploadOptienceFeedConsumption", JsonConvert.SerializeObject(result), APPCONSTANT.HISTORY_MBR_TYPE.FEED_CONSUMPTION, param.PlanType, param.Cycle, param.Case);

                // Log Success
                _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(newData));
                success = true;
            }

            // Beginning Inventory
            if (param.Type == HISTORY_MBR_TYPE.BEGINNING_INVENTORY)
            {
                var newData = new DataWitOptienceModel<OptienceCriteriaModel, ValidateBeginningInventoryModel>();
                var dataDB = _unit.BeginningInventoryRepo.FindByCriterias(param.PlanType, param.Case, param.Cycle).ToList();
                var result = UploadBeginningInventory(dataDB, param, out total, out runId, out interfaceId, out newData);

                res.Data = result;
                res.Total = total;
                res.IsSuccess = true;
                var logId = _logService.UpdateLog(interfaceId, "/api/UploadOptience/UploadOptienceBeginningInventory", JsonConvert.SerializeObject(result), APPCONSTANT.HISTORY_MBR_TYPE.BEGINNING_INVENTORY, param.PlanType, param.Cycle, param.Case);

                // Log Success
                _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(newData));
                success = true;
            }

            // Feed Purchase
            if (param.Type == HISTORY_MBR_TYPE.FEED_PURCHASE)
            {
                var newData = new DataWitOptienceModel<OptienceCriteriaModel, ValidateFeedPurchaseModel>();
                var dataDB = _unit.FeedPurchaseRepo.FindByCriteria(param.PlanType, param.Case, param.Cycle).ToList();
                var result = UploadFeedPurchase(dataDB, param, out total, out runId, out interfaceId, out newData);

                res.Data = result;
                res.Total = total;
                res.IsSuccess = true;
                var logId = _logService.UpdateLog(interfaceId, "/api/UploadOptience/UploadOptienceFeedPurchase", JsonConvert.SerializeObject(result), APPCONSTANT.HISTORY_MBR_TYPE.FEED_PURCHASE, param.PlanType, param.Cycle, param.Case);

                // Log Success
                _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(newData));
                success = true;
            }

            #endregion Optience

            // Sale Volume
            if (param.Type == HISTORY_MBR_TYPE.SALE_VOLUME && param.ProductGroup != null)
            {
                var newDataLog = new DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel>();
                var dataDB = _unit.SalesVoiumeRepo.FindByCriteriaProductGroup(param.PlanType, param.Case, param.Cycle, param.ProductGroup).ToList();
                var product = dataDB.Select(s => s.Product).Distinct().ToList();
                foreach (var item in product)
                {
                    var checkNotEQ = CheckSaleAndProduction(new SearchTrackingReqModel
                    {
                        Case = param.Case,
                        PlanType = param.PlanType,
                        Cycle = param.Cycle
                    }, item);
                    if (checkNotEQ != null && checkNotEQ.Count >= 1)
                    {
                        var dataExist = _unit.SaleConfirmRepo.FindByCriteria(param.PlanType, param.Cycle, param.Case, param.ProductGroup);
                        if (dataExist == null)
                        {
                            var newData = new MBR_MST_SALECONFIRM(param.PlanType, param.Cycle, param.Case, param.ProductGroup);
                            _unit.SaleConfirmRepo.Add(newData);
                            _unit.SaveTransaction();
                        }
                    }
                }

                var result = UploadSaleVolume(dataDB, param, out total, out runId, out interfaceId, out newDataLog);
                var updatedBy = result.FirstOrDefault()?.UpdatedBy ?? result.FirstOrDefault()?.CreatedBy;
                var updatedDate = result.FirstOrDefault()?.UpdatedDate ?? result.FirstOrDefault()?.CreatedDate;
                var dataUpdate = _unit.SaleConfirmRepo.FindByCriteria(param.PlanType, param.Cycle, param.Case, param.ProductGroup);
                if (dataUpdate != null)
                {
                    dataUpdate.UpdatedBy = updatedBy;
                    dataUpdate.UpdatedDate = updatedDate;
                    _unit.SaveTransaction();
                }

                res.Data = result;
                res.Total = total;
                res.IsSuccess = true;
                var logId = _logService.UpdateLog(interfaceId, "/api/UploadSales/UploadSales", JsonConvert.SerializeObject(result), APPCONSTANT.HISTORY_MBR_TYPE.SALE_VOLUME, param.PlanType, param.Cycle, param.Case);

                // Log Success
                _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(newDataLog));
                success = true;
            }
            // Feed Info
            if (param.Type == HISTORY_MBR_TYPE.FEED_DATA)
            {
                var newData = new DataWithFeedInfoModel<FeedInfoCriteriaModel, ValidateFeedInfoModel>();
                var dataDB = _unit.FeedInfoRepo.FindByCriterias(param.PlanType, param.Case, param.Cycle).ToList();
                var result = UploadFeedInfoCenter(dataDB, param, out total, out runId, out interfaceId, out newData);

                res.Data = result;
                res.Total = total;
                res.IsSuccess = true;
                var logId = _logService.UpdateLog(interfaceId, "/api/UploadFeedInfo/UploadFeedInfo", JsonConvert.SerializeObject(result), APPCONSTANT.HISTORY_MBR_TYPE.FEED_DATA, param.PlanType, param.Cycle, param.Case);

                // Log Success
                _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(newData));
                success = true;
            }
            return runId;
        }

        public LockUnlockModel UpdateLockUnlockCycle(LockUnlockModel param)
        {
            LockUnlockModel res = new LockUnlockModel();
            if (string.IsNullOrEmpty(param.Scenario)) throw new Exception("Scanerio is require.");
            if (string.IsNullOrEmpty(param.Cycle)) throw new Exception("Cycle is require.");
            if (string.IsNullOrEmpty(param.Case)) throw new Exception("Case is require.");

            #region update Lock / Unlock

            var dataDB = _unit.LockUnlockCycleRepo.GetByCriteria(param.Scenario, param.Cycle, param.Case);
            if (dataDB == null)
            {
                MBR_MST_LOCKUNLOCKCYCLE newData = new MBR_MST_LOCKUNLOCKCYCLE(param.Scenario, param.Cycle, param.Case, param.Islock);
                _unit.LockUnlockCycleRepo.Add(newData);
                res.Islock = newData.IsLocked;
                res.Scenario = newData.PlanType;
                res.Cycle = newData.Cycle;
                res.Case = newData.Case;
            }
            else
            {
                dataDB.UpdateLockUnlock(param.Islock);
                res.Islock = dataDB.IsLocked;
                res.Scenario = dataDB.PlanType;
                res.Cycle = dataDB.Cycle;
                res.Case = dataDB.Case;
            }

            #endregion update Lock / Unlock

            _unit.SaveTransaction();
            return res;
        }

        public bool GetLockUnlock(LockUnlockModel param)
        {
            bool res = false;
            if (string.IsNullOrEmpty(param.Scenario)) throw new Exception("Scanerio is require.");
            if (string.IsNullOrEmpty(param.Cycle)) throw new Exception("Cycle is require.");
            if (string.IsNullOrEmpty(param.Case)) throw new Exception("Case is require.");

            #region Get Lock / Unlock

            var dataDB = _unit.LockUnlockCycleRepo.GetByCriteria(param.Scenario, param.Cycle, param.Case);
            if (dataDB != null)
            {
                res = dataDB.IsLocked;
            }

            #endregion Get Lock / Unlock

            return res;
        }

        private DateTime? GetDate(DateTime? update, DateTime? create)
        {
            if (!update.HasValue && !create.HasValue) return update;  // doesn't matter

            if (!update.HasValue) return create;
            if (!create.HasValue) return update;

            return update.Value > create.Value ? update : create;
        }

        #region Upload

        private List<MBR_TMP_MARKET_PRICE_FORECAST> UploadMarketPriceForecast(List<MBR_TRN_MARKET_PRICE_FORECAST> data, ConfirmTrackingModel param, out int total, out string runId, out long interfaceId, out DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel> newData)
        {
            runId = "";
            var group = data.GroupBy(g => new { g.PlanType, g.Case, g.Cycle, g.MarketSource }).ToList();
            newData = new DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel>
            {
                Criteria = new MarketPriceForecastCriteriaModel
                {
                    Scenario = param.PlanType,
                    Case = param.Case,
                    Cycle = param.Cycle,
                    isMerge = false
                }
            };
            var listData = new List<ValidateMarketPriceForecastModel>();
            foreach (var cycle in group)
            {
                var validateModel = new ValidateMarketPriceForecastModel
                {
                    MarketSource = cycle.Key.MarketSource,
                    Unit = cycle.FirstOrDefault().Unit,
                    EBACode = cycle.FirstOrDefault()?.EBACode,
                    M0 = cycle.FirstOrDefault(f => f.MonthIndex == "M0")?.Price.ToString() ?? "",
                    M1 = cycle.FirstOrDefault(f => f.MonthIndex == "M1")?.Price.ToString() ?? "",
                    M2 = cycle.FirstOrDefault(f => f.MonthIndex == "M2")?.Price.ToString() ?? "",
                    M3 = cycle.FirstOrDefault(f => f.MonthIndex == "M3")?.Price.ToString() ?? "",
                    M4 = cycle.FirstOrDefault(f => f.MonthIndex == "M4")?.Price.ToString() ?? "",
                    M5 = cycle.FirstOrDefault(f => f.MonthIndex == "M5")?.Price.ToString() ?? "",
                    M6 = cycle.FirstOrDefault(f => f.MonthIndex == "M6")?.Price.ToString() ?? "",
                    M7 = cycle.FirstOrDefault(f => f.MonthIndex == "M7")?.Price.ToString() ?? "",
                    M8 = cycle.FirstOrDefault(f => f.MonthIndex == "M8")?.Price.ToString() ?? "",
                    M9 = cycle.FirstOrDefault(f => f.MonthIndex == "M9")?.Price.ToString() ?? "",
                    M10 = cycle.FirstOrDefault(f => f.MonthIndex == "M10")?.Price.ToString() ?? "",
                    M11 = cycle.FirstOrDefault(f => f.MonthIndex == "M11")?.Price.ToString() ?? "",
                    M12 = cycle.FirstOrDefault(f => f.MonthIndex == "M12")?.Price.ToString() ?? "",
                    M13 = cycle.FirstOrDefault(f => f.MonthIndex == "M13")?.Price.ToString() ?? "",
                    M14 = cycle.FirstOrDefault(f => f.MonthIndex == "M14")?.Price.ToString() ?? "",
                    M15 = cycle.FirstOrDefault(f => f.MonthIndex == "M15")?.Price.ToString() ?? "",
                    M16 = cycle.FirstOrDefault(f => f.MonthIndex == "M16")?.Price.ToString() ?? "",
                    M17 = cycle.FirstOrDefault(f => f.MonthIndex == "M17")?.Price.ToString() ?? "",
                    M18 = cycle.FirstOrDefault(f => f.MonthIndex == "M18")?.Price.ToString() ?? ""
                };
                listData.Add(validateModel);
            }
            newData.Data = listData;

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateMarketPriceForecastModel>();
            newData.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();

                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateMarketPriceForecastModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateModels.Add(validateModel);
            });
            newData.Data = validateModels;

            #endregion Create Validate Model & Set Id (RowNo)

            var logId = _logService.CreateLog("/api/UploadMarketPriceForecast/ValidateMarketPriceForecast", JsonConvert.SerializeObject(newData), APPCONSTANT.HISTORY_MBR_TYPE.MARKET_PRICE_FORECAST, param.PlanType, param.Cycle, param.Case);
            interfaceId = logId;

            #region Save Data

            var addMarketDataList = new List<MBR_TMP_MARKET_PRICE_FORECAST>();
            foreach (var cycle in group)
            {
                foreach (var item in cycle)
                {
                    decimal? monthIndexData = item.Price;

                    var bind = BindMarketPriceForecastTempModelToDB(new MarketPriceForecastCriteriaModel
                    {
                        Cycle = item.Cycle,
                        Case = item.Case,
                        Scenario = item.PlanType,
                    }, new MarketPriceForecastDataModel
                    {
                        Unit = item.Unit,
                        MarketSource = item.MarketSource,
                        EBACode = item.EBACode
                    }, monthIndexData, item.MonthIndex, item.MonthNo);

                    bind.MergedWithCase = item.MergedWithCase;
                    bind.MergedWithCycle = item.MergedWithCycle;
                    bind.MergedWithPlanType = item.MergedWithPlanType;
                    bind.CopiedFromCase = item.CopiedFromCase;
                    bind.CopiedFromCycle = item.CopiedFromCycle;
                    bind.CopiedFromPlanType = item.CopiedFromPlanType;
                    addMarketDataList.Add(bind);
                }
            }
            // set Total record
            total = addMarketDataList.Count();

            // Log Success

            _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(new ResponseModel
            {
                Data = addMarketDataList,
                Total = total,
                IsSuccess = true
            }), JsonConvert.SerializeObject(addMarketDataList));

            #region Call API

            bool isCallApiSuccess = true;
            runId = CallDataFactoryMarketPrice("MBR_TMP_MarketPriceForecast", "MarketPriceForecast", param.Cycle, param.Case, param.PlanType);
            if (runId != "error")
            {
                // insert runId to Database
            }
            else
            {
                var res = new ResponseModel()
                {
                    Error = "Cannot Run Pipeline",
                    IsSuccess = false,
                };
                // Log Error
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(newData));
                isCallApiSuccess = false;
                throw new Exception("Cannot Run Pipeline");
            }

            #endregion Call API

            foreach (var item in addMarketDataList)
            {
                item.RunId = runId;
            }
            if (addMarketDataList != null && addMarketDataList.Count > 0)
                _unit.MarketPriceForecastTempRepo.Add(addMarketDataList);

            #region del tmep after 30 minute

            var delAfter30minute = _unit.MarketPriceForecastTempRepo.FindAfter30minute();
            if (delAfter30minute != null && delAfter30minute.Count >= 1)
            {
                _unit.MarketPriceForecastTempRepo.BulkDelete(delAfter30minute);
            }

            #endregion del tmep after 30 minute

            _unit.SaveTransaction();

            #endregion Save Data

            return addMarketDataList;
        }

        private List<MBR_TMP_FEED_CONSUMPTION> UploadFeedConsumptionData(List<MBR_TRN_FEED_CONSUMPTION> data, ConfirmTrackingModel param, out int total, out string runId, out long interfaceId
            , out DataWitOptienceModel<OptienceCriteriaModel, ValidateFeedConsumptionModel> newData)
        {
            runId = "";
            var group = data.GroupBy(g => new { g.PlanType, g.Case, g.Cycle, g.Company, g.MCSC, g.FeedName }).ToList();
            newData = new DataWitOptienceModel<OptienceCriteriaModel, ValidateFeedConsumptionModel>
            {
                Criteria = new OptienceCriteriaModel
                {
                    Scenario = param.PlanType,
                    Case = param.Case,
                    Cycle = param.Cycle,
                    isMerge = false,
                    Company = data.Select(s => s.Company).Distinct().ToList()
                }
            };
            var listData = new List<ValidateFeedConsumptionModel>();
            foreach (var cycle in group)
            {
                var validateModel = new ValidateFeedConsumptionModel
                {
                    Company = cycle.Key.Company,
                    MCSC = cycle.Key.MCSC,
                    FeedName = cycle.Key.FeedName,
                    ElementCode = cycle.FirstOrDefault()?.ElementCodeEBA ?? "",
                    FeedShortName = cycle.FirstOrDefault()?.FeedShortName ?? "",
                    SupplierKey = cycle.FirstOrDefault()?.SupplierKey ?? "",
                    SupplierCode = cycle.FirstOrDefault()?.SupplierCode ?? "",
                    M0 = cycle.FirstOrDefault(f => f.MonthIndex == "M0")?.Price.ToString() ?? "",
                    M1 = cycle.FirstOrDefault(f => f.MonthIndex == "M1")?.Price.ToString() ?? "",
                    M2 = cycle.FirstOrDefault(f => f.MonthIndex == "M2")?.Price.ToString() ?? "",
                    M3 = cycle.FirstOrDefault(f => f.MonthIndex == "M3")?.Price.ToString() ?? "",
                    M4 = cycle.FirstOrDefault(f => f.MonthIndex == "M4")?.Price.ToString() ?? "",
                    M5 = cycle.FirstOrDefault(f => f.MonthIndex == "M5")?.Price.ToString() ?? "",
                    M6 = cycle.FirstOrDefault(f => f.MonthIndex == "M6")?.Price.ToString() ?? "",
                    M7 = cycle.FirstOrDefault(f => f.MonthIndex == "M7")?.Price.ToString() ?? "",
                    M8 = cycle.FirstOrDefault(f => f.MonthIndex == "M8")?.Price.ToString() ?? "",
                    M9 = cycle.FirstOrDefault(f => f.MonthIndex == "M9")?.Price.ToString() ?? "",
                    M10 = cycle.FirstOrDefault(f => f.MonthIndex == "M10")?.Price.ToString() ?? "",
                    M11 = cycle.FirstOrDefault(f => f.MonthIndex == "M11")?.Price.ToString() ?? "",
                    M12 = cycle.FirstOrDefault(f => f.MonthIndex == "M12")?.Price.ToString() ?? "",
                    M13 = cycle.FirstOrDefault(f => f.MonthIndex == "M13")?.Price.ToString() ?? "",
                    M14 = cycle.FirstOrDefault(f => f.MonthIndex == "M14")?.Price.ToString() ?? "",
                    M15 = cycle.FirstOrDefault(f => f.MonthIndex == "M15")?.Price.ToString() ?? "",
                    M16 = cycle.FirstOrDefault(f => f.MonthIndex == "M16")?.Price.ToString() ?? "",
                    M17 = cycle.FirstOrDefault(f => f.MonthIndex == "M17")?.Price.ToString() ?? "",
                    M18 = cycle.FirstOrDefault(f => f.MonthIndex == "M18")?.Price.ToString() ?? "",
                    MaterialCode = cycle.FirstOrDefault()?.MaterialCode ?? ""
                };
                listData.Add(validateModel);
            }
            newData.Data = listData;

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateFeedConsumptionModel>();
            newData.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();

                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateFeedConsumptionModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateModels.Add(validateModel);
            });
            newData.Data = validateModels;

            #endregion Create Validate Model & Set Id (RowNo)

            var logId = _logService.CreateLog("/api/UploadOptience/ValidateOptienceFeedConsumption", JsonConvert.SerializeObject(newData), APPCONSTANT.HISTORY_MBR_TYPE.FEED_CONSUMPTION, param.PlanType, param.Cycle, param.Case);
            interfaceId = logId;

            #region Save Data

            var addFeedConsumptionDataList = new List<MBR_TMP_FEED_CONSUMPTION>();
            var feedConsumptionList = new List<MBR_TMP_FEED_CONSUMPTION>();

            //add

            foreach (var cycle in group)
            {
                foreach (var item in cycle)
                {
                    decimal? monthIndexData = item.Price;

                    var bind = BindFeedConsumptionTempModelToDB(new OptienceCriteriaModel
                    {
                        Cycle = item.Cycle,
                        Case = item.Case,
                        Scenario = item.PlanType,
                    }, new FeedConsumptionModel
                    {
                        MCSC = item.MCSC,
                        Company = item.Company,
                        FeedName = item.FeedName,
                        ElementCode = item.ElementCodeEBA,
                        FeedShortName = item.FeedShortName,
                        SupplierKey = item.SupplierKey,
                        SupplierCode = item.SupplierCode,
                        MaterialCode = item.MaterialCode
                    }, monthIndexData, item.MonthIndex, item.MonthNo);
                    bind.MergedWithCase = item.MergedWithCase;
                    bind.MergedWithCycle = item.MergedWithCycle;
                    bind.MergedWithPlanType = item.MergedWithPlanType;
                    bind.CopiedFromCase = item.CopiedFromCase;
                    bind.CopiedFromCycle = item.CopiedFromCycle;
                    bind.CopiedFromPlanType = item.CopiedFromPlanType;
                    addFeedConsumptionDataList.Add(bind);
                    //productionVolumeList.Add(bind);
                    //}
                }
            }
            // set Total record
            total = feedConsumptionList.Count();

            // Log Success

            _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(new ResponseModel
            {
                Data = addFeedConsumptionDataList,
                Total = total,
                IsSuccess = true
            }), JsonConvert.SerializeObject(newData));

            #region Call Api

            bool isCallApiSuccess = true;
            var pipeLine = CallDataFactoryOptience("MBR_TMP_FeedConsumption", "FeedConsumption", param.Cycle, param.Case, param.PlanType, data.Select(s => s.Company).Distinct().ToList());
            if (pipeLine != "error")
            {
                runId = pipeLine;
            }
            else
            {
                var res = new ResponseModel()
                {
                    Error = "Cannot Run Pipeline",
                    IsSuccess = false,
                };
                // Log Error
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(newData));
                isCallApiSuccess = false;
                throw new Exception("Cannot Run Pipeline");
            }
            if (isCallApiSuccess)
            {
                foreach (var item in addFeedConsumptionDataList)
                {
                    item.RunId = pipeLine;
                }

                if (addFeedConsumptionDataList != null && addFeedConsumptionDataList.Count > 0)
                    _unit.FeedConsumptionTempRepo.Add(addFeedConsumptionDataList);

                #region del tmep after 30 minute

                var delAfter30minute = _unit.FeedConsumptionTempRepo.FindAfter30minute();
                if (delAfter30minute != null && delAfter30minute.Count >= 1)
                {
                    _unit.FeedConsumptionTempRepo.BulkDelete(delAfter30minute);
                }

                #endregion del tmep after 30 minute

                _unit.SaveTransaction();
            }

            #endregion Call Api

            #endregion Save Data

            return feedConsumptionList;
        }

        private List<MBR_TMP_FEED_PURCHASE> UploadFeedPurchase(List<MBR_TRN_FEED_PURCHASE> data, ConfirmTrackingModel param, out int total, out string runId, out long interfaceId
            , out DataWitOptienceModel<OptienceCriteriaModel, ValidateFeedPurchaseModel> newData)
        {
            runId = "";

            var group = data.GroupBy(g => new { g.PlanType, g.Case, g.Cycle, g.Company, g.MCSC, g.FeedName }).ToList();
            newData = new DataWitOptienceModel<OptienceCriteriaModel, ValidateFeedPurchaseModel>
            {
                Criteria = new OptienceCriteriaModel
                {
                    Scenario = param.PlanType,
                    Case = param.Case,
                    Cycle = param.Cycle,
                    isMerge = false,
                    Company = data.Select(s => s.Company).Distinct().ToList()
                }
            };
            var listData = new List<ValidateFeedPurchaseModel>();
            foreach (var cycle in group)
            {
                var validateModel = new ValidateFeedPurchaseModel
                {
                    Company = cycle.Key.Company,
                    MCSC = cycle.Key.MCSC,
                    FeedName = cycle.Key.FeedName,
                    ElementCode = cycle.FirstOrDefault()?.ElementCodeEBA ?? "",
                    FeedShortName = cycle.FirstOrDefault()?.FeedShortName ?? "",
                    SupplierKey = cycle.FirstOrDefault()?.SupplierKey ?? "",
                    SupplierCode = cycle.FirstOrDefault()?.SupplierCode ?? "",
                    M0 = cycle.FirstOrDefault(f => f.MonthIndex == "M0")?.Price.ToString() ?? "",
                    M1 = cycle.FirstOrDefault(f => f.MonthIndex == "M1")?.Price.ToString() ?? "",
                    M2 = cycle.FirstOrDefault(f => f.MonthIndex == "M2")?.Price.ToString() ?? "",
                    M3 = cycle.FirstOrDefault(f => f.MonthIndex == "M3")?.Price.ToString() ?? "",
                    M4 = cycle.FirstOrDefault(f => f.MonthIndex == "M4")?.Price.ToString() ?? "",
                    M5 = cycle.FirstOrDefault(f => f.MonthIndex == "M5")?.Price.ToString() ?? "",
                    M6 = cycle.FirstOrDefault(f => f.MonthIndex == "M6")?.Price.ToString() ?? "",
                    M7 = cycle.FirstOrDefault(f => f.MonthIndex == "M7")?.Price.ToString() ?? "",
                    M8 = cycle.FirstOrDefault(f => f.MonthIndex == "M8")?.Price.ToString() ?? "",
                    M9 = cycle.FirstOrDefault(f => f.MonthIndex == "M9")?.Price.ToString() ?? "",
                    M10 = cycle.FirstOrDefault(f => f.MonthIndex == "M10")?.Price.ToString() ?? "",
                    M11 = cycle.FirstOrDefault(f => f.MonthIndex == "M11")?.Price.ToString() ?? "",
                    M12 = cycle.FirstOrDefault(f => f.MonthIndex == "M12")?.Price.ToString() ?? "",
                    M13 = cycle.FirstOrDefault(f => f.MonthIndex == "M13")?.Price.ToString() ?? "",
                    M14 = cycle.FirstOrDefault(f => f.MonthIndex == "M14")?.Price.ToString() ?? "",
                    M15 = cycle.FirstOrDefault(f => f.MonthIndex == "M15")?.Price.ToString() ?? "",
                    M16 = cycle.FirstOrDefault(f => f.MonthIndex == "M16")?.Price.ToString() ?? "",
                    M17 = cycle.FirstOrDefault(f => f.MonthIndex == "M17")?.Price.ToString() ?? "",
                    M18 = cycle.FirstOrDefault(f => f.MonthIndex == "M18")?.Price.ToString() ?? "",
                    MaterialCode = cycle.FirstOrDefault()?.MaterialCode ?? ""
                };
                listData.Add(validateModel);
            }
            newData.Data = listData;

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateFeedPurchaseModel>();
            newData.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();

                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateFeedPurchaseModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateModels.Add(validateModel);
            });
            newData.Data = validateModels;

            #endregion Create Validate Model & Set Id (RowNo)

            var logId = _logService.CreateLog("/api/UploadOptience/ValidateOptienceFeedPurchase", JsonConvert.SerializeObject(newData), APPCONSTANT.HISTORY_MBR_TYPE.FEED_PURCHASE, param.PlanType, param.Cycle, param.Case);
            interfaceId = logId;

            #region Save Data

            var addFeedPurchaseDataList = new List<MBR_TMP_FEED_PURCHASE>();
            var feedPurchaseList = new List<MBR_TMP_FEED_PURCHASE>();

            foreach (var cycle in group)
            {
                foreach (var item in cycle)
                {
                    decimal? monthIndexData = item.Price;

                    var bind = BindFeedPurchaseTempModelToDB(new OptienceCriteriaModel
                    {
                        Cycle = item.Cycle,
                        Case = item.Case,
                        Scenario = item.PlanType,
                    }, new FeedPurchaseModel
                    {
                        MCSC = item.MCSC,
                        Company = item.Company,
                        FeedName = item.FeedName,
                        ElementCode = item.ElementCodeEBA,
                        FeedShortName = item.FeedShortName,
                        SupplierKey = item.SupplierKey,
                        SupplierCode = item.SupplierCode,
                        MaterialCode = item.MaterialCode
                    }, monthIndexData, item.MonthIndex, item.MonthNo);
                    bind.CopiedFromCase = item.CopiedFromCase;
                    bind.CopiedFromCycle = item.CopiedFromCycle;
                    bind.CopiedFromPlanType = item.CopiedFromPlanType;
                    addFeedPurchaseDataList.Add(bind);
                    //productionVolumeList.Add(bind);
                    //}
                }
            }

            // set Total record
            total = feedPurchaseList.Count();
            // Log Success

            _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(new ResponseModel
            {
                Data = addFeedPurchaseDataList,
                Total = total,
                IsSuccess = true
            }), JsonConvert.SerializeObject(newData));

            #region Call Api

            bool isCallApiSuccess = true;
            var pipeLine = CallDataFactoryOptience("MBR_TMP_FeedPurchase", "FeedPurchase", param.Cycle, param.Case, param.PlanType, data.Select(s => s.Company).Distinct().ToList());
            if (pipeLine != "error")
            {
                runId = pipeLine;
            }
            else
            {
                var res = new ResponseModel()
                {
                    Error = "Cannot Run Pipeline",
                    IsSuccess = false,
                };
                // Log Error
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(newData));
                isCallApiSuccess = false;
                throw new Exception("Cannot Run Pipeline");
            }
            if (isCallApiSuccess)
            {
                foreach (var item in addFeedPurchaseDataList)
                {
                    item.RunId = pipeLine;
                }

                if (addFeedPurchaseDataList != null && addFeedPurchaseDataList.Count > 0)
                    _unit.FeedPurchaseTempRepo.Add(addFeedPurchaseDataList);

                #region del tmep after 30 minute

                var delAfter30minute = _unit.FeedPurchaseTempRepo.FindAfter30minute();
                if (delAfter30minute != null && delAfter30minute.Count >= 1)
                {
                    _unit.FeedPurchaseTempRepo.BulkDelete(delAfter30minute);
                }

                #endregion del tmep after 30 minute

                _unit.SaveTransaction();
            }

            #endregion Call Api

            #endregion Save Data

            return feedPurchaseList;
        }

        private List<MBR_TMP_PRODUCTION_VOLUME> UploadProductionVolume(List<MBR_TRN_PRODUCTION_VOLUME> data, ConfirmTrackingModel param, out int total, out string runId, out long interfaceId
            , out DataWitOptienceModel<OptienceCriteriaModel, ValidateProductionVolumeModel> newData)
        {
            runId = "";

            var group = data.GroupBy(g => new { g.PlanType, g.Case, g.Cycle, g.Company, g.MCSC, g.ProductName }).ToList();
            newData = new DataWitOptienceModel<OptienceCriteriaModel, ValidateProductionVolumeModel>
            {
                Criteria = new OptienceCriteriaModel
                {
                    Scenario = param.PlanType,
                    Case = param.Case,
                    Cycle = param.Cycle,
                    isMerge = false,
                    Company = data.Select(s => s.Company).Distinct().ToList()
                }
            };
            var listData = new List<ValidateProductionVolumeModel>();
            foreach (var cycle in group)
            {
                var validateModel = new ValidateProductionVolumeModel
                {
                    Company = cycle.Key.Company,
                    MCSC = cycle.Key.MCSC,
                    ProductName = cycle.Key.ProductName,
                    ElementCode = cycle.FirstOrDefault()?.ElementCodeEBA ?? "",
                    ProductShortName = cycle.FirstOrDefault()?.ProductShortName ?? "",
                    M0 = cycle.FirstOrDefault(f => f.MonthIndex == "M0")?.Price.ToString() ?? "",
                    M1 = cycle.FirstOrDefault(f => f.MonthIndex == "M1")?.Price.ToString() ?? "",
                    M2 = cycle.FirstOrDefault(f => f.MonthIndex == "M2")?.Price.ToString() ?? "",
                    M3 = cycle.FirstOrDefault(f => f.MonthIndex == "M3")?.Price.ToString() ?? "",
                    M4 = cycle.FirstOrDefault(f => f.MonthIndex == "M4")?.Price.ToString() ?? "",
                    M5 = cycle.FirstOrDefault(f => f.MonthIndex == "M5")?.Price.ToString() ?? "",
                    M6 = cycle.FirstOrDefault(f => f.MonthIndex == "M6")?.Price.ToString() ?? "",
                    M7 = cycle.FirstOrDefault(f => f.MonthIndex == "M7")?.Price.ToString() ?? "",
                    M8 = cycle.FirstOrDefault(f => f.MonthIndex == "M8")?.Price.ToString() ?? "",
                    M9 = cycle.FirstOrDefault(f => f.MonthIndex == "M9")?.Price.ToString() ?? "",
                    M10 = cycle.FirstOrDefault(f => f.MonthIndex == "M10")?.Price.ToString() ?? "",
                    M11 = cycle.FirstOrDefault(f => f.MonthIndex == "M11")?.Price.ToString() ?? "",
                    M12 = cycle.FirstOrDefault(f => f.MonthIndex == "M12")?.Price.ToString() ?? "",
                    M13 = cycle.FirstOrDefault(f => f.MonthIndex == "M13")?.Price.ToString() ?? "",
                    M14 = cycle.FirstOrDefault(f => f.MonthIndex == "M14")?.Price.ToString() ?? "",
                    M15 = cycle.FirstOrDefault(f => f.MonthIndex == "M15")?.Price.ToString() ?? "",
                    M16 = cycle.FirstOrDefault(f => f.MonthIndex == "M16")?.Price.ToString() ?? "",
                    M17 = cycle.FirstOrDefault(f => f.MonthIndex == "M17")?.Price.ToString() ?? "",
                    M18 = cycle.FirstOrDefault(f => f.MonthIndex == "M18")?.Price.ToString() ?? "",
                    MaterialCode = cycle.FirstOrDefault()?.MaterialCode ?? ""
                };
                listData.Add(validateModel);
            }
            newData.Data = listData;

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateProductionVolumeModel>();
            newData.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();

                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateProductionVolumeModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateModels.Add(validateModel);
            });
            newData.Data = validateModels;

            #endregion Create Validate Model & Set Id (RowNo)

            var logId = _logService.CreateLog("/api/UploadOptience/ValidateOptienceProductionVolume", JsonConvert.SerializeObject(newData), APPCONSTANT.HISTORY_MBR_TYPE.PRODUCTION_VOLUME, param.PlanType, param.Cycle, param.Case);
            interfaceId = logId;

            #region Save Data

            #region upload temp

            // Temp

            var addProductionVolumeDataList = new List<MBR_TMP_PRODUCTION_VOLUME>();
            var productionVolumeList = new List<MBR_TMP_PRODUCTION_VOLUME>();

            foreach (var cycle in group)
            {
                foreach (var item in cycle)
                {
                    decimal? monthIndexData = item.Price;

                    var bind = BindProductionVolumeTempModelToDB(new OptienceCriteriaModel
                    {
                        Cycle = item.Cycle,
                        Case = item.Case,
                        Scenario = item.PlanType,
                    }, new ProductionVolumeModel
                    {
                        MCSC = item.MCSC,
                        Company = item.Company,
                        ProductName = item.ProductName,
                        ElementCode = item.ElementCodeEBA,
                        ProductShortName = item.ProductShortName,
                        MaterialCode = item.MaterialCode
                    }, monthIndexData, item.MonthIndex, item.MonthNo);
                    bind.CopiedFromCase = item.CopiedFromCase;
                    bind.CopiedFromCycle = item.CopiedFromCycle;
                    bind.CopiedFromPlanType = item.CopiedFromPlanType;
                    bind.MergedWithCase = item.MergedWithCase;
                    bind.MergedWithCycle = item.MergedWithCycle;
                    bind.MergedWithPlanType = item.MergedWithPlanType;
                    addProductionVolumeDataList.Add(bind);
                    //productionVolumeList.Add(bind);
                    //}
                }
            }

            // set Total record
            total = productionVolumeList.Count();

            // Log Success

            _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(new ResponseModel
            {
                Data = addProductionVolumeDataList,
                Total = total,
                IsSuccess = true
            }), JsonConvert.SerializeObject(newData));

            #region Call Api

            bool isCallApiSuccess = true;
            var pipeLine = CallDataFactoryOptience("MBR_TMP_ProductionVolume", "ProductionVolume", param.Cycle, param.Case, param.PlanType, data.Select(s => s.Company).Distinct().ToList());
            if (pipeLine != "error")
            {
                runId = pipeLine;
            }
            else
            {
                var res = new ResponseModel()
                {
                    Error = "Cannot Run Pipeline",
                    IsSuccess = false,
                };
                // Log Error
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(newData));
                isCallApiSuccess = false;
                throw new Exception("Cannot Run Pipeline");
            }
            if (isCallApiSuccess)
            {
                foreach (var item in addProductionVolumeDataList)
                {
                    item.RunId = pipeLine;
                }

                if (addProductionVolumeDataList != null && addProductionVolumeDataList.Count > 0)
                    _unit.ProductionVolumeTempRepo.Add(addProductionVolumeDataList);

                #region del tmep after 30 minute

                var delAfter30minute = _unit.ProductionVolumeTempRepo.FindAfter30minute();
                if (delAfter30minute != null && delAfter30minute.Count >= 1)
                {
                    _unit.ProductionVolumeTempRepo.BulkDelete(delAfter30minute);
                }

                #endregion del tmep after 30 minute

                _unit.SaveTransaction();
            }

            #endregion Call Api

            #endregion upload temp

            #endregion Save Data

            return productionVolumeList;
        }

        private List<MBR_TMP_BEGINING_INVENTORY> UploadBeginningInventory(List<MBR_TRN_BEGINING_INVENTORY> data, ConfirmTrackingModel param, out int total, out string runId, out long interfaceId
            , out DataWitOptienceModel<OptienceCriteriaModel, ValidateBeginningInventoryModel> newData)
        {
            runId = "";

            var group = data.GroupBy(g => new { g.PlanType, g.Case, g.Cycle, g.Company, g.MCSC, g.ProductShortName, g.MaterialCode, g.SupplierKey }).ToList();
            newData = new DataWitOptienceModel<OptienceCriteriaModel, ValidateBeginningInventoryModel>
            {
                Criteria = new OptienceCriteriaModel
                {
                    Scenario = param.PlanType,
                    Case = param.Case,
                    Cycle = param.Cycle,
                    isMerge = false,
                    Company = data.Select(s => s.Company).Distinct().ToList()
                }
            };
            var listData = new List<ValidateBeginningInventoryModel>();
            foreach (var cycle in group)
            {
                var validateModel = new ValidateBeginningInventoryModel
                {
                    Company = cycle.Key.Company,
                    MCSC = cycle.Key.MCSC,
                    InventoryName = cycle.FirstOrDefault()?.InventoryName ?? "",
                    TankNumber = cycle.FirstOrDefault()?.TankNumber ?? "",
                    ProductShortName = cycle.FirstOrDefault()?.ProductShortName ?? "",
                    MaterialCode = cycle.Key.MaterialCode,
                    SupplierKey = cycle.Key.SupplierKey,
                    SupplierCode = cycle.FirstOrDefault()?.SupplierCode ?? "",
                    ElementCode = cycle.FirstOrDefault()?.ElementCodeEBA ?? "",
                    M0 = cycle.FirstOrDefault(f => f.MonthIndex == "M0")?.Price.ToString() ?? "",
                };
                listData.Add(validateModel);
            }
            newData.Data = listData;

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateBeginningInventoryModel>();
            newData.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();

                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateBeginningInventoryModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateModels.Add(validateModel);
            });
            newData.Data = validateModels;

            #endregion Create Validate Model & Set Id (RowNo)

            var logId = _logService.CreateLog("/api/UploadOptience/ValidateOptienceBeginningInventory", JsonConvert.SerializeObject(newData), APPCONSTANT.HISTORY_MBR_TYPE.BEGINNING_INVENTORY, param.PlanType, param.Cycle, param.Case);
            interfaceId = logId;

            #region Save Data

            #region upload temp

            // Temp

            var addBeginningInventorytDataList = new List<MBR_TMP_BEGINING_INVENTORY>();
            var beginningInventoryList = new List<MBR_TMP_BEGINING_INVENTORY>();

            foreach (var cycle in group)
            {
                foreach (var item in cycle)
                {
                    decimal? monthIndexData = item.Price;

                    var bind = BindBeginningInventoryTempModelToDB(new OptienceCriteriaModel
                    {
                        Cycle = item.Cycle,
                        Case = item.Case,
                        Scenario = item.PlanType,
                    }, new BeginningInventoryModel
                    {
                        MCSC = item.MCSC,
                        Company = item.Company,
                        InventoryName = item.InventoryName,
                        TankNumber = item.TankNumber,
                        ProductShortName = item.ProductShortName,
                        MaterialCode = item.MaterialCode,
                        SupplierKey = item.SupplierKey,
                        SupplierCode = item.SupplierCode,
                        ElementCode = item.ElementCodeEBA
                    }, monthIndexData, item.MonthIndex, item.MonthNo);

                    bind.CopiedFromCase = item.CopiedFromCase;
                    bind.CopiedFromCycle = item.CopiedFromCycle;
                    bind.CopiedFromPlanType = item.CopiedFromPlanType;
                    addBeginningInventorytDataList.Add(bind);
                    //productionVolumeList.Add(bind);
                    //    }
                    //}
                }
            }
            // set Total record
            total = beginningInventoryList.Count();
            // Log Success

            _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(new ResponseModel
            {
                Data = addBeginningInventorytDataList,
                Total = total,
                IsSuccess = true
            }), JsonConvert.SerializeObject(newData));

            #region Call Api

            bool isCallApiSuccess = true;
            var pipeLine = CallDataFactoryOptience("MBR_TMP_BeginningInventory", "BeginningInventory", param.Cycle, param.Case, param.PlanType, data.Select(s => s.Company).Distinct().ToList());
            if (pipeLine != "error")
            {
                runId = pipeLine;
            }
            else
            {
                var res = new ResponseModel()
                {
                    Error = "Cannot Run Pipeline",
                    IsSuccess = false,
                };
                // Log Error
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(newData));
                isCallApiSuccess = false;
                throw new Exception("Cannot Run Pipeline");
            }
            if (isCallApiSuccess)
            {
                foreach (var item in addBeginningInventorytDataList)
                {
                    item.RunId = pipeLine;
                }

                if (addBeginningInventorytDataList != null && addBeginningInventorytDataList.Count > 0)
                    _unit.BeginningInventoryTempRepo.Add(addBeginningInventorytDataList);

                #region del tmep after 30 minute

                var delAfter30minute = _unit.BeginningInventoryTempRepo.FindAfter30minute();
                if (delAfter30minute != null && delAfter30minute.Count >= 1)
                {
                    _unit.BeginningInventoryTempRepo.BulkDelete(delAfter30minute);
                }

                #endregion del tmep after 30 minute

                _unit.SaveTransaction();
            }

            #endregion Call Api

            #endregion upload temp

            #endregion Save Data

            return beginningInventoryList;
        }

        private List<MRB_TMP_FEED_INFO> UploadFeedInfoCenter(List<MRB_TRN_FEED_INFO> data, ConfirmTrackingModel param, out int total, out string runId, out long interfaceId
            , out DataWithFeedInfoModel<FeedInfoCriteriaModel, ValidateFeedInfoModel> newData)
        {
            runId = "";

            newData = new DataWithFeedInfoModel<FeedInfoCriteriaModel, ValidateFeedInfoModel>
            {
                Criteria = new FeedInfoCriteriaModel
                {
                    PlaneType = param.PlanType,
                    Case = param.Case,
                    Cycle = param.Cycle,
                    isMerge = false,
                    Company = data.Select(s => s.Company).Distinct().ToList(),
                    FeedGeoCategoryKey = data.Select(s => s.FeedGeoCategoryKey).Distinct().ToList(),
                    FeedNameKey = data.Select(s => s.FeedNameKey).Distinct().ToList(),
                    ProductGroup = data.Select(s => s.ProductGroup).Distinct().ToList(),
                }
            };
            var listData = new List<ValidateFeedInfoModel>();
            foreach (var item in data)
            {
                var validateModel = new ValidateFeedInfoModel
                {
                    Id = item.ID,
                    RefNo = item.RefNo,
                    Company = item.Company,
                    MCSC = item.MCSC,
                    MonthStatus = item.MonthIndex,
                    FeedNameKey = item.FeedNameKey,
                    FeedGeoCategoryKey = item.FeedGeoCategoryKey,
                    SupplierKey = item.SupplierKey,
                    SupplierCode = item.SupplierCode,
                    PricingIndexKey = item.PricingIndexKey,
                    PricingRefKey = item.PricingRefKey,
                    OriginKey = item.OriginKey,
                    ContractSpot = item.ContractSpot,
                    TransportationKey = item.TransportationKey,
                    BuyerRightKey = item.BuyerRightKey,
                    PurchasingVolume = item.PurchasingVolume?.ToString() ?? "",
                    PurchasingPremium = item.PurchasingPremium?.ToString() ?? "",
                    HedgingGainLoss = item.HedgingGainLoss?.ToString() ?? "",
                    GITStatus = item.GITStatus,
                    Surveyor = item.Surveyor?.ToString() ?? "",
                    Insurance = item.Insurance?.ToString() ?? "",
                    Margin = item.Margin?.ToString() ?? "",
                    TR = item.TR?.ToString() ?? "",
                    MaterialCode = item.MaterialCode,
                };
                listData.Add(validateModel);
            }
            newData.Data = listData;

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateFeedInfoModel>();
            newData.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();

                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateFeedInfoModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateModels.Add(validateModel);
            });
            newData.Data = validateModels;

            #endregion Create Validate Model & Set Id (RowNo)

            var logId = _logService.CreateLog("/api/UploadFeedInfo/ValidateFeedInfo", JsonConvert.SerializeObject(newData), APPCONSTANT.HISTORY_MBR_TYPE.FEED_DATA, param.PlanType, param.Cycle, param.Case);
            interfaceId = logId;

            #region Save Data

            // Temp
            var feedInfoList = new List<MRB_TMP_FEED_INFO>();

            //add
            foreach (var item in data)
            {
                //add
                var bind = BindFeedInfoTempModelToDB(newData.Criteria, item, item.ProductGroup, item.Price, item.MonthNo);
                bind.CopiedFromCase = item.CopiedFromCase;
                bind.CopiedFromCycle = item.CopiedFromCycle;
                bind.CopiedFromPlanType = item.CopiedFromPlanType;
                bind.MergedWithCase = item.MergedWithCase;
                bind.MergedWithCycle = item.MergedWithCycle;
                bind.MergedWithPlanType = item.MergedWithPlanType;
                feedInfoList.Add(bind);
            }

            // set Total record
            total = feedInfoList.Count();
            // Log Success
            _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(new ResponseModel
            {
                Data = feedInfoList,
                Total = total,
                IsSuccess = true
            }), JsonConvert.SerializeObject(newData));

            #region Call API

            bool isCallApiSuccess = true;
            var criteria = new RequestCriteriaTransaction();
            criteria.PlaneType = param.PlanType;
            criteria.Case = param.Case;
            criteria.Cycle = param.Cycle;
            criteria.Company = String.Join(",", newData.Criteria.Company);
            criteria.FeedGeoCategoryKey = String.Join(",", newData.Criteria.FeedGeoCategoryKey);
            criteria.FeedNameKey = String.Join(",", newData.Criteria.FeedNameKey);
            criteria.ProductGroup = String.Join(",", newData.Criteria.ProductGroup);

            runId = CallDataFactoryFeedInfo("MBR_TMP_FeedInfo", "FeedInfo", criteria, APPCONSTANT.SUBMIT_STATUS.SUBMIT);
            if (isCallApiSuccess)
            {
                // insert runId to Database
            }
            else
            {
                var res = new ResponseModel()
                {
                    Error = "Cannot Run Pipeline",
                    IsSuccess = false,
                };
                // Log Error
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(newData));
                throw new Exception("Cannot Run Pipeline.");
            }

            #endregion Call API

            foreach (var item in feedInfoList)
            {
                item.RunId = runId;
            }

            if (feedInfoList.Count > 0)
                _unit.FeedInfoTempRepo.BulkInsert(feedInfoList);

            #region del tmep after 30 minute

            var delAfter30minute = _unit.ProductionVolumeTempRepo.FindAfter30minute();
            if (delAfter30minute != null && delAfter30minute.Count >= 1)
            {
                _unit.ProductionVolumeTempRepo.BulkDelete(delAfter30minute);
            }

            #endregion del tmep after 30 minute

            _unit.SaveTransaction();

            #endregion Save Data

            return feedInfoList;
        }

        private List<MBR_TMP_SALES_VOLUME> UploadSaleVolume(List<MBR_TRN_SALES_VOLUME> data, ConfirmTrackingModel param, out int total, out string runId, out long interfaceId,
            out DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel> newData)
        {
            runId = "";

            var group = data.GroupBy(g => new { g.PlanType, g.Case, g.Cycle, g.Company, g.MCSC, g.Channel, g.Customers, g.FormulaName, g.PriceSet, g.Product, g.TermSpot }).ToList();
            newData = new DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel>
            {
                Criteria = new SalesCriteriaModel
                {
                    PlaneType = param.PlanType,
                    Case = param.Case,
                    Cycle = param.Cycle,
                    isMerge = false,
                    Company = data.Select(s => s.Company).Distinct().ToList(),
                    Product = data.Select(s => s.Product).Distinct().ToList(),
                    ProductGroup = data.Select(s => s.ProductGroup).Distinct().ToList(),
                    Channel = data.Select(s => s.Channel).Distinct().ToList()
                }
            };
            var listData = new List<ValidateSalesModel>();
            var addSalesDataList = new List<MBR_TMP_SALES_VOLUME>();
            foreach (var cycle in group)
            {
                foreach (var item in cycle)
                {
                    var validateModel = new ValidateSalesModel
                    {
                        Adj1 = item.Adj1.ToString() ?? "",
                        Adj2 = item.Adj2.ToString() ?? "",
                        Adj3 = item.Adj3.ToString() ?? "",
                        Adj4 = item.Adj4.ToString() ?? "",
                        Adj5 = item.Adj5.ToString() ?? "",

                        Company = item.Company,
                        MCSC = item.MCSC,
                        MonthIndex = item.MonthIndex,
                        Product = item.Product,
                        Channel = item.Channel,
                        ReEXP = item.ReEXP,
                        FormulaName = item.FormulaName,
                        Formula = item.Formula,
                        Customers = item.Customers,
                        Margin = item.Margin,
                        Countries = item.Countries,
                        TransportationMode = item.TransportationMode,
                        CountryPort = item.CountryPort,
                        TermSpot = item.TermSpot,
                        PriceSet = item.PriceSet,
                        PaymentCondition = item.PaymentCondition,
                        ContractNo = item.ContractNo,
                        VesselOrderNo = item.VesselOrderNo,
                        Remark = item.Remark,
                        VolTons = item.VolTons.ToString() ?? "",
                        HedgingGainLoss = item.HedgingGainLoss?.ToString() ?? "",
                        Alpha1 = item.Alpha1.ToString() ?? "",
                        Alpha2 = item.Alpha2.ToString() ?? "",
                        Premium = item.Premium.ToString() ?? "",
                        FinalPrice = item.FinalPrice.ToString() ?? "",
                        BD = item.BD.ToString() ?? "",
                        IB = item.IB.ToString() ?? "",
                        Den = item.Den.ToString() ?? ""
                    };
                    listData.Add(validateModel);

                    //add
                    var bind = BindSalesTempModelToDB(new SalesCriteriaModel
                    {
                        Cycle = item.Cycle,
                        Case = item.Case,
                        PlaneType = item.PlanType,
                    }, item, item.MonthNo, item.ProductGroup);
                    bind.ProductGroup = item.ProductGroup;
                    bind.MergedWithCase = item.MergedWithCase;
                    bind.MergedWithCycle = item.MergedWithCycle;
                    bind.MergedWithPlanType = item.MergedWithPlanType;
                    bind.CopiedFromCase = item.CopiedFromCase;
                    bind.CopiedFromCycle = item.CopiedFromCycle;
                    bind.CopiedFromPlanType = item.CopiedFromPlanType;
                    bind.ProductGroup = item.ProductGroup;
                    addSalesDataList.Add(bind);
                }
            }
            newData.Data = listData;

            #region Create Validate Model & Set Id (RowNo)

            int row = 0;
            var validateModels = new List<ValidateSalesModel>();
            newData.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();

                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToModel(out convertErrorList);

                // create model
                var validateModel = new ValidateSalesModel();
                validateModel.Id = i.Id;
                validateModel.SetModel(convertModel);
                validateModel.ErrorMsg.AddRange(convertErrorList);
                validateModels.Add(validateModel);
            });
            newData.Data = validateModels;

            #endregion Create Validate Model & Set Id (RowNo)

            var logId = _logService.CreateLog("/api/UploadSales/ValidateSales", JsonConvert.SerializeObject(newData), APPCONSTANT.HISTORY_MBR_TYPE.SALE_VOLUME, param.PlanType, param.Cycle, param.Case);
            interfaceId = logId;

            // set Total record
            total = addSalesDataList.Count();

            // Log Success

            _logService.LogSuccessPassValidate(logId, JsonConvert.SerializeObject(new ResponseModel
            {
                Data = addSalesDataList,
                Total = total,
                IsSuccess = true
            }), JsonConvert.SerializeObject(newData));
            bool isCallApiSuccess = true;

            total = addSalesDataList.Count();
            var createParam = new RequestCriteriaSalesCreateParam
            {
                PlaneType = param.PlanType,
                Case = param.Case,
                Cycle = param.Cycle,
                Company = data.Select(s => s.Company).Distinct().ToList(),
                Product = data.Select(s => s.Product).Distinct().ToList(),
                ProductGroup = data.Select(s => s.ProductGroup).Distinct().ToList(),
                Channel = data.Select(s => s.Channel).Distinct().ToList(),
            };
            var criteria = new RequestCriteriaSales(createParam);
            runId = CallDataFactorySale("MBR_TMP_SalesVolume", "SaleVolume", criteria, APPCONSTANT.SUBMIT_STATUS.SUBMIT, false, param.WebUUID.Value);

            if (runId != "error")
            {
            }
            else
            {
                var res = new ResponseModel()
                {
                    Error = "Cannot Run Pipeline",
                    IsSuccess = false,
                };
                // Log Error
                _logService.LogError(logId, JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(newData));
                isCallApiSuccess = false;
                throw new Exception("Cannot Run Pipeline");
            }
            foreach (var item in addSalesDataList)
            {
                item.RunId = runId;
            }

            if (addSalesDataList != null && addSalesDataList.Count > 0)
                _unit.SalesVoiumeTempRepo.Add(addSalesDataList);

            _unit.SaveTransaction();

            return addSalesDataList;
        }

        #endregion Upload

        #region Bind

        private MBR_TMP_MARKET_PRICE_FORECAST BindMarketPriceForecastTempModelToDB(MarketPriceForecastCriteriaModel criteria, MarketPriceForecastDataModel item, decimal? price, string monthIndex, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.Scenario == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TMP_MARKET_PRICE_FORECAST()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                CyclePoly = cyclePoly,
                PlanType = criteria.Scenario,
                MarketSource = item.MarketSource,
                MonthIndex = monthIndex,
                Price = price,
                Unit = item.Unit,
                MonthNo = monthNo,
                UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                UpdatedDate = DateTime.Now,
                CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                CreatedDate = DateTime.Now,
                EBACode = item.EBACode
            };
            return newData;
        }

        private MBR_TMP_FEED_CONSUMPTION BindFeedConsumptionTempModelToDB(OptienceCriteriaModel criteria, FeedConsumptionModel item, decimal? price, string monthIndex, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.Scenario == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TMP_FEED_CONSUMPTION()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                PlanType = criteria.Scenario,
                MCSC = item.MCSC,
                Company = item.Company,
                SupplierKey = item.SupplierKey,
                SupplierCode = item.SupplierCode,
                FeedShortName = item.FeedShortName,
                ElementCodeEBA = item.ElementCode,
                FeedName = item.FeedName,
                MonthIndex = monthIndex,
                MonthNo = monthNo,
                Price = price,
                CyclePoly = cyclePoly,
                UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                UpdatedDate = DateTime.Now,
                CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                CreatedDate = DateTime.Now,
                MaterialCode = item.MaterialCode
            };
            return newData;
        }

        private MBR_TMP_FEED_PURCHASE BindFeedPurchaseTempModelToDB(OptienceCriteriaModel criteria, FeedPurchaseModel item, decimal? price, string monthIndex, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.Scenario == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TMP_FEED_PURCHASE()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                PlanType = criteria.Scenario,
                MCSC = item.MCSC,
                Company = item.Company,
                SupplierKey = item.SupplierKey,
                SupplierCode = item.SupplierCode,
                FeedShortName = item.FeedShortName,
                ElementCodeEBA = item.ElementCode,
                FeedName = item.FeedName,
                MonthIndex = monthIndex,
                Price = price,
                CyclePoly = cyclePoly,
                MonthNo = monthNo,
                UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                UpdatedDate = DateTime.Now,
                CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                CreatedDate = DateTime.Now,
                MaterialCode = item.MaterialCode
            };
            return newData;
        }

        private MBR_TMP_PRODUCTION_VOLUME BindProductionVolumeTempModelToDB(OptienceCriteriaModel criteria, ProductionVolumeModel item, decimal? price, string monthIndex, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.Scenario == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TMP_PRODUCTION_VOLUME()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                PlanType = criteria.Scenario,
                MCSC = item.MCSC,
                Company = item.Company,
                ProductName = item.ProductName,
                ElementCodeEBA = item.ElementCode,
                ProductShortName = item.ProductShortName,
                MonthIndex = monthIndex,
                MonthNo = monthNo,
                Price = price,
                CyclePoly = cyclePoly,
                UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                UpdatedDate = DateTime.Now,
                CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                CreatedDate = DateTime.Now,
                MaterialCode = item.MaterialCode
            };
            return newData;
        }

        private MBR_TMP_BEGINING_INVENTORY BindBeginningInventoryTempModelToDB(OptienceCriteriaModel criteria, BeginningInventoryModel item, decimal? price, string monthIndex, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.Scenario == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TMP_BEGINING_INVENTORY()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                PlanType = criteria.Scenario,
                MCSC = item.MCSC,
                InventoryName = item.InventoryName,
                TankNumber = item.TankNumber,
                Company = item.Company,
                ProductShortName = item.ProductShortName,
                MaterialCode = item.MaterialCode,
                SupplierKey = item.SupplierKey,
                SupplierCode = item.SupplierCode,
                ElementCodeEBA = item.ElementCode,
                MonthIndex = monthIndex,
                MonthNo = monthNo,
                Price = price,
                CyclePoly = cyclePoly,
                UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                UpdatedDate = DateTime.Now,
                CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                CreatedDate = DateTime.Now
            };
            return newData;
        }

        private MRB_TMP_FEED_INFO BindFeedInfoTempModelToDB(FeedInfoCriteriaModel criteria, MRB_TRN_FEED_INFO item, string productGroup, decimal? price, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.PlaneType == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MRB_TMP_FEED_INFO()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                CyclePoly = cyclePoly,
                PlanType = criteria.PlaneType,
                RefNo = item.RefNo,
                Company = item.Company,
                MCSC = item.MCSC,
                FeedNameKey = item.FeedNameKey,
                FeedGeoCategoryKey = item.FeedGeoCategoryKey,
                SupplierKey = item.SupplierKey,
                SupplierCode = item.SupplierCode,
                PricingIndexKey = item.PricingIndexKey,
                PricingRefKey = item.PricingRefKey,
                OriginKey = item.OriginKey,
                ContractSpot = item.ContractSpot,
                TransportationKey = item.TransportationKey,
                BuyerRightKey = item.BuyerRightKey,
                PurchasingVolume = item.PurchasingVolume,
                PurchasingPremium = item.PurchasingPremium,
                HedgingGainLoss = item.HedgingGainLoss,
                GITStatus = item.GITStatus ?? "",
                Surveyor = item.Surveyor,
                Insurance = item.Insurance,
                Margin = item.Margin,
                TR = item.TR,
                MonthIndex = item.MonthIndex,
                MonthNo = monthNo,
                ProductGroup = productGroup,
                Price = price,
                MaterialCode = item.MaterialCode,

                UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                UpdatedDate = DateTime.Now,
                CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                CreatedDate = DateTime.Now
            };
            return newData;
        }

        private MBR_TMP_SALES_VOLUME BindSalesTempModelToDB(SalesCriteriaModel criteria, MBR_TRN_SALES_VOLUME item, string monthNo, string productGroup)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.PlaneType == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            var newData = new MBR_TMP_SALES_VOLUME()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                CyclePoly = cyclePoly,
                PlanType = criteria.PlaneType,
                Adj1 = item.Adj1,
                Adj2 = item.Adj2,
                Adj3 = item.Adj3,
                Adj4 = item.Adj4,
                Adj5 = item.Adj5,
                Den = item.Den,
                Alpha1 = item.Alpha1,
                Alpha2 = item.Alpha2,
                BD = item.BD,
                Channel = item.Channel,
                Company = item.Company,
                ContractNo = item.ContractNo,
                Countries = item.Countries,
                CountryPort = item.CountryPort,
                Customers = item.Customers,
                FinalPrice = item.FinalPrice,
                Formula = item.Formula,
                FormulaName = item.FormulaName,
                IB = item.IB,
                Margin = item.Margin,
                HedgingGainLoss = item.HedgingGainLoss,
                PaymentCondition = item.PaymentCondition,
                Premium = item.Premium,
                PriceSet = item.PriceSet,
                ReEXP = item.ReEXP,
                Product = item.Product,
                Remark = item.Remark,
                TermSpot = item.TermSpot,
                TransportationMode = item.TransportationMode,
                VesselOrderNo = item.VesselOrderNo,
                VolTons = item.VolTons,
                ProductGroup = productGroup,
                MonthNo = monthNo,
                MCSC = item.MCSC,
                MonthIndex = item.MonthIndex,

                UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                UpdatedDate = DateTime.Now,
                CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                CreatedDate = DateTime.Now
            };
            return newData;
        }

        #endregion Bind

        public List<PriceList> CheckSaleAndProduction(SearchTrackingReqModel param, string product)
        {
            var dataDB = _unit.SalesVoiumeRepo.FindByCriteria(param.PlanType, param.Case, param.Cycle, product).ToList();
            var dataDB2 = _unit.ProductionVolumeRepo.FindByCriterias(param.PlanType, param.Case, param.Cycle, product).GroupBy(g => new { g.Company, g.MCSC, g.ProductShortName }).ToList();
            var res = new List<PriceList>();
            foreach (var productVol in dataDB2)
            {
                var data = dataDB.Where(w => w.Product == productVol.Key.ProductShortName && w.Company == productVol.Key.Company && w.MCSC == productVol.Key.MCSC).ToList();
                var list = productVol.GroupBy(g => g.MonthIndex).Select(s => new PriceListCal { name = s.Key, value = s.Sum(ss => ss.Price) }).ToList();
                list.ForEach(f =>
                {
                    if (data.Where(w => w.MonthIndex == f.name).Sum(s => s.VolTons) != f.value)
                    {
                        res.Add(new PriceList { name = f.name, value = product, error = product + " not equal" });
                    }
                });
            }

            return res;
        }

        public List<DownloadTrackingResponseModel> DownloadCheckSaleAndProduct(DownloadTrackingRequestModel param)
        {
            var result = new List<DownloadTrackingResponseModel>();

            var dataDB = _unit.SalesVoiumeRepo.FindByCriteriaProductGroup(param.PlanType, param.Case, param.Cycle, param.ProductGroup).ToList();
            var product = dataDB.Select(s => s.Product).Distinct().ToList();

            var res = new List<PriceList>();
            foreach (var item in product)
            {
                var dataDB1 = _unit.SalesVoiumeRepo.FindByCriteria(param.PlanType, param.Case, param.Cycle, item).ToList();
                var dataDB2 = _unit.ProductionVolumeRepo.FindByCriterias(param.PlanType, param.Case, param.Cycle, product).GroupBy(g => new { g.Company, g.MCSC, g.ProductShortName }).ToList();
                result = new List<DownloadTrackingResponseModel>();
                foreach (var productVol in dataDB2)
                {
                    var data = dataDB.Where(w => w.Product == productVol.Key.ProductShortName && w.Company == productVol.Key.Company && w.MCSC == productVol.Key.MCSC).ToList();
                    var list = productVol.GroupBy(g => g.MonthIndex).Select(s => new PriceListCal { name = s.Key, value = s.Sum(ss => ss.Price) }).ToList();
                    list.ForEach(f =>
                    {
                        if (data.Where(w => w.MonthIndex == f.name).Sum(s => s.VolTons) != f.value)
                        {
                            res.Add(new PriceList 
                            { 
                                name = f.name, 
                                value = item, 
                                error = product + " not equal" 
                            });
                        }
                    });
                }
            }

            return result;
        }
    }
}