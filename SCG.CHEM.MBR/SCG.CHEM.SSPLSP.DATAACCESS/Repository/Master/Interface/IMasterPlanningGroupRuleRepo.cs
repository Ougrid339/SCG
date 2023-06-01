using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterPlanningGroupRuleRepo : IRepositoryBase<SSP_MST_PLANNING_GROUP_RULE>
    {
        List<SSP_MST_PLANNING_GROUP_RULE> GetByKeyData(List<string> planningGroupName, List<string> matPrefix, List<string> materialGroup, List<string> product, List<string> productSub, List<string> application, List<string> productForm, List<string> productColor);
    }
}