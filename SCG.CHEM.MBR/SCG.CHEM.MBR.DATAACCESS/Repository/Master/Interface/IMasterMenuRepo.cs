using SCG.CHEM.MBR.DATAACCESS.Entities.Master;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterMenuRepo : IRepositoryBase<MST_MENU>
    {
        List<MST_MENU> GetMenuByRoles(List<short> roles);
    }
}