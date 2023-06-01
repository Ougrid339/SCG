using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.MASTER.API.AppModels.Master;
using SCG.CHEM.MBR.MASTER.API.AppModels.Account;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master.Interface;
using SCG.CHEM.MBR.DATAACCESS.Entities.Views.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master
{
    public sealed class DownloadService : IDownloadService
    {
        public Object[] exportRepos;
        public Object[] templateRepos;
        private readonly UnitOfWork _unit;

        public DownloadService(UnitOfWork unitOfWork)
        {
            this._unit = unitOfWork;
        }

        public Dictionary<int, List<Object>> DownloadMasters(RequestDownloadModel requestDownload)
        {
            //Dictionary<int, Object> viewsExport = new Dictionary<int, Object>();
            //viewsExport.Add(1, _unit.ViewFreightExportRepo);
            //viewsExport.Add(2, _unit.ViewFreightSubRegionExportRepo);
            //viewsExport.Add(3, _unit.ViewDeliveryCostFlagExportRepo);
            //viewsExport.Add(4, _unit.ViewDeliveryCostExportRepo);
            //viewsExport.Add(5, _unit.ViewAdditionalByCustomerExportRepo);
            //viewsExport.Add(6, _unit.ViewAdditionalByGradePackExportRepo);
            //viewsExport.Add(7, _unit.ViewAdditionalByPackExportRepo);
            //viewsExport.Add(8, _unit.ViewCPDGradeAttrExportRepo);
            //viewsExport.Add(9, _unit.ViewManualAdjustCostGradeLineExportRepo);
            //viewsExport.Add(10, _unit.ViewMonomerExportExpenseExportRepo);
            //viewsExport.Add(11, _unit.ViewRawMatGapExportRepo);
            //viewsExport.Add(12, _unit.ViewMarketPriceGapExportRepo);
            //viewsExport.Add(13, _unit.ViewMonomerPriceExportRepo);
            //viewsExport.Add(14, _unit.ViewActualHedgingExportRepo);
            //viewsExport.Add(15, _unit.ViewWaxViscosityPercentExportRepo);
            //viewsExport.Add(16, _unit.ViewExchangeRateExportRepo);
            //viewsExport.Add(17, _unit.ViewOtherCostExportRepo);
            //viewsExport.Add(18, _unit.ViewOperationChargeExportRepo);
            //viewsExport.Add(19, _unit.ViewRMRollingExportRepo);
            //viewsExport.Add(20, _unit.ViewManualCostRotoExportRepo);
            //viewsExport.Add(21, _unit.ViewPriceGapExportRepo);
            //viewsExport.Add(22, _unit.ViewImportRMRotoExportRepo);
            //viewsExport.Add(23, _unit.ViewMultisiteRotoExportRepo);
            //viewsExport.Add(24, _unit.ViewPolymerPriceExportRepo);
            //viewsExport.Add(25, _unit.ViewStandardLineExportRepo);
            //viewsExport.Add(26, _unit.ViewTariffDestinationDeliveryCostExportRepo);
            //viewsExport.Add(27, _unit.ViewDeliveryByZoneExportRepo);
            //viewsExport.Add(28, _unit.ViewMoveMappingByGradeExportRepo);
            //viewsExport.Add(29, _unit.ViewMappingWaxGroupByGradeExportRepo);
            //viewsExport.Add(30, _unit.ViewAFPStandardEarnExportRepo);

            //Dictionary<int, Object> viewsTemplate = new Dictionary<int, Object>();
            //viewsTemplate.Add(1, _unit.ViewFreightTemplateRepo);
            //viewsTemplate.Add(2, _unit.ViewFreightSubRegionTemplateRepo);
            //viewsTemplate.Add(3, _unit.ViewDeliveryCostFlagTemplateRepo);
            //viewsTemplate.Add(4, _unit.ViewDeliveryCostTemplateRepo);
            //viewsTemplate.Add(5, _unit.ViewAdditionalByCustomerTemplateRepo);
            //viewsTemplate.Add(6, _unit.ViewAdditionalByGradePackTemplateRepo);
            //viewsTemplate.Add(7, _unit.ViewAdditionalByPackTemplateRepo);
            //viewsTemplate.Add(8, _unit.ViewCPDGradeAttrTemplateRepo);
            //viewsTemplate.Add(9, _unit.ViewManualAdjustCostGradeLineTemplateRepo);
            //viewsTemplate.Add(10, _unit.ViewMonomerExportExpenseTemplateRepo);
            //viewsTemplate.Add(11, _unit.ViewRawMatGapTemplateRepo);
            //viewsTemplate.Add(12, _unit.ViewMarketPriceGapTemplateRepo);
            //viewsTemplate.Add(13, _unit.ViewMonomerPriceTemplateRepo);
            //viewsTemplate.Add(14, _unit.ViewActualHedgingTemplateRepo);
            //viewsTemplate.Add(15, _unit.ViewWaxViscosityPercentTemplateRepo);
            //viewsTemplate.Add(16, _unit.ViewExchangeRateTemplateRepo);
            //viewsTemplate.Add(17, _unit.ViewOtherCostTemplateRepo);
            //viewsTemplate.Add(18, _unit.ViewOperationChargeTemplateRepo);
            //viewsTemplate.Add(19, _unit.ViewRMRollingTemplateRepo);
            //viewsTemplate.Add(20, _unit.ViewManualCostRotoTemplateRepo);
            //viewsTemplate.Add(21, _unit.ViewPriceGapTemplateRepo);
            //viewsTemplate.Add(22, _unit.ViewImportRMRotoTemplateRepo);
            //viewsTemplate.Add(23, _unit.ViewMultisiteRotoTemplateRepo);
            //viewsTemplate.Add(24, _unit.ViewPolymerPriceTemplateRepo);
            //viewsTemplate.Add(25, _unit.ViewStandardLineTemplateRepo);
            //viewsTemplate.Add(26, _unit.ViewTariffDestinationDeliveryCostTemplateRepo);
            //viewsTemplate.Add(27, _unit.ViewDeliveryByZoneTemplateRepo);
            //viewsTemplate.Add(28, _unit.ViewMoveMappingByGradeTemplateRepo);
            //viewsTemplate.Add(29, _unit.ViewMappingWaxGroupByGradeTemplateRepo);
            //viewsTemplate.Add(30, _unit.ViewAFPStandardEarnTemplateRepo);

            Dictionary<int, List<Object>> result = new Dictionary<int, List<Object>>();
            //if (requestDownload.mode?.ToLower() == "export")
            //{
            //    foreach (var master in requestDownload.masters)
            //    {
            //        List<Object> resultView = new List<Object>();
            //        IDownloadRepo down = (IDownloadRepo)viewsExport.GetValueOrDefault(master);
            //        var exportData = down.DownloadMaster(requestDownload.plantypes, requestDownload.startdate, requestDownload.cycle);
            //        resultView.Add(exportData);
            //        result.Add(master, resultView);
            //    }
            //}
            //else if (requestDownload.mode?.ToLower() == "view")
            //{
            //    foreach (var master in requestDownload.masters)
            //    {
            //        List<Object> resultView = new List<Object>();
            //        IDownloadRepo down = (IDownloadRepo)viewsTemplate.GetValueOrDefault(master);
            //        var exportData = down.DownloadMaster(requestDownload.plantypes, requestDownload.startdate, requestDownload.cycle);
            //        resultView.Add(exportData);
            //        result.Add(master, resultView);
            //    }
            //}

            return result;
        }

        public Dictionary<string, List<Object>> DownloadAccountReports(RequestAccountDownloadModel requestDownload)
        {
            //Dictionary<string, Object> viewsExport = new Dictionary<string, Object>();
            //viewsExport.Add("Constraint Sales Plan", _unit.ViewLSPConstraintSalesPlanRepo);
            //viewsExport.Add("Exchange Rate", _unit.ViewLSPExchangeRateRepo);
            //viewsExport.Add("Market Price", _unit.ViewLSPMarketPriceRepo);
            //viewsExport.Add("Monomer Price", _unit.ViewLSPMonomerPriceRepo);
            //viewsExport.Add("Production Plan", _unit.ViewLSPProductPlanRepo);
            //viewsExport.Add("RM Price", _unit.ViewLSPRMPriceRepo);
            //viewsExport.Add("RM Price Avg", _unit.ViewLSPMonomerAvailableComspRMPrice);

            Dictionary<string, List<Object>> result = new Dictionary<string, List<Object>>();
            //foreach (var type in requestDownload.types)
            //{
            //    List<Object> resultView = new List<Object>();
            //    IDownloadAccountReportRepo down = (IDownloadAccountReportRepo)viewsExport.GetValueOrDefault(type);
            //    var exportData = down.DownloadAccountReports(requestDownload.plantypes, requestDownload.startdate, requestDownload.cycle, requestDownload.planningGroups);
            //    resultView.Add(exportData);
            //    result.Add(type, resultView);
            //    if (type == "RM Price")
            //    {
            //        List<Object> resultViewAvg = new List<Object>();
            //        IDownloadAccountReportRepo downAvg = (IDownloadAccountReportRepo)viewsExport.GetValueOrDefault("RM Price Avg");
            //        var exportDataAvg = downAvg.DownloadAccountReports(requestDownload.plantypes, requestDownload.startdate, requestDownload.cycle, requestDownload.planningGroups);
            //        resultViewAvg.Add(exportDataAvg);
            //        result.Add("RM Price Avg", resultViewAvg);
            //    }
            //}

            return result;
        }

        public List<MasterDownloadResponse> DownloadMasters(MasterDownloadRequest req)
        {
            var result = new List<MasterDownloadResponse>();

            //Dictionary<int, object> repoRef = new Dictionary<int, object>();
            //repoRef.Add(1, _unit.ViewProductMappingRepo);
            //repoRef.Add(2, _unit.ViewLSPPriceFormulaRepo);
            //repoRef.Add(3, _unit.ViewProductMappingRepo);
            //repoRef.Add(4, _unit.ViewProductMappingRepo);
            //repoRef.Add(5, _unit.ViewProductMappingRepo);

            foreach (var masterId in req.MasterIds)
            {
                var eachMasterResponse = new MasterDownloadResponse()
                {
                    MasterId = masterId,
                    MasterMapping = _unit.MasterMappingRepo.GetMapping(masterId),
                    Master = _unit.MasterRepo.GetMaster(masterId),
                };

                // There must be some smarter ways, but this is okay for 4 master.
                if (masterId == 1)
                {
                    eachMasterResponse.MasterData = _unit.ViewProductMappingRepo.GetAll()
                        .Where(m => req.StartDate == null ? true : m.CreatedDate >= req.StartDate);
                }

                else if(masterId == 2)
                {
                    eachMasterResponse.MasterData = _unit.ViewLSPPriceFormulaRepo.GetAll()
                        .Where(m => req.StartDate == null ? true : m.CreatedDate >= req.StartDate);
                }

                else if (masterId == 3)
                {
                    eachMasterResponse.MasterData = _unit.ViewCustomerVendorMappingRepo.GetAll()
                        .Where(m => req.StartDate == null ? true : m.CreatedDate >= req.StartDate);
                }

                else if (masterId == 4)
                {
                    eachMasterResponse.MasterData = _unit.ViewMarketPriceMappingRepo.GetAll()
                        .Where(m => req.StartDate == null ? true : m.CreatedDate >= req.StartDate);
                }

                result.Add(eachMasterResponse);
            }
            return result;
        }
    }
}