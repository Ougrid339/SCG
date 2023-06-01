using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Export.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Export
{
    public class ViewMonomerPriceExportRepo : RepositoryBase<vSSP_MST_MONOMER_PRICE_EXPORT>, IViewMonomerPriceExportRepo, IDownloadRepo
    {
        #region Inject

        public ViewMonomerPriceExportRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<Object> DownloadMaster(List<string> planTypeList = null, string startdate = null, string cycle = null)
        {
            var query = _context.vSSP_MST_MONOMER_PRICE_EXPORTs.AsQueryable();
            //if (startdate != null)
            //{
            //    var date = DateTime.ParseExact(string.Concat(startdate, "-01"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //    query = query.Where(d => date >= d.FirstDate);
            //    query = query.Where(e => date < e.EndDate);
            //}
            //if (planTypeList != null)
            //{
            //    query = query.Where(p => planTypeList.Contains(p.PlanType));
            //}
            if (cycle != null)
            {
                query = query.Where(p => cycle == p.VersionName);
            }
            var result = query.ToList<Object>();
            return result;
        }

        public List<MarketPriceModel> GetMonomerPricebyProduct(string planType, string cycle)
        {
            List<MarketPriceModel> result = new List<MarketPriceModel>();
            var dataDB = _context.vSSP_MST_MONOMER_PRICE_EXPORTs.Where(s => s.PlanType == planType && s.VersionName == cycle).ToList();
            var groupDB = dataDB.GroupBy(g => new { g.PlanType, g.VersionName });

            // Product C2
            var c2 = groupDB
                .Select(s => new MarketPriceModel()
                {
                    Product = "C2",
                    Type = APPCONSTANT.MARKETPICETYPE.MONOMER,
                    PriceM1 = s.Where(w => w.MonthIndex == "M1").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM2 = s.Where(w => w.MonthIndex == "M2").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM3 = s.Where(w => w.MonthIndex == "M3").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM4 = s.Where(w => w.MonthIndex == "M4").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM5 = s.Where(w => w.MonthIndex == "M5").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM6 = s.Where(w => w.MonthIndex == "M6").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM7 = s.Where(w => w.MonthIndex == "M7").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM8 = s.Where(w => w.MonthIndex == "M8").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM9 = s.Where(w => w.MonthIndex == "M9").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM10 = s.Where(w => w.MonthIndex == "M10").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM11 = s.Where(w => w.MonthIndex == "M11").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM12 = s.Where(w => w.MonthIndex == "M12").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM13 = s.Where(w => w.MonthIndex == "M13").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM14 = s.Where(w => w.MonthIndex == "M14").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM15 = s.Where(w => w.MonthIndex == "M15").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM16 = s.Where(w => w.MonthIndex == "M16").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM17 = s.Where(w => w.MonthIndex == "M17").Select(s => s.C2).FirstOrDefault() ?? 0,
                    PriceM18 = s.Where(w => w.MonthIndex == "M18").Select(s => s.C2).FirstOrDefault() ?? 0,
                }).ToList();

            // Product C3
            var c3 = groupDB
                .Select(s => new MarketPriceModel()
                {
                    Product = "C3",
                    Type = APPCONSTANT.MARKETPICETYPE.MONOMER,
                    PriceM1 = s.Where(w => w.MonthIndex == "M1").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM2 = s.Where(w => w.MonthIndex == "M2").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM3 = s.Where(w => w.MonthIndex == "M3").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM4 = s.Where(w => w.MonthIndex == "M4").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM5 = s.Where(w => w.MonthIndex == "M5").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM6 = s.Where(w => w.MonthIndex == "M6").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM7 = s.Where(w => w.MonthIndex == "M7").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM8 = s.Where(w => w.MonthIndex == "M8").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM9 = s.Where(w => w.MonthIndex == "M9").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM10 = s.Where(w => w.MonthIndex == "M10").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM11 = s.Where(w => w.MonthIndex == "M11").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM12 = s.Where(w => w.MonthIndex == "M12").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM13 = s.Where(w => w.MonthIndex == "M13").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM14 = s.Where(w => w.MonthIndex == "M14").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM15 = s.Where(w => w.MonthIndex == "M15").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM16 = s.Where(w => w.MonthIndex == "M16").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM17 = s.Where(w => w.MonthIndex == "M17").Select(s => s.C3).FirstOrDefault() ?? 0,
                    PriceM18 = s.Where(w => w.MonthIndex == "M18").Select(s => s.C3).FirstOrDefault() ?? 0,
                }).ToList();

            // Product C4
            var c4 = groupDB
                .Select(s => new MarketPriceModel()
                {
                    Product = "C4",
                    Type = APPCONSTANT.MARKETPICETYPE.MONOMER,
                    PriceM1 = s.Where(w => w.MonthIndex == "M1").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM2 = s.Where(w => w.MonthIndex == "M2").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM3 = s.Where(w => w.MonthIndex == "M3").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM4 = s.Where(w => w.MonthIndex == "M4").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM5 = s.Where(w => w.MonthIndex == "M5").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM6 = s.Where(w => w.MonthIndex == "M6").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM7 = s.Where(w => w.MonthIndex == "M7").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM8 = s.Where(w => w.MonthIndex == "M8").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM9 = s.Where(w => w.MonthIndex == "M9").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM10 = s.Where(w => w.MonthIndex == "M10").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM11 = s.Where(w => w.MonthIndex == "M11").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM12 = s.Where(w => w.MonthIndex == "M12").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM13 = s.Where(w => w.MonthIndex == "M13").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM14 = s.Where(w => w.MonthIndex == "M14").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM15 = s.Where(w => w.MonthIndex == "M15").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM16 = s.Where(w => w.MonthIndex == "M16").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM17 = s.Where(w => w.MonthIndex == "M17").Select(s => s.C4).FirstOrDefault() ?? 0,
                    PriceM18 = s.Where(w => w.MonthIndex == "M18").Select(s => s.C4).FirstOrDefault() ?? 0,
                }).ToList();

            // Product C6
            var c6 = groupDB
                .Select(s => new MarketPriceModel()
                {
                    Product = "C6",
                    Type = APPCONSTANT.MARKETPICETYPE.MONOMER,
                    PriceM1 = s.Where(w => w.MonthIndex == "M1").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM2 = s.Where(w => w.MonthIndex == "M2").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM3 = s.Where(w => w.MonthIndex == "M3").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM4 = s.Where(w => w.MonthIndex == "M4").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM5 = s.Where(w => w.MonthIndex == "M5").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM6 = s.Where(w => w.MonthIndex == "M6").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM7 = s.Where(w => w.MonthIndex == "M7").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM8 = s.Where(w => w.MonthIndex == "M8").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM9 = s.Where(w => w.MonthIndex == "M9").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM10 = s.Where(w => w.MonthIndex == "M10").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM11 = s.Where(w => w.MonthIndex == "M11").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM12 = s.Where(w => w.MonthIndex == "M12").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM13 = s.Where(w => w.MonthIndex == "M13").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM14 = s.Where(w => w.MonthIndex == "M14").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM15 = s.Where(w => w.MonthIndex == "M15").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM16 = s.Where(w => w.MonthIndex == "M16").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM17 = s.Where(w => w.MonthIndex == "M17").Select(s => s.C6).FirstOrDefault() ?? 0,
                    PriceM18 = s.Where(w => w.MonthIndex == "M18").Select(s => s.C6).FirstOrDefault() ?? 0,
                }).ToList();

            // Product C8
            var c8 = groupDB
                .Select(s => new MarketPriceModel()
                {
                    Product = "C8",
                    Type = APPCONSTANT.MARKETPICETYPE.MONOMER,
                    PriceM1 = s.Where(w => w.MonthIndex == "M1").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM2 = s.Where(w => w.MonthIndex == "M2").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM3 = s.Where(w => w.MonthIndex == "M3").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM4 = s.Where(w => w.MonthIndex == "M4").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM5 = s.Where(w => w.MonthIndex == "M5").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM6 = s.Where(w => w.MonthIndex == "M6").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM7 = s.Where(w => w.MonthIndex == "M7").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM8 = s.Where(w => w.MonthIndex == "M8").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM9 = s.Where(w => w.MonthIndex == "M9").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM10 = s.Where(w => w.MonthIndex == "M10").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM11 = s.Where(w => w.MonthIndex == "M11").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM12 = s.Where(w => w.MonthIndex == "M12").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM13 = s.Where(w => w.MonthIndex == "M13").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM14 = s.Where(w => w.MonthIndex == "M14").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM15 = s.Where(w => w.MonthIndex == "M15").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM16 = s.Where(w => w.MonthIndex == "M16").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM17 = s.Where(w => w.MonthIndex == "M17").Select(s => s.C8).FirstOrDefault() ?? 0,
                    PriceM18 = s.Where(w => w.MonthIndex == "M18").Select(s => s.C8).FirstOrDefault() ?? 0,
                }).ToList();

            result = c2.Union(c3).ToList();
            result = result.Union(c4).ToList();
            result = result.Union(c6).ToList();
            result = result.Union(c8).ToList();

            return result;
        }
    }
}