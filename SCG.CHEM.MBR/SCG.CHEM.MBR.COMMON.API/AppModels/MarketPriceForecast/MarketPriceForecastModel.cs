using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.COMMON.API.AppModels.MarketPriceForecast
{
    public class MarketPriceForecastDataModel
    {
        public string MarketSource { get; set; }
        public string? EBACode { get; set; }
        public string Unit { get; set; }
        public string? M0 { get; set; }
        public string? M1 { get; set; }
        public string? M2 { get; set; }
        public string? M3 { get; set; }
        public string? M4 { get; set; }
        public string? M5 { get; set; }
        public string? M6 { get; set; }
        public string? M7 { get; set; }
        public string? M8 { get; set; }
        public string? M9 { get; set; }
        public string? M10 { get; set; }
        public string? M11 { get; set; }
        public string? M12 { get; set; }
        public string? M13 { get; set; }
        public string? M14 { get; set; }
        public string? M15 { get; set; }
        public string? M16 { get; set; }
        public string? M17 { get; set; }
        public string? M18 { get; set; }

        public void SetModel(MarketPriceForecastDataModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }

        public MarketPriceForecastDataModel TryConvertToModel(out List<string> errList)
        {
            var model = new MarketPriceForecastDataModel();
            errList = new List<string>();

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.MarketSource))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MarketSource"));
            }
            else
            {
                model.MarketSource = this.MarketSource;
            }

            if (String.IsNullOrEmpty(this.Unit))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Unit"));
            }
            else
            {
                model.Unit = this.Unit;
            }
            model.MarketSource = this.MarketSource;
            model.EBACode = this.EBACode;
            var M0 = isDecimal(this.M0, "M0", errList);
            var M1 = isDecimal(this.M1, "M1", errList);
            var M2 = isDecimal(this.M2, "M2", errList);
            var M3 = isDecimal(this.M3, "M3", errList);
            var M4 = isDecimal(this.M4, "M4", errList);
            var M5 = isDecimal(this.M5, "M5", errList);
            var M6 = isDecimal(this.M6, "M6", errList);
            var M7 = isDecimal(this.M7, "M7", errList);
            var M8 = isDecimal(this.M8, "M8", errList);
            var M9 = isDecimal(this.M9, "M9", errList);
            var M10 = isDecimal(this.M10, "M10", errList);
            var M11 = isDecimal(this.M11, "M11", errList);
            var M12 = isDecimal(this.M12, "M12", errList);
            var M13 = isDecimal(this.M13, "M13", errList);
            var M14 = isDecimal(this.M14, "M14", errList);
            var M15 = isDecimal(this.M15, "M15", errList);
            var M16 = isDecimal(this.M16, "M16", errList);
            var M17 = isDecimal(this.M17, "M17", errList);
            var M18 = isDecimal(this.M18, "M18", errList);

            model.M0 = M0?.ToString() ?? "";
            model.M1 = M1?.ToString() ?? "";
            model.M2 = M2?.ToString() ?? "";
            model.M3 = M3?.ToString() ?? "";
            model.M4 = M4?.ToString() ?? "";
            model.M5 = M5?.ToString() ?? "";
            model.M6 = M6?.ToString() ?? "";
            model.M7 = M7?.ToString() ?? "";
            model.M8 = M8?.ToString() ?? "";
            model.M9 = M9?.ToString() ?? "";
            model.M10 = M10?.ToString() ?? "";
            model.M11 = M11?.ToString() ?? "";
            model.M12 = M12?.ToString() ?? "";
            model.M13 = M13?.ToString() ?? "";
            model.M14 = M14?.ToString() ?? "";
            model.M15 = M15?.ToString() ?? "";
            model.M16 = M16?.ToString() ?? "";
            model.M17 = M17?.ToString() ?? "";
            model.M18 = M18?.ToString() ?? "";

            return model;
        }

        public MarketPriceForecastDataModel TryConvertToModel(List<MBR_TRN_MARKET_PRICE_FORECAST>? existingData, List<MBR_MST_MARKET_PRICE_MAPPING> marketPriceMIs, bool isMerge, bool isZero, out List<string> errList, out List<string> warningList)
        {
            var model = new MarketPriceForecastDataModel();
            errList = new List<string>();
            warningList = new List<string>();

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.MarketSource))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "MarketSource"));
            }
            else
            {
                model.MarketSource = this.MarketSource;
            }

            if (String.IsNullOrEmpty(this.Unit))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "Unit"));
            }
            else
            {
                model.Unit = this.Unit;
            }
            var isContainMarketPriceMI = marketPriceMIs.Where(w => w.MarketPriceMI == this.MarketSource).FirstOrDefault();
            if (isContainMarketPriceMI != null)
            {
                model.MarketSource = isContainMarketPriceMI.MarketPriceMI;
                model.EBACode = isContainMarketPriceMI.EBACode;
            }
            else
            {
                errList.Add(APPCONSTANT.ERROR_MSG.ERROR_MARKET_SOURCE_FOUND);
            }
            var M0 = isDecimal(this.M0, "M0", errList);
            var M1 = isDecimal(this.M1, "M1", errList);
            var M2 = isDecimal(this.M2, "M2", errList);
            var M3 = isDecimal(this.M3, "M3", errList);
            var M4 = isDecimal(this.M4, "M4", errList);
            var M5 = isDecimal(this.M5, "M5", errList);
            var M6 = isDecimal(this.M6, "M6", errList);
            var M7 = isDecimal(this.M7, "M7", errList);
            var M8 = isDecimal(this.M8, "M8", errList);
            var M9 = isDecimal(this.M9, "M9", errList);
            var M10 = isDecimal(this.M10, "M10", errList);
            var M11 = isDecimal(this.M11, "M11", errList);
            var M12 = isDecimal(this.M12, "M12", errList);
            var M13 = isDecimal(this.M13, "M13", errList);
            var M14 = isDecimal(this.M14, "M14", errList);
            var M15 = isDecimal(this.M15, "M15", errList);
            var M16 = isDecimal(this.M16, "M16", errList);
            var M17 = isDecimal(this.M17, "M17", errList);
            var M18 = isDecimal(this.M18, "M18", errList);

            //merge
            if (existingData != null && isMerge)
            {
                List<string> statusSame = new List<string>();
                model.M0 = MergeData(M0, existingData?.FirstOrDefault(f => f.MonthIndex == "M0")?.Price, "M0", warningList, statusSame, isZero);
                model.M1 = MergeData(M1, existingData?.FirstOrDefault(f => f.MonthIndex == "M1")?.Price, "M1", warningList, statusSame, isZero);
                model.M2 = MergeData(M2, existingData?.FirstOrDefault(f => f.MonthIndex == "M2")?.Price, "M2", warningList, statusSame, isZero);
                model.M3 = MergeData(M3, existingData?.FirstOrDefault(f => f.MonthIndex == "M3")?.Price, "M3", warningList, statusSame, isZero);
                model.M4 = MergeData(M4, existingData?.FirstOrDefault(f => f.MonthIndex == "M4")?.Price, "M4", warningList, statusSame, isZero);
                model.M5 = MergeData(M5, existingData?.FirstOrDefault(f => f.MonthIndex == "M5")?.Price, "M5", warningList, statusSame, isZero);
                model.M6 = MergeData(M6, existingData?.FirstOrDefault(f => f.MonthIndex == "M6")?.Price, "M6", warningList, statusSame, isZero);
                model.M7 = MergeData(M7, existingData?.FirstOrDefault(f => f.MonthIndex == "M7")?.Price, "M7", warningList, statusSame, isZero);
                model.M8 = MergeData(M8, existingData?.FirstOrDefault(f => f.MonthIndex == "M8")?.Price, "M8", warningList, statusSame, isZero);
                model.M9 = MergeData(M9, existingData?.FirstOrDefault(f => f.MonthIndex == "M9")?.Price, "M9", warningList, statusSame, isZero);
                model.M10 = MergeData(M10, existingData?.FirstOrDefault(f => f.MonthIndex == "M10")?.Price, "M10", warningList, statusSame, isZero);
                model.M11 = MergeData(M11, existingData?.FirstOrDefault(f => f.MonthIndex == "M11")?.Price, "M11", warningList, statusSame, isZero);
                model.M12 = MergeData(M12, existingData?.FirstOrDefault(f => f.MonthIndex == "M12")?.Price, "M12", warningList, statusSame, isZero);
                model.M13 = MergeData(M13, existingData?.FirstOrDefault(f => f.MonthIndex == "M13")?.Price, "M13", warningList, statusSame, isZero);
                model.M14 = MergeData(M14, existingData?.FirstOrDefault(f => f.MonthIndex == "M14")?.Price, "M14", warningList, statusSame, isZero);
                model.M15 = MergeData(M15, existingData?.FirstOrDefault(f => f.MonthIndex == "M15")?.Price, "M15", warningList, statusSame, isZero);
                model.M16 = MergeData(M16, existingData?.FirstOrDefault(f => f.MonthIndex == "M16")?.Price, "M16", warningList, statusSame, isZero);
                model.M17 = MergeData(M17, existingData?.FirstOrDefault(f => f.MonthIndex == "M17")?.Price, "M17", warningList, statusSame, isZero);
                model.M18 = MergeData(M18, existingData?.FirstOrDefault(f => f.MonthIndex == "M18")?.Price, "M18", warningList, statusSame, isZero);
                if (statusSame.Count >= Enum.GetNames(typeof(MONTH_INDEX)).Length)
                {
                    warningList.Add(APPCONSTANT.ERROR_MSG.ERROR_MERGE_SAME_FIELD);
                }
            }
            else
            {
                model.M0 = this.M0;
                model.M1 = this.M1;
                model.M2 = this.M2;
                model.M3 = this.M3;
                model.M4 = this.M4;
                model.M5 = this.M5;
                model.M6 = this.M6;
                model.M7 = this.M7;
                model.M8 = this.M8;
                model.M9 = this.M9;
                model.M10 = this.M10;
                model.M11 = this.M11;
                model.M12 = this.M12;
                model.M13 = this.M13;
                model.M14 = this.M14;
                model.M15 = this.M15;
                model.M16 = this.M16;
                model.M17 = this.M17;
                model.M18 = this.M18;
            }
            var genModel = AutoGenerate(model);
            return genModel;
            //return model;
        }

        private decimal? isDecimal(string? value, string text, List<string> errList)
        {
            decimal number;
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            else if (!decimal.TryParse(value, out number))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_CONVERT_STR_TO_DECIMAL, text));
                return null;
            }
            return number;
        }

        private string? MergeData(decimal? dataFileUpload, decimal? existingData, string text, List<string> errList, List<string> statusSame, bool isZero)
        {
            if (dataFileUpload == 0 && existingData == 0)
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_MERGE_ZERO_OR_NULL_FIELD, text, dataFileUpload.ToString()));
                statusSame.Add(text);
                return dataFileUpload.ToString();
            }
            else if (dataFileUpload == null && existingData == null)
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_MERGE_ZERO_OR_NULL_FIELD, text, "null"));
                statusSame.Add(text);
            }
            else
            {
                var mergeData = Merge(dataFileUpload, existingData, isZero);
                decimal? mergeDataDecimal = !string.IsNullOrWhiteSpace(mergeData) ? decimal.Parse(mergeData) : null;
                if (dataFileUpload.HasValue && Math.Round(dataFileUpload.Value, 5) == mergeDataDecimal || (dataFileUpload == mergeDataDecimal))
                {
                    statusSame.Add(text);
                }
                if (mergeDataDecimal == null || mergeDataDecimal == 0)
                {
                    errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_MERGE_ZERO_OR_NULL_FIELD, text, mergeData ?? "null"));
                }
                else
                {
                    return mergeData;
                }
            }
            return null;
        }

        private string? Merge(decimal? dataFileUpload, decimal? dataExisting, bool isZero)
        {
            if (dataExisting.HasValue && ((dataFileUpload == 0 && !isZero) || dataFileUpload == null))
            {
                return dataExisting.ToString();
            }
            else if (dataFileUpload.HasValue && ((dataExisting == 0 && !isZero) || dataExisting == null))
            {
                return dataFileUpload.ToString();
            }
            else
            {
                return dataFileUpload?.ToString();
            }
        }

        private MarketPriceForecastDataModel AutoGenerate(MarketPriceForecastDataModel data)
        {
            var result = new MarketPriceForecastDataModel();
            var monthIndex = Enum.GetNames(typeof(MONTH_INDEX));
            List<MonthIndexList> MonthIndexList = new List<MonthIndexList>();

            MonthIndexList.Add(new MonthIndexList { id = 0, value = data.M0 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 1, value = data.M1 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 2, value = data.M2 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 3, value = data.M3 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 4, value = data.M4 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 5, value = data.M5 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 6, value = data.M6 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 7, value = data.M7 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 8, value = data.M8 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 9, value = data.M9 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 10, value = data.M10 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 11, value = data.M11 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 12, value = data.M12 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 13, value = data.M13 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 14, value = data.M14 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 15, value = data.M15 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 16, value = data.M16 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 17, value = data.M17 ?? "" });
            MonthIndexList.Add(new MonthIndexList { id = 18, value = data.M18 ?? "" });

            var resultMonthIndex = MonthIndexList.Where(x => x.value != "" && x.value != "0").ToList();

            if (resultMonthIndex.Count > 0)
            {
                var maxHasValueMonthIndex = resultMonthIndex.Max(x => x.id);

                result.MarketSource = data.MarketSource;
                result.Unit = data.Unit;
                result.EBACode = data.EBACode;
                result.M0 = MonthIndexList[0].value == "" || MonthIndexList[0].value == "0" ? MonthIndexList[0].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[0].value;
                result.M1 = MonthIndexList[1].value == "" || MonthIndexList[1].value == "0" ? MonthIndexList[1].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[1].value;
                result.M2 = MonthIndexList[2].value == "" || MonthIndexList[2].value == "0" ? MonthIndexList[2].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[2].value;
                result.M3 = MonthIndexList[3].value == "" || MonthIndexList[3].value == "0" ? MonthIndexList[3].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[3].value;
                result.M4 = MonthIndexList[4].value == "" || MonthIndexList[4].value == "0" ? MonthIndexList[4].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[4].value;
                result.M5 = MonthIndexList[5].value == "" || MonthIndexList[5].value == "0" ? MonthIndexList[5].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[5].value;
                result.M6 = MonthIndexList[6].value == "" || MonthIndexList[6].value == "0" ? MonthIndexList[6].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[6].value;
                result.M7 = MonthIndexList[7].value == "" || MonthIndexList[7].value == "0" ? MonthIndexList[7].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[7].value;
                result.M8 = MonthIndexList[8].value == "" || MonthIndexList[8].value == "0" ? MonthIndexList[8].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[8].value;
                result.M9 = MonthIndexList[9].value == "" || MonthIndexList[9].value == "0" ? MonthIndexList[9].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[9].value;
                result.M10 = MonthIndexList[10].value == "" || MonthIndexList[10].value == "0" ? MonthIndexList[10].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[10].value;
                result.M11 = MonthIndexList[11].value == "" || MonthIndexList[11].value == "0" ? MonthIndexList[11].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[11].value;
                result.M12 = MonthIndexList[12].value == "" || MonthIndexList[12].value == "0" ? MonthIndexList[12].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[12].value;
                result.M13 = MonthIndexList[13].value == "" || MonthIndexList[13].value == "0" ? MonthIndexList[13].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[13].value;
                result.M14 = MonthIndexList[14].value == "" || MonthIndexList[14].value == "0" ? MonthIndexList[14].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[14].value;
                result.M15 = MonthIndexList[15].value == "" || MonthIndexList[15].value == "0" ? MonthIndexList[15].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[15].value;
                result.M16 = MonthIndexList[16].value == "" || MonthIndexList[16].value == "0" ? MonthIndexList[16].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[16].value;
                result.M17 = MonthIndexList[17].value == "" || MonthIndexList[17].value == "0" ? MonthIndexList[17].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[17].value;
                result.M18 = MonthIndexList[18].value == "" || MonthIndexList[18].value == "0" ? MonthIndexList[18].id < maxHasValueMonthIndex ? "0" : "" : MonthIndexList[18].value;
            }
            else
            {
                result.MarketSource = data.MarketSource;
                result.Unit = data.Unit;
                result.EBACode = data.EBACode;
                result.M0 = data.M0 == "0" ? "" : data.M0;
                result.M1 = data.M1 == "0" ? "" : data.M1;
                result.M2 = data.M2 == "0" ? "" : data.M2;
                result.M3 = data.M3 == "0" ? "" : data.M3;
                result.M4 = data.M4 == "0" ? "" : data.M4;
                result.M5 = data.M5 == "0" ? "" : data.M5;
                result.M6 = data.M6 == "0" ? "" : data.M6;
                result.M7 = data.M7 == "0" ? "" : data.M7;
                result.M8 = data.M8 == "0" ? "" : data.M8;
                result.M9 = data.M9 == "0" ? "" : data.M9;
                result.M10 = data.M10 == "0" ? "" : data.M10;
                result.M11 = data.M11 == "0" ? "" : data.M11;
                result.M12 = data.M12 == "0" ? "" : data.M12;
                result.M13 = data.M13 == "0" ? "" : data.M13;
                result.M14 = data.M14 == "0" ? "" : data.M14;
                result.M15 = data.M15 == "0" ? "" : data.M15;
                result.M16 = data.M16 == "0" ? "" : data.M16;
                result.M17 = data.M17 == "0" ? "" : data.M17;
                result.M18 = data.M18 == "0" ? "" : data.M18;
            }

            return result;
        }
    }

    public class MarketPriceForecastCriteriaModel
    {
        public string Scenario { get; set; }
        public string Case { get; set; }
        public string Cycle { get; set; }
        public string? MergeScenario { get; set; }
        public string? MergeCase { get; set; }
        public string? MergeCycle { get; set; }
        public bool isMerge { get; set; }

        public void SetModel(MarketPriceForecastCriteriaModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }
    }

    public class ValidateMarketPriceForecastModel : MarketPriceForecastDataModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();

        public ValidateMarketPriceForecastModel()
        { }

        public ValidateMarketPriceForecastModel(ValidateMarketPriceForecastModel from)
        {
            this.MarketSource = from.MarketSource;
            this.Unit = from.Unit;
            this.Id = from.Id;
            this.M0 = from.M0;
            this.M1 = from.M1;
            this.M2 = from.M2;
            this.M3 = from.M3;
            this.M4 = from.M4;
            this.M5 = from.M5;
            this.M6 = from.M6;
            this.M7 = from.M7;
            this.M8 = from.M8;
            this.M9 = from.M9;
            this.M10 = from.M10;
            this.M11 = from.M11;
            this.M12 = from.M12;
            this.M13 = from.M13;
            this.M14 = from.M14;
            this.M15 = from.M15;
            this.M16 = from.M16;
            this.M17 = from.M17;
            this.M18 = from.M18;
        }
    }
}