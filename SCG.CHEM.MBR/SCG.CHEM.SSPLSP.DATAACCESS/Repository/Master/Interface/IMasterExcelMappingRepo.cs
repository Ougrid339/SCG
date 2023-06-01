using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterExcelMappingRepo : IRepositoryBase<SSP_MST_EXCEL_MAPPING>
    {
        List<SSP_MST_EXCEL_MAPPING> GetMapping(int excelId);

        List<SSP_MST_EXCEL_MAPPING> GetMappingByVariable(int excelId, string variable);
    }
}