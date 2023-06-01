using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterTempMappingWaxGroupByGradeRepo : IRepositoryBase<SSP_TMP_MAPPING_WAX_GROUP_BY_GRADE>
    {
        List<SSP_TMP_MAPPING_WAX_GROUP_BY_GRADE> GetByKey(string grade, string waxGroup);

        List<SSP_TMP_MAPPING_WAX_GROUP_BY_GRADE> GetAllByKeyAndVersion(string grade, string waxGroup, int versionNo);

        void Truncate();
    }
}