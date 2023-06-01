using System.ComponentModel.DataAnnotations;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction
{
    public class MergeHistoryRequestModel
    {
        [Required]
        public List<int> ExcelId { get; set; }
        [Required]
        public string Case { get; set; }
        [Required]
        public string Cycle { get; set; }
        [Required]
        public string MergeCase { get; set; }
        [Required]
        public string MergeCycle { get; set; }
        public string? Type { get; set; }
    }
}
