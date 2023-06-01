using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Logging.Interface
{
    public interface ILogSendDWHRepo : IRepositoryBase<LOG_SEND_DWH>
    {
        LOG_SEND_DWH FindbyId(long id);
    }
}