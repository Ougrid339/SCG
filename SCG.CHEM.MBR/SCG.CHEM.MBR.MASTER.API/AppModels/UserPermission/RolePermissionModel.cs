namespace SCG.CHEM.MBR.MASTER.API.AppModels.UserPermission
{
    public class RolePermissionModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<string> PagesId { get; set; }
        public List<string> MastersId { get; set; }
        public List<string> OptienceId { get; set; }
        public List<string> CompanyId { get; set; }
    }

    public class RolePermissionModelId
    {
        public int? RoleId { get; set; }
    }
}