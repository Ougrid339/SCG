using System.ComponentModel.DataAnnotations;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo
{
    public class FeedInfoCopyRequest
    {
        [Required]
        public string PlaneTypeTo { get; set; }
        [Required]
        public string CaseTo { get; set; }
        [Required]
        public string CycleTo { get; set; }
        [Required]
        public string PlaneTypeFrom { get; set; }
        [Required]
        public string CaseFrom { get; set; }
        [Required]
        public string CycleFrom { get; set; }
        [Required]
        public List<string> CompanyFrom { get; set; }
        public List<string> FeedNameKeyFrom { get; set; }
        public List<string> FeedGeoCategoryKeyFrom { get; set; }
        public List<string> ProductGroupFrom { get; set; }
    }

}
