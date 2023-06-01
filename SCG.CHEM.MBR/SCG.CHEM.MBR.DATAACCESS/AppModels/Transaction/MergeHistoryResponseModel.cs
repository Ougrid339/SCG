using System.ComponentModel.DataAnnotations;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction
{
    public class MergeHistoryResponseModel : MergeHistoryRequestModel
    {
        public int ExcelId { get; set; }
        public bool CanMerge { get; set; } = true;
    }
}
