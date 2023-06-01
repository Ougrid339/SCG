using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.Sales
{
    public class SalesPreviewResponse
    {
        public string Company { get; set; }

        public string MCSC { get; set; }

        public string MonthIndex { get; set; }

        public string Product { get; set; }

        public string Channel { get; set; }

        public string? ReEXP { get; set; }

        public string FormulaName { get; set; }

        public string Customers { get; set; }
        public int? Margin { get; set; }
        public string? Countries { get; set; }
        public string? TransportationMode { get; set; }

        public string? CountryPort { get; set; }

        public string TermSpot { get; set; }

        public string PriceSet { get; set; }

        public string? PaymentCondition { get; set; }

        public string? ContractNo { get; set; }

        public string? Formula { get; set; }
        public string? VesselOrderNo { get; set; }
        public string? Remark { get; set; }

        public decimal VolTons { get; set; }

        public decimal? HedgingGainLoss { get; set; }

        public decimal? Alpha1 { get; set; }

        public decimal? Alpha2 { get; set; }

        public decimal? Premium { get; set; }

        public decimal? BD { get; set; }
        public decimal? IB { get; set; }
        public decimal? Adj1 { get; set; }
        public decimal? Adj2 { get; set; }
        public decimal? Adj3 { get; set; }
        public decimal? Adj4 { get; set; }
        public decimal? Adj5 { get; set; }
        public decimal? Den { get; set; }
        public decimal? FinalPrice { get; set; }
        public string? ErrorMessage { get; set; }

        public SalesPreviewResponse(MBR_TMP_SALES_VOLUME from)
        {
            this.Company = from.Company;
            this.MCSC = from.MCSC;
            this.MonthIndex = from.MonthIndex;
            this.Product = from.Product;
            this.Channel = from.Channel;
            this.ReEXP = from.ReEXP;
            this.FormulaName = from.FormulaName;
            this.Customers = from.Customers;
            this.Margin = from.Margin;
            this.Countries = from.Countries;
            this.TransportationMode = from.TransportationMode;
            this.CountryPort = from.CountryPort;
            this.TermSpot = from.TermSpot;
            this.PriceSet = from.PriceSet;
            this.PaymentCondition = from.PaymentCondition;
            this.ContractNo = from.ContractNo;
            this.Formula = from.Formula;
            this.VesselOrderNo = from.VesselOrderNo;
            this.Remark = from.Remark;
            this.VolTons = from.VolTons;
            this.HedgingGainLoss = from.HedgingGainLoss;
            this.Alpha1 = from.Alpha1;
            this.Alpha2 = from.Alpha2;
            this.Premium = from.Premium;
            this.BD = from.BD;
            this.IB = from.IB;
            this.Adj1 = from.Adj1;
            this.Adj2 = from.Adj2;
            this.Adj3 = from.Adj3;
            this.Adj4 = from.Adj4;
            this.Adj5 = from.Adj5;
            this.Den = from.Den;
            this.FinalPrice = from.FinalPrice;
            this.ErrorMessage = from.ErrorMessage;
        }
        public SalesPreviewResponse() { }
    }
}
