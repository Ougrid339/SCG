using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class DataFactoryRunRepo : RepositoryBase<SSP_MST_DATAFACTORY_RUN>, IDataFactoryRunRepo
    {
        public DataFactoryRunRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        public SSP_MST_DATAFACTORY_RUN GetByRunId(string runId)
        {
            var result = _context.SSP_MST_DATAFACTORY_RUNs.Where(s => s.RunId == runId).FirstOrDefault();

            return result;
        }

        public SSP_MST_DATAFACTORY_RUN GetSalesPlanLatestUpdate()
        {
            var result = _context.SSP_MST_DATAFACTORY_RUNs.Where(s => s.Status.Equals("Complete") && s.MasterName.Contains("SalesPlan|")).OrderByDescending(x => x.CreatedDate).FirstOrDefault();

            return result;
        }
    }
}