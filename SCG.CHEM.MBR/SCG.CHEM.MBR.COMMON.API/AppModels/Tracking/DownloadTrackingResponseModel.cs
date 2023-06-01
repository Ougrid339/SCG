namespace SCG.CHEM.MBR.COMMON.API.AppModels.Tracking
{
    public class DownloadTrackingResponseModel
    {
        public string Company { get; set; }
        public string MCSC { get; set; }
        public string MaterialCode { get; set; }
        public string ProductionVolume { get; set; }
        public string SaleVolume { get; set; }
        public string Diff { get; set; }
    }
}
