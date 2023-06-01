namespace SCG.CHEM.MBR.COMMON.API.AppModels.DataFactory
{
    public class RequestCriteriaSales
    {
        public string PlaneType { get; set; }

        public string caseName { get; set; }

        public string cycleName { get; set; }

        public string company { get; set; }

        public string channel { get; set; }

        public string product { get; set; }

        public string productGroup { get; set; }

        public string? runId { get; set; }

        public RequestCriteriaSales(RequestCriteriaSalesCreateParam param)
        {
            PlaneType = param.PlaneType ?? "";

            caseName = param.Case ?? "";

            cycleName = param.Cycle ?? "";

            this.company = param.Company.Count == 0 ? "" : String.Join(",", param.Company);

            this.channel = param.Channel.Count == 0 ? "" : String.Join(",", param.Channel);

            this.product = param.Product.Count == 0 ? "" : String.Join(",", param.Product);

            this.productGroup = param.ProductGroup.Count == 0 ? "" : String.Join(",", param.ProductGroup);

            this.runId = param.RunId ?? "";
        }
    }

    public class RequestCriteriaSalesCreateParam
    {
        public string? PlaneType { get; set; }

        public string? Case { get; set; }

        public string? Cycle { get; set; }

        public List<string> Company { get; set; }

        public List<string> Channel { get; set; }

        public List<string> Product { get; set; }

        public List<string> ProductGroup { get; set; }

        public string? RunId { get; set; }

        public RequestCriteriaSalesCreateParam()
        {
            Company = new List<string>();

            Channel = new List<string>();

            Product = new List<string>();

            ProductGroup = new List<string>();
        }
    }
}