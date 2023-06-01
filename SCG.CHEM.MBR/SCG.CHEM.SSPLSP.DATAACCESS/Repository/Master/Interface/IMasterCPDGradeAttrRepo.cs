using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterCPDGradeAttrRepo : IRepositoryBase<SSP_MST_CPD_GRADE_ATTR>
    {
        List<SSP_MST_CPD_GRADE_ATTR> GetByKey(string productionSite, string matPrefix, string grade, string startMonth);

        List<SSP_MST_CPD_GRADE_ATTR> GetAllByKeyAndVersion(string productionSite, string matPrefix, string grade, string startMonth, int versionNo);
    }
}