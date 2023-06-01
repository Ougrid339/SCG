using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterSandOPLocationMappingRepo : RepositoryBase<SSP_MST_SANDOP_LOCATION_MAPPING>, IMasterSandOPLocationMappingRepo
    {
        #region Inject

        public MasterSandOPLocationMappingRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_SANDOP_LOCATION_MAPPING> GetProductionLineCode(List<string> data)
        {
            var result = _context.SSP_MST_SANDOP_LOCATION_MAPPINGs.Where(s => data.Contains(s.ProductionLineCode) && s.ValuationTypeCode != "").ToList();
            return result;
        }

        public List<SSP_MST_SANDOP_LOCATION_MAPPING> GetValuationTypeCode(List<string> data)
        {
            var result = _context.SSP_MST_SANDOP_LOCATION_MAPPINGs.Where(s => data.Contains(s.ValuationTypeCode)).ToList();
            return result;
        }
    }
}