using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Optience.Interface;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Optience
{
    public class MergeReportService : IMergeReportService
    {
        private readonly UnitOfWork _unit;

        public MergeReportService(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }

        public async Task<MergeReportResponseModel> GetReport(MergeReportRequestModel request)
        {
            var result = new MergeReportResponseModel()
            {
                Case = request.Case,
                Cycle = request.Cycle,
                EndDate = request.EndDate,
                MergeCase = request.MergeCase,
                MergeCycle = request.MergeCycle,
                MergeScenario = request.MergeScenario,
                Scenario = request.Scenario,
                StartDate = request.StartDate
            };

            int rowNo = 1;
            result.Table = new List<TableItem>();
            var actualData = _unit.FctMarketPriceOlefinsRepo.GetMergeReportData(request);
            var foreCastData = _unit.MarketPriceForecastRepo.GetMergeReportData(request);
            var mergeForeCastData = _unit.MarketPriceForecastRepo.GetMergeReportData(new MergeReportRequestModel()
            {
                Scenario = request.MergeScenario,
                StartDate = request.StartDate,
                Case = request.MergeCase,
                Cycle = request.MergeCycle,
                EndDate = request.EndDate
            });
            var productWeb = actualData.Where(p => !string.IsNullOrEmpty(p.ProductWeb)).Select(x => x.ProductWeb).Distinct().ToList();
            foreach (var product in productWeb)
            {
                var cycleDate = Convert.ToDateTime(request.Cycle.Split('_').LastOrDefault());
                var marketSource = _unit.MasterMarketPriceMappingRepo.GetMarketPriceMIByMarketPriceName(product);
                //for test
                //marketSource = "BRENT";
                if (marketSource is not null)
                {
                    var actData = actualData.Where(x => x.ProductWeb == product).OrderBy(c => c.PricingMonth).ToList();
                    var fcData = foreCastData.Where(x => x.MarketSource.ToUpper() == marketSource.MarketPriceMI.ToUpper()).ToList();
                    var row = new TableItem()
                    {
                        RowNo = rowNo,
                    };
                    row.Column = new List<Column>()
                    {
                        new Column()
                        {
                            ColNo = 1,
                            Header = MERGE_REPORT.MARKET_SOURCE,
                            Value = marketSource.MarketPriceMI
                        },
                        new Column()
                        {
                            ColNo = 2,
                            Header = MERGE_REPORT.UNIT,
                            Value = actData.Select(x=>x.Unit).FirstOrDefault() ?? ""
                        }
                    };
                    int colNo = 3;
                    var pricingDate = Convert.ToDateTime(actData.Where(x => Convert.ToDateTime(x.PricingDate) >= request.StartDate.Date && Convert.ToDateTime(x.PricingDate) <= request.EndDate.Date).Select(x => x.PricingDate).FirstOrDefault());
                    var pricingDate2 = Convert.ToDateTime(actData.Where(x => Convert.ToDateTime(x.PricingDate) >= request.StartDate.Date && Convert.ToDateTime(x.PricingDate) <= request.EndDate.Date).Select(x => x.PricingDate).FirstOrDefault());

                    var startMonth = request.StartDate.Date;
                    while (startMonth.Month < pricingDate.Month)
                    {
                        row.Column.Add(
                            new Column()
                            {
                                ColNo = colNo,
                                Header = Convert.ToDateTime(startMonth).ToString("MMM-yy"),
                                Value = null,
                                Remark = MERGE_REPORT.ACT
                            });
                        startMonth = startMonth.AddMonths(1);
                        colNo++;
                    }
                    foreach (var act in actData)
                    {
                        pricingDate = Convert.ToDateTime(act.PricingDate);
                        if (pricingDate.Month >= request.StartDate.Month && pricingDate.Year <= cycleDate.Year && pricingDate <= cycleDate)
                        {
                            string header = Convert.ToDateTime(act.PricingDate).ToString("MMM-yy");
                            if (actData.Count(x => x.PricingDate == act.PricingDate) > 1)
                            {
                                if (!row.Column.Any(x => x.Header == header))
                                {
                                    row.Column.Add(
                                        new Column()
                                        {
                                            ColNo = colNo,
                                            Header = header,
                                            Value = actData.Where(x => x.PricingDate == act.PricingDate).Average(s => s.AvgPrice),
                                            Remark = MERGE_REPORT.ACT
                                        });
                                    colNo++;
                                }
                            }
                            else
                            {
                                row.Column.Add(
                                    new Column()
                                    {
                                        ColNo = colNo,
                                        Header = header,
                                        Value = act.AvgPrice,
                                        Remark = MERGE_REPORT.ACT
                                    });
                                colNo++;
                            }
                        }
                        int actIndex = actData.IndexOf(act) + 1;
                        if (actIndex < actData.Count)
                        {
                            var nextPricingDate = Convert.ToDateTime(actData[actIndex].PricingDate);

                            while ((MonthDifference(nextPricingDate, pricingDate) > 1) && nextPricingDate < cycleDate && pricingDate.Month >= request.StartDate.Month && pricingDate.Month > startMonth.Month)
                            {
                                var tmp = pricingDate.Date;
                                tmp = tmp.AddMonths(1);
                                row.Column.Add(
                                    new Column()
                                    {
                                        ColNo = colNo,
                                        Header = Convert.ToDateTime(tmp).ToString("MMM-yy"),
                                        Value = null,
                                        Remark = MERGE_REPORT.ACT
                                    });
                                pricingDate = tmp.Date;
                                colNo++;
                            }
                            //actIndex++;
                        }
                    }
                    var lastItem = row.Column.LastOrDefault();
                    if (lastItem is not null)
                    {
                        if (string.IsNullOrEmpty(lastItem.Remark))
                        {
                            pricingDate = request.StartDate.Date;
                            row.Column.Add(
                                new Column()
                                {
                                    ColNo = colNo,
                                    Header = Convert.ToDateTime(pricingDate).ToString("MMM-yy"),
                                    Value = null,
                                    Remark = MERGE_REPORT.ACT
                                });
                            colNo++;
                        }
                        else
                        {
                            pricingDate = Convert.ToDateTime(row.Column.Last().Header);
                        }
                    }
                    while (MonthDifference(cycleDate, pricingDate2) > 1 && pricingDate2.Month >= request.StartDate.Month)
                    {
                        var tmp = pricingDate2.Date;
                        tmp = tmp.AddMonths(1);
                        row.Column.Add(
                            new Column()
                            {
                                ColNo = colNo,
                                Header = Convert.ToDateTime(tmp).ToString("MMM-yy"),
                                Value = null,
                                Remark = MERGE_REPORT.ACT
                            });
                        pricingDate2 = tmp.Date;
                        colNo++;
                    }

                    while (cycleDate.Year <= request.EndDate.Year)
                    {
                        if (cycleDate <= request.EndDate)
                        {
                            var monthNo = cycleDate.ToString("yyyy-MM");
                            var monthData = fcData.Where(x => Convert.ToDateTime(x.MonthNo).ToString("yyyy-MM") == monthNo).ToList();
                            var mergeMonthData = mergeForeCastData.Where(x => Convert.ToDateTime(x.MonthNo).ToString("yyyy-MM") == monthNo).ToList();
                            decimal? value = null;
                            if (request.IsMerge)
                            {
                                if (mergeMonthData is not null && mergeMonthData.Count > 0)
                                {
                                    value = mergeMonthData?.Average(x => x.Price);
                                }
                            }
                            else
                            {
                                if (monthData is not null && monthData.Count > 0)
                                {
                                    value = monthData?.Average(x => x.Price);
                                }
                            }
                            row.Column.Add(
                                new Column()
                                {
                                    ColNo = colNo,
                                    Header = cycleDate.ToString("MMM-yy"),
                                    Value = value,
                                    Remark = request.IsMerge ? request.MergeScenario : request.Scenario
                                });
                            colNo++;
                        }

                        cycleDate = cycleDate.AddMonths(1);
                    }

                    var mtdData = _unit.FctMarketPriceOlefinsRepo.GetMTDByProduct(actData.Select(x => x.Product).FirstOrDefault());
                    var today = DateTime.Today;
                    //for test
                    //today = today.AddMonths(-1);
                    var mtd = (mtdData.Any() ? mtdData?.Where(x => Convert.ToDateTime(x.PricingDate) <= today)?.Average(a => a.AvgPrice) : null) ?? null;
                    row.Column.Add(
                        new Column()
                        {
                            ColNo = colNo,
                            Header = MERGE_REPORT.MTD,
                            Value = mtd,
                        });
                    colNo++;
                    var lastWeekData = _unit.FctMarketPriceOlefinsRepo.GetLastWeekByProductWeb(marketSource.MarketPriceName);
                    //var lastweekDate = today.AddDays(-7);
                    //var lastweek = mtdData is not null && mtdData.Any() ? mtdData?.Where(x => Convert.ToDateTime(x.PricingDate) <= today && Convert.ToDateTime(x.PricingDate) >= lastweekDate).ToList() : new List<DATAACCESS.Entities.Master.MBR_FCT_MARKETPRICEOLEFINS>();
                    row.Column.Add(
                        new Column()
                        {
                            ColNo = colNo,
                            Header = MERGE_REPORT.LASST_WEEK,
                            Value = lastWeekData is not null && lastWeekData.Any() ? lastWeekData.Average(x => x.AvgPrice) : "N/A"
                        });
                    colNo++;
                    var yearCount = request.EndDate.Year - request.StartDate.Year;
                    var year = request.StartDate.Year;
                    for (int i = 0; i <= yearCount; i++)
                    {
                        List<decimal?> avgPrice = new List<decimal?>();
                        for (int month = 1; month <= 12; month++)
                        {
                            var tmpDate = new DateTime(year, month, 1);
                            if (month >= request.StartDate.Month && month < Convert.ToDateTime(request.Cycle.Split('_').LastOrDefault()).Month)
                            {
                                var tmp = actData.Where(x => x.PricingMonth == tmpDate.ToString("yyyyMM")).ToList();
                                if (tmp.Any())
                                {
                                    avgPrice.Add(tmp.Average(s => s.AvgPrice));
                                }
                                else
                                {
                                    avgPrice.Add(0);
                                }
                            }
                            else
                            {
                                decimal? tmp = null;
                                if (request.IsMerge)
                                {
                                    tmp = mergeForeCastData.Where(x =>
                                            Convert.ToInt32(x.MonthIndex.Replace("M", "")) > 0
                                            && Convert.ToInt32(x.MonthIndex.Replace("M", "")) < 13
                                            && Convert.ToDateTime(string.Format("{0}-{1}", x.Cycle.Split('_').Last().Split('-').First(), x.MonthIndex.Replace("M", ""))).Date == tmpDate).Average(s => s.Price);
                                }
                                else
                                {
                                    tmp = fcData.Where(x =>
                                            Convert.ToInt32(x.MonthIndex.Replace("M", "")) > 0
                                            && Convert.ToInt32(x.MonthIndex.Replace("M", "")) < 13
                                            && Convert.ToDateTime(string.Format("{0}-{1}", x.Cycle.Split('_').Last().Split('-').First(), x.MonthIndex.Replace("M", ""))).Date == tmpDate).Average(s => s.Price);
                                }
                                if (tmp is null)
                                {
                                    var tmpAct = actData.Where(x => x.PricingMonth == tmpDate.ToString("yyyyMM")).ToList();
                                    if (tmpAct.Any())
                                    {
                                        tmp = tmpAct.Average(s => s.AvgPrice);
                                    }
                                }
                                avgPrice.Add((decimal?)tmp);
                            }
                        }
                        row.Column.Add(
                           new Column()
                           {
                               ColNo = colNo,
                               Header = String.Format("{0}-{1}", MERGE_REPORT.Q1, year),
                               Value = (new List<decimal?>() { avgPrice[0], avgPrice[1], avgPrice[2] }).Where(x => x is not null).Average()
                           });
                        colNo++;
                        row.Column.Add(
                           new Column()
                           {
                               ColNo = colNo,
                               Header = String.Format("{0}-{1}", MERGE_REPORT.Q2, year),
                               Value = (new List<decimal?>() { avgPrice[3], avgPrice[4], avgPrice[5] }).Where(x => x is not null).Average()
                           });
                        colNo++;
                        row.Column.Add(
                           new Column()
                           {
                               ColNo = colNo,
                               Header = String.Format("{0}-{1}", MERGE_REPORT.Q3, year),
                               Value = (new List<decimal?>() { avgPrice[6], avgPrice[7], avgPrice[8] }).Where(x => x is not null).Average()
                           });
                        colNo++;
                        row.Column.Add(
                           new Column()
                           {
                               ColNo = colNo,
                               Header = String.Format("{0}-{1}", MERGE_REPORT.Q4, year),
                               Value = (new List<decimal?>() { avgPrice[9], avgPrice[10], avgPrice[11] }).Where(x => x is not null).Average()
                           });
                        colNo++;
                        year++;
                    }
                    rowNo++;
                    result.Table.Add(row);
                }
            }
            var bdData = result.Table.Where(x => x.Column.Select(c => c.Value).ToList().Contains("BD")).ToList();
            // for merge BD data
            if (bdData.Count > 0)
            {
                var data = result.Table.Where(x => !bdData.Contains(x)).ToList();
                var key = (from t in bdData
                           select t.Column into column
                           from col in column
                           group col by col.Header into g
                           select g.Key).ToList();
                int colIndex = 1;
                var bdRow = new TableItem()
                {
                    RowNo = rowNo,
                    Column = new List<Column>()
                };
                foreach (var k in key)
                {
                    var tmp = (from t in bdData
                               select t.Column into columns
                               from col in columns
                               where col.Header == k
                               select col.Value).ToList();
                    var column = new Column()
                    {
                        ColNo = colIndex,
                        Header = k,
                        Value = colIndex > 2 ? tmp.Any(a => a?.ToString() == "N/A") ? "N/A" : tmp.Where(z => z is not null).Average(x => (decimal?)x) : tmp.FirstOrDefault(),
                        Remark = MERGE_REPORT.ACT
                    };
                    bdRow.Column.Add(column);
                    colIndex++;
                }
                data.Add(bdRow);
                result.Table = data;
            }
            return result;
        }

        public static int MonthDifference(DateTime lValue, DateTime rValue)
        {
            return Math.Abs((lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year));
        }
    }
}