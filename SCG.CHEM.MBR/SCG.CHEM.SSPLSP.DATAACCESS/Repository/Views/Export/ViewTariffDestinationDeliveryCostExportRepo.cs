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
    public class ViewTariffDestinationDeliveryCostExportRepo : RepositoryBase<vSSP_MST_TARIFF_DESTINATION_DELIVERY_COST_EXPORT>, IViewTariffDestinationDeliveryCostExportRepo, IDownloadRepo
    {
        #region Inject

        public ViewTariffDestinationDeliveryCostExportRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<Object> DownloadMaster(List<string> planTypeList = null, string startdate = null, string cycle = null)
        {
            var query = _context.vSSP_MST_TARIFF_DESTINATION_DELIVERY_COST_EXPORTs.AsQueryable();
            if (startdate != null)
            {
                var date = DateTime.ParseExact(string.Concat(startdate, "-01"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                query = query.Where(c => (c.FirstDate <= date && date < c.EndDate) || c.FirstDate > date);
                //query = query.Where(d => date >= d.FirstDate);
                //query = query.Where(e => date < e.EndDate);
            }
            if (planTypeList != null)
            {
                query = query.Where(p => planTypeList.Contains(p.PlanType));
            }
            //if (cycle != null)
            //{
            //    query = query.Where(p => cycle == p.VersionName);
            //}
            var result = query.ToList<Object>();
            return result;
        }

        public decimal GetTariff(string? product, string? productSub, string planType, string productSite, string region, DateTime yearMonth)
        {
            DateTime dt;

            var query = _context.vSSP_MST_TARIFF_DESTINATION_DELIVERY_COST_EXPORTs.AsQueryable();
            var result = query.Where(w => w.Product == product && w.ProductSub == productSub && w.PlanType == planType && w.ProductionSite == productSite
                                        && w.Region == region).AsEnumerable();
            result = result.Where(w => DateTime.TryParseExact(w.StartMonth, APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)
                                   && DateTime.ParseExact(w.StartMonth, APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture) <= yearMonth
                                   && DateTime.ParseExact(w.EndMonth, APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture) >= yearMonth);
            return result.FirstOrDefault()?.TariffCost ?? 0;
        }
    }
}