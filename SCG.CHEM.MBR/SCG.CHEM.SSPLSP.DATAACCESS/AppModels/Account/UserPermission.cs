using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SCG.CHEM.MBR.COMMON.Constants.AppConstant;

namespace SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Account
{
    public class UserAuthorizeModel
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