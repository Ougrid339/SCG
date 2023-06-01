using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Common;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast
{
    public class DataWithMarketPriceForecastModel<T1, T2>
    {
        [Required]
        public T1 Criteria { get; set; }

        [Required]
        public List<T2> Data { get; set; } = new List<T2>();

        public List<T2> DataWarnning { get; set; } = new List<T2>();

        public long InterfaceId { get; set; }
    }
}