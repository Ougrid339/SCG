using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterScenarioRepo : RepositoryBase<MBR_MST_SCENARIO>, IMasterScenarioRepo
    {
        public MasterScenarioRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }
        public List<MBR_MST_SCENARIO> GetScenario()
        {
            return _context.MBR_MST_SCENARIOs.ToList();
        }

    }
}
