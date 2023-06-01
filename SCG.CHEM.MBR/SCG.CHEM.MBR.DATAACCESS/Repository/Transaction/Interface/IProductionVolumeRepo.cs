using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Transaction.Interface
{
    public interface IProductionVolumeRepo : IRepositoryBase<MBR_TRN_PRODUCTION_VOLUME>
    {
        List<MBR_TRN_PRODUCTION_VOLUME> FindByCriterias(string mergeScenario, string mergeCase, string mergeCycle);

        List<MBR_TRN_PRODUCTION_VOLUME> FindByCriterias(string scenario, string @case, string cycle, string product);

        List<MBR_TRN_PRODUCTION_VOLUME> FindByCriterias(string mergeScenario, string mergeCase, string mergeCycle, List<string> companys);

        List<OptienceMergeScenario> GetMergeScenario();
    }
}