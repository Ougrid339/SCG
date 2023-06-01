namespace SCG.CHEM.MBR.MASTER.API.AppModels.DataFactory
{
    public class RequestCreateRunPipeline
    {
        public string masterName { get; set; }
        public string tableName { get; set; }

        public RequestCreateRunPipeline(string masterName, string table)
        {
            this.masterName = masterName;
            this.tableName = table;
        }
    }
}