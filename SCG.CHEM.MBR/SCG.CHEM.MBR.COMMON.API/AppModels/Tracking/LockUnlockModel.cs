namespace SCG.CHEM.MBR.COMMON.API.AppModels.Tracking
{
    public class LockUnlockModel
    {
        public string Scenario { get; set; }
        public string Cycle { get; set; }
        public string Case { get; set; }
        public bool Islock { get; set; } = false;
    }
}