using SCG.CHEM.MBR.DATAACCESS.Entities.Master;

namespace SCG.CHEM.MBR.COMMON.API.AppModels.ExcelMapping
{
    public class AllMappingResponse
    {
        public List<MBR_MST_MASTER_EXCEL_MAPPING> Upload { get; set; }

        public List<MBR_MST_MASTER_EXCEL_MAPPING> Download { get; set; }
    }
}
