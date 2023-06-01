using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterGenerateRunningRepo : RepositoryBase<SSP_MST_GENERATE_RUNNING>, IMasterGenerateRunningRepo
    {
        #region Inject

        public MasterGenerateRunningRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public SSP_MST_GENERATE_RUNNING GeyById(string id)
        {
            var result = _context.SSP_MST_GENERATE_RUNNINGs.Where(w => w.Id == id).FirstOrDefault();
            return result;
        }
    }
}