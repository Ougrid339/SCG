using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterManualCostRotoRepo : IRepositoryBase<SSP_MST_MANUAL_COST_ROTO>
    {
        List<SSP_MST_MANUAL_COST_ROTO> GetByKey(string planType, string matPrefix, string product, string productSub, string productForm, string productColor, string startMonth);

        List<SSP_MST_MANUAL_COST_ROTO> GetAllByKeyAndVersion(string planType, string matPrefix, string product, string productSub, string productForm, string productColor, string startMonth, int versionNo);
    }
}