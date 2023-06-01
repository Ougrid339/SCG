using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Common;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.MBR.MASTER.API.AppModels.Validation
{
    public class ProductMappingValidationModel : CommonValidationModel
    {
        public string ProductShortName { get; set; }
        //public string MatPrefix { get; set; }
        //public string Grade { get; set; }
        //public string Package { get; set; }
        //public string MatClass { get; set; } = APPCONSTANT.MATERIAL.POSTFIX.OTHER;
    }
}