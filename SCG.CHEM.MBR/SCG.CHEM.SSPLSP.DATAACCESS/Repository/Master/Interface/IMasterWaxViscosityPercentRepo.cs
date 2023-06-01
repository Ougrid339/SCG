using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterWaxViscosityPercentRepo : IRepositoryBase<SSP_MST_WAX_VISCOSITY_PERCENT>
    {
        List<SSP_MST_WAX_VISCOSITY_PERCENT> GetByKey(string planType, string matPrefix, string grade, string gradeComp, string plant, string productionLine, string startMonth);

        List<SSP_MST_WAX_VISCOSITY_PERCENT> GetAllByKeyAndVersion(string planType, string matPrefix, string grade, string gradeComp, string plant, string productionLine, string startMonth, int versionNo);
    }
}