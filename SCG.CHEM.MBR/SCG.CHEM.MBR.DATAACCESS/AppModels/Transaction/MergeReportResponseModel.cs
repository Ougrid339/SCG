using System.ComponentModel.DataAnnotations;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction
{
    public class MergeReportResponseModel
    {
        public string Scenario { get; set; }
        public string Cycle { get; set; }
        public string Case { get; set; }
        public string? MergeScenario { get; set; }
        public string? MergeCycle { get; set; }
        public string? MergeCase { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<TableItem> Table { get; set; }

    }

    public class TableItem
    {
        public int RowNo { get; set; }
        public List<Column> Column { get; set; }
    }

    public class Column
    {
        public int ColNo { get; set; }
        public string Header { get; set; }
        public string Remark { get; set; }
        public object? Value { get; set; }
    }
}
