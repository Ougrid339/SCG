using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterStockTypeRepo : IRepositoryBase<SSP_MST_STOCK_TYPE>
    {
        List<SSP_MST_STOCK_TYPE> GetByStockTypeDesc(List<string> data);
    }
}