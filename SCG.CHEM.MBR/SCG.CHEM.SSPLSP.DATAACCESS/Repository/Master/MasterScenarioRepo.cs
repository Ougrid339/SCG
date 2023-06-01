using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterScenarioRepo : RepositoryBase<SSP_MST_SCENARIO>, IMasterScenarioRepo
    {
        #region Inject

        public MasterScenarioRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_SCENARIO> GetByDescriptions(List<string> data)
        {
            var result = _context.SSP_MST_SCENARIOs.Where(s => data.Contains(s.SceneDesc)).ToList();
            return result;
        }
    }
}