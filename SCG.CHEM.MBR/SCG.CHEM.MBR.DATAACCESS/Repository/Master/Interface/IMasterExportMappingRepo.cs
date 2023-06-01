using SCG.CHEM.MBR.DATAACCESS.Entities.Master;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterExportMappingRepo : IRepositoryBase<MBR_MST_EXPORT_MAPPING>
    {
        List<MBR_MST_EXPORT_MAPPING> GetMapping(int masterId);

        List<MBR_MST_EXPORT_MAPPING> GetMappingByVariable(int masterId, string variable);
    }
}