using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction
{
    public class OptienceMergeScenarioModel
    {
        public List<OptienceMergeScenario> Available { get; set; }
    }

    public class OptienceMergeScenario
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string Scenario { get; set; }
        public string Case { get; set; }
        public string Cycle { get; set; }
    }
}
