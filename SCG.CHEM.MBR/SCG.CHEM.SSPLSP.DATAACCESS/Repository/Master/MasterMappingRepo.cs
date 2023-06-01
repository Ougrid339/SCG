using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterMappingRepo : RepositoryBase<SSP_MST_MASTER_MAPPING>, IMasterMappingRepo
    {
        #region Inject

        public MasterMappingRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_MASTER_MAPPING> GetMapping(int masterId)
        {
            var result = _context.SSP_MST_MASTER_MAPPINGs.Where(s => masterId.Equals(s.MasterId)).OrderBy(s => s.Sequence).ToList();
            return result;
        }

        public List<SSP_MST_MASTER_MAPPING> GetMappingByVariable(int masterId, string variable)
        {
            var result = _context.SSP_MST_MASTER_MAPPINGs.Where(s => masterId.Equals(s.MasterId) && variable.Equals(s.Variable)).ToList();
            return result;
        }
    }
}