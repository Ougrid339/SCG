using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterRepo : IRepositoryBase<SSP_MST_MASTER>
    {
        List<SSP_MST_MASTER> GetPlanType(List<string> data);

        List<SSP_MST_MASTER> GetMaster(int masterId);

        List<SSP_MST_MASTER> GetMasterFromName(string masterName);
    }
}