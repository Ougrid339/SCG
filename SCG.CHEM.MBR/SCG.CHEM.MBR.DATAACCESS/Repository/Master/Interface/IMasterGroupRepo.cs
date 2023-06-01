using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterGroupRepo : IRepositoryBase<MST_GROUP>
    {
        IQueryable<MST_GROUP> Find(GroupSearchReqModel criteria);
    }
}