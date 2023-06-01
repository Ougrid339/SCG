using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempManualCostRotoRepo : IRepositoryBase<SSP_TMP_MANUAL_COST_ROTO>
    {
        List<SSP_TMP_MANUAL_COST_ROTO> GetByKey(string planType, string matPrefix, string product, string productSub, string productForm, string productColor, decimal? sTDYield, decimal? inventoryCost, int inventoryCostUnitId, decimal? maintenanceCost, int maintenanceCostUnitId, decimal? semiVC, int semiVCUnitId, decimal? fC, int fCUnitId, string startMonth);

        void Truncate();
    }
}