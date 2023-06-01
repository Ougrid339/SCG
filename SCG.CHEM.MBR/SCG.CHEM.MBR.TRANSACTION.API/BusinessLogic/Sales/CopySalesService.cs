using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.DataFactory;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Sales;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Datafacetory.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Sales.Interface;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Channels;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT.CONSTRAINT.CONVERT_BETWEEN_COMPANY;
using static SCG.CHEM.SSPLSP.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Sales
{
    public class CopySalesService : ICopySalesService
    {
        private readonly UnitOfWork _unit;
        private readonly string userLogin;
        private readonly IDataFactoryService _dataFactoryService;
        private readonly ISalesService _salesService;
        private readonly SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork _unitSSP;

        public CopySalesService(UnitOfWork unitOfWork, IDataFactoryService dataFactoryService, SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork unitSSP, ISalesService salesService)
        {
            this._unit = unitOfWork;
            this.userLogin = UserUtilities.GetADAccount()?.UserId ?? "";
            this._dataFactoryService = dataFactoryService;
            this._unitSSP = unitSSP;
            _salesService = salesService;
        }

        public async Task<Tuple<string, int, List<MBR_TMP_SALES_VOLUME>>> CopySales(SalesCopyRequest param)
        {
            var data = await CopySalesCenter(param, false);
            var result = new List<SalesPreviewResponse>();

            if (data != null)
            {
                foreach (var group in data.Item3)
                {
                    var mapData = new SalesPreviewResponse(group);
                    result.Add(mapData);
                }

                return Tuple.Create(data.Item1, data.Item2, data.Item3);
            }

            throw new Exception("Cannot copy sales");
        }

        public string CallDataFactory(string tableName, string transactionName, RequestCriteriaSales criteria, string submitStatus, bool IsPreview)
        {
            string userName = UserUtilities.GetADAccount()?.UserId ?? "";
            string res = _dataFactoryService.RunPipelineSalesCriteria(tableName, transactionName, criteria, submitStatus, userName, IsPreview);

            return res;
        }

        public async Task<Tuple<string, int, List<MBR_TMP_SALES_VOLUME>>> CopySalesCenter(SalesCopyRequest param, bool IsPreview)
        {
            #region Clear tmp record older than 1 hr

            var olderThanOneHourRecords = await _unit.SalesVoiumeTempRepo.FindOlderThanOneHourRecordAsync();
            _unit.SalesVoiumeTempRepo.BulkDelete(olderThanOneHourRecords);

            #endregion Clear tmp record older than 1 hr

            #region Prepare record to be copied

            var matchedRecords = _unit.SalesVoiumeRepo.FindByCriterias(param.CycleFrom, param.CaseFrom, param.CompanyFrom, param.ProductFrom, param.ProductGroupFrom, param.ChannelFrom);
            var tempSalesDataToBeCopied = new List<MBR_TMP_SALES_VOLUME>();

            foreach (var item in matchedRecords)
            {
                var bind = BindSalesTempModelToDB(new SalesCriteriaModel
                {
                    Cycle = param.CycleTo,
                    Case = param.CaseTo,
                    PlaneType = param.PlaneTypeTo,
                }, item);

                bind.CopiedFromCycle = param.CycleFrom;
                bind.CopiedFromPlanType = param.PlaneTypeFrom;
                bind.CopiedFromCase = param.CaseFrom;
                tempSalesDataToBeCopied.Add(bind);
            }

            #endregion Prepare record to be copied

            int total = tempSalesDataToBeCopied.Count;

            // Prepare cirteria for dwh pipeline
            var createCriteriaParam = new RequestCriteriaSalesCreateParam()
            {
                PlaneType = param.PlaneTypeTo,
                Case = param.CaseTo,
                Cycle = param.CycleTo,
                Company = param.CompanyFrom,
                ProductGroup = param.ProductGroupFrom ?? new List<string>(),
                Product = param.ProductFrom ?? new List<string>(),
                Channel = param.ChannelFrom ?? new List<string>()
            };

            var criteria = new RequestCriteriaSales(createCriteriaParam);

            #region Main logic

            var salesPreviewSubmitRepo = _unit.MasterTempSalesPreviewSubmitRepo.GetByWebUUID(param.WebUUID);

            string? runId;

            // Direct copy or copy after preview
            if (!IsPreview)
            {
                // Copy after preview
                if (salesPreviewSubmitRepo != null && !string.IsNullOrEmpty(salesPreviewSubmitRepo?.PriviewRunId))
                {
                    criteria.runId = salesPreviewSubmitRepo.PriviewRunId;
                    runId = await _salesService.CallDataFactory("MBR_TMP_SalesVolume", "SaleVolume", criteria, SUBMIT_STATUS.SUBMIT_AFTER_PREVIEW, param.WebUUID, IsPreview, false);
                }

                // Direct copy
                else
                {
                    // Run pipeline
                    runId = await _salesService.CallDataFactory("MBR_TMP_SalesVolume", "SaleVolume", criteria, SUBMIT_STATUS.SUBMIT, param.WebUUID, IsPreview, false);

                    // Save data in temp with runid
                    foreach (var item in tempSalesDataToBeCopied)
                    {
                        item.RunId = runId;
                    }
                    if (tempSalesDataToBeCopied != null && tempSalesDataToBeCopied.Count > 0)
                        _unit.SalesVoiumeTempRepo.Add(tempSalesDataToBeCopied);

                    _unit.SaveTransaction();
                }

                return Tuple.Create(runId, total, new List<MBR_TMP_SALES_VOLUME>());
            }

            // Preview
            else
            {
                //Update PreviewRunId and Mode 'Preview-Inprogress' in SalesPreviewSubmit
                runId = await _salesService.CallDataFactory("MBR_TMP_SalesVolume", "SaleVolume", criteria, APPCONSTANT.SUBMIT_STATUS.PREVIEW, param.WebUUID, IsPreview, false);

                foreach (var item in tempSalesDataToBeCopied)
                {
                    item.RunId = runId;
                }

                if (tempSalesDataToBeCopied != null && tempSalesDataToBeCopied.Count > 0)
                    _unit.SalesVoiumeTempRepo.Add(tempSalesDataToBeCopied);

                _unit.SaveTransaction();

                await Task.Delay(10000);

                while (await _salesService.KeepCheckingForStatus(SALES_MODE.PREVIEW_SUCCEDED, param.WebUUID))
                {
                    await Task.Delay(10000);
                }

                await _dataFactoryService.RunPipeLineImportFinalPrice(runId, IsPreview);

                while (await _salesService.KeepCheckingForStatus(SALES_MODE.IMPORTING_SUCCEDED, param.WebUUID))
                {
                    await Task.Delay(10000);
                }
            }

            var salesVolumeDataWithFinalPrice = await _unit.SalesVoiumeTempRepo.FindByRunIdNoTrackingAsync(runId);

            return Tuple.Create(runId, total, salesVolumeDataWithFinalPrice);

            #endregion Main logic
        }

        public bool CheckExistData(SalesCopyRequest param)
        {
            #region check exist data

            var SalesFromRepo = _unit.SalesVoiumeRepo.FindByCriterias(param.CycleFrom, param.CaseFrom, param.CompanyFrom, param.ProductFrom, param.ProductGroupFrom, param.ChannelFrom);

            if (SalesFromRepo.Count <= 0)
            {
                throw new Exception("No sale volume based on your selected criteria.");
            }

            #endregion check exist data

            return true;
        }

        private MBR_TMP_SALES_VOLUME BindSalesTempModelToDB(SalesCriteriaModel criteria, MBR_TRN_SALES_VOLUME item)
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
                Den = item.Den,
                MonthNo = item.MonthNo,
                MCSC = item.MCSC,
                MonthIndex = item.MonthIndex,
                CreatedBy = userLogin,
                CreatedDate = DateTime.Now,
                ProductGroup = item.ProductGroup
            };
            return newData;
        }

        public async Task<List<SalesPreviewResponse>> PreviewCopySales(SalesCopyRequest param)
        {
            var data = await CopySalesCenter(param, true);
            var result = new List<SalesPreviewResponse>();

            if (data != null)
            {
                foreach (var group in data.Item3)
                {
                    var mapData = new SalesPreviewResponse(group);
                    result.Add(mapData);
                }
            }

            return result;
        }
    }
}