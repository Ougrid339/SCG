using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterScenarioRepo : IRepositoryBase<SSP_MST_SCENARIO>
    {
        List<SSP_MST_SCENARIO> GetByDescriptions(List<string> data);
    }
}