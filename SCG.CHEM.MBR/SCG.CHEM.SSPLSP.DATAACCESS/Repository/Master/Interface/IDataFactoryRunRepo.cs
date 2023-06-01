using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IDataFactoryRunRepo : IRepositoryBase<SSP_MST_DATAFACTORY_RUN>
    {
        public SSP_MST_DATAFACTORY_RUN GetByRunId(string runId);

        public SSP_MST_DATAFACTORY_RUN GetSalesPlanLatestUpdate();
    }
}