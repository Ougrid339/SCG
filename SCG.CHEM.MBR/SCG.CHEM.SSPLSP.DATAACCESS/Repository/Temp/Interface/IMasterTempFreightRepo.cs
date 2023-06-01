using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempFreightRepo : IRepositoryBase<SSP_TMP_FREIGHT>
    {
        List<SSP_TMP_FREIGHT> GetByKey(string productionSite, string regionCode, string planType, string startMonth);

        void Truncate();
    }
}