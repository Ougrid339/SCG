using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempAFPStandardEarnRepo : IRepositoryBase<SSP_TMP_AFP_STANDARD_EARN>
    {
        List<SSP_TMP_AFP_STANDARD_EARN> GetByKey(string planType, string matPrefix, string grade, string productionLine, string startMonth);

        void Truncate();
    }
}