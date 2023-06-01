using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterMappingRepo : IRepositoryBase<SSP_MST_MASTER_MAPPING>
    {
        List<SSP_MST_MASTER_MAPPING> GetMapping(int masterId);

        List<SSP_MST_MASTER_MAPPING> GetMappingByVariable(int masterId, string variable);
    }
}