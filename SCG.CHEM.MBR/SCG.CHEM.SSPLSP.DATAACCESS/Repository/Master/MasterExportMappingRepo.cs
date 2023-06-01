using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterExportMappingRepo : RepositoryBase<SSP_MST_EXPORT_MAPPING>, IMasterExportMappingRepo
    {
        #region Inject

        public MasterExportMappingRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_EXPORT_MAPPING> GetMapping(int masterId)
        {
            var result = _context.SSP_MST_EXPORT_MAPPINGs.Where(s => masterId.Equals(s.MasterId)).ToList();
            return result;
        }

        public List<SSP_MST_EXPORT_MAPPING> GetMappingByVariable(int masterId, string variable)
        {
            var result = _context.SSP_MST_EXPORT_MAPPINGs.Where(s => masterId.Equals(s.MasterId) && variable.Equals(s.Variable)).ToList();
            return result;
        }
    }
}