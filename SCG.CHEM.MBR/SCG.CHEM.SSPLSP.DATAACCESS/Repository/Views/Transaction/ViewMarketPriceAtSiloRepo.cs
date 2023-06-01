using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Transaction
{
    public class ViewMarketPriceAtSiloRepo : RepositoryBase<vSSP_MST_MARKETPRICEATSILO>, IViewMarketPriceAtSiloRepo
    {
        #region Inject

        public ViewMarketPriceAtSiloRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<MarketPriceModel> GetMarketPriceAtSilo(string planType, string cycle)
        {
            List<MarketPriceModel> result = new List<MarketPriceModel>();
            var dataDB = _context.vSSP_MST_MARKETPRICEATSILOs.Where(a => a.PlanType == planType && a.VersionName == cycle).ToList();
            var groupDB = dataDB.GroupBy(g => new { g.MarketGroup, g.VersionName, g.PlanType });
            var atSiloTH = groupDB
                .Where(s => !s.Key.MarketGroup.Contains("LD-COATING") && !s.Key.MarketGroup.Contains("PH-FILM") && !s.Key.MarketGroup.Contains("PP-RANDOM"))
                .Select(s => new MarketPriceModel()
                {
                    Product = s.Key.MarketGroup + APPCONSTANT.MARKETPICETYPE.AT_SILO_TH,
                    Type = APPCONSTANT.MARKETPICETYPE.POLYMER,
                    PriceM1 = s.Where(w => w.MonthIndex == "M1").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM2 = s.Where(w => w.MonthIndex == "M2").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM3 = s.Where(w => w.MonthIndex == "M3").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM4 = s.Where(w => w.MonthIndex == "M4").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM5 = s.Where(w => w.MonthIndex == "M5").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM6 = s.Where(w => w.MonthIndex == "M6").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM7 = s.Where(w => w.MonthIndex == "M7").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM8 = s.Where(w => w.MonthIndex == "M8").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM9 = s.Where(w => w.MonthIndex == "M9").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM10 = s.Where(w => w.MonthIndex == "M10").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM11 = s.Where(w => w.MonthIndex == "M11").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM12 = s.Where(w => w.MonthIndex == "M12").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM13 = s.Where(w => w.MonthIndex == "M13").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM14 = s.Where(w => w.MonthIndex == "M14").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM15 = s.Where(w => w.MonthIndex == "M15").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM16 = s.Where(w => w.MonthIndex == "M16").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM17 = s.Where(w => w.MonthIndex == "M17").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0,
                    PriceM18 = s.Where(w => w.MonthIndex == "M18").Select(s => s.MarketPriceAtSiloTH).FirstOrDefault() ?? 0
                });
            var atSiloVN = groupDB
                .Where(s => !s.Key.MarketGroup.Contains("LD-COATING") && !s.Key.MarketGroup.Contains("PH-FILM") && !s.Key.MarketGroup.Contains("PP-RANDOM"))
                .Select(s => new MarketPriceModel()
                {
                    Product = s.Key.MarketGroup + APPCONSTANT.MARKETPICETYPE.AT_SILO_VN,
                    Type = APPCONSTANT.MARKETPICETYPE.POLYMER,
                    PriceM1 = s.Where(w => w.MonthIndex == "M1").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM2 = s.Where(w => w.MonthIndex == "M2").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM3 = s.Where(w => w.MonthIndex == "M3").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM4 = s.Where(w => w.MonthIndex == "M4").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM5 = s.Where(w => w.MonthIndex == "M5").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM6 = s.Where(w => w.MonthIndex == "M6").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM7 = s.Where(w => w.MonthIndex == "M7").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM8 = s.Where(w => w.MonthIndex == "M8").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM9 = s.Where(w => w.MonthIndex == "M9").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM10 = s.Where(w => w.MonthIndex == "M10").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM11 = s.Where(w => w.MonthIndex == "M11").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM12 = s.Where(w => w.MonthIndex == "M12").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM13 = s.Where(w => w.MonthIndex == "M13").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM14 = s.Where(w => w.MonthIndex == "M14").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM15 = s.Where(w => w.MonthIndex == "M15").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM16 = s.Where(w => w.MonthIndex == "M16").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM17 = s.Where(w => w.MonthIndex == "M17").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0,
                    PriceM18 = s.Where(w => w.MonthIndex == "M18").Select(s => s.MarketPriceAtSiloVN).FirstOrDefault() ?? 0
                });

            result = atSiloTH.Union(atSiloVN).ToList();

            return result;
        }
    }
}