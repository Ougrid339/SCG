using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterFormulaParameterMappingRepo : RepositoryBase<MBR_MST_FormulaParameterMapping>, IMasterFormulaParameterMappingRepo
    {
        public MasterFormulaParameterMappingRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public List<MBR_MST_FormulaParameterMapping> GetMasterFormulaParameterByMarketPriceWebPricing(List<string> marketPriceWebPricings)
        {
            return _readContext.MBR_MST_FormulaParameterMapping.Where(w => marketPriceWebPricings.Select(s => s.ToLower()).Contains(w.Parameter.ToLower())).ToList();
        }
        public List<MBR_MST_FormulaParameterMapping> GetMasterFormulaParameterByFormulaName(List<string> formulaName)
        {
            return _readContext.MBR_MST_FormulaParameterMapping.Where(w => formulaName.Select(s => s.ToLower()).Contains(w.FormulaName.ToLower())).ToList();
        }
    }
}
