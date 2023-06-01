namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.Sales
{
    public class SalesDownloadRequest
    {
        public string PlaneType { get; set; }
        public string Case { get; set; }
        public string Cycle { get; set; }
        public List<string> Company { get; set; }
        public List<string>? Product { get; set; }
        public List<string>? ProductGroup { get; set; }
        public List<string>? Channel { get; set; }
    }
}
