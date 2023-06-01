using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;

namespace SCG.CHEM.MBR.MASTER.API.AppModels.Master
{
    public class MasterDownloadResponse
    {
        public int MasterId { get; set; }

        public object? MasterData { get; set; }

        public List<MBR_MST_MASTER_MAPPING> MasterMapping { get; set; }

        public List<MBR_MST_MASTER> Master { get; set; }
    }
}