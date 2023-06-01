namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.Optience
{
    public class OptiencePreviewResponse
    {
        public List<FeedPurchasePreviewModel> FeedPurchaseData;
        public List<FeedConsumptionPreviewModel> FeedConsumptionData;
        public List<ProductionVolumePreviewModel> ProductionVolumeData;
        public List<BeginningInventoryPreviewModel> BeginningInventoryData;
    }

    public class FeedPurchasePreviewModel
    {
        public string Company { get; set; }
        public string MCSC { get; set; }
        public string FeedName { get; set; }
        public string FeedShortName { get; set; }
        public string SupplierKey { get; set; }
        public string SupplierCode { get; set; }
        public string? ElementCode { get; set; }
        public string MaterialCode { get; set; }
        public List<HeaderListItem> HeaderList { get; set; }
        //public decimal? M0 { get; set; }
        //public decimal? M1 { get; set; }
        //public decimal? M2 { get; set; }
        //public decimal? M3 { get; set; }
        //public decimal? M4 { get; set; }
        //public decimal? M5 { get; set; }
        //public decimal? M6 { get; set; }
        //public decimal? M7 { get; set; }
        //public decimal? M8 { get; set; }
        //public decimal? M9 { get; set; }
        //public decimal? M10 { get; set; }
        //public decimal? M11 { get; set; }
        //public decimal? M12 { get; set; }
        //public decimal? M13 { get; set; }
        //public decimal? M14 { get; set; }
        //public decimal? M15 { get; set; }
        //public decimal? M16 { get; set; }
        //public decimal? M17 { get; set; }
        //public decimal? M18 { get; set; }
    }

    public class FeedConsumptionPreviewModel
    {
        public string Company { get; set; }
        public string MCSC { get; set; }
        public string FeedName { get; set; }
        public string FeedShortName { get; set; }
        public string SupplierKey { get; set; }
        public string SupplierCode { get; set; }
        public string? ElementCode { get; set; }
        public string MaterialCode { get; set; }
        public List<HeaderListItem> HeaderList { get; set; }
        //public decimal? M0 { get; set; }
        //public decimal? M1 { get; set; }
        //public decimal? M2 { get; set; }
        //public decimal? M3 { get; set; }
        //public decimal? M4 { get; set; }
        //public decimal? M5 { get; set; }
        //public decimal? M6 { get; set; }
        //public decimal? M7 { get; set; }
        //public decimal? M8 { get; set; }
        //public decimal? M9 { get; set; }
        //public decimal? M10 { get; set; }
        //public decimal? M11 { get; set; }
        //public decimal? M12 { get; set; }
        //public decimal? M13 { get; set; }
        //public decimal? M14 { get; set; }
        //public decimal? M15 { get; set; }
        //public decimal? M16 { get; set; }
        //public decimal? M17 { get; set; }
        //public decimal? M18 { get; set; }
    }

    public class ProductionVolumePreviewModel
    {
        public string Company { get; set; }
        public string MCSC { get; set; }
        public string ProductName { get; set; }
        public string ProductShortName { get; set; }
        public string MaterialCode { get; set; }
        public string? ElementCode { get; set; }
        public List<HeaderListItem> HeaderList { get; set; }
        //public decimal? M0 { get; set; }
        //public decimal? M1 { get; set; }
        //public decimal? M2 { get; set; }
        //public decimal? M3 { get; set; }
        //public decimal? M4 { get; set; }
        //public decimal? M5 { get; set; }
        //public decimal? M6 { get; set; }
        //public decimal? M7 { get; set; }
        //public decimal? M8 { get; set; }
        //public decimal? M9 { get; set; }
        //public decimal? M10 { get; set; }
        //public decimal? M11 { get; set; }
        //public decimal? M12 { get; set; }
        //public decimal? M13 { get; set; }
        //public decimal? M14 { get; set; }
        //public decimal? M15 { get; set; }
        //public decimal? M16 { get; set; }
        //public decimal? M17 { get; set; }
        //public decimal? M18 { get; set; }
    }

    public class BeginningInventoryPreviewModel
    {
        public string Company { get; set; }
        public string MCSC { get; set; }
        public string? InventoryName { get; set; }
        public string? TankNumber { get; set; }
        public string ProductShortName { get; set; }
        public string MaterialCode { get; set; }
        public string SupplierKey { get; set; }
        public string SupplierCode { get; set; }
        public string? ElementCode { get; set; }
        public List<HeaderListItem> HeaderList { get; set; }
        //public decimal? M0 { get; set; }
    }
}