using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.COMMON.API.AppModels.Tracking;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.Tracking.Interface;

namespace SCG.CHEM.MBR.COMMON.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class TrackingController : ControllerBase
    {
        #region Inject

        private readonly AppSettings _appSetting;
        private readonly ITrackingService _trackingService;

        public TrackingController(AppSettings appSetting, ITrackingService trackingService)
        {
            _appSetting = appSetting;
            _trackingService = trackingService;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult SearchTracking([FromBody] SearchTrackingReqModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                int total;
                res.Data = _trackingService.SearchTracking(data, out total);
                res.Total = total;
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
        public IActionResult ConfirmTracking([FromBody] ConfirmTrackingModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                int total;
                res.Data = _trackingService.Confirm(data);
                res.Total = 0;
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
        public IActionResult UpdateLockUnlockCycle([FromBody] LockUnlockModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                int total;
                res.Data = _trackingService.UpdateLockUnlockCycle(data);
                res.Total = 0;
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
        public IActionResult Islocked([FromBody] LockUnlockModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                int total;
                res.Data = _trackingService.GetLockUnlock(data);
                res.Total = 0;
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
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult DownloadCheckSaleAndProduct([FromBody] DownloadTrackingRequestModel data)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                int total;
                res.Data = _trackingService.DownloadCheckSaleAndProduct(data);
                res.Total = 0;
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