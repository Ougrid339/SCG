using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterPriceGapRepo : IRepositoryBase<SSP_MST_PRICE_GAP>
    {
        List<SSP_MST_PRICE_GAP> GetByKey(string planType, string rawMatCode, string startMonth);

        List<SSP_MST_PRICE_GAP> GetAllByKeyAndVersion(string planType, string rawMatCode, string startMonth, int versionNo);
    }
}