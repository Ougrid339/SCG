using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempManualAdjustCostGradeLineRepo : IRepositoryBase<SSP_TMP_MANUAL_ADJUST_COST_GRADELINE>
    {
        List<SSP_TMP_MANUAL_ADJUST_COST_GRADELINE> GetByKey(string productionSite, string planType, string matPrefix, string grade, string plant, string productionLine, string startMonth);

        void Truncate();
    }
}