using SCG.CHEM.SSPLSP.DATAACCESS;

namespace SCG.CHEM.MBR.COMMON.API.AppModels.Validation
{
    public class SandOPMaterialCodeValidationModel : CommonValidationModel
    {
        public string MatPrefix { get; set; }
        public string MainGrade { get; set; }
        public string Package { get; set; }
        public string MatClass { get; set; } = APPCONSTANT.MATERIAL.POSTFIX.OTHER;
        public string plant { get; set; }
        public string ProductionLine { get; set; }
    }
}