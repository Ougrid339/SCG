using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;

namespace SCG.CHEM.MBR.COMMON.API.AppModels.Tracking
{
    public class SearchTrackingReqModel
    {
        public string PlanType { get; set; }
        public string Cycle { get; set; }
        public string Case { get; set; }
        //public string Rev { get; set; }
    }
}