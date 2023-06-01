using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterMaterialGradeLevelRepo : RepositoryBase<SSP_MST_MATERIAL_GRADE_LEVEL>, IMasterMaterialGradeLevelRepo
    {
        public MasterMaterialGradeLevelRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        public List<SSP_MST_MATERIAL_GRADE_LEVEL> GetByGrade(List<string> data)
        {
            var result = _context.SSP_MST_MATERIAL_GRADE_LEVELs.Where(w => data.Contains(w.Grade)).ToList();
            return result;
        }
    }
}