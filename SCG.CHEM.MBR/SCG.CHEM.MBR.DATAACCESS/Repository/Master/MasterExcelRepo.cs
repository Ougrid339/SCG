using Microsoft.EntityFrameworkCore;
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
    public class MasterExcelRepo : RepositoryBase<MBR_MST_MASTER_EXCEL>, IMasterExcelRepo
    {
        #region Inject

        public MasterExcelRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public MBR_MST_MASTER_EXCEL? GetByExcelId(int excelId)
        {
            return _context.MBR_MST_MASTER_EXCELs.Where(x => x.ExcelId == excelId).FirstOrDefault();
        }
    }
}
