using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempAdditionalByGradePackRepo : IRepositoryBase<SSP_TMP_ADDITIONAL_BY_GRADEPACK>
    {
        List<SSP_TMP_ADDITIONAL_BY_GRADEPACK> GetByKey(string productionSite, string plantType, string matPrefix, string grade, string package, string channelGroup, decimal deliveryCostByGrade, string startMonth);

        void Truncate();
    }
}