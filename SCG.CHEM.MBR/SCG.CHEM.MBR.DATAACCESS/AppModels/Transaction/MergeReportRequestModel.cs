using System.ComponentModel.DataAnnotations;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction
{
    public class MergeReportRequestModel
    {
        [Required]
        public string Scenario { get; set; }
        [Required]
        public string Case { get; set; }
        [Required]
        public string Cycle { get; set; }
        [Required]
        public bool IsMerge { get; set; } = false;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public string? MergeScenario { get; set; }
        public string? MergeCase { get; set; }
        public string? MergeCycle { get; set; }
    }
}
