using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterPolymerPriceRepo : RepositoryBase<SSP_MST_POLYMER_PRICE>, IMasterPolymerPriceRepo
    {
        #region Inject

        public MasterPolymerPriceRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_POLYMER_PRICE> GetByKey(string planType, string marketPrice)
        {
            var result = _context.SSP_MST_POLYMER_PRICEs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.PlanType == planType && s.MarketGroup == marketPrice).ToList();
            return result;
        }

        public List<SSP_MST_POLYMER_PRICE> GetAllByKeyAndVersion(string planType, string marketPrice, string inputM1, string versionName, string monthNo, int versionNo)
        {
            var result = _context.SSP_MST_POLYMER_PRICEs.Where(s => s.VersionNo == versionNo && s.PlanType == planType && s.MarketGroup == marketPrice && s.InputM1 == inputM1 && s.VersionName == versionName && s.MonthNo == monthNo).ToList();
            return result;
        }

        public List<MarketPriceModel> GetPolymerPriceLastVersion(string planType, string cycle)
        {
            var result = _context.SSP_MST_POLYMER_PRICEs.Where(s => s.PlanType == planType && s.VersionName == cycle && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).
                GroupBy(g => new { g.MarketGroup, g.InputM1, g.PlanType, g.VersionName })
                .Select(s => new MarketPriceModel()
                {
                    Product = s.Key.MarketGroup,
                    Type = APPCONSTANT.MARKETPICETYPE.POLYMER,
                    PriceM1 = s.Where(w => w.MonthIndex == "M1").Select(s => s.Price).FirstOrDefault(),
                    PriceM2 = s.Where(w => w.MonthIndex == "M2").Select(s => s.Price).FirstOrDefault(),
                    PriceM3 = s.Where(w => w.MonthIndex == "M3").Select(s => s.Price).FirstOrDefault(),
                    PriceM4 = s.Where(w => w.MonthIndex == "M4").Select(s => s.Price).FirstOrDefault(),
                    PriceM5 = s.Where(w => w.MonthIndex == "M5").Select(s => s.Price).FirstOrDefault(),
                    PriceM6 = s.Where(w => w.MonthIndex == "M6").Select(s => s.Price).FirstOrDefault(),
                    PriceM7 = s.Where(w => w.MonthIndex == "M7").Select(s => s.Price).FirstOrDefault(),
                    PriceM8 = s.Where(w => w.MonthIndex == "M8").Select(s => s.Price).FirstOrDefault(),
                    PriceM9 = s.Where(w => w.MonthIndex == "M9").Select(s => s.Price).FirstOrDefault(),
                    PriceM10 = s.Where(w => w.MonthIndex == "M10").Select(s => s.Price).FirstOrDefault(),
                    PriceM11 = s.Where(w => w.MonthIndex == "M11").Select(s => s.Price).FirstOrDefault(),
                    PriceM12 = s.Where(w => w.MonthIndex == "M12").Select(s => s.Price).FirstOrDefault(),
                    PriceM13 = s.Where(w => w.MonthIndex == "M13").Select(s => s.Price).FirstOrDefault(),
                    PriceM14 = s.Where(w => w.MonthIndex == "M14").Select(s => s.Price).FirstOrDefault(),
                    PriceM15 = s.Where(w => w.MonthIndex == "M15").Select(s => s.Price).FirstOrDefault(),
                    PriceM16 = s.Where(w => w.MonthIndex == "M16").Select(s => s.Price).FirstOrDefault(),
                    PriceM17 = s.Where(w => w.MonthIndex == "M17").Select(s => s.Price).FirstOrDefault(),
                    PriceM18 = s.Where(w => w.MonthIndex == "M18").Select(s => s.Price).FirstOrDefault()
                }).ToList();
            return result;
        }
    }
}