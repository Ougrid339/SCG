using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempManualCostRotoRepo : RepositoryBase<SSP_TMP_MANUAL_COST_ROTO>, IMasterTempManualCostRotoRepo
    {
        #region Inject

        public MasterTempManualCostRotoRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_MANUAL_COST_ROTO> GetByKey(string planType, string matPrefix, string product, string productSub, string productForm
                                                     , string productColor, decimal? sTDYield, decimal? inventoryCost, int inventoryCostUnitId, decimal? maintenanceCost
                                                     , int maintenanceCostUnitId, decimal? semiVC, int semiVCUnitId, decimal? fC, int fCUnitId, string startMonth)
        {
            var result = _context.SSP_TMP_MANUAL_COST_ROTOs.Where(s => s.PlanType == planType && s.MatPrefix == matPrefix && s.Product == product
                        && s.ProductSub == productSub && s.ProductForm == productForm && s.ProductColor == productColor
                        && s.STDYield == sTDYield && s.InventoryCost == inventoryCost && s.InventoryCostUnitId == inventoryCostUnitId && s.MaintenanceCost == maintenanceCost
                        && s.MaintenanceCostUnitId == maintenanceCostUnitId && s.SemiVC == semiVC && s.SemiVCUnitId == semiVCUnitId
                        && s.FC == fC && s.FCUnitId == fCUnitId && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_MANUAL_COST_ROTOs.ToList();
            _context.RemoveRange(data);
        }
    }
}