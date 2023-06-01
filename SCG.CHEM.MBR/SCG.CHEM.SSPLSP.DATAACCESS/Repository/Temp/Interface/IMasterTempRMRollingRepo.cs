using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempRMRollingRepo : IRepositoryBase<SSP_TMP_RM_ROLLING>
    {
        List<SSP_TMP_RM_ROLLING> GetByKey(string planType, string inputM1, string versionName, string companyCode, string matCode, string unitId, string dataPart, string monthNo);

        public void Truncate();
    }
}