using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterSandOPLocationMappingRepo : IRepositoryBase<SSP_MST_SANDOP_LOCATION_MAPPING>
    {
        List<SSP_MST_SANDOP_LOCATION_MAPPING> GetProductionLineCode(List<string> data);

        List<SSP_MST_SANDOP_LOCATION_MAPPING> GetValuationTypeCode(List<string> data);
    }
}