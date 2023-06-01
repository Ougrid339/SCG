using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterSandOPProductionVersionRepo : RepositoryBase<SSP_MST_SANDOP_PRODUCTION_VERSION>, IMasterSandOPProductionVersionRepo
    {
        #region Inject

        public MasterSandOPProductionVersionRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_SANDOP_PRODUCTION_VERSION> GetSandOPMaterialCode(List<string> data)
        {
            var result = _context.SSP_MST_SANDOP_PRODUCTION_VERSIONs.Where(w => w.ActiveFlag == true && w.MaterialCode.StartsWith("Z1") && w.BOMUsage == "M")
                .GroupBy(g => new { g.MaterialCode, g.Plant, g.CustomizationProductionLine })
                .Select(s => new SSP_MST_SANDOP_PRODUCTION_VERSION()
                {
                    MaterialCode = s.Key.MaterialCode,
                    Plant = s.Key.Plant,
                    CustomizationProductionLine = s.Key.CustomizationProductionLine
                })
                .Where(w => data.Contains(w.MaterialCode)).ToList();
            return result;
        }
    }
}