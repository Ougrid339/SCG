using System.ComponentModel.DataAnnotations;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast
{
    public class MarketPriceForecastCopyRequest
    {
        [Required]
        public string ScenarioTo { get; set; }
        [Required]
        public string CaseTo { get; set; }
        [Required]
        public string CycleTo { get; set; }
        [Required]
        public string ScenarioFrom { get; set; }
        [Required]
        public string CaseFrom { get; set; }
        [Required]
        public string CycleFrom { get; set; }
    }
}
