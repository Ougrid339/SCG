using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Transaction.Interface
{
    public interface ISalesVoiumeRepo : IRepositoryBase<MBR_TRN_SALES_VOLUME>
    {
        List<MBR_TRN_SALES_VOLUME> FindByCriteria(string scenario, string @case, string cycle);

        List<MBR_TRN_SALES_VOLUME> FindByCriteria(string scenario, string @case, string cycle, string product);

        List<MBR_TRN_SALES_VOLUME> FindByCriterias(string cycle, string @case, List<string>? company, List<string>? product, List<string>? productGroup, List<string>? channel);
        public List<MBR_TRN_SALES_VOLUME> FindByCriteriaProductGroup(string scenario, string @case, string cycle, string productGroup);

        SalesMergeScenarioModel GetMergeScenario();
    }
}