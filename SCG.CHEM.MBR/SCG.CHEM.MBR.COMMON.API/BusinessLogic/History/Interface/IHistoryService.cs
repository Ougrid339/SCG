using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.DATAACCESS.Entities.Logging;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.Services;
using SCG.CHEM.MBR.COMMON.API.AppModels.History;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;

namespace SCG.CHEM.MBR.COMMON.API.BusinessLogic.History.Interface
{
    public interface IHistoryService : IBaseService
    {
        List<ReponseHistoryModel> GetHistory(RequesHistoryModel data);

        ResponseDownloadHistoryModel DownloadHistory(RequestDownloadHistoryModel data);

        List<DropdownModel> GetHistoryType();
    }
}