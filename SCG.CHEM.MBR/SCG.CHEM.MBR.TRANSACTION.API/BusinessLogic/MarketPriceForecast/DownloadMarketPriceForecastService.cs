using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MarketPriceForecast.Interface;
using System.Reflection;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.MarketPriceForecast
{
    public class DownloadMarketPriceForecastService : IDownloadMarketPriceForecastService
    {
        private readonly UnitOfWork _unit;
        private readonly string userLogin;

        public DownloadMarketPriceForecastService(UnitOfWork unitOfWork)
        {
            this._unit = unitOfWork;
            this.userLogin = UserUtilities.GetADAccount()?.UserId ?? "";
        }

        public List<MarketPriceForecastDownloadResponse> DownloadMarketPriceForecast(MarketPriceForecastDownloadRequest param)
        {
            var result = new List<MarketPriceForecastDownloadResponse>();
            var marketPriceForecastRepo = _unit.MarketPriceForecastRepo.FindByCriteria(param.Scenario, param.Case, param.Cycle);
            var marketSourceGroup = marketPriceForecastRepo.GroupBy(g => g.MarketSource).ToList();
            var marketpriceMapping = _unit.MasterExcelMappingRepo.GetMapping(1, false);
            foreach (var group in marketSourceGroup)
            {
                var mapData = new MarketPriceForecastDownloadResponse();
                var headerLists = new List<HeaderList>();
                foreach (var item in group)
                {
                    var DataLists = new HeaderList();
                    DataLists.Cycle = String.IsNullOrEmpty(item.MergedWithCycle) ? item.Cycle : item.MergedWithCycle;
                    DataLists.MonthNo = item.MonthNo.Replace("-", "");
                    DataLists.Header = item.MonthIndex.ToLower().ToString();
                    DataLists.Value = item.Price;
                    headerLists.Add(DataLists);
                }
                mapData.HeaderList = headerLists;

                var lastUpdate = group.OrderByDescending(b => b.UpdatedDate).FirstOrDefault();

                mapData.MarketSource = lastUpdate.MarketSource;
                mapData.Unit = lastUpdate.Unit;
                mapData.EBACode = lastUpdate.EBACode;
                if (lastUpdate.UpdatedDate != null)
                {
                    mapData.UpdatedBy = lastUpdate.UpdatedBy;
                    mapData.UpdatedDate = lastUpdate.UpdatedDate.HasValue ? lastUpdate?.UpdatedDate : null;
                }
                else
                {
                    var lastCreate = group.OrderByDescending(b => b.CreatedDate).FirstOrDefault();
                    mapData.UpdatedBy = lastCreate.CreatedBy;
                    mapData.UpdatedDate = lastCreate.CreatedDate;
                }
                result.Add(mapData);
            }

            return result;
        }

        /*public List<MarketPriceForecastDownloadResponse> DownloadMarketPriceForecast(MarketPriceForecastDownloadRequest param)
        {
            var result = new List<MarketPriceForecastDownloadResponse>();
            var marketPriceForecastRepo = _unit.MarketPriceForecastRepo.FindByCriteria(param.Scenario, param.Case, param.Cycle);
            var marketSourceGroup = marketPriceForecastRepo.GroupBy(g => g.MarketSource).ToList();
            foreach (var group in marketSourceGroup)
            {
                var mapData = new MarketPriceForecastDownloadResponse();
                foreach (var item in group)
                {
                    PropertyInfo prop = mapData.GetType().GetProperty(item.MonthIndex, BindingFlags.Public | BindingFlags.Instance);
                    if (null != prop && prop.CanWrite)
                    {
                        prop.SetValue(mapData, item.Price, null);
                    }
                }
                var lastUpdate = group.OrderByDescending(b => b.UpdatedDate).FirstOrDefault();

                mapData.MarketSource = lastUpdate.MarketSource;
                mapData.Unit = lastUpdate.Unit;
                if (lastUpdate.UpdatedDate != null)
                {
                    mapData.UpdatedBy = lastUpdate.UpdatedBy;
                    mapData.UpdatedDate = lastUpdate.UpdatedDate.HasValue ? lastUpdate?.UpdatedDate : null;
                }
                else
                {
                    var lastCreate = group.OrderByDescending(b => b.CreatedDate).FirstOrDefault();
                    mapData.UpdatedBy = lastCreate.CreatedBy;
                    mapData.UpdatedDate = lastCreate.CreatedDate;
                }
                result.Add(mapData);
            }

            return result;
        }*/
    }
}