using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MergeHistory.Interface;

namespace SCG.CHEM.MBR.TRANSACTION.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiException]
    [AdAuthorize]
    public class MergeHistoryController : ControllerBase
    {
        #region Inject

        private readonly IMergeHistoryService _mergeHistoryService;

        public MergeHistoryController(AppSettings appSetting, IMergeHistoryService mergeHistoryService)
        {
            _mergeHistoryService = mergeHistoryService;
        }

        #endregion Inject

        [HttpPost]
        public async Task<IActionResult> GetData([FromBody] MergeHistoryRequestModel request)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Data = await _mergeHistoryService.GetMergeHistory(request);
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
