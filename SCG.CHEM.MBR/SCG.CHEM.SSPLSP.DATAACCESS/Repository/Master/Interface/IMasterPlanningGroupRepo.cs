using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterPlanningGroupRepo : IRepositoryBase<SSP_MST_PLANNING_GROUP>
    {
        List<SSP_MST_PLANNING_GROUP> GetPlanningGroup();

        List<SSP_MST_PLANNING_GROUP> GetByPlanningGroupCode(List<string> data);

        List<SSP_MST_PLANNING_GROUP> GetByPlanningGroupName(List<string> data);
    }
}