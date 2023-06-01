using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterRawMatGapRepo : IRepositoryBase<SSP_MST_RAW_MAT_GAP>
    {
        List<SSP_MST_RAW_MAT_GAP> GetByKey(string productionSite, string planType, string company, string matCode, string startMonth);

        List<SSP_MST_RAW_MAT_GAP> GetAllByKeyAndVersion(string productionSite, string planType, string company, string matCode, string startMonth, int versionNo);
    }
}