using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterFormulaParameterMappingRepo : IRepositoryBase<MBR_MST_FormulaParameterMapping>
    {
        List<MBR_MST_FormulaParameterMapping> GetMasterFormulaParameterByMarketPriceWebPricing(List<string> marketPriceWebPricings);
        List<MBR_MST_FormulaParameterMapping> GetMasterFormulaParameterByFormulaName(List<string> formulaName);
    }
}
