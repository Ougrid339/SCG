using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo
{
    public class FeedInfoActualDownloadResponse
    {
        public string Cycle { get; set; }
        public List<FeedInfoDownloadResponse> data = new List<FeedInfoDownloadResponse>();
    }

    public class FeedInfoDownloadResponse
    {
        public string RefNo { get; set; }
        public string Company { get; set; }
        public string MCSC { get; set; }
        public string MonthStatus { get; set; }
        public string? MonthNo { get; set; }
        public string FeedNameKey { get; set; }
        public string FeedGeoCategoryKey { get; set; }
        public string SupplierKey { get; set; }
        public string SupplierCode { get; set; }
        public string PricingIndexKey { get; set; }
        public string PricingRefKey { get; set; }
        public string? OriginKey { get; set; }
        public string ContractSpot { get; set; }
        public string TransportationKey { get; set; }
        public string BuyerRightKey { get; set; }
        public string Cycle { get; set; }
        public decimal? PurchasingVolume { get; set; }
        public decimal? PurchasingPremium { get; set; }
        public decimal? HedgingGainLoss { get; set; }
        public string? GITStatus { get; set; }
        public decimal? Surveyor { get; set; }
        public decimal? Insurance { get; set; }
        public decimal? Margin { get; set; }
        public decimal? TR { get; set; }
        public decimal? InsuranceT { get; set; }
        public decimal? PriceT { get; set; }
        public dynamic? MarketPriceT { get; set; }
        public dynamic? MOPJM0T { get; set; }
        public decimal? SurveyorT { get; set; }
        public string MaterialCode { get; set; }
        public decimal? FX { get; set; }

        public FeedInfoDownloadResponse(MRB_TRN_FEED_INFO from, MBR_TRN_MARKET_PRICE_FORECAST? marketPrice, bool isPositive, MBR_TRN_MARKET_PRICE_FORECAST? marketPriceMOPJ, MBR_FCT_MARKETPRICEOLEFINS ole, MBR_FCT_MARKETPRICEOLEFINS oleMOPJ, decimal? fx)
        {
            this.RefNo = from.RefNo;
            this.Company = from.Company;
            this.MCSC = from.MCSC;
            this.Cycle = String.IsNullOrEmpty(from.MergedWithCycle) ? from.Cycle : from.MergedWithCycle;
            this.MonthStatus = from.MonthIndex;
            this.MonthNo = from.MonthNo;
            this.FeedNameKey = from.FeedNameKey;
            this.FeedGeoCategoryKey = from.FeedGeoCategoryKey;
            this.SupplierKey = from.SupplierKey;
            this.SupplierCode = from.SupplierCode;
            this.PricingIndexKey = from.PricingIndexKey;
            this.PricingRefKey = from.PricingRefKey;
            this.OriginKey = from.OriginKey;
            this.ContractSpot = from.ContractSpot;
            this.TransportationKey = from.TransportationKey;
            this.BuyerRightKey = from.BuyerRightKey;
            this.PurchasingVolume = from.PurchasingVolume;
            this.PurchasingPremium = from.PurchasingPremium;
            this.HedgingGainLoss = from.HedgingGainLoss;
            this.GITStatus = from.GITStatus;
            this.Surveyor = from.Surveyor;
            this.Insurance = from.Insurance;
            this.Margin = from.Margin;
            this.TR = from.TR;
            this.MaterialCode = from.MaterialCode;
            decimal? marketPriceT = null;
            decimal? mopjData = null;
            bool MarketPriceTIsNull = false;
            bool mopjIsNull = false;
            if (isPositive)
            {
                marketPriceT = marketPrice?.Price;
                mopjData = marketPriceMOPJ?.Price;
            }
            else
            {
                marketPriceT = ole?.AvgPrice;
                mopjData = oleMOPJ?.AvgPrice;
            }
            if ((isPositive && marketPrice == null) || !isPositive && ole == null)
            {
                MarketPriceTIsNull = true;
            }
            if ((isPositive && marketPriceMOPJ == null) || !isPositive && oleMOPJ == null)
            {
                mopjIsNull = true;
            }
            if (from.PurchasingVolume == 0)
            {
                this.InsuranceT = 0;
                this.PriceT = 0;
                this.SurveyorT = 0;
            }
            else
            {
                this.InsuranceT = !MarketPriceTIsNull ? (((from.Insurance ?? 0) * (marketPriceT + (from.PurchasingPremium ?? 0) + ((from.HedgingGainLoss ?? 0) / (from.PurchasingVolume ?? 0)) + (from.Margin ?? 0)) / 100)) : null;
                this.PriceT = !MarketPriceTIsNull ? ((marketPriceT + (from.PurchasingPremium ?? 0) + ((from.HedgingGainLoss ?? 0) / (from.PurchasingVolume ?? 0)) + (from.Margin ?? 0)) + (from.Insurance ?? 0) + (from.Surveyor ?? 0) + (from.TR ?? 0)) : null;

                this.SurveyorT = ((from.Surveyor ?? 0) / (from.PurchasingVolume ?? 0)) * (fx ?? 0);
            }

            this.MOPJM0T = !mopjIsNull ? mopjData : "MOPJ (M0)($/T) not found";
            this.MarketPriceT = !MarketPriceTIsNull ? marketPriceT : "Market Price ($/T) not found";
            this.FX = fx;
        }

        public FeedInfoDownloadResponse()
        { }
    }

    public class FeedInfoMarketPriceName
    {
        public string PricingMonth { get; set; }
        public string PricingWeb { get; set; }
    }
}