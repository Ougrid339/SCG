using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Master
{
    public class PriceList
    {
        public string name { get; set; }
        public string value { get; set; }
        public string? error { get; set; }
    }

    public class OptienceList
    {
        public string company { get; set; }
        public string mcsc { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string? error { get; set; }
    }

    public class SalesList
    {
        public string company { get; set; }
        public string mcsc { get; set; }
        public string product { get; set; }
        public string channel { get; set; }
        public string value { get; set; }
        public string formulaName { get; set; }
        public string customers { get; set; }
        public string termSpot { get; set; }
        public string priceSet { get; set; }
        public string? error { get; set; }
    }

    public class MonthIndexList
    {
        public int id { get; set; }
        public string value { get; set; }
    }

    public class PriceListCal
    {
        public string name { get; set; }
        public decimal? value { get; set; }
    }

    public class BeginningInventoryList
    {
        public string mcsc { get; set; }
        public string name { get; set; }
        public string materialCode { get; set; }
        public string supplierKey { get; set; }
        public string value { get; set; }
        public string? error { get; set; }
    }
}