using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface
{
    public interface IBeginningInventoryTempRepo : IRepositoryBase<MBR_TMP_BEGINING_INVENTORY>
    {
        List<MBR_TMP_BEGINING_INVENTORY> FindByCriterias(string scenario, string @case, string cycle);

        List<MBR_TMP_BEGINING_INVENTORY> FindByRunId(string runId);

        List<MBR_TMP_BEGINING_INVENTORY> FindAfter30minute();
    }
}