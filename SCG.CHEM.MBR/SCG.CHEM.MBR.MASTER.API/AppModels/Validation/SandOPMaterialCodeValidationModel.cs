using SCG.CHEM.MBR.MASTER.API.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS;

namespace SCG.CHEM.MBR.MASTER.API.AppModels.Validation
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