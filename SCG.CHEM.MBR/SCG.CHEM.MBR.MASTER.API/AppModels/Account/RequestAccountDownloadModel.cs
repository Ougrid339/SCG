namespace SCG.CHEM.MBR.MASTER.API.AppModels.Account
{
    public class RequestAccountDownloadModel
    {
        public List<string>? plantypes { get; set; }
        public string? cycle { get; set; }
        public List<string>? types { get; set; }
        public List<string>? planningGroups { get; set; }
        public string? startdate { get; set; }
    }
}