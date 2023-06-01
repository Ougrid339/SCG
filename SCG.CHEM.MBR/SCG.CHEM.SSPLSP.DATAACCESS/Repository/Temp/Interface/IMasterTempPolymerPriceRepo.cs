using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterTempPolymerPriceRepo : IRepositoryBase<SSP_TMP_POLYMER_PRICE>
    {
        List<SSP_TMP_POLYMER_PRICE> GetByKey(string planType, string marketPrice);

        void Truncate();
    }
}