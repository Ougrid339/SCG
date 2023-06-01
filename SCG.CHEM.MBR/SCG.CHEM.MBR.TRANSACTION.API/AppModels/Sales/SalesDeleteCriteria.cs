using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.DataFactory;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.Sales
{
    public class SalesDeleteCriteria
    {

        public string Cycle { get; set; }

        public string Case { get; set; }

        public List<string>? Company { get; set; }

        public List<string>? ProductGroup { get; set; }

        public List<string>? Product { get; set; }

        public List<string>? Channel { get; set; }

        public SalesDeleteCriteria(string? cycle, string? @case, string? company, string? productGroup, string? product, string? channel)
        {
            Cycle = cycle ?? "";
            Case = @case ?? "";
            Company = String.IsNullOrEmpty(company) ? null : company.SplitToList(",");
            ProductGroup = String.IsNullOrEmpty(productGroup) ? null : productGroup.SplitToList(",");
            Product = String.IsNullOrEmpty(product) ? null : product.SplitToList(",");
            Channel = String.IsNullOrEmpty(channel) ? null : channel.SplitToList(",");
        }

        public SalesDeleteCriteria(RequestDataFactoryRunIdStatus req)
        {
            Cycle = req.cycleName ?? "";
            Case = req.caseName ?? "";
            Company = String.IsNullOrEmpty(req.company) ? null : req.company.SplitToList(",");
            ProductGroup = String.IsNullOrEmpty(req.productGroup) ? null : req.productGroup.SplitToList(",");
            Product = String.IsNullOrEmpty(req.product) ? null : req.product.SplitToList(",");
            Channel = String.IsNullOrEmpty(req.channel) ? null : req.channel.SplitToList(",");
        }
    }
}
