using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Authentication.Interface
{
    public interface ITokenManager
    {
        string GenerateAppToken(AccountLoggedInResModel data);

        AccountTokenModel GetAppLoggedInAccount();
    }
}