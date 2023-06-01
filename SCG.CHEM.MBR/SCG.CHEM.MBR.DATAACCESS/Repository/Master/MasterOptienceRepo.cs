using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterOptienceRepo : RepositoryBase<MBR_MST_OPTIENCE>, IMasterOptienceRepo
    {
        #region Inject

        public MasterOptienceRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject


        public MBR_MST_OPTIENCE? GetNameByExcelId(int excelId)
        {
            return _context.MBR_MST_OPTIENCEs.Where(x => x.ExcelId == excelId).FirstOrDefault();
        }
    }
}
