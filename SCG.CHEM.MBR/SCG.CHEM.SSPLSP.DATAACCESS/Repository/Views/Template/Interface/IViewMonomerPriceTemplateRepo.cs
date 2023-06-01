using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Template.Interface
{
    public interface IViewMonomerPriceTemplateRepo : IRepositoryBase<vSSP_MST_MONOMER_PRICE_TEMPLATE>
    {
        public List<MarketPriceModel> GetMonomerPriceByCycle(string cycle);
    }
}