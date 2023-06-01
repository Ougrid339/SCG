using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MergeHistory.Interface;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MergeHistory
{
    public class MergeHistoryService : IMergeHistoryService
    {
        private readonly UnitOfWork _unit;
        public MergeHistoryService(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }

        public async Task<List<MergeHistoryResponseModel>> GetMergeHistory(MergeHistoryRequestModel request)
        {
            var resultList = new List<MergeHistoryResponseModel>();
            foreach (var excelId in request.ExcelId)
            {
                var mergeData = _unit.MergeHistoryRepo.GetDataByCriteria(request, excelId);
                request.Type = _unit.MasterExcelRepo.GetByExcelId(excelId)?.MasterName?.Replace(" ", "") ?? "";
                var result = new MergeHistoryResponseModel()
                {
                    ExcelId = excelId,
                    Case = request.Case,
                    Cycle = request.Cycle,
                    MergeCase = request.MergeCase,
                    MergeCycle = request.MergeCycle,
                    Type = request.Type
                };
                if (mergeData is not null)
                {
                    if (request.MergeCycle.ToUpper() != mergeData.MergedWithCycle.ToUpper()
                        || request.MergeCase.ToUpper() != mergeData.MergedWithCase.ToUpper())
                    {
                        result.CanMerge = false;
                        result.Type = mergeData.Type;
                        result.Case = mergeData.Case;
                        result.Cycle = mergeData.Cycle;
                        result.MergeCycle = mergeData.MergedWithCycle;
                        result.MergeCase = mergeData.MergedWithCase;
                    }
                }
                else
                {
                    var dataFac = _unit.DataFactoryRunRepo.GetTransactionByMergeCriteria(request);
                    if (dataFac is not null && dataFac.IsMerge == true)
                    {
                        string mergedCycle = null;
                        string mergedCase = null;
                        var today = DateTime.Now;
                        var diffTime = today.Subtract(dataFac.CreatedDate).TotalMinutes;
                        if (diffTime <= 30)
                        {
                            if (excelId == MASTER_EXCEL_TYPE.PRODUCTION_VOLUME)
                            {
                                var rec = _unit.ProductionVolumeTempRepo.FindByRunId(dataFac.RunId).FirstOrDefault();
                                mergedCycle = rec?.MergedWithCycle;
                                mergedCase = rec?.MergedWithCase;
                            }
                            else if (excelId == MASTER_EXCEL_TYPE.FEED_CONSUMPTION)
                            {
                                var rec = _unit.FeedConsumptionTempRepo.FindByRunId(dataFac.RunId).FirstOrDefault();
                                mergedCycle = rec?.MergedWithCycle;
                                mergedCase = rec?.MergedWithCase;
                            }
                            if (!string.IsNullOrEmpty(mergedCase) && !string.IsNullOrEmpty(mergedCycle)
                                && (request.MergeCycle.ToUpper() != mergedCycle?.ToUpper() || request.MergeCase.ToUpper() != mergedCase?.ToUpper()))
                            {
                                result.CanMerge = false;
                                result.Type = request.Type;
                                result.Case = dataFac.Case;
                                result.Cycle = dataFac.Cycle;
                                result.MergeCycle = mergedCycle;
                                result.MergeCase = mergedCase;
                            }
                        }
                    }
                }
                resultList.Add(result);
            }

            return resultList;
        }


    }
}
