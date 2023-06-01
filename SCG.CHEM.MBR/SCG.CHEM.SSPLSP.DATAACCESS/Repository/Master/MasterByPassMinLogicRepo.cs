using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterByPassMinLogicRepo : RepositoryBase<SSP_MST_BYPASS_MIN_LOGIC>, IMasterByPassMinLogicRepo
    {
        #region Inject

        public MasterByPassMinLogicRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public SSP_MST_BYPASS_MIN_LOGIC GetById(int id)
        {
            var result = _context.SSP_MST_BYPASS_MIN_LOGICs.Where(w => w.Id == id).FirstOrDefault();
            return result;
        }
    }
}