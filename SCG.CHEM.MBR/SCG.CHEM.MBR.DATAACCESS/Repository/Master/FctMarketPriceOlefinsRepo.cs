using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class FctMarketPriceOlefinsRepo : RepositoryBase<MBR_FCT_MARKETPRICEOLEFINS>, IFctMarketPriceOlefinsRepo
    {
        public FctMarketPriceOlefinsRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public Dictionary<MRB_TRN_FEED_INFO, MBR_FCT_MARKETPRICEOLEFINS> GetFctMarketPriceOlefinsByFeedInfo(List<MRB_TRN_FEED_INFO> mNegative, List<MBR_MST_MARKET_PRICE_MAPPING> marketPriceName)
        {
            Dictionary<MRB_TRN_FEED_INFO, MBR_FCT_MARKETPRICEOLEFINS> response = new Dictionary<MRB_TRN_FEED_INFO, MBR_FCT_MARKETPRICEOLEFINS>();
            var enumData = _readContext.MBR_FCT_MARKETPRICEOLEFINs.Where(w => !string.IsNullOrEmpty(w.ProductWeb)
                                                                   && marketPriceName.Select(s => s.MarketPriceName.ToUpper()).Contains(w.ProductWeb.ToUpper())

                                                                   && w.Scenario.ToUpper() == "MONTHLY").ToList();

            foreach (var item in mNegative)
            {
                var month = int.Parse(item.MonthIndex.Substring(1)) + int.Parse(item.PricingRefKey.Substring(1));

                var cycle = item.Cycle.Substring(item.Cycle.IndexOf("_") + 1);
                var date = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                date = date.AddMonths(month);
                var prict = marketPriceName.FirstOrDefault(f => f.MarketPriceMI == item.PricingIndexKey);
                var pricingMonth = enumData.FirstOrDefault(w => w.ProductWeb == prict.MarketPriceName && date.Year.ToString() + date.Month.ToString("00") == w.PricingMonth);
                response.Add(item, pricingMonth);
            }

            return response;
        }

        public List<MBR_FCT_MARKETPRICEOLEFINS> GetFctMarketPriceOlefinsByMarketPriceName(List<string?> marketPriceNames)
        {
            return _readContext.MBR_FCT_MARKETPRICEOLEFINs.Where(w => !string.IsNullOrEmpty(w.ProductWeb) && marketPriceNames.Select(s => s.ToLower()).Contains(w.ProductWeb.ToLower())).ToList();
        }

        public List<MBR_FCT_MARKETPRICEOLEFINS> GetMergeReportData(MergeReportRequestModel criteria)
        {
            //var a = _readContext.MBR_FCT_MARKETPRICEOLEFINs.Where(w =>
            //w.Scenario.ToUpper() == MERGE_REPORT.MONTHLY
            //&& Convert.ToInt32(w.PricingYear) >= criteria.StartDate.Year
            //&& Convert.ToInt32(w.PricingYear) <= criteria.EndDate.Year
            //).DistinctBy(w => new { w.Product, w.PricingDate }).ToList();
            //var b = _readContext.MBR_FCT_MARKETPRICEOLEFINs.Where(w =>
            //w.Scenario.ToUpper() == MERGE_REPORT.MONTHLY
            //&& Convert.ToInt32(w.PricingYear) >= criteria.StartDate.Year
            //&& Convert.ToInt32(w.PricingYear) <= criteria.EndDate.Year
            //&& !a.Contains(w)).ToList();


            return _readContext.MBR_FCT_MARKETPRICEOLEFINs.Where(w =>
            w.Scenario.ToUpper() == MERGE_REPORT.MONTHLY
            && Convert.ToInt32(w.PricingYear) >= criteria.StartDate.Year
            && Convert.ToInt32(w.PricingYear) <= criteria.EndDate.Year
            ).OrderBy(x => x.Product).ThenBy(x => x.PricingDate).ToList();
        }

        public List<MBR_FCT_MARKETPRICEOLEFINS> GetMTDByProduct(string product)
        {
            var today = DateTime.Today;
            return _readContext.MBR_FCT_MARKETPRICEOLEFINs.Where(w =>
            w.Scenario.ToUpper() == MERGE_REPORT.DAILY
            && w.Product == product
            && w.PricingMonth == today.ToString("yyyyMM")
            ).ToList();
        }

        public List<MBR_FCT_MARKETPRICEOLEFINS> GetLastWeekByProductWeb(string productWeb)
        {
            decimal? result = null;
            var today = DateTime.Today;
            var splitStr = productWeb.Split("_");
            var productWebRp = productWeb.Replace(splitStr.Last(), "W");
            var startDate = new DateTime();
            var endDate = new DateTime();
            int week = 0;
            if (today.DayOfWeek == DayOfWeek.Saturday)
            {
                startDate = ISOWeek.ToDateTime(today.Year, ISOWeek.GetWeekOfYear(today) - 1, DayOfWeek.Sunday);
                endDate = ISOWeek.ToDateTime(today.Year, ISOWeek.GetWeekOfYear(today), DayOfWeek.Saturday);
                week = ISOWeek.GetWeekOfYear(today);
            }
            else
            {
                startDate = ISOWeek.ToDateTime(today.Year, ISOWeek.GetWeekOfYear(today) - 2, DayOfWeek.Sunday);
                endDate = ISOWeek.ToDateTime(today.Year, ISOWeek.GetWeekOfYear(today) - 1, DayOfWeek.Saturday);
                week = ISOWeek.GetWeekOfYear(today) - 1;
            }
            var query = _readContext.MBR_FCT_MARKETPRICEOLEFINs.Where(s =>
                            s.ProductWeb == productWebRp);
            if (!query.Any())
            {
                productWebRp = productWeb.Replace(splitStr.Last(), "WD");
                query = _readContext.MBR_FCT_MARKETPRICEOLEFINs.Where(s =>
                            s.ProductWeb == productWebRp);
            }

            var weekData = query.Where(s => s.PricingWeekNo == string.Format("W{0}", week) && s.PricingYear == today.Year.ToString());
            while (weekData?.Count() == 0 && week >= 0)
            {
                week--;
                weekData = query.Where(s => s.PricingWeekNo == string.Format("W{0}", week) && s.PricingYear == today.Year.ToString());
            }

            return weekData?.ToList();
        }

    }
}
