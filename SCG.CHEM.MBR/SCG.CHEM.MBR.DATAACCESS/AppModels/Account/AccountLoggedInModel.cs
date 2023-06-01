using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SCG.CHEM.MBR.COMMON.Constants.AppConstant;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Account
{
    public class AccountLoggedInReqModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string GetAccount()
        {
            int index = this.UserId.IndexOf(AppConstant.SPLIT_STRING.EMAIL_ADDRESS);
            if (index < 0) return this.UserId;
            return this.UserId.Substring(0, index);
        }
    }

    public class AccountLoggedInResModel
    {
        public UserDetailModel UserDetail { get; set; }
        public List<short> Roles { get; set; }
        public List<MenuModel> Menu { get; set; }
        public string AppToken { get; set; }
        public string AppVersion { get; set; }
        public bool? IsProduction { get; set; }
    }

    public class AccountTokenModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<short> Roles { get; set; }

        public bool IsRole(ROLE role)
        {
            if (this.Roles == null) return false;
            return this.Roles.Contains((short)role);
        }

        public string GetAccount()
        {
            int index = this.UserId.IndexOf(AppConstant.SPLIT_STRING.EMAIL_ADDRESS);
            if (index < 0) return this.UserId;
            return this.UserId.Substring(0, index);
        }
    }
}