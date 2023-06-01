using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.DataFactory
{
    public class RequestDataFactoryRunIdStatus
    {
        // Common datafactory response
        public string RunId { get; set; }
        public string? status { get; set; }
        public string? ErrorMsg { get; set; }

        // Common for all transactions
        public string? tableName { get; set; }
        public string? cycleName { get; set; }
        public string? caseName { get; set; }
        public string? planTypeName { get; set; }
        public string? company { get; set; }

        // For FeedInfo and SalesVolume
        public string? productGroup { get; set; }

        // For FeedInfo only
        public string? feedGeoCategoryKey { get; set; }
        public string? feedNameKey { get; set; }

        // For SalesVolume only
        public string? channel { get; set; }
        public string? submitStatus { get; set; }
        public string? product { get; set; }
    }
}