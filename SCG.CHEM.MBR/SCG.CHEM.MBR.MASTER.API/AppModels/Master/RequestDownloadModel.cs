using Microsoft.AspNetCore.Mvc;

namespace SCG.CHEM.MBR.MASTER.API.AppModels.Master
{
    public class RequestDownloadModel
    {
        public List<string>? plantypes { get; set; }

        public string mode { get; set; }

        public string? cycle { get; set; }

        public List<int> masters { get; set; }

        public string? startdate { get; set; }
    }
}