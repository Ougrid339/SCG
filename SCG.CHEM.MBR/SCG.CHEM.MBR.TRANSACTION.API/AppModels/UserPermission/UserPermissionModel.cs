namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.UserPermission
{
    public class UserPermissionModel
    {
        public int? UserId { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public List<string> Roles { get; set; }
    }

    public class UserPermissionIdModel
    {
        public int? UserId { get; set; }
    }

    public class GetUserAccountModel
    {
        public string UserName { get; set; }
    }
}