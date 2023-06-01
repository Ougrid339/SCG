using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempActualHedgingRepo : IRepositoryBase<SSP_TMP_ACTUAL_HEDGING>
    {
        List<SSP_TMP_ACTUAL_HEDGING> GetByKey(string planType, string productionSite, string customer, string salesGroup, string matCode, string startMonth);

        void Truncate();
    }
}