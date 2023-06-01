namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo
{
    public class FeedInfoDownloadRequest
    {
        public string PlaneType { get; set; }
        public string Case { get; set; }
        public List<string> Cycle { get; set; }
        public List<string> Company { get; set; }
        public List<string> FeedNameKey { get; set; }
        public List<string> FeedGeoCategoryKey { get; set; }
        public List<string> ProductGroup { get; set; }
    }
}
