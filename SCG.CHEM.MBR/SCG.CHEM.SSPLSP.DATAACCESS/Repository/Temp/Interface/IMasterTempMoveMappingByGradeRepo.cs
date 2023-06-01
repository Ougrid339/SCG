using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempMoveMappingByGradeRepo : IRepositoryBase<SSP_TMP_MOVE_MAPPING_BY_GRADE>
    {
        List<SSP_TMP_MOVE_MAPPING_BY_GRADE> GetByKey(string productionSite, string grade);

        void Truncate();
    }
}