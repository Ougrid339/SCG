using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.MASTER.API.AppModels.Config;

namespace SCG.CHEM.MBR.MASTER.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class ConfigController : ControllerBase
    {
        private readonly UnitOfWork _unit;

        public ConfigController(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult GetConfig([FromBody] RequestConfigModel data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Status = 200;
                res.Data = _unit.MasterConfigRepo.FindById(data.ConfigId);
                res.IsSuccess = res.Data != null ? true : false;
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