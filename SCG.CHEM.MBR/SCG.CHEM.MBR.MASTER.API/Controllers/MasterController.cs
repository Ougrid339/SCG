using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.MASTER.API.AppModels.DataFactory;
using SCG.CHEM.MBR.MASTER.API.AppModels.Master;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master.Interface;

namespace SCG.CHEM.MBR.MASTER.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class MasterController : ControllerBase
    {
        #region Inject

        private readonly IMasterService _masterService;
        private readonly IDataFactoryService _dataFactoryService;
        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;

        public MasterController(IDataFactoryService dataFactoryService, IMasterService masterService, AppSettings appSetting)
        {
            _masterService = masterService;
            _dataFactoryService = dataFactoryService;
            _appSetting = appSetting;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult List()
        {
            ResponseModel res = new ResponseModel();

            try
            {
                // get UserName from token
                //var username = UserUtilities.GetADAccount()?.UserId ?? "";

                res.IsSuccess = true;
                //res.Data = _masterService.GetMasters(username);
                res.Data = _masterService.GetAllMasters();
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

        [HttpGet]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult ListByToken()
        {
            ResponseModel res = new ResponseModel();

            try
            {
                var username = UserUtilities.GetADAccount()?.UserId ?? "";
                res.IsSuccess = true;
                res.Data = _masterService.GetMasters(username);
                //res.Data = _masterService.GetAllMasters();
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
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult Get([FromBody] MasterDetailModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                res.IsSuccess = true;
                res.Data = _masterService.GetMasterMapping(data.masterId);
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
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult GetExportMapping([FromBody] MasterDetailModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                res.IsSuccess = true;
                res.Data = _masterService.GetExportMapping(data.masterId);
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
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult Test([FromBody] MasterDetailModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                res.IsSuccess = true;
                res.Data = Environment.GetEnvironmentVariable("APP_ENV");
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
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult RunStatus([FromBody] DataFactoryRunId data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                res.IsSuccess = true;
                res.Data = _dataFactoryService.StatusRunId(data.RunId);
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
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult MoveMasterProductMapping([FromBody] RequestMoveMasterModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                var masterName = _dataFactoryService.StatusRunId(data.runid).MasterName;
                var masterId = _masterService.GetMastersByName(masterName).MasterId;

                res.IsSuccess = true;
                res.Data = _dataFactoryService.DWHImportCompleteStatus(data.runid, data.status, masterId);
                res.Total = _masterService.MoveMasterProductMapping();
                var status = _dataFactoryService.WebImportCompleteStatus(data.runid, masterId);
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
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult MoveMasterCustomerVendorMapping([FromBody] RequestMoveMasterModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                var masterName = _dataFactoryService.StatusRunId(data.runid).MasterName;
                var masterId = _masterService.GetMastersByName(masterName).MasterId;

                res.IsSuccess = true;
                res.Data = _dataFactoryService.DWHImportCompleteStatus(data.runid, data.status, masterId);
                res.Total = _masterService.MoveMasterCustomerVendorMapping();
                var status = _dataFactoryService.WebImportCompleteStatus(data.runid, masterId);
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
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult MoveMasterMarketPriceMapping([FromBody] RequestMoveMasterModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                var masterName = _dataFactoryService.StatusRunId(data.runid).MasterName;
                var masterId = _masterService.GetMastersByName(masterName).MasterId;

                res.IsSuccess = true;
                res.Data = _dataFactoryService.DWHImportCompleteStatus(data.runid, data.status, masterId);
                res.Total = _masterService.MoveMasterMarketPriceMapping();
                var status = _dataFactoryService.WebImportCompleteStatus(data.runid, masterId);
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
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult MoveMasterLSPPriceFormula([FromBody] RequestMoveMasterModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                var masterName = _dataFactoryService.StatusRunId(data.runid).MasterName;
                var masterId = _masterService.GetMastersByName(masterName).MasterId;

                res.IsSuccess = true;
                res.Data = _dataFactoryService.DWHImportCompleteStatus(data.runid, data.status, masterId);
                res.Total = _masterService.MoveMasterLSPPriceFormula();
                var status = _dataFactoryService.WebImportCompleteStatus(data.runid, masterId);
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
};