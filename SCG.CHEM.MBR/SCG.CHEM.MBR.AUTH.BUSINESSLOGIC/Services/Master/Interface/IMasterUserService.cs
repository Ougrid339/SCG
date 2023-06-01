using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services.Master
{
    public interface IMasterUserService : IBaseService
    {
        UserDetailModel GetUser(string userId, AccountTokenModel currentUser);

        void EditMasterUser(UserDetailModel userModel, AccountTokenModel currentUser);

        void DeleteMasterUser(UserDetailModel userModel, AccountTokenModel currentUser);

        UserDetailModel CreateAndGetUser(string userId, string firstName, string lastName, string email, bool isForLogin = true);

        UserDetailModel SetupUserDetail(MST_USER_PROFILE dbUser, bool isForLogin = true);
    }
}