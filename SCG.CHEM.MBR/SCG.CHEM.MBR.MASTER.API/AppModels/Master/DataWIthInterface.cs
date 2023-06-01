namespace SCG.CHEM.MBR.MASTER.API.AppModels.Master
{
    public class DataWIthInterface<T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public long InterfaceId { get; set; }
    }
}