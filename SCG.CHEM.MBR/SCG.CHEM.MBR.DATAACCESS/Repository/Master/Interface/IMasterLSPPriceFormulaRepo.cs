using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterLSPPriceFormulaRepo : IRepositoryBase<MBR_MST_LSP_PRICE_FORMULA>
    {
        public List<MBR_MST_LSP_PRICE_FORMULA> GetAllByKeyAndVersion(string formulaName, int versionNo);
    }
}