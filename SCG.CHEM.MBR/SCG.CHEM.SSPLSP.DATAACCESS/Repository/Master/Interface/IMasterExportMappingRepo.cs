using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterExportMappingRepo : IRepositoryBase<SSP_MST_EXPORT_MAPPING>
    {
        List<SSP_MST_EXPORT_MAPPING> GetMapping(int masterId);

        List<SSP_MST_EXPORT_MAPPING> GetMappingByVariable(int masterId, string variable);
    }
}