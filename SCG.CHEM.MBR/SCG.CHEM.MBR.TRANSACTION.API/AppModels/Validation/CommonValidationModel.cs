using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Common;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.Master
{
    public class CommonValidationModel
    {
        public int? Id { get; set; } = -1;
        public List<string> Message { get; set; } = new List<string>();
    }
}