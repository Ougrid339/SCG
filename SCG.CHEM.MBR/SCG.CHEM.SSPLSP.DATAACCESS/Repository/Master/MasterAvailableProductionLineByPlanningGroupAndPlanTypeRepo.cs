using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterAvailableProductionLineByPlanningGroupAndPlanTypeRepo : RepositoryBase<SSP_MST_AVAILABLE_PRODUCTION_LINE_BY_PLANNING_GROUP_AND_PLAN_TYPE>, IMasterAvailableProductionLineByPlanningGroupAndPlanTypeRepo
    {
        #region Inject

        public MasterAvailableProductionLineByPlanningGroupAndPlanTypeRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject
    }
}