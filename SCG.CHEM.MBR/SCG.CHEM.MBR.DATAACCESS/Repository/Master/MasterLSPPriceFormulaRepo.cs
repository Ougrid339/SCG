using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterLSPPriceFormulaRepo : RepositoryBase<MBR_MST_LSP_PRICE_FORMULA>, IMasterLSPPriceFormulaRepo
    {
        #region Inject

        public MasterLSPPriceFormulaRepo(EntitiesMBRContext context, EntitiesMBRReadContext readContext) : base(context, readContext)
        {
        }

        #endregion Inject

        public List<MBR_MST_LSP_PRICE_FORMULA> GetAllByKeyAndVersion(string formulaName, int versionNo)
        {
            var result = _context.MBR_MST_LSP_PRICE_FORMULAs
                        .Where(s => s.FormulaName.ToUpper() == formulaName.ToUpper() && s.VersionNo == versionNo)
                        .ToList();

            return result;
        }
    }
}