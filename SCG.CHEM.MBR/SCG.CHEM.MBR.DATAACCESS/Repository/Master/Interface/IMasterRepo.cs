using SCG.CHEM.MBR.DATAACCESS.Entities.Master;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterRepo : IRepositoryBase<MBR_MST_MASTER>
    {
        List<MBR_MST_MASTER> GetMaster(int masterId);

        List<MBR_MST_MASTER> GetMasterFromName(string masterName);

        List<MBR_MST_MASTER> GetPlanType(List<string> data);
    }
}