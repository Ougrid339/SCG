using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Account;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Account.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Account
{
    public class ViewLSPExchangeRateRepo : RepositoryBase<vSSP_INF_LSP_EXCHANGE_RATE>, IViewLSPExchangeRateRepo, IDownloadAccountReportRepo
    {
        #region Inject

        public ViewLSPExchangeRateRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<object> DownloadAccountReports(List<string> plantypes = null, string startdate = null, string cycle = null, List<string> planningGroup = null)
        {
            var query = _context.vSSP_INF_LSP_EXCHANGE_RATEs.AsQueryable();
            if (startdate != null)
            {
                var date = DateTime.ParseExact(string.Concat(startdate, "-01"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                query = query.Where(c => (c.FirstDate <= date && date < c.EndDate) || c.FirstDate > date);
            }
            if (plantypes != null)
            {
                query = query.Where(p => plantypes.Contains(p.PlanType));
            }
            //if (cycle != null)
            //{
            //    query = query.Where(p => cycle == p.VersionName);
            //}
            var result = query.ToList<Object>();
            return result;
        }
    }
}