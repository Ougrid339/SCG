using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.MASTER.API.AppModels.Assumption;
using SCG.CHEM.MBR.MASTER.API.AppModels.DataFactory;
using SCG.CHEM.MBR.MASTER.API.AppModels.Master;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Assumption.Interface;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master.Interface;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services.Validation.Interface;

namespace SCG.CHEM.MBR.MASTER.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class AssumptionController : ControllerBase
    {
        #region Inject
        private readonly AppSettings _appSetting;
        private readonly UnitOfWork _unit;
        private readonly IAssumptionService _assumptionService;
        private readonly IDataFactoryService _dataFactoryService;
        private readonly IMasterService _masterService;

        public AssumptionController(UnitOfWork unit, AppSettings appSetting, IAssumptionService assumptionService, IDataFactoryService dataFactoryService, IMasterService masterService)
        {
            _unit = unit;
            _appSetting = appSetting;
            _assumptionService = assumptionService;
            _dataFactoryService = dataFactoryService;
            _masterService = masterService;
        }

        #endregion Inject

        [HttpGet]
        [ActionName("Assumption")]
        public IActionResult GetAssumption([FromQuery] AssumptionRequest req)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                var assumptions = _assumptionService.GetAssumption(req);
                res.Data = assumptions;
                res.Total = assumptions.Count;
                res.IsSuccess = true;
            }
            catch (Exception e)
            {
                res = new ResponseModel()
                {
                    Error = e.Message,
                    Data = e.StackTrace,
                    IsSuccess = false,
                };
                return new BadRequestObjectResult(res);
            }

            return new OkObjectResult(res);
        }

        [HttpPost]
        [ActionName("Assumption")]
        public async Task<IActionResult> PostAssumption([FromBody] AssumptionModel data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Data = await _assumptionService.AddAssumption(data);
                res.IsSuccess = true;
            }
            catch (Exception e)
            {
                res = new ResponseModel()
                {
                    Error = e.Message,
                    Data = e.StackTrace,
                    IsSuccess = false,
                };
                return new BadRequestObjectResult(res);
            }

            return new OkObjectResult(res);
        }

        [HttpPost]
        public IActionResult MoveAssumption([FromBody] RequestMoveMasterModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                var masterName = _dataFactoryService.StatusRunId(data.runid).MasterName;

                res.IsSuccess = true;
                res.Data = _dataFactoryService.DWHImportCompleteStatus(data.runid, data.status);
                res.Total = _assumptionService.MoveAssumption(data);
                var status = _dataFactoryService.WebImportCompleteStatus(data.runid);
            }
            catch (Exception e)
            {
                res = new ResponseModel()
                {
                    Error = e.Message,
                    Data = e.StackTrace,
                    IsSuccess = false,
                };

                return new BadRequestObjectResult(res);
            }

            return new OkObjectResult(res);
        }
    }
}
