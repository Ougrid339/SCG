using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterSandOPProductionLineRepo : IRepositoryBase<SSP_MST_SANDOP_PRODUCTION_LINE>
    {
        List<SSP_MST_SANDOP_PRODUCTION_LINE> GetSandOPProductionLine(List<string> data);
    }
}