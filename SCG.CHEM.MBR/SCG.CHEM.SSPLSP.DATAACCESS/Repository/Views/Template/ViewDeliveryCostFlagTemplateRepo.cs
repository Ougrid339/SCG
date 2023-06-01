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
    public class ViewDeliveryCostFlagTemplateRepo : RepositoryBase<vSSP_MST_DELIVERY_COST_FLAG_TEMPLATE>, IViewDeliveryCostFlagTemplateRepo, IDownloadRepo
    {
        #region Inject

        public ViewDeliveryCostFlagTemplateRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<Object> DownloadMaster(List<string> planTypeList = null, string startdate = null, string cycle = null)
        {
            var query = _context.vSSP_MST_DELIVERY_COST_FLAG_TEMPLATEs.AsQueryable();
            if (startdate != null)
            {
                var date = DateTime.ParseExact(string.Concat(startdate, "-01"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                query = query.Where(d => date <= d.FirstDate);
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
    }
}