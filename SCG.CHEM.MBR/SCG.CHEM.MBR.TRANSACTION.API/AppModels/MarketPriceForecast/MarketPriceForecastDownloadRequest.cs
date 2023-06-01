using System.ComponentModel.DataAnnotations;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast
{
    public class MarketPriceForecastDownloadRequest
    {
        [Required]
        public string Scenario { get; set; }
        [Required]
        public string Case { get; set; }
        [Required]
        public string Cycle { get; set; }
    }
}
