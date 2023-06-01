using SCG.CHEM.MBR.DATAACCESS.Entities.Master;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterCaseRepo : IRepositoryBase<MBR_MST_CASE>
    {
        List<MBR_MST_CASE> GetCase();
    }
}