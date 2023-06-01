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
    public class MasterOptienceTypeRepo : RepositoryBase<MBR_MST_MASTER_EXCEL>, IMasterOptienceTypeRepo
    {
        #region Inject

        public MasterOptienceTypeRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public List<MBR_MST_MASTER_EXCEL> GetOptienceType()
        {
            return _context.MBR_MST_MASTER_EXCELs.Where(x=>x.ExcelId > 1 && x.ExcelId <= 5).ToList();
        }

        #endregion Inject
    }
}
