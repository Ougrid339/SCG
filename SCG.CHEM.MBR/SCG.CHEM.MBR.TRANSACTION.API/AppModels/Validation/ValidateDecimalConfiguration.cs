namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.Validation
{
    public class ValidateDecimalConfiguration
    {
        public string PropertyName { get; set; }

        public bool IsRequired { get; set; }

        public ValidateDecimalConfiguration(string propertyName, bool isRequired = false)
        {
            PropertyName = propertyName;
            IsRequired = isRequired;
        }
    }
}
