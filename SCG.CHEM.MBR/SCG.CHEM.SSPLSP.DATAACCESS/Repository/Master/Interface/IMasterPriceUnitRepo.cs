using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterPriceUnitRepo : IRepositoryBase<SSP_MST_PRICE_UNIT>
    {
        List<SSP_MST_PRICE_UNIT> GetByPriceUnitId(List<int> data);

        List<SSP_MST_PRICE_UNIT> GetByPriceUnitDesc(List<string> data);
    }
}