using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterActualHedgingRepo : IRepositoryBase<SSP_MST_ACTUAL_HEDGING>
    {
        List<SSP_MST_ACTUAL_HEDGING> GetByKey(string planType, string productionSite, string customer, string salesGroup, string matCode, string startMonth);

        List<SSP_MST_ACTUAL_HEDGING> GetAllByKeyAndVersion(string planType, string productionSite, string customer, string salesGroup, string matCode, string startMonth, int versionNo);
    }
}