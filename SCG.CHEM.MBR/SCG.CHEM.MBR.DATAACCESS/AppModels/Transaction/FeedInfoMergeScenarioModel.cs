using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction
{
    public class FeedInfoMergeScenarioModel
    {
        public List<FeedInfoMergeScenario> Available { get; set; }
    }
    public class FeedInfoMergeScenario
    {
        public string Scenario { get; set; }
        public string Case { get; set; }
        public string Cycle { get; set; }
    }
}
