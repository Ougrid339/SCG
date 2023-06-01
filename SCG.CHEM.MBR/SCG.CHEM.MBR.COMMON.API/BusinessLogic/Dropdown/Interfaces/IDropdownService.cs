using SCG.CHEM.MBR.COMMON.API.AppModels.HistoryType;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.Services;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;

namespace SCG.CHEM.MBR.COMMON.API.BusinessLogic.Dropdown.Interfaces
{
    public interface IDropdownService : IBaseService
    {
        List<DropdownModel> GetCase();
        List<DropdownModel> GetScenario();
        List<DropdownModel> GetScenarioWithActual();
        MarketPriceForecastMergeScenarioModel GetMergeScenarioMarketPriceForecast();
        OptienceMergeScenarioModel GetMergeScenarioOptience();
        FeedInfoMergeScenarioModel GetMergeScenarioFeedInfo();
        SalesMergeScenarioModel GetMergeScenarioSales();
        List<DropdownModel> GetOptienceType();
        List<DropdownModel> GetOptienceTypeByToken();
        List<DropdownModel> GetCompany();
        List<DropdownModel> GetCompanyByToken();
        List<DropdownModel> GetHistoryGroup();
        List<HistoryTypeResponse> GetHistoryType();
        List<DropdownModel> GetFeedNameKey();
        List<DropdownModel> GetProductGroup();
        List<DropdownModel> GetProduct();
        List<DropdownModel> GetFeedGeoCategoryKey();
        List<DropdownModel> GetChannel();
        List<DropdownModel> GetUserAD();
    }
}
