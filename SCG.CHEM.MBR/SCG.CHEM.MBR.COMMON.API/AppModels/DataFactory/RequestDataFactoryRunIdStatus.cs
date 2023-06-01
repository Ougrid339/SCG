namespace SCG.CHEM.MBR.COMMON.API.AppModels.DataFactory
{
    public class RequestDataFactoryRunIdStatus
    {
        public string RunId { get; set; }
        public string? status { get; set; }
        public string? ErrorMsg { get; set; }
        public string? tableName { get; set; }
        public string? cycleName { get; set; }
        public string? caseName { get; set; }
        public string? planTypeName { get; set; }
        public string? company { get; set; }
        public string? feedGeoCategoryKey { get; set; }
        public string? feedNameKey { get; set; }
        public string? productGroup { get; set; }
    }
}