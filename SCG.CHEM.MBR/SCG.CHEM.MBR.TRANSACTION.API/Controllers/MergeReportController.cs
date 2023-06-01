using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Optience.Interface;

namespace SCG.CHEM.MBR.TRANSACTION.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    //[AdAuthorize]
    public class MergeReportController : ControllerBase
    {
        #region Inject

        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;
        private readonly IMergeReportService _mergeReportService;

        public MergeReportController(AppSettings appSetting, IMergeReportService mergeReportService)
        {

            _appSetting = appSetting;
            _mergeReportService = mergeReportService;
        }

        #endregion Inject

        [HttpPost]
        public async Task<IActionResult> DownloadAsync([FromBody] MergeReportRequestModel request)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Data = await _mergeReportService.GetReport(request);
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
