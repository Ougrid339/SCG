using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface
{
    public interface ISalesVoiumeTempRepo : IRepositoryBase<MBR_TMP_SALES_VOLUME>
    {
        public List<MBR_TMP_SALES_VOLUME> FindByCriteria(string scenario, string @case, string cycle);

        public List<MBR_TMP_SALES_VOLUME> FindByRunId(string runId);

        public Task<List<MBR_TMP_SALES_VOLUME>> FindByRunIdNoTrackingAsync(string runId);

        public List<MBR_TMP_SALES_VOLUME> FindByCriterias(string cycle, string @case, List<string>? company, List<string>? product, List<string>? productGroup, List<string>? channel);

        public Task<List<MBR_TMP_SALES_VOLUME>> FindOlderThanOneHourRecordAsync();

    }
}
