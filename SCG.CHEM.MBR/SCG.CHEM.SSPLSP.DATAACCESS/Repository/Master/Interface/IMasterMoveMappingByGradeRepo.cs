using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterMoveMappingByGradeRepo : IRepositoryBase<SSP_MST_MOVE_MAPPING_BY_GRADE>
    {
        List<SSP_MST_MOVE_MAPPING_BY_GRADE> GetByKey(string productionSite, string grade);

        List<SSP_MST_MOVE_MAPPING_BY_GRADE> GetAllByKeyAndVersion(string productionSite, string grade, int versionNo);
    }
}