using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterPolymerPriceRepo : IRepositoryBase<SSP_MST_POLYMER_PRICE>
    {
        List<SSP_MST_POLYMER_PRICE> GetByKey(string planType, string marketPrice);

        List<SSP_MST_POLYMER_PRICE> GetAllByKeyAndVersion(string planType, string marketPrice, string inputM1, string versionName, string monthNo, int versionNo);

        List<MarketPriceModel> GetPolymerPriceLastVersion(string planType, string cycle);
    }
}