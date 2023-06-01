using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterMaterialGradeLevelRepo : IRepositoryBase<SSP_MST_MATERIAL_GRADE_LEVEL>
    {
        List<SSP_MST_MATERIAL_GRADE_LEVEL> GetByGrade(List<string> data);
    }
}