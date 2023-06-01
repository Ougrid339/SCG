namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.DataFactory
{
    public class RequestRunPipelineDelTransaction
    {
        public string tableName { get; set; }
        public string cycleName { get; set; }
        public string caseName { get; set; }
        public string planTypeName { get; set; }
        public string? company { get; set; }
        public string? feedGeoCategoryKey { get; set; }
        public string? feedNameKey { get; set; }
        public string? productGroup { get; set; }
        public string submitStatus { get; set; }

        public RequestRunPipelineDelTransaction(string tableName, RequestCriteriaTransaction param, string submitStatus)
        {
            this.tableName = tableName;
            this.caseName = param.Case;
            this.cycleName = param.Cycle;
            this.planTypeName = param.PlaneType;
            this.company = param.Company;
            this.feedGeoCategoryKey = param.FeedGeoCategoryKey;
            this.feedNameKey = param.FeedNameKey;
            this.productGroup = param.ProductGroup;
            this.submitStatus = submitStatus;
        }
    }
}