namespace SCG.CHEM.MBR.COMMON.API.AppModels.Tracking
{
    public class DownloadTrackingRequestModel
    {
        public int Type { get; set; }
        public string PlanType { get; set; }
        public string Cycle { get; set; }
        public string Case { get; set; }
        public string ProductGroup { get; set; }
    }
}
