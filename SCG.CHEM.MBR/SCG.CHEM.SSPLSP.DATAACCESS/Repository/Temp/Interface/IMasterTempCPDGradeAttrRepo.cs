using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempCPDGradeAttrRepo : IRepositoryBase<SSP_TMP_CPD_GRADE_ATTR>
    {
        List<SSP_TMP_CPD_GRADE_ATTR> GetByKey(string productionSite, string matPrefix, string grade, string startMonth);

        void Truncate();
    }
}