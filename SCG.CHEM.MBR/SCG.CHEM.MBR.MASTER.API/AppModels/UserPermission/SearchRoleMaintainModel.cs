﻿namespace SCG.CHEM.MBR.MASTER.API.AppModels.UserPermission
{
    public class SearchRoleMaintainModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public List<string> Username { get; set; }
    }
}