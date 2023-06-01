using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Repository.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Sales;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MarketPriceForecast.Interface;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Sales.Interface;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Sales
{
    public class DownloadSalesService : IDownloadSalesService
    {
        private readonly UnitOfWork _unit;
        private readonly SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork _unitSSP;
        private readonly string userLogin;
        private readonly IDownloadMarketPriceForecastService _marketPriceForecastService;

        public DownloadSalesService(UnitOfWork unitOfWork, SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork unitSSP, IDownloadMarketPriceForecastService marketPriceForecastService)
        {
            this._unit = unitOfWork;
            this._unitSSP = unitSSP;
            this.userLogin = UserUtilities.GetADAccount()?.UserId ?? "";
            this._marketPriceForecastService = marketPriceForecastService;
        }

        public SalesResponse DownloadSales(SalesDownloadRequest param)
        {
            var result = new SalesResponse();
            var resSales = new List<SalesDownloadResponse>();
            var reqMarketPriceForecast = new MarketPriceForecastDownloadRequest();
            reqMarketPriceForecast.Scenario = param.PlaneType;
            reqMarketPriceForecast.Case = param.Case;
            reqMarketPriceForecast.Cycle = param.Cycle;
            var feedInfoRepo = _unit.SalesVoiumeRepo.FindByCriterias(param.Cycle, param.Case, param.Company, param.Product, param.ProductGroup, param.Channel);
            foreach (var group in feedInfoRepo)
            {
                group.MonthNo = group.MonthNo.Replace("-", "");
                var mapData = new SalesDownloadResponse(group);
                resSales.Add(mapData);
            }
            var resMarketPriceForecast = _marketPriceForecastService.DownloadMarketPriceForecast(reqMarketPriceForecast);
            result.SalesDownloadResponse = resSales;
            result.MarketPriceForecastDownloadResponse = resMarketPriceForecast;

            return result;
        }
    }
}