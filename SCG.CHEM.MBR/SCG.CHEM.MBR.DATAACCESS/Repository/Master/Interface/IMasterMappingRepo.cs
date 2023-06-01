using SCG.CHEM.MBR.DATAACCESS.Entities.Master;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterMappingRepo : IRepositoryBase<MBR_MST_MASTER_MAPPING>
    {
        List<MBR_MST_MASTER_MAPPING> GetMapping(int masterId);

        List<MBR_MST_MASTER_MAPPING> GetMappingByVariable(int masterId, string variable);
    }
}