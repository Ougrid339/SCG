using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SCG.CHEM.MBR.COMMON.Constants.AppConstant;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Account
{
    public class UserAuthorizeModel
    {
        public int? UserId { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public List<SelectedModel> Role { get; set; }
        public List<SelectedModel> Pages { get; set; }
        public List<SelectedModel> Masters { get; set; }
    }
}