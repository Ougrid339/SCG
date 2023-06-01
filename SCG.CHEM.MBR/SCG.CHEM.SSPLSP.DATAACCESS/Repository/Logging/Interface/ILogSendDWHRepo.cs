using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Common;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Logging.Interface
{
    public interface ILogSendDWHRepo : IRepositoryBase<LOG_SEND_DWH>
    {
        LOG_SEND_DWH FindbyId(long id);
    }
}