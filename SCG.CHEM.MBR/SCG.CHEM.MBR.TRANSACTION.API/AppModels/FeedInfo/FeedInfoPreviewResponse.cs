using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.FeedInfo
{
    public class FeedInfoPreviewResponse
    {
        public string RefNo { get; set; }
        public string Company { get; set; }
        public string MCSC { get; set; }
        public string MonthStatus { get; set; }
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
        public decimal? MarketPriceT { get; set; }
        public decimal? MOPJM0T { get; set; }
        public decimal? SurveyorT { get; set; }
        public string MaterialCode { get; set; }

        public FeedInfoPreviewResponse(MRB_TMP_FEED_INFO from)
        {
            this.RefNo = from.RefNo;
            this.Company = from.Company;
            this.MCSC = from.MCSC;
            this.MonthStatus = from.MonthIndex;
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
            var MarketPriceT = 0;
            this.InsuranceT = ((from.Insurance ?? 0) * (MarketPriceT + (from.PurchasingPremium ?? 0) + ((from.HedgingGainLoss ?? 0) / (from.PurchasingVolume ?? 0)) + (from.Margin ?? 0)) / 100);
            this.PriceT = ((MarketPriceT + (from.PurchasingPremium ?? 0) + ((from.HedgingGainLoss ?? 0) / (from.PurchasingVolume ?? 0)) + (from.Margin ?? 0)) + (from.Insurance ?? 0) + (from.Surveyor ?? 0) + (from.TR ?? 0));

            this.SurveyorT = ((from.Surveyor ?? 0) / (from.PurchasingVolume ?? 0));/* * from.Fx*/
        }

        public FeedInfoPreviewResponse()
        { }
    }
}