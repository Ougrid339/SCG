using SCG.CHEM.MBR.COMMON.AppModels.Account;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterUserProfileRepo : IRepositoryBase<MST_USER_PROFILE>
    {
        List<MST_USER_PROFILE> FindAll();

        List<MST_USER_PROFILE> FindById(params string[] userId);

        MST_USER_PROFILE FindOne(string userId);

        AppModels.Account.AccountTokenModel GetUserAccountTokenModel(string userId);
    }
}