using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Common;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS;
using System;
using System.Collections.Generic;
using System.Text;
using SCG.CHEM.MBR.MASTER.API.AppModels.Master;

namespace SCG.CHEM.MBR.MASTER.API.AppModels.Validation
{
    public class ProductShortNameValidationModel : CommonValidationModel
    {
        public string ProductShortName { get; set; }
        public string MaterialCode { get; set; }
        public string SourceSystem { get; set; }
        //public string Package { get; set; }
        //public string MatClass { get; set; } = APPCONSTANT.MATERIAL.POSTFIX.OTHER;
    }
}