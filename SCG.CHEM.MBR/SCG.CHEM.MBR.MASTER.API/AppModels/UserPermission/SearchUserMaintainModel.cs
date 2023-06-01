namespace SCG.CHEM.MBR.MASTER.API.AppModels.UserPermission
{
    public class SearchUserMaintainModel
    {
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }

    public class SearchUserExportModel
    {
        public string Username { get; set; }
        public string Rolename { get; set; }
    }
}