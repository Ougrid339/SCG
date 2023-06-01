using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterManualAdjustCostGradeLineRepo : IRepositoryBase<SSP_MST_MANUAL_ADJUST_COST_GRADELINE>
    {
        List<SSP_MST_MANUAL_ADJUST_COST_GRADELINE> GetByKey(string productionSite, string planType, string matPrefix, string grade, string plant, string productionLine, string startMonth);

        List<SSP_MST_MANUAL_ADJUST_COST_GRADELINE> GetAllByKeyAndVersion(string productionSite, string planType, string matPrefix, string grade, string plant, string productionLine, string startMonth, int versionNo);
    }
}