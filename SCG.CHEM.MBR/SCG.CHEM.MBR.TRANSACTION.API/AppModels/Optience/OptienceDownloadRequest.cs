using System.ComponentModel.DataAnnotations;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.Optience
{
    public class OptienceDownloadRequest
    {
        [Required]
        public List<int> OptienceTypeId { get; set; }
        [Required]
        public string Scenario { get; set; }
        [Required]
        public string Cycle { get; set; }
        [Required]
        public string Case { get; set; }
        [Required]
        public List<string> Company { get; set; }
    }
}
