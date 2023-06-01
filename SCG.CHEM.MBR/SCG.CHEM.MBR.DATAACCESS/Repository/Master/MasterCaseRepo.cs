using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterCaseRepo : RepositoryBase<MBR_MST_CASE>, IMasterCaseRepo
    {
        #region Inject

        public MasterCaseRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public List<MBR_MST_CASE> GetCase()
        {
            return _context.MBR_MST_CASEs.ToList();
        }

        #endregion Inject
    }
}