using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterPPRPackageCostByGradePackageLSPRepo : IRepositoryBase<SSP_MST_PPR_PACKAGE_COST_BY_GRADE_PACKAGE_LSP>
    {
        List<PackagingCostModel> PackagingCost(string planType, string cycle);
    }
}