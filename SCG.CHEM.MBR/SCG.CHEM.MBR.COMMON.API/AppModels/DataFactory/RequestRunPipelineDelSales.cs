namespace SCG.CHEM.MBR.COMMON.API.AppModels.DataFactory
{
    // This class uses lowercase property names
    // to be correctly converted to json
    public class RequestRunPipelineDelSales
    {
        public string tableName { get; set; }

        public string caseName { get; set; }

        public string cycleName { get; set; }

        public string company { get; set; }

        public string channel { get; set; }

        public string product { get; set; }

        public string productGroup { get; set; }

        public string submitStatus { get; set; }

        public string runid { get; set; }

        public RequestRunPipelineDelSales(string tableName, RequestCriteriaSales param, string submitStatus, string runId = "")
        {
            this.tableName = tableName;
            this.caseName = param.caseName;
            this.cycleName = param.cycleName;
            this.submitStatus = submitStatus;
            this.productGroup = param.productGroup;
            this.product = param.product;
            this.channel = param.channel;
            this.company = param.company;
            this.runid = runId;
        }
    }
}