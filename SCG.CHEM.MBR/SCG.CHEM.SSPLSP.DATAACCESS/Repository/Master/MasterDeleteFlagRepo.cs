using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterDeleteFlagRepo : RepositoryBase<SSP_MST_DELETE_FLAG>, IMasterDeleteFlagRepo
    {
        #region Inject

        public MasterDeleteFlagRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public SSP_MST_DELETE_FLAG GetById(string id)
        {
            var result = _context.SSP_MST_DELETE_FLAGs.Where(w => w.Id == id).FirstOrDefault();
            return result;
        }
    }
}