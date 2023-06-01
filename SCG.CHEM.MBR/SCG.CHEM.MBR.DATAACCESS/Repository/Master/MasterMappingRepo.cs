using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterMappingRepo : RepositoryBase<MBR_MST_MASTER_MAPPING>, IMasterMappingRepo
    {
        #region Inject

        public MasterMappingRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<MBR_MST_MASTER_MAPPING> GetMapping(int masterId)
        {
            var result = _context.MBR_MST_MASTER_MAPPINGs.Where(s => masterId.Equals(s.MasterId)).OrderBy(s => s.Sequence).ToList();
            return result;
        }

        public List<MBR_MST_MASTER_MAPPING> GetMappingByVariable(int masterId, string variable)
        {
            var result = _context.MBR_MST_MASTER_MAPPINGs.Where(s => masterId.Equals(s.MasterId) && variable.Equals(s.Variable)).ToList();
            return result;
        }
    }
}