namespace SCG.CHEM.MBR.MASTER.API.AppModels.Maintain
{
    public class RequestMaintainMapping
    {
        public string variable { get; set; }
        public string? excelheader { get; set; }
        public bool? required { get; set; }
    }

    public class RequestMaintainModel
    {
        public int masterId { get; set; }
        public string sheetName { get; set; }

        public List<RequestMaintainMapping>? mapping { get; set; }
        public List<RequestMaintainMapping>? exportmapping { get; set; }
    }
}