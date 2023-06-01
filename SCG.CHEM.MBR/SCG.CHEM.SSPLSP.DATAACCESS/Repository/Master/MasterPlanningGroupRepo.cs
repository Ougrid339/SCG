using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterPlanningGroupRepo : RepositoryBase<SSP_MST_PLANNING_GROUP>, IMasterPlanningGroupRepo
    {
        #region Inject

        public MasterPlanningGroupRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_PLANNING_GROUP> GetPlanningGroup()
        {
            var result = _context.SSP_MST_PLANNING_GROUPs.ToList();
            return result;
        }

        public List<SSP_MST_PLANNING_GROUP> GetByPlanningGroupCode(List<string> data)
        {
            var result = _context.SSP_MST_PLANNING_GROUPs.Where(w => data.Contains(w.PlanningGroupCode)).ToList();
            return result;
        }

        public List<SSP_MST_PLANNING_GROUP> GetByPlanningGroupName(List<string> data)
        {
            var result = _context.SSP_MST_PLANNING_GROUPs.Where(w => data.Contains(w.PlanningGroupName)).ToList();
            return result;
        }
    }
}