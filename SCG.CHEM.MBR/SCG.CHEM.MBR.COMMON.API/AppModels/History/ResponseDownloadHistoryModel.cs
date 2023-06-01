using Newtonsoft.Json.Linq;

namespace SCG.CHEM.MBR.COMMON.API.AppModels.History
{
    public class ResponseDownloadHistoryModel
    {
        public long? InterfaceId { get; set; }
        public object? UploadedData { get; set; }
        public object? ExcelMapping { get; set; }
        public bool? IsValidationSuccess { get; set; }
        public string? TypeName { get; set; }
        public int? TypeId { get; set; }
        public string? ServicePath { get; set; }
        public string? ErrorMessage { get; set; }
        public int? Status { get; set; }
        public DateTime? InboundDate { get; set; }
    }
}