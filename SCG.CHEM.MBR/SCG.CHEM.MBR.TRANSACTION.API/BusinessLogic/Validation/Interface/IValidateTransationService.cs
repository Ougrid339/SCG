using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services.Validation.Interface
{
    public interface IValidateTransationService : IBaseService
    {
        DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel> ValidateMarketPriceForecast(DataWithMarketPriceForecastModel<MarketPriceForecastCriteriaModel, ValidateMarketPriceForecastModel> data);
    }
}