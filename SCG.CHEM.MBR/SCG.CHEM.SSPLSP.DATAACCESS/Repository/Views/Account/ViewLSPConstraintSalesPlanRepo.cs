using System;
using System.Collections.Generic;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Account;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Account.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Interface;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Account
{
    public class ViewLSPConstraintSalesPlanRepo : RepositoryBase<vSSP_INF_LSP_CONSTRAINT_SALES_PLAN>, IViewLSPConstraintSalesPlanRepo, IDownloadAccountReportRepo
    {
        #region Inject

        public ViewLSPConstraintSalesPlanRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<Object> DownloadAccountReports(List<string> plantypes = null, string startdate = null, string cycle = null, List<string> planningGroup = null)
        {
            var query = _context.vSSP_INF_LSP_CONSTRAINT_SALES_PLANs.AsQueryable();
            if (cycle != null)
            {
                query = query.Where(p => cycle == p.CycleName);
            }
            if (planningGroup != null)
            {
                query = query.Where(p => planningGroup.Contains(p.PlanningGroup));
            }
            var result = query.ToList<Object>();
            return result;
        }
    }
}