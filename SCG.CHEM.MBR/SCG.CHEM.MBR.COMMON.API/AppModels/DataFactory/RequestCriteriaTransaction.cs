namespace SCG.CHEM.MBR.COMMON.API.AppModels.DataFactory
{
    public class RequestCriteriaTransaction
    {
        public string PlaneType { get; set; }
        public string Case { get; set; }
        public string Cycle { get; set; }
        public string? Company { get; set; }
        public string? FeedGeoCategoryKey { get; set; }
        public string? FeedNameKey { get; set; }
        public string? ProductGroup { get; set; }
    }
}