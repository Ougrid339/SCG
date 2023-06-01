using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.UserPermission
{
    public class UserSelectedModel
    {
        public int? UserId { get; set; }
        public string? Username { get; set; }
        public bool IsActive { get; set; }
        public List<SelectedModel> Roles { get; set; }
    }

    public class UserExportModel
    {
        public int? UserId { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public List<SelectedModel> Role { get; set; }
        public List<SelectedModel> Pages { get; set; }
        public List<SelectedModel> Masters { get; set; }
        public List<SelectedModel> ProductFlag { get; set; }
        public List<SelectedModel> UploadPlanningGroup { get; set; }
        public List<SelectedModel> DWHPlanningGroup { get; set; }
        public List<SelectedModel> SalesGroup { get; set; }
    }
}