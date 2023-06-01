using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.UserPermission
{
    public class RoleSelectedModel
    {
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
        public List<SelectedModel> Pages { get; set; }
        public List<SelectedModel> Masters { get; set; }
    }

    public class RoleExportModel
    {
        public string Role { get; set; }
        public List<RoleModel> Roles { get; set; }
        public List<PageModel> Pages { get; set; }
        public List<MasterModel> Masters { get; set; }
    }

    public class RoleModel
    {
        public string Role { get; set; }
        public object User { get; set; }
        public string Id { get; set; }
    }

    public class PageModel
    {
        public string Role { get; set; }
        public object Page { get; set; }
        public string Id { get; set; }
    }

    public class MasterModel
    {
        public string Role { get; set; }
        public object Master { get; set; }
        public string Id { get; set; }
    }

    public class CriteriaModel
    {
        public string Role { get; set; }
        public object Name { get; set; }
        public string Code { get; set; }
    }
}