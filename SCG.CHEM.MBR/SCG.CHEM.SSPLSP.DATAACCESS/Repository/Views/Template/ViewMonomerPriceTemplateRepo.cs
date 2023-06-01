using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Template.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Template
{
    internal class ViewMonomerPriceTemplateRepo : RepositoryBase<vSSP_MST_MONOMER_PRICE_TEMPLATE>, IViewMonomerPriceTemplateRepo, IDownloadRepo
    {
        #region Inject

        public ViewMonomerPriceTemplateRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<Object> DownloadMaster(List<string> planTypeList = null, string startdate = null, string cycle = null)
        {
            var query = _context.vSSP_MST_MONOMER_PRICE_TEMPLATEs.AsQueryable();
            //if (startdate != null)
            //{
            //    var date = DateTime.ParseExact(string.Concat(startdate, "-01"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //    query = query.Where(d => date <= d.FirstDate);
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

        public List<MarketPriceModel> GetMonomerPriceByCycle(string cycle)
        {
            Dictionary<string, string> mapping = new Dictionary<string, string>();
            mapping.Add("ETHYLENE", "C2");
            mapping.Add("PROPYLENE", "C3");
            mapping.Add("BUTENE-1", "C4");

            List<MarketPriceModel> result = new List<MarketPriceModel>();
            var dataDB = _context.vSSP_MST_MONOMER_PRICE_TEMPLATEs.Where(s => s.VersionName == cycle).ToList();

            foreach (var item in dataDB)
            {
                var isInMapping = mapping.ContainsKey(item.Monomer.ToUpper());
                if (isInMapping)
                {
                    item.Monomer = mapping[item.Monomer.ToUpper()];
                }
                result.Add(new MarketPriceModel
                {
                    Product = item.Monomer,
                    Type = APPCONSTANT.MARKETPICETYPE.MONOMER,
                    PriceM1 = item.PriceM1,
                    PriceM2 = item.PriceM2,
                    PriceM3 = item.PriceM3,
                    PriceM4 = item.PriceM4,
                    PriceM5 = item.PriceM5,
                    PriceM6 = item.PriceM6,
                    PriceM7 = item.PriceM7,
                    PriceM8 = item.PriceM8,
                    PriceM9 = item.PriceM9,
                    PriceM10 = item.PriceM10,
                    PriceM11 = item.PriceM11,
                    PriceM12 = item.PriceM12,
                    PriceM13 = item.PriceM13,
                    PriceM14 = item.PriceM14,
                    PriceM15 = item.PriceM15,
                    PriceM16 = item.PriceM16,
                    PriceM17 = item.PriceM17,
                    PriceM18 = item.PriceM18,
                });
            }
            return result.OrderBy(s => s.Product).ToList();
        }
    }
}