using SCG.CHEM.MBR.DATAACCESS.Entities.Master;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterOptienceRepo : IRepositoryBase<MBR_MST_OPTIENCE>
    {
        public MBR_MST_OPTIENCE? GetNameByExcelId(int excelId);
    }
}