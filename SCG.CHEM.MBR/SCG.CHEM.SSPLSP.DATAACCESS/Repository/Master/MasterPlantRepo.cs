using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterPlantRepo : RepositoryBase<SSP_MST_PLANT>, IMasterPlantRepo
    {
        #region Inject

        public MasterPlantRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_PLANT> GetPlant(List<string> data)
        {
            var result = _context.SSP_MST_PLANTs.Where(w => data.Contains(w.Plant)).Distinct().ToList();
            return result;
        }
    }
}