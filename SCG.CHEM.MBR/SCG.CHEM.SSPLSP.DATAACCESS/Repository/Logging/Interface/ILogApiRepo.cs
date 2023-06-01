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
    public interface ILogApiRepo : IRepositoryBase<LOG_API>
    {
        LOG_API FindbyId(long id);

        IQueryable<HistoryModel> GetHistory();

        IQueryable<HistoryModel> DownloadHistoryByInterfaceId(long interfaceId);
    }
}