using SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Optience;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Validation.Interface
{
    public interface IValidateFeedInfoService : IBaseService
    {
        DataWithFeedInfoModel<FeedInfoCriteriaModel, ValidateFeedInfoModel> ValidateFeedInfo(DataWithFeedInfoModel<FeedInfoCriteriaModel, ValidateFeedInfoModel> data);
    }
}
