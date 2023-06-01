using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterTempLSPPriceFormulaRepo : RepositoryBase<MBR_TMP_LSP_PRICE_FORMULA>, IMasterTempLSPPriceFormulaRepo
    {
        #region Inject

        public MasterTempLSPPriceFormulaRepo(EntitiesMBRContext context, EntitiesMBRReadContext readContext) : base(context, readContext)
        {
        }

        #endregion Inject

        public void Truncate()
        {
            var data = _context.MBR_TMP_LSP_PRICE_FORMULAs.ToList();
            _context.RemoveRange(data);
        }
    }
}