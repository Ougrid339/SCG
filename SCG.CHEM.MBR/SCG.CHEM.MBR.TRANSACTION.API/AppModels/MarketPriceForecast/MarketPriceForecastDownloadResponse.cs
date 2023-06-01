namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast
{
    public class MarketPriceForecastDownloadResponse
    {
        public string MarketSource { get; set; }
        public string Unit { get; set; }
        public string? EBACode { get; set; }
        public List<HeaderList>? HeaderList { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }

    public class HeaderList
    {
        public string Cycle { get; set; }
        public string MonthNo { get; set; }
        public string Header { get; set; }
        public decimal? Value { get; set; }
    }

    public class MarketPriceForecastSetMonthIndex
    {
        public decimal? M0 { get; set; }
        public decimal? M1 { get; set; }
        public decimal? M2 { get; set; }
        public decimal? M3 { get; set; }
        public decimal? M4 { get; set; }
        public decimal? M5 { get; set; }
        public decimal? M6 { get; set; }
        public decimal? M7 { get; set; }
        public decimal? M8 { get; set; }
        public decimal? M9 { get; set; }
        public decimal? M10 { get; set; }
        public decimal? M11 { get; set; }
        public decimal? M12 { get; set; }
        public decimal? M13 { get; set; }
        public decimal? M14 { get; set; }
        public decimal? M15 { get; set; }
        public decimal? M16 { get; set; }
        public decimal? M17 { get; set; }
        public decimal? M18 { get; set; }
    }
}