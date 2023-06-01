using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterSandOPProductionLineRepo : RepositoryBase<SSP_MST_SANDOP_PRODUCTION_LINE>, IMasterSandOPProductionLineRepo
    {
        #region Inject

        public MasterSandOPProductionLineRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_SANDOP_PRODUCTION_LINE> GetSandOPProductionLine(List<string> data)
        {
            var result = _context.SSP_MST_SANDOP_PRODUCTION_LINEs.Where(s => s.Active == true && data.Contains(s.ProductionLineCode)).ToList();
            return result;
        }
    }
}