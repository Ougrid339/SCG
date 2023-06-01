using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterConfigRepo : IRepositoryBase<MST_CONFIG>
    {
        MST_CONFIG FindById(string id);

        Dictionary<AppConstant.CONFIG, string> ReadConfigs(params AppConstant.CONFIG[] key);
    }
}