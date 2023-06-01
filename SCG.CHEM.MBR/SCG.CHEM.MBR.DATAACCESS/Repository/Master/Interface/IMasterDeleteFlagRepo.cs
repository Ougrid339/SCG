using SCG.CHEM.MBR.DATAACCESS.Entities.Master;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterDeleteFlagRepo : IRepositoryBase<MBR_MST_DELETE_FLAG>
    {
        MBR_MST_DELETE_FLAG GetById(string id);
    }
}