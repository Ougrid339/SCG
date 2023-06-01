namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast
{
    public class MarketPriceForecastPreviewResponse
    {
        public string MarketSource { get; set; }
        public string Unit { get; set; }
        public string? EBACode { get; set; }
        public List<HeaderListPreview>? HeaderList { get; set; }
    }

    public class HeaderListPreview
    {
        public string Cycle { get; set; }
        public string MonthNo { get; set; }
        public string Header { get; set; }
        public decimal? Value { get; set; }
    }
}