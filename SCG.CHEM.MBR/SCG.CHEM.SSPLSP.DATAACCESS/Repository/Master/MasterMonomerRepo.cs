using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterMonomerRepo : RepositoryBase<SSP_MST_MONOMER>, IMasterMonomerRepo
    {
        #region Inject

        public MasterMonomerRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_MONOMER> GetMonomer(List<string> data)
        {
            var result = _context.SSP_MST_MONOMERs.Where(s => data.Contains(s.Monomer)).ToList();
            return result;
        }
    }
}