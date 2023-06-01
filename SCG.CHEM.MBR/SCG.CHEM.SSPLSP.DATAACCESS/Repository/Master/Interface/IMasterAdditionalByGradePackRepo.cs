using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterAdditionalByGradePackRepo : IRepositoryBase<SSP_MST_ADDITIONAL_BY_GRADEPACK>
    {
        List<SSP_MST_ADDITIONAL_BY_GRADEPACK> GetByKey(string productionSite, string plantType, string matPrefix, string grade, string package, string channelGroup, decimal deliveryCostByGrade, string startMonth);

        List<SSP_MST_ADDITIONAL_BY_GRADEPACK> GetAllByKeyAndVersion(string productionSite, string plantType, string matPrefix, string grade, string package, string channelGroup, decimal deliveryCostByGrade, string startMonth, int versionNo);
    }
}