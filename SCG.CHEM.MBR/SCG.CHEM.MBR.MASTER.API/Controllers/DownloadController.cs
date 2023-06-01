using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.MASTER.API.AppModels.Master;
using SCG.CHEM.MBR.MASTER.API.AppModels.Account;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master.Interface;

namespace SCG.CHEM.MBR.MASTER.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    //[AdAuthorize]
    public class DownloadController : ControllerBase
    {
        #region Inject

        private readonly IDownloadService _downloadService;
        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;

        public DownloadController(IDownloadService downloadService, AppSettings appSetting)
        {
            _downloadService = downloadService;
            _appSetting = appSetting;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult Masters([FromBody] RequestDownloadModel data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Status = 200;
                res.IsSuccess = true;
                res.Data = _downloadService.DownloadMasters(data);
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
        public IActionResult DownloadMasters(MasterDownloadRequest req)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Status = 200;
                res.IsSuccess = true;
                res.Data = _downloadService.DownloadMasters(req);
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
        public IActionResult AccountReport([FromBody] RequestAccountDownloadModel data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Status = 200;
                res.IsSuccess = true;
                res.Data = _downloadService.DownloadAccountReports(data);
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