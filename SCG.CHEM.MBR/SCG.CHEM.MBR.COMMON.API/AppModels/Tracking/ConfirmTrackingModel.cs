namespace SCG.CHEM.MBR.COMMON.API.AppModels.Tracking
{
    public class ConfirmTrackingModel
    {
        public string PlanType { get; set; }
        public string Cycle { get; set; }
        public string Case { get; set; }
        public int Type { get; set; }
        public string? ProductGroup { get; set; }
        public Guid? WebUUID { get; set; }
    }
}