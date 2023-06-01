using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON.API.AppModels.History;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.History.Interface;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;

namespace SCG.CHEM.MBR.COMMON.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class HistoryController : ControllerBase
    {
        #region Inject

        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;
        private readonly IHistoryService _historyService;

        public HistoryController(AppSettings appSetting, UnitOfWork unit, IHistoryService historyService)
        {
            _appSetting = appSetting;
            _unit = unit;
            _historyService = historyService;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult GetHistory([FromBody] RequesHistoryModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                res.Data = _historyService.GetHistory(data);
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
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult DownloadHistory([FromBody] RequestDownloadHistoryModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                res.Data = _historyService.DownloadHistory(data);
                res.IsSuccess = true;
                res.Status = 200;
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