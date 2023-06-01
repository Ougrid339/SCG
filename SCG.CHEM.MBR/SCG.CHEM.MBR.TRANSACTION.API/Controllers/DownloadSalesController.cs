using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Sales;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Sales.Interface;

namespace SCG.CHEM.MBR.TRANSACTION.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class DownloadSalesController : Controller
    {
        #region Inject
        private readonly IDownloadSalesService _dowloadService;

        public DownloadSalesController(IDownloadSalesService downloadService)
        {
            _dowloadService = downloadService;
        }

        #endregion Inject
        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult DownloadSales(SalesDownloadRequest req)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Status = 200;
                res.IsSuccess = true;
                res.Data = _dowloadService.DownloadSales(req);
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
