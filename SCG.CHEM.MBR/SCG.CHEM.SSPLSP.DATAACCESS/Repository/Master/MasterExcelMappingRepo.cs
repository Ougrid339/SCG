using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterExcelMappingRepo : RepositoryBase<SSP_MST_EXCEL_MAPPING>, IMasterExcelMappingRepo
    {
        #region Inject

        public MasterExcelMappingRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_EXCEL_MAPPING> GetMapping(int excelId)
        {
            var result = _context.SSP_MST_EXCEL_MAPPINGs.Where(s => excelId.Equals(s.ExcelId)).OrderBy(s => s.Sequence).ToList();
            return result;
        }

        public List<SSP_MST_EXCEL_MAPPING> GetMappingByVariable(int excelId, string variable)
        {
            var result = _context.SSP_MST_EXCEL_MAPPINGs.Where(s => excelId.Equals(s.ExcelId) && variable.Equals(s.Variable)).ToList();
            return result;
        }
    }
}