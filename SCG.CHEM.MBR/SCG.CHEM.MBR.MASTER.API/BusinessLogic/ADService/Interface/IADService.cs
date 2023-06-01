using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services;
using SCG.CHEM.MBR.MASTER.API.AppModels.AD;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services.Interface
{
    public interface IADService : IBaseService
    {
        ResADModel GetADUserResult(ReqADTokenModel req);

        ResADModel GetADUsers(ReqADModel req);

        string GetUserAD(string token, string name);
    }
}