using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services;
using System.Collections.Generic;

namespace SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services.Account.Interface
{
    public interface IAccountService : IBaseService
    {
        AccountLoggedInResModel GetAccount(AccountLoggedInReqModel req, MST_USER_PROFILE dbUser = null, bool isForLogin = true);

        List<MenuModel> GetMenu(List<short> Roles);
    }
}