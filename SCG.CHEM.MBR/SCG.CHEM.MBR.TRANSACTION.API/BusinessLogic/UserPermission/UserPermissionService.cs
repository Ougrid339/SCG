using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.UserPermission;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services.Interface;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly UnitOfWork _unit;

        public UserPermissionService(UnitOfWork unitOfWork)
        {
            this._unit = unitOfWork;
        }

        public RoleSelectedModel GetRoleSelected()
        {
            var result = new RoleSelectedModel();

            #region Set Selected

            result.RoleId = null;
            result.RoleName = null;
            // Select Pages
            result.Pages = _unit.MasterPageRepo.GetAll().Select(s => new SelectedModel()
            {
                Value = s.Id.ToString(),
                Text = s.Pages,
            }).ToList();

            // Select Master
            result.Masters = _unit.MasterRepo.GetAll().Select(s => new SelectedModel()
            {
                Value = s.MasterId.ToString(),
                Text = s.MasterName,
            }).ToList();

            // Select ProductFlag
            //result.ProductFlag = _unit.MasterNewProductFlagRepo.GetAll().Select(s => new SelectedModel()
            //{
            //    Value = s.NewProductId.ToString(),
            //    Text = s.NewProductLDesc,
            //}).ToList();

            // Select PlanningGroup
            //result.UploadPlanningGroup = _unit.MasterPlanningGroupRepo.GetAll().Select(s => new SelectedModel()
            //{
            //    Value = s.PlanningGroupCode.ToString(),
            //    Text = s.PlanningGroupName,
            //}).ToList();

            // Select PlanningGroup
            //result.DWHPlanningGroup = _unit.MasterPlanningGroupRepo.GetAll().Select(s => new SelectedModel()
            //{
            //    Value = s.PlanningGroupCode.ToString(),
            //    Text = s.PlanningGroupName,
            //}).ToList();

            // Select SalesGroup
            //result.SalesGroup = _unit.MasterSalesGroupRepo.GetAll().Select(s => new SelectedModel()
            //{
            //    Value = s.SalesGroupCode.ToString(),
            //    Text = s.SalesGroupSDesc,
            //}).ToList();

            #endregion Set Selected

            return result;
        }

        public RoleSelectedModel GetRoleById(int id)
        {
            var result = new RoleSelectedModel();
            result.RoleId = null;
            var roleDB = _unit.MasterRoleRepo.GetAll().Where(w => w.Id == id && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).FirstOrDefault();
            if (roleDB != null)
            {
                List<string> rolePage = roleDB.AvailablePages.Split(",").ToList();
                List<string> roleMaster = roleDB.AvailableMasters.Split(",").ToList();

                #region Set Selected

                result.RoleId = roleDB.Id;
                result.RoleName = roleDB.RoleName;
                // Select Pages
                result.Pages = _unit.MasterPageRepo.GetAll().Select(s => new SelectedModel()
                {
                    Value = s.Id.ToString(),
                    Text = s.Pages,
                    IsSelect = rolePage.Contains(s.Id.ToString())
                }).ToList();

                // Select Master
                result.Masters = _unit.MasterRepo.GetAll().Select(s => new SelectedModel()
                {
                    Value = s.MasterId.ToString(),
                    Text = s.MasterName,
                    IsSelect = roleMaster.Contains(s.MasterId.ToString())
                }).ToList();

                #endregion Set Selected
            }
            return result;
        }

        public ResponseModel CreateRole(RolePermissionModel data)
        {
            ResponseModel result = new ResponseModel();
            result.IsSuccess = false;

            #region Validate

            // name
            var isName = _unit.MasterRoleRepo.GetAll().Where(w => w.RoleName == data.RoleName && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).Any();
            if (isName)
            {
                result.IsSuccess = false;
                result.Error = "This role already exists!";
                return result;
            }

            #endregion Validate

            #region new Data

            var comma = ",";

            var availablePages = data.PagesId.Count == 0 ? "" : data.PagesId.Aggregate((x, y) => x + comma + y);
            var availableMasters = data.MastersId.Count == 0 ? "" : data.MastersId.Aggregate((x, y) => x + comma + y);
            var availableOptience = data.OptienceId.Count == 0 ? "" : data.OptienceId.Aggregate((x, y) => x + comma + y);
            var availableCompany = data.CompanyId.Count == 0 ? "" : data.CompanyId.Aggregate((x, y) => x + comma + y);

            var newData = new MBR_MST_ROLES(data.RoleName, availablePages, availableMasters, availableOptience, availableCompany);

            _unit.MasterRoleRepo.Add(newData);

            _unit.SaveTransaction();
            result.IsSuccess = true;
            result.Data = true;

            #endregion new Data

            return result;
        }

        public List<SearchRoleMaintainModel> GetRoleName()
        {
            List<SearchRoleMaintainModel> result = new List<SearchRoleMaintainModel>();

            result = _unit.MasterRoleRepo.GetAll().Where(w => w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES)
                .Select(s => new SearchRoleMaintainModel()
                {
                    Id = s.Id,
                    RoleName = s.RoleName,
                    Username = _unit.MasterUsersRepo.GetAll().Where(o => o.Roles.Split(",").ToList().Contains(s.Id.ToString()) && o.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).Select(o => o.Username).ToList()
                }).ToList();

            return result;
        }

        public ResponseModel UpdateRole(RolePermissionModel data)
        {
            ResponseModel result = new ResponseModel();
            result.IsSuccess = false;
            var dataDB = _unit.MasterRoleRepo.GetAll().Where(w => w.Id == data.RoleId && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).FirstOrDefault();
            if (dataDB == null)
            {
                result.Error = "Data not found";
                result.IsSuccess = false;
                return result;
            }

            #region Validate

            // name
            var isName = _unit.MasterRoleRepo.GetAll().Where(w => w.Id != data.RoleId && w.RoleName == data.RoleName && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).Any();
            if (isName)
            {
                result.IsSuccess = false;
                result.Error = "Duplicate name!";
                return result;
            }

            #endregion Validate

            #region Update Data

            var comma = ",";

            var availablePages = data.PagesId.Count == 0 ? "" : data.PagesId.Aggregate((x, y) => x + comma + y);
            var availableMasters = data.MastersId.Count == 0 ? "" : data.MastersId.Aggregate((x, y) => x + comma + y);
           
            dataDB.AvailablePages = availablePages;
            dataDB.AvailableMasters = availableMasters;

            dataDB.UpdateChange();
            _unit.MasterRoleRepo.Update(dataDB);

            _unit.SaveTransaction();
            result.IsSuccess = true;
            result.Data = true;

            #endregion Update Data

            return result;
        }

        public ResponseModel RemoveRole(RolePermissionModelId data)
        {
            ResponseModel result = new ResponseModel();
            result.IsSuccess = false;
            // check data
            var dataDB = _unit.MasterRoleRepo.GetAll().Where(w => w.Id == data.RoleId && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).FirstOrDefault();
            if (dataDB == null)
            {
                result.Error = "Data not found.";
                result.IsSuccess = false;
                return result;
            }
            // check is use
            var isUse = _unit.MasterUsersRepo.GetAll().Where(o => o.Roles.Split(",").ToList().Contains(data.RoleId.ToString()) && o.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).Select(o => o.Username).Any();
            if (isUse)
            {
                result.Error = "Cannot remove assigned role.";
                result.IsSuccess = false;
                return result;
            }
            dataDB.DeleteBy();
            _unit.MasterRoleRepo.Update(dataDB);

            _unit.SaveTransaction();
            result.IsSuccess = true;
            result.Data = true;

            return result;
        }

        public List<RoleExportModel> RoleExport(RolePermissionModelId data)
        {
            List<RoleExportModel> result = new List<RoleExportModel>();

            #region get user in role

            var roleDB = _unit.MasterRoleRepo.GetAll().Where(o => o.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            if (data.RoleId.HasValue)
                roleDB = roleDB.Where(w => w.Id == data.RoleId).ToList();

            foreach (var item in roleDB)
            {
                var userLs = _unit.MasterUsersRepo.GetAll().Where(o => o.Roles.Split(",").ToList().Contains(item.Id.ToString()) && o.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).Select(s => new RoleModel() { Role = item.RoleName, Id = s.Id.ToString(), User = s.Username }).ToList();
                var pageLs = _unit.MasterPageRepo.GetAll().Where(w => item.AvailablePages.Split(",").ToList().Contains(w.Id.ToString())).Select(s => new PageModel() { Role = item.RoleName, Id = s.Id.ToString(), Page = s.Pages }).ToList();
                var masterLs = _unit.MasterRepo.GetAll().Where(w => item.AvailableMasters.Split(",").ToList().Contains(w.MasterId.ToString())).Select(s => new MasterModel() { Role = item.RoleName, Id = s.MasterId.ToString(), Master = s.MasterName }).ToList();
                //var uploadPlanningGroupLs = _unit.MasterPlanningGroupRepo.GetAll().Where(w => item.AvailableUploadPlanningGroups.Split(",").ToList().Contains(w.PlanningGroupCode.ToString())).Select(s => new CriteriaModel() { Role = item.RoleName, Code = s.PlanningGroupCode, Name = s.PlanningGroupName }).ToList();
                //var dwhPlanningGroupLs = _unit.MasterPlanningGroupRepo.GetAll().Where(w => item.AvailableDWHPlanningGroups.Split(",").ToList().Contains(w.PlanningGroupCode.ToString())).Select(s => new CriteriaModel() { Role = item.RoleName, Code = s.PlanningGroupCode, Name = s.PlanningGroupName }).ToList();
                //var saleGroupLs = _unit.MasterSalesGroupRepo.GetAll().Where(w => item.AvailableSalesGroup.Split(",").ToList().Contains(w.SalesGroupCode.ToString())).Select(s => new CriteriaModel() { Role = item.RoleName, Code = s.SalesGroupCode, Name = s.SalesGroupSDesc }).ToList();
                //var newProductLs = _unit.MasterNewProductFlagRepo.GetAll().Where(w => item.AvailableNewProductFlag.Split(",").ToList().Contains(w.NewProductId.ToString())).Select(s => new CriteriaModel() { Role = item.RoleName, Code = s.NewProductId.ToString(), Name = s.NewProductLDesc }).ToList();

                var role = new RoleExportModel()
                {
                    Role = item.RoleName,
                    Roles = userLs,
                    Pages = pageLs,
                    Masters = masterLs,
                    //UploadPlanningGroup = uploadPlanningGroupLs,
                    //DWHPlanningGroup = dwhPlanningGroupLs,
                    //SalesGroup = saleGroupLs,
                    //ProductFlag = newProductLs
                };
                result.Add(role);
            }

            #endregion get user in role

            return result;
        }

        public List<SearchUserMaintainModel> GetUserPermissions()
        {
            List<SearchUserMaintainModel> result = new List<SearchUserMaintainModel>();

            #region get user in role

            var userDB = _unit.MasterUsersRepo.GetAll().Where(o => o.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            var roleDB = _unit.MasterRoleRepo.GetAll().Where(o => o.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).Select(o => new { o.Id, o.RoleName }).ToList();
            var comma = ", ";
            result = userDB.Select(s => new SearchUserMaintainModel()
            {
                UserId = s.Id,
                Username = s.Username,
                Role = s.Roles == "" || s.Roles == null ? "" : roleDB.Where(w => s.Roles.Split(",").ToList().Contains(w.Id.ToString())).Select(o => o.RoleName).ToList().Aggregate((x, y) => x + comma + y),
                IsActive = s.IsActive,
            }).ToList();

            #endregion get user in role

            return result;
        }

        public UserSelectedModel GetUserSelected()
        {
            var result = new UserSelectedModel();

            #region Set Selected

            result.UserId = null;
            result.Username = null;
            // Select Pages
            result.Roles = _unit.MasterRoleRepo.GetAll().Where(o => o.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).Select(s => new SelectedModel()
            {
                Value = s.Id.ToString(),
                Text = s.RoleName,
            }).ToList();

            #endregion Set Selected

            return result;
        }

        public UserSelectedModel GetUserById(int id)
        {
            var result = new UserSelectedModel();
            result.UserId = null;
            var userDB = _unit.MasterUsersRepo.GetAll().Where(w => w.Id == id && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).FirstOrDefault();
            if (userDB != null)
            {
                #region Set Selected

                result.UserId = userDB.Id;
                result.Username = userDB.Username;
                result.IsActive = userDB.IsActive;
                var lsRole = userDB.Roles.Split(",").ToList();
                // Select Role
                result.Roles = _unit.MasterRoleRepo.GetAll().Where(o => o.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).Select(s => new SelectedModel()
                {
                    Value = s.Id.ToString(),
                    Text = s.RoleName,
                    IsSelect = lsRole.Contains(s.Id.ToString())
                }).ToList();

                #endregion Set Selected
            }
            return result;
        }

        public ResponseModel CreateUser(UserPermissionModel data)
        {
            ResponseModel result = new ResponseModel();
            result.IsSuccess = false;

            #region Validate

            // name
            var isName = _unit.MasterUsersRepo.GetAll().Where(w => w.Username.ToUpper() == data.Username.ToUpper() && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).Any();
            if (isName)
            {
                result.IsSuccess = false;
                result.Error = "This user already exists!";
                return result;
            }

            #endregion Validate

            #region new Data

            var comma = ",";

            var roles = data.Roles.Count() == 0 ? "" : data.Roles.Aggregate((x, y) => x + comma + y);

            var newData = new MBR_MST_USERS(data.Username, roles, data.IsActive);

            _unit.MasterUsersRepo.Add(newData);

            _unit.SaveTransaction();
            result.IsSuccess = true;
            result.Data = true;

            #endregion new Data

            return result;
        }

        public ResponseModel UpdateUser(UserPermissionModel data)
        {
            ResponseModel result = new ResponseModel();
            result.IsSuccess = false;
            var dataDB = _unit.MasterUsersRepo.GetAll().Where(w => w.Id == data.UserId && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).FirstOrDefault();
            if (dataDB == null)
            {
                result.Error = "Data not found";
                result.IsSuccess = false;
                return result;
            }

            #region Validate

            // name
            var isName = _unit.MasterUsersRepo.GetAll().Where(w => w.Id != data.UserId && w.Username.ToUpper() == data.Username.ToUpper() && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).Any();
            if (isName)
            {
                result.IsSuccess = false;
                result.Error = "Duplicate name!";
                return result;
            }

            #endregion Validate

            #region new Data

            var comma = ",";

            var roles = data.Roles.Count() == 0 ? "" : data.Roles.Aggregate((x, y) => x + comma + y);

            dataDB.Roles = roles;
            dataDB.IsActive = data.IsActive;
            dataDB.UpdateChange();
            _unit.MasterUsersRepo.Update(dataDB);

            _unit.SaveTransaction();
            result.IsSuccess = true;
            result.Data = true;

            #endregion new Data

            return result;
        }

        public ResponseModel RemoveUser(UserPermissionIdModel data)
        {
            ResponseModel result = new ResponseModel();
            result.IsSuccess = false;
            var dataDB = _unit.MasterUsersRepo.GetAll().Where(w => w.Id == data.UserId && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).FirstOrDefault();
            if (dataDB == null)
            {
                result.Error = "Data not found";
                result.IsSuccess = false;
                return result;
            }

            dataDB.DeleteBy();
            _unit.MasterUsersRepo.Update(dataDB);

            _unit.SaveTransaction();
            result.IsSuccess = true;
            result.Data = true;

            return result;
        }

        public List<UserExportModel> UserExport(SearchUserExportModel data)
        {
            List<UserExportModel> result = new List<UserExportModel>();

            #region get user in role

            var userDB = _unit.MasterUsersRepo.GetAll().Where(o => o.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            var comma = ", ";

            //var roleDB = _unit.MasterRoleRepo.GetAll().Where(o => o.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).FirstOrDefault();
            //var pageLs = _unit.MasterPageRepo.GetAll().Where(w => roleDB.AvailablePages.Split(",").ToList().Contains(w.Id.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.Id, Text = s.Pages }).ToList();
            //var masterLs = _unit.MasterRepo.GetAll().Where(w => roleDB.AvailableMasters.Split(",").ToList().Contains(w.MasterId.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.MasterId, Text = s.MasterName }).ToList();
            //var uploadPlanningGroupLs = _unit.MasterPlanningGroupRepo.GetAll().Where(w => roleDB.AvailableUploadPlanningGroups.Split(",").ToList().Contains(w.PlanningGroupCode.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.PlanningGroupCode, Text = s.PlanningGroupName }).ToList();
            //var dwhPlanningGroupLs = _unit.MasterPlanningGroupRepo.GetAll().Where(w => roleDB.AvailableDWHPlanningGroups.Split(",").ToList().Contains(w.PlanningGroupCode.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.PlanningGroupCode, Text = s.PlanningGroupName }).ToList();
            //var saleGroupLs = _unit.MasterSalesGroupRepo.GetAll().Where(w => roleDB.AvailableSalesGroup.Split(",").ToList().Contains(w.SalesGroupCode.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.SalesGroupCode, Text = s.SalesGroupSDesc }).ToList();
            //var newProductLs = _unit.MasterNewProductFlagRepo.GetAll().Where(w => roleDB.AvailableNewProductFlag.Split(",").ToList().Contains(w.NewProductId.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.NewProductId, Text = s.NewProductLDesc }).ToList();

            foreach (var user in userDB)
            {
                var roleLs = _unit.MasterRoleRepo.GetAll().Where(w => user.Roles.Split(",").ToList().Contains(w.Id.ToString())).ToList();

                List<string> pageLs = new List<string>();
                List<string> masterLs = new List<string>();

                foreach (var role in roleLs)
                {
                    // add page
                    var pages = role.AvailablePages.Split(",").Where(w => w != "");
                    pageLs = pageLs.Union(pages).ToList();

                    // add master
                    var masters = role.AvailableMasters.Split(",").Where(w => w != "");
                    masterLs = masterLs.Union(masters).ToList();

                }

                UserExportModel userExport = new UserExportModel()
                {
                    UserId = user.Id,
                    Username = user.Username,
                    IsActive = user.IsActive,
                    Role = _unit.MasterRoleRepo.GetAll().Where(w => user.Roles.Split(",").ToList().Contains(w.Id.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.Id, Text = s.RoleName }).ToList(),
                    Pages = _unit.MasterPageRepo.GetAll().Where(w => pageLs.Contains(w.Id.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.Id, Text = s.Pages }).ToList(),
                    Masters = _unit.MasterRepo.GetAll().Where(w => masterLs.Contains(w.MasterId.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.MasterId, Text = s.MasterName }).ToList(),
                   
                };

                result.Add(userExport);
            }

            #endregion get user in role

            // Filter Username
            if (!string.IsNullOrEmpty(data.Username))
            {
                result = result.Where(w => w.Username.Contains(data.Username)).ToList();
            }

            // Filter Role
            if (!string.IsNullOrEmpty(data.Rolename))
            {
                result = result.Where(w => w.Role.Select(o => o.Text).Contains(data.Rolename)).ToList();
            }

            return result;
        }

        public UserAuthorizeModel GetUserAccount(string username)
        {
            UserAuthorizeModel result = new UserAuthorizeModel();

            // Validate

            #region Valdiate Case 1

            /* Possible login cases
             *
             * 0. User outside SCG/LSP AD - no need to handle this case.
             *
             * Assume that token is valid and the signature is verified
             *
             * 1. Request with token in header but we:-
             *    cannot extract UserId/UserName (email, upn, preferred, etc.) from token
             *    or maybe token is in invalid format
             *    or token is not provided in the header
             *    or UserId/UserName extracted from token is empty (possible?)
             *    return 401
             *
             * 2. User inside SCG/LSP AD
             *    - user is inactive and delete flag = 'N'
             *    - user is active and delete flag = 'Y'
             *    - user is inactive and delete flag = 'Y'
             *    return 401
             *
             * 3. User inside SCG/LSP AD and maintained in SSP
             *    - user is active and delete flag = 'N'
             *    return 200
             */

            if (String.IsNullOrEmpty(username))
            {
                throw new InvalidCastException("Unauthorized.");
            }

            #endregion Valdiate Case 1

            #region get user in role

            var userDB = _unit.MasterUsersRepo.Query().Where(o => o.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && o.Username == username).FirstOrDefault();

            if (userDB == null)
                throw new InvalidCastException("User not found.");

            var masterRole = _unit.MasterRoleRepo.GetAll();
            var masterPage = _unit.MasterPageRepo.GetAll();
            var masterMaster = _unit.MasterRepo.GetAll();
            //var masterPlanningGroup = _unit.MasterPlanningGroupRepo.GetAll();
            //var masterSalesGroup = _unit.MasterSalesGroupRepo.GetAll();
            //var masterNewProductFlag = _unit.MasterNewProductFlagRepo.GetAll();

            var comma = ", ";

            var roleLs = masterRole.Where(w => userDB.Roles.Split(",").ToList().Contains(w.Id.ToString())).ToList();

            List<string> pageLs = new List<string>();
            List<string> masterLs = new List<string>();

            foreach (var role in roleLs)
            {
                // add page
                var pages = role.AvailablePages.Split(",").Where(w => w != "");
                pageLs = pageLs.Union(pages).ToList();

                // add master
                var masters = role.AvailableMasters.Split(",").Where(w => w != "");
                masterLs = masterLs.Union(masters).ToList();

            }

            result = new UserAuthorizeModel()
            {
                UserId = userDB.Id,
                Username = userDB.Username,
                IsActive = userDB.IsActive,
                Role = masterRole.Where(w => userDB.Roles.Split(",").ToList().Contains(w.Id.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.Id, Text = s.RoleName }).ToList(),
                Pages = masterPage.Where(w => pageLs.Contains(w.Id.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.Id, Text = s.Pages }).ToList(),
                Masters = masterMaster.Where(w => masterLs.Contains(w.MasterId.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.MasterId, Text = s.MasterName }).ToList(),
                //UploadPlanningGroup = masterPlanningGroup.Where(w => uploadPlanningGroupLs.Contains(w.PlanningGroupCode.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.PlanningGroupCode, Text = s.PlanningGroupName }).ToList(),
                //DWHPlanningGroup = masterPlanningGroup.Where(w => dwhPlanningGroupLs.Contains(w.PlanningGroupCode.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.PlanningGroupCode, Text = s.PlanningGroupName }).ToList(),
                //SalesGroup = masterSalesGroup.Where(w => saleGroupLs.Contains(w.SalesGroupCode.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.SalesGroupCode, Text = s.SalesGroupSDesc }).ToList(),
                //ProductFlag = masterNewProductFlag.Where(w => newProductLs.Contains(w.NewProductId.ToString())).Select(s => new SelectedModel() { IsSelect = true, Value = s.NewProductId, Text = s.NewProductLDesc }).ToList()
            };

            #endregion get user in role

            // Validate

            #region Valdiate Case 2

            /* Possible login cases
             *
             * 0. User outside SCG/LSP AD - no need to handle this case.
             *
             * Assume that token is valid and the signature is verified
             *
             * 1. Request with token in header but we:-
             *    cannot extract UserId/UserName (email, upn, preferred, etc.) from token
             *    or maybe token is in invalid format
             *    or token is not provided in the header
             *    or UserId/UserName extracted from token is empty (possible?)
             *    return 401
             *
             * 2. User inside SCG/LSP AD
             *    - user is inactive and delete flag = 'N'
             *    - user is active and delete flag = 'Y'
             *    - user is inactive and delete flag = 'Y'
             *    return 401
             *
             * 3. User inside SCG/LSP AD and maintained in SSP
             *    - user is active and delete flag = 'N'
             *    return 200
             */

            if (String.IsNullOrEmpty(result.Username) || !result.IsActive)
            {
                throw new InvalidCastException("Unauthorized. Please contact your administrator.");
            }

            #endregion Valdiate Case 2

            return result;
        }
    }
}