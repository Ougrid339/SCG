using System.ComponentModel.DataAnnotations;

namespace SCG.CHEM.MBR.COMMON.API.AppModels.HistoryType
{
    public class HistoryTypeResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? MasterId { get; set; }

        public int? ExcelId { get; set; }

        public string? Description { get; set; }

        public int? Group { get; set; }
    }
}
