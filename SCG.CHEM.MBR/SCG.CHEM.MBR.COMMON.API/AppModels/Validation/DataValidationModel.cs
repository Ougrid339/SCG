using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Common;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.MBR.COMMON.API.AppModels.Validation
{
    public class DataValidationModel : CommonValidationModel
    {
        public string Data { get; set; }
    }

    public class DecimalValidationModel : CommonValidationModel
    {
        public decimal Data { get; set; }
    }
}