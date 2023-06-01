using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.MASTER.API.AppModels.Master;
using SCG.CHEM.MBR.MASTER.API.AppModels.Account;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services;
using SCG.CHEM.MBR.DATAACCESS.Entities.Views.Master;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master.Interface
{
    public interface IDownloadService : IBaseService
    {
        Dictionary<int, List<Object>> DownloadMasters(RequestDownloadModel requestDownloadModel);

        public Dictionary<string, List<Object>> DownloadAccountReports(RequestAccountDownloadModel requestDownload);

        public List<MasterDownloadResponse> DownloadMasters(MasterDownloadRequest req);
    }
}