using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;

namespace SCG.CHEM.MBR.COMMON.API.AppModels.Tracking
{
    public class SearchTrackingResModel
    {
        public string Name { get; set; }
        public List<TrackingModel> Data { get; set; }
    }

    public class TrackingModel
    {
        public string Detail { get; set; }
        public string UploadStatus { get; set; }
        public string ValidateStatus { get; set; }
        public DateTime? Updateddate { get; set; }
        public string? UpdatedBy { get; set; }
        public int? Type { get; set; }
        public int ExcelId { get; set; }
        public string? ProductGroup { get; set; }
        public List<PriceList>? NotEq { get; set; }
    }
}