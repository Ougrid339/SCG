using System.ComponentModel.DataAnnotations;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo
{
    public class DataWithFeedInfoModel<T1, T2>
    {
        [Required]
        public T1 Criteria { get; set; }

        [Required]
        public List<T2> Data { get; set; } = new List<T2>();

        public List<T2> DataWarnning { get; set; } = new List<T2>();
        public long InterfaceId { get; set; }
    }
}