using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.DataFactory;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Sales;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Datafacetory.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Sales.Interface;
using System.Globalization;
using System.Reflection;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Sales
{
    public class SalesService : ISalesService
    {
        private readonly UnitOfWork _unit;
        private readonly SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork _unitSSP;
        private readonly IDataFactoryService _dataFactoryService;
        private readonly string userLogin;

        public SalesService(UnitOfWork unitOfWork, SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork unitSSP, IDataFactoryService dataFactoryService)
        {
            this._unit = unitOfWork;
            this._unitSSP = unitSSP;
            this.userLogin = UserUtilities.GetADAccount()?.UserId ?? "";
            this._dataFactoryService = dataFactoryService;
        }

        public async Task<string> CallDataFactory(string tableName, string transactionName, RequestCriteriaSales criteria, string submitStatus, Guid webUUID, bool isPreview, bool isMerge = false, string MergedWithPlanType = "", string MergedWithCycle = "", string MergedWithCase = "")
        {
            string userName = UserUtilities.GetADAccount()?.UserId ?? "";

            string res = await _dataFactoryService.RunPipelineSalesCriteria(tableName, transactionName, criteria, submitStatus, userName, webUUID, isPreview, isMerge, MergedWithPlanType, MergedWithCycle, MergedWithCase);

            return res;
        }

        public string GetPreviewRunIdFromSubmitRunId(string submitRunId)
        {
            var result = _unit.MasterTempSalesPreviewSubmitRepo.GetByPreviewOrSubmitRunId(submitRunId, false);

            if (result != null && result.PriviewRunId != null)
            {
                return result.PriviewRunId;
            }

            throw new Exception("Cannot find runid");
        }

        public Guid GetUUIDFromSubmitRunId(string submitRunId)
        {
            var result = _unit.MasterTempSalesPreviewSubmitRepo.GetByPreviewOrSubmitRunIdNoTracking(submitRunId, false);

            if (result != null)
            {
                return result.WebUUID;
            }

            throw new Exception("Cannot find runid");
        }

        #region Move

        public int MoveSales(RequestDataFactoryRunIdStatus criteria, string previewRunIdOrSubmitRunId)
        {
            var deleteCriterias = new SalesDeleteCriteria(criteria);
            var transactionTobeDeleted = _unit.SalesVoiumeRepo.FindByCriterias(deleteCriterias.Cycle,
                                                                               deleteCriterias.Case,
                                                                               deleteCriterias.Company,
                                                                               deleteCriterias.Product,
                                                                               deleteCriterias.ProductGroup,
                                                                               deleteCriterias.Channel);

            if (transactionTobeDeleted != null && transactionTobeDeleted.Count > 0)
                _unit.SalesVoiumeRepo.BulkDelete(transactionTobeDeleted);

            var tempTransaction = _unit.SalesVoiumeTempRepo.FindByRunId(previewRunIdOrSubmitRunId);

            var transactionToBeInserted = new List<MBR_TRN_SALES_VOLUME>();

            var group = tempTransaction.GroupBy(g => new { g.PlanType, g.Case, g.Cycle, g.Company, g.MCSC, g.Channel, g.Customers, g.FormulaName, g.PriceSet, g.Product, g.TermSpot }).ToList();

            foreach (var cycle in group)
            {
                foreach (var item in cycle)
                {
                    var bind = BindSalesModelToDB(new SalesCriteriaModel
                    {
                        Cycle = item.Cycle,
                        Case = item.Case,
                        PlaneType = item.PlanType,
                    }, new SalesDataModel(item), item.MonthNo);
                    bind.ProductGroup = item.ProductGroup;
                    bind.MergedWithCase = item.MergedWithCase;
                    bind.MergedWithCycle = item.MergedWithCycle;
                    bind.MergedWithPlanType = item.MergedWithPlanType;
                    bind.CopiedFromCase = item.CopiedFromCase;
                    bind.CopiedFromCycle = item.CopiedFromCycle;
                    bind.CopiedFromPlanType = item.CopiedFromPlanType;
                    bind.UpdatedBy = item.UpdatedBy;
                    bind.UpdatedDate = item.UpdatedDate;
                    bind.ProductGroup = item.ProductGroup;
                    transactionToBeInserted.Add(bind);
                }
            }

            var dataFac = _unit.DataFactoryRunRepo.GetByRunId(criteria.RunId);
            var saleData = transactionToBeInserted?.Where(w => w.MergedWithCycle != null).FirstOrDefault();
            if (dataFac is not null && dataFac.IsMerge == true && saleData is not null)
            {
                var request = new MergeHistoryRequestModel()
                {
                    Cycle = dataFac.Cycle,
                    Case = dataFac.Case
                };
                var mergeData = _unit.MergeHistoryRepo.GetDataByCriteria(request, MASTER_EXCEL_TYPE.SALES_VOLUME);
                if (mergeData is null)
                {
                    var typeName = _unit.MasterExcelRepo.GetByExcelId(MASTER_EXCEL_TYPE.SALES_VOLUME)?.MasterName?.Replace(" ", "") ?? "";
                    var mergeHistory = new MBR_TRN_MERGE_HISTORY()
                    {
                        ExcelId = MASTER_EXCEL_TYPE.SALES_VOLUME,
                        Type = typeName,
                        Case = dataFac.Case,
                        Cycle = dataFac.Cycle,
                        MergedWithCase = dataFac.MergedWithCase ?? "",
                        MergedWithCycle = dataFac.MergedWithCycle ?? "",
                        CreatedBy = userLogin,
                        CreatedDate = DateTime.Now,
                    };
                    _unit.MergeHistoryRepo.Add(mergeHistory);
                }
            }

            _unit.SalesVoiumeRepo.BulkInsert(transactionToBeInserted);
            _unit.SalesVoiumeTempRepo.BulkDelete(tempTransaction);

            return transactionToBeInserted.Count;
        }

        #endregion Move

        #region upload

        public async Task<Tuple<int, string, List<MBR_TMP_SALES_VOLUME>>> UploadSalesCenter(DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel> param, bool IsPreview)
        {
            // Clear TMP_SalesVolume older than 1 hr
            var olderThanOneHourRecords = await _unit.SalesVoiumeTempRepo.FindOlderThanOneHourRecordAsync();
            _unit.SalesVoiumeTempRepo.BulkDelete(olderThanOneHourRecords);

            var runId = "";

            #region Set Id (RowNo) for dataValidates List

            // Set RowId (Row No)
            int row = 0;
            param.Data.ForEach(i =>
            {
                row++;
                i.Id = row;
                i.ErrorMsg = new List<string>();
            });

            #endregion Set Id (RowNo) for dataValidates List

            #region Create Validate Model & Set Id (RowNo)

            List<PriceList> priceLst = new List<PriceList>();

            var validateModels = new List<SalesDataModel>();
            var isZero = _unit.MasterMaintainPriceRepo.GetByMaintainId(MASTER_EXCEL_TYPE.SALES_VOLUME)?.IsZero ?? false;
            var containCompany = _unitSSP.MasterCompanyRepo.GetByShortName(param.Data.Select(s => s.Company).ToList());
            var containProductMapping = _unit.MasterProductMappingRepo.GetProductShortName(param.Data.Select(s => s.Product).ToList());
            var containFormulaName = _unit.MasterFormulaParameterMappingRepo.GetMasterFormulaParameterByFormulaName(param.Data.Select(s => s.FormulaName).ToList());
            var containBusinessPartner = _unitSSP.FCTBusinessPartnerRepo.GetByShortnamepriceweb(param.Data.Select(s => s.Customers).ToList());
            var containCountries = _unitSSP.MasterCountryMasterRepo.GetByCountryCode(param.Data.Select(s => s.Countries).ToList());
            List<MBR_TRN_SALES_VOLUME> SalesExistingData = new List<MBR_TRN_SALES_VOLUME>();
            if (param.Criteria.isMerge && param.Criteria.MergePlaneType != null && param.Criteria.MergeCase != null && param.Criteria.MergeCycle != null)
                SalesExistingData = _unit.SalesVoiumeRepo.FindByCriteria(param.Criteria.MergePlaneType, param.Criteria.MergeCase, param.Criteria.MergeCycle);
            param.Data.ForEach(i =>
            {
                row++;
                List<MBR_TRN_SALES_VOLUME> existingData = null;
                if (SalesExistingData != null)
                    existingData = SalesExistingData.Where(f => f.Company.ToLower() == i.Company.ToLower()
                                                                && f.MCSC.ToLower() == i.MCSC.ToLower()
                                                                && f.Product.ToLower() == i.Product.ToLower()
                                                                && f.Channel.ToLower() == i.Channel.ToLower()
                                                                && f.FormulaName.ToLower() == i.FormulaName.ToLower()
                                                                && f.Customers.ToLower() == i.Customers.ToLower()
                                                                && f.TermSpot.ToLower() == i.TermSpot.ToLower()
                                                                && f.PriceSet.ToLower() == i.PriceSet.ToLower()).ToList();
                var convertErrorList = new List<string>();
                var convertDataWarningList = new List<string>();
                var convertModel = i.TryConvertToSalesModel(existingData, containProductMapping, containCompany, containFormulaName, containBusinessPartner, containCountries, param.Criteria.isMerge, out convertErrorList, out convertDataWarningList);

                validateModels.Add(convertModel);
            });

            #endregion Create Validate Model & Set Id (RowNo)

            // Temp
            var addSalesDataList = new List<MBR_TMP_SALES_VOLUME>();
            var salesList = new List<MBR_TMP_SALES_VOLUME>();

            var salesTrmRepo = _unit.SalesVoiumeTempRepo.FindByCriteria(param.Criteria.PlaneType, param.Criteria.Case, param.Criteria.Cycle);
            var salesMainRepo = _unit.SalesVoiumeRepo.FindByCriteria(param.Criteria.PlaneType, param.Criteria.Case, param.Criteria.Cycle);

            //add
            var lstData = new List<SalesList>();

            void prepareLstData()
            {
                addSalesDataList = new List<MBR_TMP_SALES_VOLUME>();
                lstData = new List<SalesList>();
                salesList = new List<MBR_TMP_SALES_VOLUME>();

                foreach (var item in validateModels)
                {
                    var productGroup = _unit.MasterProductMappingRepo.GetProductGroup(item.Product).FirstOrDefault();
                    var monthNo = ConverseMonthNo(param.Criteria.Cycle, param.Criteria.PlaneType, item.MonthIndex);
                    var bind = BindSalesTempModelToDB(param.Criteria, item, monthNo, productGroup.ProductGroup);
                    //if (param.Criteria.isMerge)
                    //{
                    //    bind.MergedWithCycle = param.Criteria.MergeCycle;
                    //    bind.MergedWithCase = param.Criteria.MergeCase;
                    //    bind.MergedWithPlanType = param.Criteria.MergePlaneType;
                    //}
                    addSalesDataList.Add(bind);
                    salesList.Add(bind);
                    lstData.Add(new SalesList { company = item.Company, mcsc = item.MCSC, channel = item.Channel, customers = item.Customers, formulaName = item.FormulaName, priceSet = item.PriceSet, product = item.Product, termSpot = item.TermSpot, value = item.MonthIndex });
                }
            }

            prepareLstData();

            //Auto Generate
            /*var autogenData = UploadAutoGenerateMonthIndex(addSalesDataList);
            addSalesDataList = new List<MBR_TMP_SALES_VOLUME>();
            salesList = new List<MBR_TMP_SALES_VOLUME>();
            addSalesDataList = autogenData;
            salesList = autogenData;*/

            if (param.Criteria.isMerge)
            {
                var salesVolumeMainRepo = _unit.SalesVoiumeRepo.FindByCriterias(param.Criteria.MergeCycle, param.Criteria.MergeCase, param.Criteria.Company, param.Criteria.Product, param.Criteria.ProductGroup, param.Criteria.Channel);
                var mergeExistingData = MergeExistingData(param.Criteria, addSalesDataList, salesVolumeMainRepo);
                addSalesDataList = new List<MBR_TMP_SALES_VOLUME>();
                salesList = new List<MBR_TMP_SALES_VOLUME>();
                addSalesDataList = mergeExistingData;
                salesList = mergeExistingData;
            }
            /*else
            {
                var autogenData = UploadAutoGenerateMonthIndex(addSalesDataList);
                addSalesDataList = new List<MBR_TMP_SALES_VOLUME>();
                salesList = new List<MBR_TMP_SALES_VOLUME>();
                addSalesDataList = autogenData;
                salesList = autogenData;
            }*/

            // set Total record
            var total = salesList.Count();

            var createCriteriaParam = new RequestCriteriaSalesCreateParam()
            {
                PlaneType = param.Criteria.PlaneType,
                Case = param.Criteria.Case,
                Cycle = param.Criteria.Cycle,
                Company = param.Criteria.Company,
                Channel = param.Criteria.Channel,
                Product = param.Criteria.Product,
                ProductGroup = param.Criteria.ProductGroup
            };

            var criteria = new RequestCriteriaSales(createCriteriaParam);

            var salesPreviewSubmitRepo = _unit.MasterTempSalesPreviewSubmitRepo.GetByWebUUID(param.Criteria.WebUUID);

            // Direct submit or submit after preview
            if (!IsPreview)
            {
                total = salesList.Count();

                // Submit after preview
                if (salesPreviewSubmitRepo != null && !string.IsNullOrEmpty(salesPreviewSubmitRepo?.PriviewRunId))
                {
                    criteria.runId = salesPreviewSubmitRepo.PriviewRunId;
                    runId = param.Criteria.isMerge ? await CallDataFactory("MBR_TMP_SalesVolume", "SaleVolume", criteria, SUBMIT_STATUS.SUBMIT_AFTER_PREVIEW, param.Criteria.WebUUID, IsPreview, param.Criteria.isMerge, param.Criteria.MergePlaneType, param.Criteria.MergeCycle, param.Criteria.MergeCase)
                        : await CallDataFactory("MBR_TMP_SalesVolume", "SaleVolume", criteria, SUBMIT_STATUS.SUBMIT_AFTER_PREVIEW, param.Criteria.WebUUID, IsPreview, param.Criteria.isMerge);
                }

                // Direct submit
                else
                {
                    // Run submit pipeline
                    runId = param.Criteria.isMerge ? await CallDataFactory("MBR_TMP_SalesVolume", "SaleVolume", criteria, SUBMIT_STATUS.SUBMIT, param.Criteria.WebUUID, IsPreview, param.Criteria.isMerge, param.Criteria.MergePlaneType, param.Criteria.MergeCycle, param.Criteria.MergeCase)
                        : await CallDataFactory("MBR_TMP_SalesVolume", "SaleVolume", criteria, SUBMIT_STATUS.SUBMIT, param.Criteria.WebUUID, IsPreview, param.Criteria.isMerge);
                    // Save data in temp with runid
                    foreach (var item in salesList)
                    {
                        item.RunId = runId;
                    }
                    if (addSalesDataList != null && addSalesDataList.Count > 0)
                        _unit.SalesVoiumeTempRepo.Add(addSalesDataList);

                    _unit.SaveTransaction();
                }
            }

            // Preview
            else
            {
                //Update PreviewRunId and Mode 'Preview-Inprogress' in SalesPreviewSubmit
                runId = param.Criteria.isMerge ? await CallDataFactory("MBR_TMP_SalesVolume", "SaleVolume", criteria, SUBMIT_STATUS.PREVIEW, param.Criteria.WebUUID, IsPreview, param.Criteria.isMerge, param.Criteria.MergePlaneType, param.Criteria.MergeCycle, param.Criteria.MergeCase)
                    : await CallDataFactory("MBR_TMP_SalesVolume", "SaleVolume", criteria, SUBMIT_STATUS.PREVIEW, param.Criteria.WebUUID, IsPreview, param.Criteria.isMerge);
                foreach (var item in salesList)
                {
                    item.RunId = runId;
                }

                if (addSalesDataList != null && addSalesDataList.Count > 0)
                    _unit.SalesVoiumeTempRepo.Add(addSalesDataList);

                _unit.SaveTransaction();

                await Task.Delay(10000);

                while (await KeepCheckingForStatus(SALES_MODE.PREVIEW_SUCCEDED, param.Criteria.WebUUID))
                {
                    await Task.Delay(10000);
                }

                await _dataFactoryService.RunPipeLineImportFinalPrice(runId, IsPreview);

                while (await KeepCheckingForStatus(SALES_MODE.IMPORTING_SUCCEDED, param.Criteria.WebUUID))
                {
                    await Task.Delay(10000);
                }
            }

            var salesVolumeDataWithFinalPrice = await _unit.SalesVoiumeTempRepo.FindByRunIdNoTrackingAsync(runId);

            return Tuple.Create(total, runId, salesVolumeDataWithFinalPrice);
        }

        public async Task<bool> KeepCheckingForStatus(string status, Guid webUuid)
        {
            var currentUUID = await _unit.MasterTempSalesPreviewSubmitRepo.GetByWebUUIDNoTrackingAsync(webUuid);

            if (currentUUID != null && currentUUID.Mode != null)
            {
                if (currentUUID.Mode.Equals(SALES_MODE.PREVIEW_FAILED) || currentUUID.Mode.Equals(SALES_MODE.IMPORTING_FAILED))
                {
                    throw new Exception(currentUUID.Mode);
                }
                else if (currentUUID.Mode.Equals(status))
                {
                    return false; // Continue
                }
                else
                {
                    return true; // Keep checking
                }
            }

            throw new Exception("Web UUID not found or Mode is null");
        }

        public async Task<Tuple<string, int>> UploadSales(DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel> param)
        {
            var data = await UploadSalesCenter(param, false);
            var total = data.Item1;
            string runId = data.Item2;
            return Tuple.Create(runId, total);
        }

        public async Task<List<SalesPreviewResponse>> PreviewSales(DataWitSalesModel<SalesCriteriaModel, ValidateSalesModel> param)
        {
            try
            {
                var data = await UploadSalesCenter(param, true);

                var salesVolumeDataWithFinalPrice = data?.Item3 ?? null;

                if (salesVolumeDataWithFinalPrice != null)
                {
                    return salesVolumeDataWithFinalPrice.Select(s => new SalesPreviewResponse(s)).ToList();
                }

                throw new Exception("Cannot calculate final price.");
            }
            catch (Exception e)
            {
                throw new Exception($"Cannot calculate final price. {e.Message}.");
            }
        }

        #endregion upload

        private MBR_TRN_SALES_VOLUME BindSalesModelToDB(SalesCriteriaModel criteria, SalesDataModel item, string monthNo)
        {
            var cyclePoly = criteria.Cycle;
            if (criteria.PlaneType == APPCONSTANT.SCENATIO.M18)
            {
                var yearMonth = DateTime.ParseExact(criteria.Cycle.Substring(criteria.Cycle.Length - 7), APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture).AddMonths(1);
                cyclePoly = APPCONSTANT.SCENATIO.M18 + "_" + yearMonth.ToString(APPCONSTANT.FORMAT.YEAR_MONTH);
            }
            //var newData = new MBR_TRN_SALES_VOLUME()
            var newData = new MBR_TRN_SALES_VOLUME()
            {
                Case = criteria.Case,
                Cycle = criteria.Cycle,
                CyclePoly = cyclePoly,
                PlanType = criteria.PlaneType,
                Adj1 = !string.IsNullOrEmpty(item.Adj1) ? decimal.Parse(item.Adj1) : 0,
                Adj2 = !string.IsNullOrEmpty(item.Adj2) ? decimal.Parse(item.Adj2) : 0,
                Adj3 = !string.IsNullOrEmpty(item.Adj3) ? decimal.Parse(item.Adj3) : 0,
                Adj4 = !string.IsNullOrEmpty(item.Adj4) ? decimal.Parse(item.Adj4) : 0,
                Adj5 = !string.IsNullOrEmpty(item.Adj5) ? decimal.Parse(item.Adj5) : 0,
                Den = !string.IsNullOrEmpty(item.Den) ? decimal.Parse(item.Den) : 0,
                Alpha1 = !string.IsNullOrEmpty(item.Alpha1) ? decimal.Parse(item.Alpha1) : 0,
                Alpha2 = !string.IsNullOrEmpty(item.Alpha2) ? decimal.Parse(item.Alpha2) : 0,
                BD = !string.IsNullOrEmpty(item.BD) ? decimal.Parse(item.BD) : 0,
                Channel = item.Channel,
                Company = item.Company,
                ContractNo = item.ContractNo,
                Countries = item.Countries,
                CountryPort = item.CountryPort,
                Customers = item.Customers,
                FinalPrice = !string.IsNullOrEmpty(item.FinalPrice) ? decimal.Parse(item.FinalPrice) : 0,
                Formula = item.Formula,
                FormulaName = item.FormulaName,
                IB = !string.IsNullOrEmpty(item.IB) ? decimal.Parse(item.IB) : 0,
                Margin = item.Margin,
                HedgingGainLoss = !string.IsNullOrEmpty(item.HedgingGainLoss) ? decimal.Parse(item.HedgingGainLoss) : null,
                PaymentCondition = item.PaymentCondition,
                Premium = !string.IsNullOrEmpty(item.Premium) ? decimal.Parse(item.Premium) : 0,
                PriceSet = item.PriceSet,
                ReEXP = item.ReEXP,
                Product = item.Product,
                Remark = item.Remark,
                TermSpot = item.TermSpot,
                TransportationMode = item.TransportationMode,
                VesselOrderNo = item.VesselOrderNo,
                VolTons = decimal.Parse(item.VolTons),
                MonthNo = monthNo,

                MCSC = item.MCSC,
                MonthIndex = item.MonthIndex,
                CreatedBy = userLogin,
                CreatedDate = DateTime.Now
            };
            return newData;
        }

        private MBR_TMP_SALES_VOLUME BindSalesTempModelToDB(SalesCriteriaModel criteria, SalesDataModel item, string monthNo, string productGroup)
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
                Adj1 = !string.IsNullOrEmpty(item.Adj1) ? decimal.Parse(item.Adj1) : 0,
                Adj2 = !string.IsNullOrEmpty(item.Adj2) ? decimal.Parse(item.Adj2) : 0,
                Adj3 = !string.IsNullOrEmpty(item.Adj3) ? decimal.Parse(item.Adj3) : 0,
                Adj4 = !string.IsNullOrEmpty(item.Adj4) ? decimal.Parse(item.Adj4) : 0,
                Adj5 = !string.IsNullOrEmpty(item.Adj5) ? decimal.Parse(item.Adj5) : 0,
                Den = !string.IsNullOrEmpty(item.Den) ? decimal.Parse(item.Den) : 0,
                Alpha1 = !string.IsNullOrEmpty(item.Alpha1) ? decimal.Parse(item.Alpha1) : 0,
                Alpha2 = !string.IsNullOrEmpty(item.Alpha2) ? decimal.Parse(item.Alpha2) : 0,
                BD = !string.IsNullOrEmpty(item.BD) ? decimal.Parse(item.BD) : 0,
                Channel = item.Channel,
                Company = item.Company,
                ContractNo = item.ContractNo,
                Countries = item.Countries,
                CountryPort = item.CountryPort,
                Customers = item.Customers,
                FinalPrice = !string.IsNullOrEmpty(item.FinalPrice) ? decimal.Parse(item.FinalPrice) : null,
                Formula = item.Formula,
                FormulaName = item.FormulaName,
                IB = !string.IsNullOrEmpty(item.IB) ? decimal.Parse(item.IB) : 0,
                Margin = item.Margin,
                HedgingGainLoss = !string.IsNullOrEmpty(item.HedgingGainLoss) ? decimal.Parse(item.HedgingGainLoss) : null,
                PaymentCondition = item.PaymentCondition,
                Premium = !string.IsNullOrEmpty(item.Premium) ? decimal.Parse(item.Premium) : 0,
                PriceSet = item.PriceSet,
                ReEXP = item.ReEXP,
                Product = item.Product,
                Remark = item.Remark,
                TermSpot = item.TermSpot,
                TransportationMode = item.TransportationMode,
                VesselOrderNo = item.VesselOrderNo,
                VolTons = decimal.Parse(item.VolTons),
                ProductGroup = productGroup,
                MonthNo = monthNo,
                MCSC = item.MCSC,
                MonthIndex = item.MonthIndex,
                CreatedBy = userLogin,
                CreatedDate = DateTime.Now
            };
            return newData;
        }

        private string ConverseMonthNo(string cycle, string scenario, string monthIndex)
        {
            var format = "{0}-{1}";
            var month = int.Parse(monthIndex.Substring(1));
            cycle = cycle.Substring(cycle.IndexOf("_") + 1);
            if (scenario == SCENATIO.M18 || scenario == SCENATIO.W1 || scenario == SCENATIO.W3 || scenario.ToUpper() == SCENATIO.WEEKLY.ToUpper())
            {
                var now = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                var date = now.AddMonths(month);
                return string.Format(format, date.Year, date.Month.ToString("00"));
            }
            else if (scenario.ToUpper() == SCENATIO.OPPLAN.ToUpper())
            {
                var now = new DateTime(int.Parse(cycle.Substring(0, 4)), 1, 1);
                var date = now.AddMonths(month);
                return string.Format(format, date.Year, date.Month.ToString("00"));
            }
            else if (scenario.ToUpper() == SCENATIO.MTP.ToUpper())
            {
                var now = new DateTime(int.Parse(cycle.Substring(0, 4)), 1, 1);
                var date = now.AddYears(month);
                return string.Format(format, date.Year, date.Month.ToString("00"));
            }

            return null;
        }

        public List<MBR_TMP_SALES_VOLUME> MergeExistingData(SalesCriteriaModel criteria, List<MBR_TMP_SALES_VOLUME> uploadedData, List<MBR_TRN_SALES_VOLUME> existingTransactionData)
        {
            var result = new List<MBR_TMP_SALES_VOLUME>();

            Action<MBR_TMP_SALES_VOLUME, bool> AddOrReplaceToResult = (data, isPreemptive) =>
            {
                // Chcek if data to be added is in the result
                int existingDataInResultIndex = result.FindIndex(x =>
                {
                    return x.MonthIndex == data.MonthIndex &&
                           x.Company == data.Company &&
                           x.MCSC == data.MCSC &&
                           x.Product == data.Product &&
                           x.Channel == data.Channel &&
                           x.FormulaName == data.FormulaName &&
                           x.Customers == data.Customers &&
                           x.TermSpot == data.TermSpot &&
                           x.PriceSet == data.PriceSet;
                });

                if (existingDataInResultIndex != -1)
                {
                    // User uploaded data can replace existing data. But not vice versa.
                    if (isPreemptive)
                    {
                        result[existingDataInResultIndex] = data;
                    }
                }
                else
                {
                    result.Add(data);
                }
            };

            var cyclePoly = uploadedData.FirstOrDefault().CyclePoly;

            foreach (var data in uploadedData)
            {
                var existingTransactionDataWithTheSameKeys = existingTransactionData.Where(
                    x => x.Company == data.Company &&
                         x.MCSC == data.MCSC &&
                         x.Product == data.Product &&
                         x.Channel == data.Channel &&
                         x.FormulaName == data.FormulaName &&
                         x.Customers == data.Customers &&
                         x.TermSpot == data.TermSpot &&
                         x.PriceSet == data.PriceSet
                ).ToList();

                // No record to be merged, just add uploaded data to result e.g., NOT mergable
                if (existingTransactionDataWithTheSameKeys.Count == 0)
                {
                    AddOrReplaceToResult(data, true);
                }

                // There is more than 1 record to be merged e.g., mergable
                else
                {
                    existingTransactionDataWithTheSameKeys.ForEach((extData) =>
                    {
                        // If MonthIndex is the same, add/replace user uploaded data to result (user uploaded data is preemtive)
                        if (extData.MonthIndex == data.MonthIndex)
                        {
                            AddOrReplaceToResult(data, true);
                        }

                        // Otherwise, try to add existing data to the result (but not guarantee to be added)
                        else
                        {
                            extData.PlanType = criteria.PlaneType;
                            extData.Cycle = criteria.Cycle;
                            extData.Case = criteria.Case;
                            extData.CyclePoly = cyclePoly;
                            extData.MergedWithPlanType = criteria.MergePlaneType;
                            extData.MergedWithCycle = criteria.MergeCycle;
                            extData.MergedWithCase = criteria.MergeCase;
                            AddOrReplaceToResult(new MBR_TMP_SALES_VOLUME(extData), false);
                        }
                    });
                }
            }

            return result;
        }

        public List<MBR_TMP_SALES_VOLUME> UploadAutoGenerateMonthIndex(List<MBR_TMP_SALES_VOLUME> uploadedData)
        {
            var result = new List<MBR_TMP_SALES_VOLUME>();

            Action<MBR_TMP_SALES_VOLUME, bool> AddOrReplaceToResult = (data, isPreemptive) =>
            {
                // Chcek if data to be added is in the result
                int existingDataInResultIndex = result.FindIndex(x =>
                {
                    return x.MonthIndex == data.MonthIndex &&
                           x.Company == data.Company &&
                           x.MCSC == data.MCSC &&
                           x.Product == data.Product &&
                           x.Channel == data.Channel &&
                           x.FormulaName == data.FormulaName &&
                           x.Customers == data.Customers &&
                           x.TermSpot == data.TermSpot &&
                           x.PriceSet == data.PriceSet;
                });

                if (existingDataInResultIndex != -1)
                {
                    // User uploaded data can replace existing data. But not vice versa.
                    if (isPreemptive)
                    {
                        result[existingDataInResultIndex] = data;
                    }
                }
                else
                {
                    result.Add(data);
                }
            };

            var groupuploadedData = uploadedData.GroupBy(g => new { g.Company, g.MCSC, g.Product, g.Channel, g.FormulaName, g.Customers, g.TermSpot, g.PriceSet }).ToList();

            foreach (var uploadData in groupuploadedData)
            {
                List<string> monthIndexs = Enum.GetValues(typeof(MONTH_INDEX)).Cast<MONTH_INDEX>().Select(v => v.ToString()).ToList();
                var numMaxMonthIndex = 0;
                foreach (var data in uploadData)
                {
                    var index = monthIndexs.FindIndex(x => x.Equals(data.MonthIndex));
                    if (index > numMaxMonthIndex)
                    {
                        numMaxMonthIndex = index;
                    }
                }

                var dataGenCondition = uploadedData.Where(
                 x => x.Company == uploadData.Key.Company &&
                 x.MCSC == uploadData.Key.MCSC &&
                 x.Product == uploadData.Key.Product &&
                 x.Channel == uploadData.Key.Channel &&
                 x.FormulaName == uploadData.Key.FormulaName &&
                 x.Customers == uploadData.Key.Customers &&
                 x.TermSpot == uploadData.Key.TermSpot &&
                 x.PriceSet == uploadData.Key.PriceSet &&
                 x.MonthIndex == ((MONTH_INDEX)numMaxMonthIndex).ToString()
                 ).FirstOrDefault();

                var dataGen = new MBR_TMP_SALES_VOLUME(dataGenCondition);

                for (int i = 0; i <= numMaxMonthIndex; i++)
                {
                    var existingTransactionData = uploadedData.Where(
                         x => x.Company == uploadData.Key.Company &&
                         x.MCSC == uploadData.Key.MCSC &&
                         x.Product == uploadData.Key.Product &&
                         x.Channel == uploadData.Key.Channel &&
                         x.FormulaName == uploadData.Key.FormulaName &&
                         x.Customers == uploadData.Key.Customers &&
                         x.TermSpot == uploadData.Key.TermSpot &&
                         x.PriceSet == uploadData.Key.PriceSet &&
                         x.MonthIndex == ((MONTH_INDEX)i).ToString()
                    ).FirstOrDefault();
                    if (existingTransactionData is not null)
                    {
                        AddOrReplaceToResult(existingTransactionData, true);
                    }
                    else
                    {
                        dataGen.MonthIndex = ((MONTH_INDEX)i).ToString();
                        dataGen.MonthNo = ConverseMonthNo(dataGen.Cycle, dataGen.PlanType, ((MONTH_INDEX)i).ToString());
                        dataGen.VolTons = 0;
                        dataGen.HedgingGainLoss = 0;
                        dataGen.Alpha1 = 0;
                        dataGen.Alpha2 = 0;
                        dataGen.Premium = 0;
                        dataGen.BD = 0;
                        dataGen.IB = 0;
                        dataGen.Adj1 = 0;
                        dataGen.Adj2 = 0;
                        dataGen.Adj3 = 0;
                        dataGen.Adj4 = 0;
                        dataGen.Adj5 = 0;
                        dataGen.Den = 0;
                        dataGen.FinalPrice = 0;
                        AddOrReplaceToResult(new MBR_TMP_SALES_VOLUME(dataGen), false);
                    }
                }
            }

            return result;
        }

        public async Task<SalesFormulaValidationModel> FormulaValidation(ValidateSalesModel saleModel)
        {
            var result = new SalesFormulaValidationModel() { Errors = new List<string>() };
            Type modelType = saleModel.GetType();
            var validateParams = SALES_VALIDATION.PARAMS.Split(",");
            var formula = _unit.MasterFormulaParameterMappingRepo.GetMasterFormulaParameterByFormulaName(new List<string> { saleModel.FormulaName });
            var requiredParams = formula.Where(f => validateParams.Any(v => v.ToUpper() == f.Parameter.ToUpper())).Select(x => x.Parameter.ToUpper()).ToList();
            IList<PropertyInfo> props = new List<PropertyInfo>(modelType.GetProperties()).Where(p => requiredParams.Contains(p.Name.ToUpper())).ToList();
            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(saleModel, null);
                if (propValue is null)
                {
                    result.Errors.Add(string.Format("{0} is required", prop.Name));
                }
                else
                {
                    if (propValue.GetType() == typeof(System.String))
                    {
                        if (string.IsNullOrEmpty(propValue.ToString()))
                        {
                            result.Errors.Add(string.Format("{0} is required", prop.Name));
                        }
                    }
                }
            }
            if (result.Errors.Any())
            {
                result.IsValid = false;
            }
            else
            {
                result.IsValid = true;
            }
            return result;
        }
    }
}