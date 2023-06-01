using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master
{
    public class FreigthCodeAndSubRegionModel
    {
        public List<FreightMasterSheet> FreightCode { get; set; }
        public List<FreightSubRegionMasterSheet> SubRegion { get; set; }
    }
}