using SCG.CHEM.MBR.DATAACCESS.Entities.Master;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface ILockUnlockCycleRepo : IRepositoryBase<MBR_MST_LOCKUNLOCKCYCLE>
    {
        MBR_MST_LOCKUNLOCKCYCLE GetByCriteria(string scenario, string cycle, string caseName);
    }
}