using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON.API.AppModels.ExcelMapping;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.History.Interface;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;

namespace SCG.CHEM.MBR.COMMON.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class CommonController : ControllerBase
    {
        #region Inject

        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;
        private readonly IHistoryService _historyService;

        public CommonController(AppSettings appSetting, UnitOfWork unit, IHistoryService historyService)
        {
            _appSetting = appSetting;
            _unit = unit;
            _historyService = historyService;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult Sample()
        {
            ResponseModel res = new ResponseModel();

            try
            {
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

        [HttpGet]
        public IActionResult MasterExcelMapping(int excelId, bool isUpload = true)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                res.IsSuccess = true;
                res.Data = _unit.MasterExcelMappingRepo.GetMapping(excelId, isUpload);
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
        public IActionResult MasterExcelUploadAndDownloadMapping(int excelId)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                res.IsSuccess = true;

                var allMapping = _unit.MasterExcelMappingRepo.GetMapping(excelId);
                var response = new AllMappingResponse();

                response.Download = allMapping.Where(i => i.IsDownload).ToList();
                response.Upload = allMapping.Where(i => i.IsUpload).ToList();
                res.Data = response;
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
        public IActionResult GetHistoryType()
        {
            ResponseModel res = new ResponseModel();

            try
            {
                res.Data = _historyService.GetHistoryType();
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
    }
}