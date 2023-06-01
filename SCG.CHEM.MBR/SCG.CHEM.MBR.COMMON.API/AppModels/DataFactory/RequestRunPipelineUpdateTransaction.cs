namespace SCG.CHEM.MBR.COMMON.API.AppModels.DataFactory
{
    public class RequestRunPipelineUpdateMarketPrice
    {
        public string tableName { get; set; }
        public string cycleName { get; set; }
        public string caseName { get; set; }
        public string planTypeName { get; set; }
        //public string transactionName { get; set; }

        public RequestRunPipelineUpdateMarketPrice(string tableName, string cycleName, string caseName, string planTypeName)
        {
            this.tableName = tableName;
            this.caseName = caseName;
            this.cycleName = cycleName;
            this.planTypeName = planTypeName;
            //this.transactionName = transactionName;
        }
    }

    public class RequestRunPipelineUpdateOptience
    {
        public string tableName { get; set; }
        public string cycleName { get; set; }
        public string caseName { get; set; }
        public string planTypeName { get; set; }
        //public List<string> company { get; set; }

        public string company { get; set; }
        //public string transactionName { get; set; }

        public RequestRunPipelineUpdateOptience(string tableName, string cycleName, string caseName, string planTypeName, string company)
        {
            this.tableName = tableName;
            this.caseName = caseName;
            this.cycleName = cycleName;
            this.planTypeName = planTypeName;
            this.company = company;
        }
    }
}