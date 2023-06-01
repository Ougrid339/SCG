using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.FeedInfo.Interface;
using System.Reflection;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.FeedInfo
{
    public class DowloadFeedInfoService : IDowloadFeedInfoService
    {
        private readonly UnitOfWork _unit;
        private readonly SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork _unitSSP;
        private readonly string userLogin;

        public DowloadFeedInfoService(UnitOfWork unitOfWork, SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork unitSSP)
        {
            this._unit = unitOfWork;
            this._unitSSP = unitSSP;
            this.userLogin = UserUtilities.GetADAccount()?.UserId ?? "";
        }

        public dynamic DownloadFeedInfo(FeedInfoDownloadRequest param)
        {
            var result = new List<FeedInfoDownloadResponse>();

            var feedInfoRepo = _unit.FeedInfoRepo.FindByCriteriasAll(param.PlaneType, param.Case, param.Cycle, param.Company, param.FeedGeoCategoryKey, param.FeedNameKey, param.ProductGroup);

            var mPositive = feedInfoRepo.Where(w => int.Parse(w.MonthIndex.Substring(1)) + int.Parse(w.PricingRefKey.Substring(1)) >= 0).ToList();
            var mNegative = feedInfoRepo.Where(w => int.Parse(w.MonthIndex.Substring(1)) + int.Parse(w.PricingRefKey.Substring(1)) < 0).ToList();
            var FirstOrDefault = feedInfoRepo.FirstOrDefault();

            //cal M +
            var marketPriceRepo = _unit.MarketPriceForecastRepo.FindByFeedInfo(param.PlaneType, param.Case, param.Cycle, mPositive);
            var mopjRepo = _unit.MarketPriceForecastRepo.FindByMOPJ(param.PlaneType, param.Case, param.Cycle, mPositive);

            //cal M-
            List<FeedInfoMarketPriceName> feedInfoMarketPriceNames = new List<FeedInfoMarketPriceName>();
            var marketPriceName = _unit.MasterMarketPriceMappingRepo.GetMarketPriceNameByMarketPriceMI(mNegative.Select(s => s.PricingIndexKey).ToList());
            var marketPriceNameMOPJ = _unit.MasterMarketPriceMappingRepo.GetMarketPriceNameByMarketPriceMI(new List<string>() { "MOPJ" });
            //mi=productweb pricing month
            var olefins = _unit.FctMarketPriceOlefinsRepo.GetFctMarketPriceOlefinsByFeedInfo(mNegative, marketPriceName);
            var olefinsMOPJ = _unit.FctMarketPriceOlefinsRepo.GetFctMarketPriceOlefinsByFeedInfo(mNegative, marketPriceNameMOPJ);

            //ExchangeRate (fx)
            List<DateTime> startMonth = new List<DateTime>();
            foreach (var item in feedInfoRepo)
            {
                var cycle = string.Empty;
                var date = new DateTime();
                var month = int.Parse(item.MonthIndex.Substring(1)) + int.Parse(item.PricingRefKey.Substring(1));
                if (item.PlanType.ToUpper() == SCENATIO.OPPLAN.ToUpper() || item.PlanType.ToUpper() == SCENATIO.MTP.ToUpper())
                {
                    cycle = item.MonthNo;
                    date = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                    date = date.AddMonths(int.Parse(item.PricingRefKey.Substring(1)));
                }
                else
                {
                    cycle = item.Cycle.Substring(item.Cycle.IndexOf("_") + 1);
                    date = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                    date = date.AddMonths(month);
                }

                startMonth.Add(date);
            }
            var fxList = _unitSSP.ViewExchangeRateExportRepo.GetByFirstDate(startMonth);
            foreach (var group in feedInfoRepo)
            {
                var cycle = string.Empty;
                var date = new DateTime();
                var marketPrice = marketPriceRepo.FirstOrDefault(f => f.MarketSource == group.PricingIndexKey && f.MonthIndex == group.PricingRefKey);
                var marketPriceMOPJ = mopjRepo.FirstOrDefault(f => f.MarketSource == group.PricingIndexKey);

                var ole = olefins.FirstOrDefault(f => f.Key == group).Value;
                var oleMOPJ = olefinsMOPJ.FirstOrDefault(f => f.Key == group).Value;
                bool isPositive = mPositive.FirstOrDefault(f => f == group) != null;

                //fx
                var month = int.Parse(group.MonthIndex.Substring(1)) + int.Parse(group.PricingRefKey.Substring(1));
                if (group.PlanType.ToUpper() == SCENATIO.OPPLAN.ToUpper() || group.PlanType.ToUpper() == SCENATIO.MTP.ToUpper())
                {
                    cycle = group.MonthNo;
                    date = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                    date = date.AddMonths(int.Parse(group.PricingRefKey.Substring(1)));
                }
                else
                {
                    cycle = group.Cycle.Substring(group.Cycle.IndexOf("_") + 1);
                    date = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                    date = date.AddMonths(month);
                }
                var prict = marketPriceName.FirstOrDefault(f => f.MarketPriceMI == group.PricingIndexKey);
                var fx = fxList.Where(f => f.FirstDate.Value.Date == date.Date)
                                .FirstOrDefault()
                                ?.ExchangeRate;

                group.MonthNo = group.MonthNo.Replace("-", "");
                var mapData = new FeedInfoDownloadResponse(group, marketPrice, isPositive, marketPriceMOPJ, ole, oleMOPJ, fx);

                result.Add(mapData);
            }
            if (param.PlaneType == SCENATIO.ACTUAL)
            {
                var response = new List<FeedInfoActualDownloadResponse>();
                foreach (var item in param.Cycle)
                {
                    var actual = new List<FeedInfoDownloadResponse>();
                    actual.AddRange(result.Where(w => w.Cycle == item).ToList());
                    response.Add(new FeedInfoActualDownloadResponse()
                    {
                        Cycle = item,
                        data = actual
                    });
                }
                return response;
            }

            return result;
        }
    }
}