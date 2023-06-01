using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterExchangeRateRepo : IRepositoryBase<SSP_MST_EXCHANGE_RATE>
    {
        List<SSP_MST_EXCHANGE_RATE> GetAllByKeyAndVersion(string planType, string startMonth, int versionNo);

        List<SSP_MST_EXCHANGE_RATE> GetByKey(string planType, string startMonth);
        List<SSP_MST_EXCHANGE_RATE> GetByKey(string planType, List<string> startMonth);
    }
}