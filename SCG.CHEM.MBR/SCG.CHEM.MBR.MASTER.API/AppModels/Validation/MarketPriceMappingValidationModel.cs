using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Common;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS;
using System;
using System.Collections.Generic;
using System.Text;
using SCG.CHEM.MBR.MASTER.API.AppModels.Master;

namespace SCG.CHEM.MBR.MASTER.API.AppModels.Validation
{
    public class MarketPriceMappingValidationModel : CommonValidationModel
    {
        public string MarketPriceMI { get; set; }
        public string EBACode { get; set; }
        public string MarketPriceWebPricing { get; set; }
    }
}