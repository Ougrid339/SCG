namespace SCG.CHEM.MBR.COMMON.API.AppModels.History
{
    public class ReponseHistoryModel
    {
        public long? InterfaceId { get; set; }
        public string? ServicePath { get; set; }
        public string Type { get; set; }
        public List<CriteriaHistory> Criteria { get; set; }
        public string UserAD { get; set; }
        public DateTime? Date { get; set; }
        public int? Status { get; set; }
        public object? OutboundMessage { get; set; }
        public object? ErrorMessage { get; set; }
        public bool? IsValidationSuccess { get; set; }
    }

    public class CriteriaHistory
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
}