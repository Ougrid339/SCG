using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction
{
    public class MarketPriceForecastMergeScenarioModel
    {
        public List<MarketPriceForecastMergeScenario> Available { get; set; }
    }

    public class MarketPriceForecastMergeScenario
    {
        public string Scenario { get; set; }
        public string Case { get; set; }
        public string Cycle { get; set; }
        public string MarketSource { get; set; }
    }
}