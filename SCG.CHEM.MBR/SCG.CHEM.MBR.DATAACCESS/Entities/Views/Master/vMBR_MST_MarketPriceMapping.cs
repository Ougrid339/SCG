using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Views.Master
{
    public class vMBR_MST_MarketPriceMapping
    {
        public string MarketPriceShortName { get; set; }

        public string MarketPriceMI { get; set; }

        public string MarketPriceWebPricing { get; set; }

        public string MarketPriceName { get; set; }

        public string EBACode { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
    }
}
