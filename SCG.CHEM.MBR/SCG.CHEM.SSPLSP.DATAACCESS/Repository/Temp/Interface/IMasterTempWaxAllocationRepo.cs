using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempWaxAllocationRepo : IRepositoryBase<SSP_TMP_WAX_ALLOCATION>
    {
        List<SSP_TMP_WAX_ALLOCATION> GetByKey(string planType, string waxGroupId, string fromProductionLine, string toProductionLine, string startMonth);

        public void Truncate();
    }
}