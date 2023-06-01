using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterPlanningGroupRuleRepo : RepositoryBase<SSP_MST_PLANNING_GROUP_RULE>, IMasterPlanningGroupRuleRepo
    {
        #region Inject

        public MasterPlanningGroupRuleRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_PLANNING_GROUP_RULE> GetByKeyData(List<string> planningGroupName, List<string> matPrefix, List<string> materialGroup, List<string> product, List<string> productSub, List<string> application, List<string> productForm, List<string> productColor)
        {
            var result = _context.SSP_MST_PLANNING_GROUP_RULEs.Where(s => (s.PlanningGroupName == "*" || (s.IsNotPlanningGroupName == false && planningGroupName.Contains(s.PlanningGroupName)) || (s.IsNotPlanningGroupName == true && !planningGroupName.Contains(s.PlanningGroupName)))
                                                                        && (s.MatPrefix == "*" || (s.IsNotMatPrefix == false && matPrefix.Contains(s.MatPrefix)) || (s.IsNotMatPrefix == true && !matPrefix.Contains(s.MatPrefix)))
                                                                        && (s.MaterialGroup == "*" || (s.IsNotMaterialGroup == false && materialGroup.Contains(s.MaterialGroup)) || (s.IsNotMaterialGroup == true && !materialGroup.Contains(s.MaterialGroup)))
                                                                        && (s.Product == "*" || (s.IsNotProduct == false && product.Contains(s.Product)) || (s.IsNotProduct == true && !product.Contains(s.Product)))
                                                                        && (s.ProductSub == "*" || (s.IsNotProductSub == false && productSub.Contains(s.ProductSub)) || (s.IsNotProductSub == true && !productSub.Contains(s.ProductSub)))
                                                                        && (s.Application == "*" || (s.IsNotApplication == false && application.Contains(s.Application)) || (s.IsNotApplication == true && !application.Contains(s.Application)))
                                                                        && (s.ProductForm == "*" || (s.IsNotProductForm == false && productForm.Contains(s.ProductForm)) || (s.IsNotProductForm == true && !productForm.Contains(s.ProductForm)))
                                                                        && (s.ProductColor == "*" || (s.IsNotProductColor == false && productColor.Contains(s.ProductColor)) || (s.IsNotProductColor == true && !productColor.Contains(s.ProductColor)))
                                                                    ).ToList();

            return result;
        }
    }
}