using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempExchangeRateRepo : IRepositoryBase<SSP_TMP_EXCHANGE_RATE>
    {
        List<SSP_TMP_EXCHANGE_RATE> GetByKey(string planType, string startMonth);

        void Truncate();
    }
}