using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterRoleRepo : IRepositoryBase<MBR_MST_ROLES>
    {
        IQueryable<MBR_MST_ROLES> Find(RoleSearchReqModel criteria);
    }
}