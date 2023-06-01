using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Account;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterUserProfileRepo : IRepositoryBase<MST_USER_PROFILE>
    {
        MST_USER_PROFILE FindOne(string userId);

        AccountTokenModel GetUserAccountTokenModel(string userId);

        List<MST_USER_PROFILE> FindById(params string[] userId);

        List<MST_USER_PROFILE> FindAll();
    }
}