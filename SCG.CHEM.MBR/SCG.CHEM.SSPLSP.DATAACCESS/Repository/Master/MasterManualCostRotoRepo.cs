using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterManualCostRotoRepo : RepositoryBase<SSP_MST_MANUAL_COST_ROTO>, IMasterManualCostRotoRepo
    {
        #region Inject

        public MasterManualCostRotoRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_MANUAL_COST_ROTO> GetByKey(string planType, string matPrefix, string product, string productSub, string productForm
                                                     , string productColor, string startMonth)
        {
            var result = _context.SSP_MST_MANUAL_COST_ROTOs.Where(s => s.PlanType == planType && s.MatPrefix == matPrefix && s.Product == product
                        && s.ProductSub == productSub && s.ProductForm == productForm && s.ProductColor == productColor
                        && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public List<SSP_MST_MANUAL_COST_ROTO> GetAllByKeyAndVersion(string planType, string matPrefix, string product, string productSub, string productForm
                                                     , string productColor, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_MANUAL_COST_ROTOs.Where(s => s.VersionNo == versionNo && s.PlanType == planType && s.MatPrefix == matPrefix && s.Product == product
                        && s.ProductSub == productSub && s.ProductForm == productForm && s.ProductColor == productColor
                        && s.StartMonth == startMonth).ToList();
            return result;
        }
    }
}