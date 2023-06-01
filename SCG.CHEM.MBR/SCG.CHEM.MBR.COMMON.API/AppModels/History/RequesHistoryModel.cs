namespace SCG.CHEM.MBR.COMMON.API.AppModels.History
{
    public class RequesHistoryModel
    {
        public int GroupData { get; set; }
        public List<int>? Type { get; set; }
        public List<string>? Scenario { get; set; }
        public List<string>? Cycle { get; set; }
        public List<string>? UserAD { get; set; }
        public List<string>? Case { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }
}