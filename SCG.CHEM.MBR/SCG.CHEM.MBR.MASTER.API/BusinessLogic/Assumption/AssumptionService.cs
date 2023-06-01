using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.MASTER.API.AppModels.Assumption;
using SCG.CHEM.MBR.MASTER.API.AppModels.DataFactory;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Assumption.Interface;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master.Interface;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic.Assumption
{
    public class AssumptionService : IAssumptionService
    {
        private readonly UnitOfWork _unit;
        private readonly IDataFactoryService _dataFactoryService;

        public AssumptionService(UnitOfWork unitOfWork, IDataFactoryService dataFactoryService)
        {
            this._unit = unitOfWork;
            this._dataFactoryService = dataFactoryService;

        }

        public List<MBR_MST_ASSUMPTION> GetAssumption(AssumptionRequest req) {
            var result = _unit.AssumptionRepo.GetAssumption(req.Type, req.PlanType, req.Cycle, req.Case);
            return result;
        }

        public async Task<string> AddAssumption(AssumptionModel userInputData)
        {
            #region Clear older than 1 hour data
            var tempDataToBeCleared = _unit.AssumptionTempRepo.GetOlderThanOneHourRecord();
            _unit.AssumptionTempRepo.BulkDelete(tempDataToBeCleared);
            #endregion


            #region Save Data

            // Get data with DeleteFlag != 'Y' from master table
            List<MBR_TMP_ASSUMPTION> newTempData = _unit.AssumptionRepo
                                .Read()
                                .Where(w => w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES)
                                .OrderBy(o => o.CreatedDate)
                                .Select(s => new MBR_TMP_ASSUMPTION(s))
                                .ToList();

            // Loop through user input data, if primary key matches, then mark delete and insert new data (version + 1)
            // otherwise just insert new data (version 1)

            // this can be only one record!
            var matchedExistingRecord = newTempData
                        .Where(w => string.Equals(w.Type, userInputData.Type, StringComparison.OrdinalIgnoreCase) &&
                                    string.Equals(w.PlanType, userInputData.PlanType, StringComparison.OrdinalIgnoreCase) &&
                                    string.Equals(w.Cycle, userInputData.Cycle, StringComparison.OrdinalIgnoreCase) &&
                                    string.Equals(w.Case, userInputData.Case, StringComparison.OrdinalIgnoreCase) )
                        .OrderBy(o => o.CreatedDate)
                        .FirstOrDefault();

            // Existing data
            if (matchedExistingRecord != null)
            {
                matchedExistingRecord.MarkDelete(null);
                var newData = new MBR_TMP_ASSUMPTION()
                {
                    Type = userInputData.Type,
                    PlanType = userInputData.PlanType,
                    Cycle = userInputData.Cycle,
                    Case = userInputData.Case,
                    Assumption = userInputData.Assumption,
                    CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                    CreatedDate = DateTime.Now,
                    DeletedFlag = APPCONSTANT.DELETE_FLAG.NO,
                    VersionNo = matchedExistingRecord.VersionNo + 1,
                 };

                newTempData.Add(newData);
            }

            // New data or initial data
            else
            {
                var newData = new MBR_TMP_ASSUMPTION()
                {
                    Type = userInputData.Type,
                    PlanType = userInputData.PlanType,
                    Cycle = userInputData.Cycle,
                    Case = userInputData.Case,
                    Assumption = userInputData.Assumption,
                    CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "",
                    CreatedDate = DateTime.Now,
                    DeletedFlag = APPCONSTANT.DELETE_FLAG.NO,
                    VersionNo = 1,
                };
                newTempData.Add(newData);
            }

            var req = new RequestCreateRunPipeline("Assumption", "MBR_TMP_Assumption");

            var runId = await _dataFactoryService.RunAssumptionPipeLineAsync(req);

            newTempData.ForEach((data) =>
            {
                data.RunId = runId;
            });

            _unit.AssumptionTempRepo.BulkInsert(newTempData);

            #endregion Save Data

            return runId;
        }

        public int MoveAssumption(RequestMoveMasterModel req)
        {
            var newMasterDB = new List<MBR_MST_ASSUMPTION>();
            var listTempDB = _unit.AssumptionTempRepo.GetByRunId(req.runid);
            int total = listTempDB.Count;

            listTempDB.ForEach(i =>
            {
                var masterDB = _unit.AssumptionRepo.GetAllByKeyAndVersion(i.Type, i.PlanType, i.Cycle, i.Case, i.VersionNo).FirstOrDefault();
                if (masterDB == null)
                {
                    // create
                    masterDB = new MBR_MST_ASSUMPTION(i);
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
                _unit.AssumptionRepo.Add(newMasterDB);

            _unit.AssumptionTempRepo.BulkDelete(listTempDB);
            _unit.SaveTransaction();


            return total;
        }

    }
}
