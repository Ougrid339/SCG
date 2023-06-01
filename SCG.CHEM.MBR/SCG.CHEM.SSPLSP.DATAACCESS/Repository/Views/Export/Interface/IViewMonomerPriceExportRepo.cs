using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Export.Interface
{
    public interface IViewMonomerPriceExportRepo : IRepositoryBase<vSSP_MST_MONOMER_PRICE_EXPORT>
    {
        List<MarketPriceModel> GetMonomerPricebyProduct(string planType, string cycle);
    }
}