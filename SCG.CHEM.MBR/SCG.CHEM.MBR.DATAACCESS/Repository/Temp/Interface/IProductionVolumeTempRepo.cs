using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface
{
    public interface IProductionVolumeTempRepo : IRepositoryBase<MBR_TMP_PRODUCTION_VOLUME>
    {
        List<MBR_TMP_PRODUCTION_VOLUME> FindByCriterias(string scenario, string @case, string cycle);

        List<MBR_TMP_PRODUCTION_VOLUME> FindByRunId(string runId);

        List<MBR_TMP_PRODUCTION_VOLUME> FindAfter30minute();
    }
}