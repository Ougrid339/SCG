using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterProjectStatusRepo : RepositoryBase<SSP_MST_PROJECT_STATUS>, IMasterProjectStatusRepo
    {
        #region Inject

        public MasterProjectStatusRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public SSP_MST_PROJECT_STATUS GetById(int id)
        {
            var result = _context.SSP_MST_PROJECT_STATUSs.Where(w => w.Id == id).FirstOrDefault();
            return result;
        }
    }
}