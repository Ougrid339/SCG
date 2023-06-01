namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.Master
{
    public class LockUnlockValidateModel : CommonValidationModel
    {
        public string PlanCategory { get; set; }
        public string PlanType { get; set; }
        public string Cycle { get; set; }
        public string PlanningGroup { get; set; }
        public string SalesGroupCode { get; set; }
    }
}