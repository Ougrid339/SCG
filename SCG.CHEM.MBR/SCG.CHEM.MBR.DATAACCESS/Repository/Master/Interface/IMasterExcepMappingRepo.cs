using SCG.CHEM.MBR.DATAACCESS.Entities.Master;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterExcelMappingRepo : IRepositoryBase<MBR_MST_MASTER_EXCEL_MAPPING>
    {
        List<MBR_MST_MASTER_EXCEL_MAPPING> GetMapping(int excelId, bool isUpload);

        List<MBR_MST_MASTER_EXCEL_MAPPING> GetMapping(int excelId);
    }
}