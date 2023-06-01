using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.MASTER.API.AppModels.UserPermission;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services.Interface
{
    public interface IUserPermissionService : IBaseService
    {
        RoleSelectedModel GetRoleSelected();

        ResponseModel CreateRole(RolePermissionModel data);

        List<SearchRoleMaintainModel> GetRoleName();

        RoleSelectedModel GetRoleById(int id);

        ResponseModel UpdateRole(RolePermissionModel data);

        ResponseModel RemoveRole(RolePermissionModelId data);

        List<RoleExportModel> RoleExport(RolePermissionModelId data);

        List<SearchUserMaintainModel> GetUserPermissions();

        UserSelectedModel GetUserSelected();

        UserSelectedModel GetUserById(int id);

        ResponseModel CreateUser(UserPermissionModel data);

        ResponseModel UpdateUser(UserPermissionModel data);

        ResponseModel RemoveUser(UserPermissionIdModel data);

        List<UserExportModel> UserExport(SearchUserExportModel data);

        UserAuthorizeModel GetUserAccount(string username);
    }
}