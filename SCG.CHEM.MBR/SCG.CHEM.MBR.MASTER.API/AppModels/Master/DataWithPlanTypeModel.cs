using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Common;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.MBR.MASTER.API.AppModels.Master
{
    public class DataWithPlanTypeModel<T>
    {
        public List<string> PlanType { get; set; } = new List<string>();
        public string Cycle { get; set; }
        public List<T> Data { get; set; } = new List<T>();
        public long InterfaceId { get; set; }
    }
}