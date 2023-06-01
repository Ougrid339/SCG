using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempRawMatGapRepo : IRepositoryBase<SSP_TMP_RAW_MAT_GAP>
    {
        List<SSP_TMP_RAW_MAT_GAP> GetByKey(string productionSite, string planType, string company, string matCode, string startMonth);

        void Truncate();
    }
}