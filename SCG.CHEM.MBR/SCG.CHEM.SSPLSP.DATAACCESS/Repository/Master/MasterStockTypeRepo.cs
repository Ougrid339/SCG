using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterStockTypeRepo : RepositoryBase<SSP_MST_STOCK_TYPE>, IMasterStockTypeRepo
    {
        #region Inject

        public MasterStockTypeRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_STOCK_TYPE> GetByStockTypeDesc(List<string> data)
        {
            var result = _context.SSP_MST_STOCK_TYPEs.Where(w => data.Contains(w.StockDesc)).ToList();
            return result;
        }
    }
}