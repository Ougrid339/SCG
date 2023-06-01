using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterPriceTypeRepo : IRepositoryBase<SSP_MST_PRICE_TYPE>
    {
        List<SSP_MST_PRICE_TYPE> GetByPriceTypeDesc(List<string> priceType);

        List<SSP_MST_PRICE_TYPE> GetByPriceTypeDescAndCountry(List<string> priceType, List<string> country);
    }
}