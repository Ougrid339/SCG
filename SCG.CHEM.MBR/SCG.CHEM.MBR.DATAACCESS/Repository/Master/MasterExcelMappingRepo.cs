using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterExcelMappingRepo : RepositoryBase<MBR_MST_MASTER_EXCEL_MAPPING>, IMasterExcelMappingRepo
    {
        #region Inject

        public MasterExcelMappingRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<MBR_MST_MASTER_EXCEL_MAPPING> GetMapping(int excelId, bool isUpload)
        {
            var result = _context.MBR_MST_MASTER_EXCEL_MAPPINGs
                .Where(m => m.ExcelId == excelId);

            if (isUpload)
            {
                result = result.Where(m => m.IsUpload);
            }

            else
            {
                result = result.Where(m => m.IsDownload);
            }

            return result.OrderBy(m => m.Sequence).ToList();

        }

        public List<MBR_MST_MASTER_EXCEL_MAPPING> GetMapping(int excelId)
        {
            var result = _context.MBR_MST_MASTER_EXCEL_MAPPINGs.Where(m => m.ExcelId == excelId).OrderBy(m => m.Sequence).ToList();

            return result;
        }
    }
}