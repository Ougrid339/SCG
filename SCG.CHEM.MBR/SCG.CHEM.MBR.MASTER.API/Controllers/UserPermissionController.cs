using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.MASTER.API.AppModels.UserPermission;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services.Interface;

namespace SCG.CHEM.MBR.MASTER.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    //[AdAuthorize]
    public class UserPermissionController : ControllerBase
    {
        #region Inject

        private readonly IUserPermissionService _userPermission;
        private readonly AppSettings _appSetting;

        private readonly UnitOfWork _unit;

        public UserPermissionController(IUserPermissionService userPermission, AppSettings appSetting)
        {
            _userPermission = userPermission;
            _appSetting = appSetting;
        }

        #endregion Inject

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult GetRoleById([FromBody] RolePermissionModelId data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                if (!data.RoleId.HasValue)
                {
                    res.Data = _userPermission.GetRoleSelected();
                }
                else if (data.RoleId.HasValue)
                {
                    var result = _userPermission.GetRoleById(data.RoleId.Value);

                    if (result.RoleId == null)
                    {
                        res.Error = "data not found";
                        res.IsSuccess = false;
                        return new OkObjectResult(res);
                    }
                    else
                    {
                        res.Data = result;
                    }
                }
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
        public IActionResult GetRoleName()
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Data = _userPermission.GetRoleName();
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

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult CreateRole([FromBody] RolePermissionModel data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                var result = _userPermission.CreateRole(data);
                if (result.IsSuccess.Value)
                {
                    res.IsSuccess = true;
                    res.Status = 200;
                }
                else
                {
                    res.IsSuccess = false;
                    res.Error = result.Error;
                }
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
        public IActionResult UpdateRole([FromBody] RolePermissionModel data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                var result = _userPermission.UpdateRole(data);
                if (result.IsSuccess.Value)
                {
                    res.IsSuccess = true;
                    res.Status = 200;
                }
                else
                {
                    res.IsSuccess = false;
                    res.Error = result.Error;
                }
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
        public IActionResult RemoveRole([FromBody] RolePermissionModelId data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                var result = _userPermission.RemoveRole(data);
                if (result.IsSuccess.Value)
                {
                    res.IsSuccess = true;
                    res.Status = 200;
                }
                else
                {
                    res.IsSuccess = false;
                    res.Error = result.Error;
                }
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
        public IActionResult ExportRole([FromBody] RolePermissionModelId data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Data = _userPermission.RoleExport(data);
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

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult GetUserPermission()
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Data = _userPermission.GetUserPermissions();
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

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult GetUserById([FromBody] UserPermissionIdModel data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                if (!data.UserId.HasValue)
                {
                    res.Data = _userPermission.GetUserSelected();
                }
                else if (data.UserId.HasValue)
                {
                    var result = _userPermission.GetUserById(data.UserId.Value);

                    if (result.UserId == null)
                    {
                        res.Error = "data not found";
                        res.IsSuccess = false;
                        return new OkObjectResult(res);
                    }
                    else
                    {
                        res.Data = result;
                    }
                }
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
        public IActionResult CreateUser([FromBody] UserPermissionModel data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                var result = _userPermission.CreateUser(data);
                if (result.IsSuccess.Value)
                {
                    res.IsSuccess = true;
                    res.Status = 200;
                }
                else
                {
                    res.IsSuccess = false;
                    res.Error = result.Error;
                }
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
        public IActionResult UpdateUser([FromBody] UserPermissionModel data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                var result = _userPermission.UpdateUser(data);
                if (result.IsSuccess.Value)
                {
                    res.IsSuccess = true;
                    res.Status = 200;
                }
                else
                {
                    res.IsSuccess = false;
                    res.Error = result.Error;
                }
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
        public IActionResult RemoveUser([FromBody] UserPermissionIdModel data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                var result = _userPermission.RemoveUser(data);
                if (result.IsSuccess.Value)
                {
                    res.IsSuccess = true;
                    res.Status = 200;
                }
                else
                {
                    res.IsSuccess = false;
                    res.Error = result.Error;
                }
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
        public IActionResult ExportUser([FromBody] SearchUserExportModel data)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                res.Data = _userPermission.UserExport(data);
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

        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public IActionResult GetUserAccountByToken()
        {
            ResponseModel res = new ResponseModel();

            try
            {
                // get UserName from token
                var username = UserUtilities.GetADAccount()?.UserId ?? "";

                res.Data = _userPermission.GetUserAccount(username);
                res.IsSuccess = true;
                res.Status = 200;
            }
            catch (InvalidCastException e)
            {
                res = new ResponseModel()
                {
                    Error = e.Message,
                    Data = e.StackTrace,
                    IsSuccess = false,
                    Status = 401,
                };
                return new UnauthorizedObjectResult(res);
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