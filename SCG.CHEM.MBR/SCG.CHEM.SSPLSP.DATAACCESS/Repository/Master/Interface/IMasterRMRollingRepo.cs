using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterRMRollingRepo : IRepositoryBase<SSP_MST_RM_ROLLING>
    {
        List<SSP_MST_RM_ROLLING> GetByKey(string planType, string inputM1, string versionName, string companyCode, string matCode, string unitId, string dataPart, string monthNo);

        List<SSP_MST_RM_ROLLING> GetAllByKeyAndVersion(string planType, string inputM1, string versionName, string companyCode, string matCode, string unitId, string dataPart, string monthNo, int versionNo);
    }
}